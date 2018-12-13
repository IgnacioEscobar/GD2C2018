using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PalcoNet.funciones_utiles;

namespace PalcoNet.Abm_Rol
{
    public partial class FormNombreRol : Form
    {
        FormABMRol formABMRol;
        string rol_seleccionado;
        bool modif;

        public FormNombreRol(FormABMRol formABMRol)
        {
            InitializeComponent();
            this.formABMRol = formABMRol;
            this.rol_seleccionado = "";
            this.modif = false;
        }

        public FormNombreRol(FormABMRol formABMRol, string rol_seleccionado)
        {
            InitializeComponent();
            this.formABMRol = formABMRol;
            this.rol_seleccionado = rol_seleccionado;
            this.modif = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string mensaje;
            string nuevo_nombre = txtNombreRol.Text.Trim();

            if (nuevo_nombre == "")
            {
                MessageBox.Show("Debe ingresar un nombre para el rol.", "Alerta");
            }
            else
            {
                if (modif)
                {
                    mensaje = "¿Confirma que desea actualizar el rol " + rol_seleccionado + " a " + nuevo_nombre + "?";
                }
                else
                {
                    mensaje = "¿Confirma que desea crear el rol " + nuevo_nombre + "?";
                }
                DialogResult respuesta = MessageBox.Show(mensaje, "", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    GestorDB gestor = new GestorDB();
                    gestor.conectar();
                    if (modif)
                    {
                        gestor.generarStoredProcedure("modificar_rol");
                        gestor.parametroPorValor("descripcion_anterior", rol_seleccionado);
                    }
                    else
                    {
                        gestor.generarStoredProcedure("crear_rol");
                    }
                    gestor.parametroPorValor("descripcion", nuevo_nombre);
                    int result = gestor.ejecutarStoredProcedure();
                    gestor.desconectar();

                    if (result == 0)
                    {
                        MessageBox.Show("Ya existe un rol con esa descripción.", "Alerta");
                    }
                    else if (modif)
                    {
                        MessageBox.Show("Rol actualizado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("Rol creado exitosamente.");
                    }

                    formABMRol.actualizar();
                    this.Hide();
                }
            }
        }

        private void FormNombreRol_Load(object sender, EventArgs e)
        {
            txtNombreRol.Text = rol_seleccionado;
            txtNombreRol.Select();
        }
    }
}

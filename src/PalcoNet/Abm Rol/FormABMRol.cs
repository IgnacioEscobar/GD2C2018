using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Data.SqlClient;

using PalcoNet.funciones_utiles;
using PalcoNet.Menu_Principal;

namespace PalcoNet.Abm_Rol
{
    public partial class FormABMRol : Form
    {
        int userID;
        int rolID;
        string rol_seleccionado;

        public FormABMRol(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
        }

        // Metodos auxiliares

        private void mostrarRoles()
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT descripcion FROM PEAKY_BLINDERS.roles");
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                lsbRoles.Items.Add(lector["descripcion"].ToString());
            }
            gestor.desconectar();
        }

        private void mostrarFuncionalidades(SqlDataReader lector)
        {
            while (lector.Read())
            {
                clbFuncionalidades.Items.Add(lector["descripcion"].ToString());
            }
        }

        private void tildarFuncionalidadesActivas(SqlDataReader lector)
        {
            while (lector.Read())
            {
                for (int i = 0; i < clbFuncionalidades.Items.Count; i++)
                {
                    if (clbFuncionalidades.Items[i].ToString() == lector["descripcion"].ToString())
                    {
                        clbFuncionalidades.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void mostrarRolHabilitado(SqlDataReader lector)
        {
            if (lector.Read())
            {
                ckbHabilitado.Checked = Convert.ToBoolean(lector["habilitado"]);
            }
        }

        public void actualizar()
        {
            lsbRoles.Items.Clear();
            this.mostrarRoles();
        }

        // -------------------

        private void FormABMRol_Load(object sender, EventArgs e)
        {
            this.mostrarRoles();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (lsbRoles.SelectedItems.Count == 1)
            {
                clbFuncionalidades.Items.Clear();

                rol_seleccionado = lsbRoles.SelectedItem.ToString();
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                string query1 = "SELECT habilitado FROM PEAKY_BLINDERS.roles WHERE descripcion = '" + rol_seleccionado + "'";
                gestor.consulta(query1);
                this.mostrarRolHabilitado(gestor.obtenerRegistros());
                gestor.desconectar();
                gestor.conectar();
                string query2 = "SELECT descripcion FROM PEAKY_BLINDERS.funcionalidades";
                gestor.consulta(query2);
                this.mostrarFuncionalidades(gestor.obtenerRegistros());
                gestor.desconectar();
                gestor.conectar();
                string query3 = "SELECT F.descripcion FROM PEAKY_BLINDERS.roles R "
                                + "JOIN PEAKY_BLINDERS.funcionalidades_por_rol FR ON R.id_rol = FR.id_rol "
                                + "JOIN PEAKY_BLINDERS.funcionalidades F ON FR.id_funcionalidad = F.id_funcionalidad "
                                + "WHERE R.descripcion = '" + lsbRoles.SelectedItem.ToString() + "'";
                gestor.consulta(query3);
                this.tildarFuncionalidadesActivas(gestor.obtenerRegistros());
                gestor.desconectar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rol.", "Alerta");
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            string mensaje = "Funcionalidades asignadas al rol " + rol_seleccionado + ":";
            int cant_items = clbFuncionalidades.Items.Count;
            if (cant_items > 0)
            {
                for (int i = 0; i < cant_items; i++)
                {
                    if (clbFuncionalidades.GetItemChecked(i))
                    {
                        mensaje += "\n - " + clbFuncionalidades.Items[i].ToString().ToUpper();
                    }
                }
            }
            else
            {
                mensaje += "\n SIN FUNCIONALIDADES";
            }
            
            if (ckbHabilitado.Checked)
            {
                mensaje += "\n\n Estado del rol: HABILITADO";
            }
            else
            {
                mensaje += "\n\n Estado del rol: INHABILITADO";
            }
           
            mensaje += "\n\n ¿Confirma los cambios efectuados?";

            DialogResult result = MessageBox.Show(mensaje, "PalcoNet", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                gestor.generarStoredProcedure("actualizar_rol_habilitado");
                gestor.parametroPorValor("descripcion", rol_seleccionado);
                gestor.parametroPorValor("habilitado", Convert.ToInt32(ckbHabilitado.Checked));
                gestor.ejecutarStoredProcedure();
                gestor.desconectar();
                gestor.conectar();
                gestor.generarStoredProcedure("borrar_funcionalidades_por_rol");
                gestor.parametroPorValor("descripcion", rol_seleccionado);
                gestor.ejecutarStoredProcedure();
                gestor.desconectar();
                
                for (int i = 0; i < clbFuncionalidades.Items.Count; i++)
                {
                    if (clbFuncionalidades.GetItemChecked(i))
                    {
                        gestor.conectar();
                        gestor.generarStoredProcedure("actualizar_funcionalidades_por_rol");
                        gestor.parametroPorValor("descripcion_rol", rol_seleccionado);
                        gestor.parametroPorValor("descripcion_funcionalidad", clbFuncionalidades.Items[i].ToString());
                        gestor.ejecutarStoredProcedure();
                        gestor.desconectar();
                    }
                }

                MessageBox.Show("Los cambios se persistieron exitosamente.", "PalcoNet");
            }
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMenuPrincipal.Show();
        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            FormNombreRol formNombreRol = new FormNombreRol(this);
            formNombreRol.Show();
        }

        private void btnModificarNombre_Click(object sender, EventArgs e)
        {
            if (lsbRoles.SelectedItems.Count == 1)
            {
                FormNombreRol formNombreRol = new FormNombreRol(this, lsbRoles.SelectedItem.ToString());
                formNombreRol.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rol.", "Alerta");
            }            
        }

    }
}

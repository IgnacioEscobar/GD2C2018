using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class FormRegistroComun : Form
    {
        public FormRegistroComun()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                lblError.Text = "Ingrese usuario";
            }
            else if (txtContrasena1.Text == "" || txtContrasena2.Text == "")
            {
                lblError.Text = "Ingrese contraseña";
            }
            else if (!rbnCliente.Checked && !rbnEmpresa.Checked)
            {
                lblError.Text = "Seleccione un perfil";
            }
            else if (txtContrasena1.Text != txtContrasena2.Text)
            {
                lblError.Text = "Las contraseñas no coinciden";
            }
            else
            {
                /*
                 * Verificar en la DB si ya existe
                 */
                Form proximoForm;
                if (rbnCliente.Checked)
                {
                    proximoForm = new FormRegistroCliente();
                }
                else
                {
                    proximoForm = new FormRegistroEmpresa();
                }

                this.Hide();
                proximoForm.Show();
            }

            lblError.Visible = true;
        }

        private void FormRegistroComun_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

    }
}

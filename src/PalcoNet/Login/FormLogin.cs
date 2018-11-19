using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PalcoNet.Registro_de_Usuario;
using PalcoNet.Login;

namespace PalcoNet
{
    public partial class FormLogin : Form
    {
        string usuario = "";

        public FormLogin()
        {
            InitializeComponent();
        }

        public FormLogin(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FormRegistroComun formRegistroComun = new FormRegistroComun();
            this.Hide();
            formRegistroComun.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = usuario;
            if (usuario != "")
            {
                txtContrasena.Focus();
            }
            lblError.Visible = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                lblError.Text = "Ingrese usuario";
            }
            else if (txtContrasena.Text == "")
            {
                lblError.Text = "Ingrese contraseña";
            }
            else
            {
                /*
                 * Traer usuario de la DB para verificar que existe
                 */
                bool existe_usuario = true;
                if (!existe_usuario)
                {
                    lblError.Text = "El usuario es inválido";
                }
                else
                {
                    /*
                     * Traer contraseña de la DB para validar login
                     */
                    string contrasena = "1234";
                    if (txtContrasena.Text == contrasena)
                    {
                        /*
                         * Traer roles asignados
                         */
                        int cantRolesAsignados = 3;

                        if (cantRolesAsignados == 1)
                        {
                            // Ir a otro Form
                            MessageBox.Show("Avanza de Form");
                        }
                        else
                        {
                            FormElegirRol formElegirRol = new FormElegirRol();
                            this.Hide();
                            formElegirRol.Show();
                        }                        
                    }
                    else
                    {
                        lblError.Text = "La contraseña es inválida";
                    }
                }
            }
            lblError.Visible = true;
        }
    }
}

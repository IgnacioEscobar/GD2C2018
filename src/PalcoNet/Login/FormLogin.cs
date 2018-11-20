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
using PalcoNet.funciones_utiles;

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
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                gestor.storedProcedure("autenticar_usuario");
                gestor.parametroPorValor("@usuario", txtUsuario.Text);
                gestor.parametroPorValor("@contrasena", txtContrasena.Text);
                gestor.parametroPorReferencia("@user_id", SqlDbType.Int);
                int result = gestor.ejecutarStoredProcedure();
                gestor.desconectar();
                
                int userId;                
                if (result == 1) {
                    userId = Convert.ToInt32(gestor.obtenerValor("@user_id"));
                }

                if (result == 2)
                {
                    lblError.Text = "El usuario es inválido";
                }
                else
                {
                    if (result == 1)
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

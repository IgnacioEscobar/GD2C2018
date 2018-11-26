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
                gestor.generarStoredProcedure("autenticar_usuario");
                gestor.parametroPorValor("@usuario", txtUsuario.Text);
                gestor.parametroPorValor("@contrasenna", txtContrasena.Text);
                gestor.parametroPorReferencia("@id", SqlDbType.Int);
                int result = gestor.ejecutarStoredProcedure();
                gestor.desconectar();

                int userID = 0;                
                if (result == 1) {
                    userID = Convert.ToInt32(gestor.obtenerValor("@id"));
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
                        gestor.conectar();
                        string query = "SELECT COUNT(*) AS cant_roles FROM PEAKY_BLINDERS.usuarios U" +
                            "JOIN PEAKY_BLINDERS.roles_por_usuario RU ON U.id_usuario = RU.id_usuario " +
                            "WHERE U.id_usuario = '" + userID.ToString() + "'";
                        gestor.consulta(query);
                        int cantRolesAsignados = Convert.ToInt32(gestor.obtenerRegistros()["cant_roles"]);
                        MessageBox.Show("CANTIDAD DE ROLES CARGADOS EN DB: " + cantRolesAsignados.ToString());
                        gestor.desconectar();

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

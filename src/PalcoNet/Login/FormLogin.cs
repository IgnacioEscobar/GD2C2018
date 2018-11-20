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
using System.Data.SqlClient;

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
                SqlConnection conn = new SqlConnection(@"Data source=localhost\SQLSERVER2012; Initial Catalog=GD2C2018;user=gdEspectaculos2018;password=gd2018");
                
                SqlCommand cmd = new SqlCommand("PEAKY_BLINDERS.autenticar_usuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@contrasenna", txtContrasena.Text);
                cmd.Parameters.Add(new SqlParameter("@id",SqlDbType.Int));
                cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                cmd.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;
                
                try {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message); 
                }

                int userId;
                int result = Convert.ToInt32(cmd.Parameters["@ReturnVal"].Value);
                if (result == 1) {
                    userId = Convert.ToInt32(cmd.Parameters["@id"].Value);
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

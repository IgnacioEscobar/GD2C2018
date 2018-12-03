using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using PalcoNet.Registro_de_Usuario;
using PalcoNet.Login;
using PalcoNet.funciones_utiles;
using PalcoNet.Abm_Cliente;
using PalcoNet.Abm_Empresa_Espectaculo;
using PalcoNet.Menu_Principal;

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

                if (result == -1)
                {
                    lblError.Text = "El usuario es inválido";
                }
                else
                {
                    if (result == 0)
                    {
                        lblError.Text = "La contraseña es inválida";
                    }
                    else if (result == 1)
                    {
                        int userID = Convert.ToInt32(gestor.obtenerValor("@id"));

                        gestor.conectar();
                        string query = "SELECT COUNT(*) AS cant_roles " +
                            "FROM PEAKY_BLINDERS.roles_por_usuario " +
                            "WHERE id_usuario = '" + userID.ToString() + "'";
                        gestor.consulta(query);

                        SqlDataReader lector = gestor.obtenerRegistros();
                        int cantRolesAsignados = 0;
                        if (lector.Read())
                        {
                            cantRolesAsignados = Convert.ToInt32(lector["cant_roles"]);
                        }
                        
                        gestor.desconectar();

                        switch (cantRolesAsignados)
                        {
                            case 0:
                                lblError.Text = "Usuario sin roles asignados";
                                break;

                            case 1:
                                gestor.conectar();
                                string query2 = "SELECT R.descripcion FROM PEAKY_BLINDERS.roles R " +
                                    "JOIN PEAKY_BLINDERS.roles_por_usuario RU ON R.id_rol = RU.id_rol " +
                                    "WHERE RU.id_usuario = '" + userID + "'";
                                gestor.consulta(query2);
                                SqlDataReader lector2 = gestor.obtenerRegistros();
                                if (lector2.Read())
                                {
                                    string rolCargado = lector2["descripcion"].ToString();
                                    Form formDestino;
                                    
                                    switch (rolCargado)
                                    {
                                        case "Cliente":
                                            formDestino = new FormMenuCliente(userID);
                                            this.Hide();
                                            formDestino.Show();
                                            break;

                                        case "Empresa":
                                            formDestino = new FormMenuEmpresa(userID);
                                            this.Hide();
                                            formDestino.Show();
                                            break;

                                        case "Administrador":
                                            formDestino = new FormMenuAdministrador(userID);
                                            this.Hide();
                                            formDestino.Show();
                                            break;

                                        default:
                                            MessageBox.Show("ERROR: el rol cargado es inválido");
                                            break;
                                    }
                                }
                                break;

                            default:
                                FormElegirRol formElegirRol = new FormElegirRol(userID);
                                this.Hide();
                                formElegirRol.Show();
                                break;
                        }
                    }
                    else if (result == 2)
                    {
                        lblError.Text = "La contraseña es inválida";
                        MessageBox.Show("Su cuenta ha sido inhabilitada por realizar 3 intentos incorrectos, comúniquese con un administrador", "ALERTA");
                    }
                    else
                    {
                        lblError.Text = "Ha realizado 3 intentos fallidos, el usuario se encuentra inhabilitado";
                    }
                }
            }
            lblError.Visible = true;
        }
    }
}

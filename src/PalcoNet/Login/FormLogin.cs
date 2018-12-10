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
using PalcoNet.Abm_Usuario;

namespace PalcoNet
{
    public partial class FormLogin : Form
    {
        string usuario;
        int userID;

        public FormLogin()
        {
            InitializeComponent();
            this.usuario = "";
            this.userID = -1;
        }

        public FormLogin(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.userID = -1;
        }

        public FormLogin(int userID)
        {
            InitializeComponent();
            this.usuario = "";
            this.userID = userID;
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FormRegistroComun formRegistroComun = new FormRegistroComun();
            this.Hide();
            formRegistroComun.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (usuario != "")
            {
                txtUsuario.Text = usuario;
                txtContrasena.Select();                
            }
            else if (userID > -1)
            {
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                string query = "SELECT nombre_de_usuario FROM PEAKY_BLINDERS.usuarios WHERE id_usuario = '" + userID + "'";
                gestor.consulta(query);
                SqlDataReader lector = gestor.obtenerRegistros();
                if (lector.Read())
                {
                    txtUsuario.Text = lector["nombre_de_usuario"].ToString();
                }
                gestor.desconectar();
                txtContrasena.Select();
            }
            else
            {
                txtUsuario.Select();
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
                int result;
                try
                {                    
                    gestor.conectar();
                    gestor.generarStoredProcedure("autenticar_usuario");
                    gestor.parametroPorValor("@usuario", txtUsuario.Text);
                    gestor.parametroPorValor("@contrasenna", txtContrasena.Text);
                    gestor.parametroPorReferencia("@id", SqlDbType.Int);
                    result = gestor.ejecutarStoredProcedure();
                    gestor.desconectar();
                }
                catch (Exception)
                {
                    result = -1;
                }

                if (result == 0)
                {
                    lblError.Text = "El usuario es inválido";
                }
                else
                {
                    if (result == 1)
                    {
                        lblError.Text = "La contraseña es inválida";
                    }
                    else if (result == 3)
                    {
                        int userID = Convert.ToInt32(gestor.obtenerValor("@id"));
                        FormMiUsuario formMiUsuario = new FormMiUsuario(userID);
                        this.Hide();
                        formMiUsuario.Show();
                    }
                    else if (result == 2)
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
                                            lblError.Text = "ERROR: el rol cargado es inválido";
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
                    else if (result == 4)
                    {
                        lblError.Text = "La contraseña es inválida";
                        MessageBox.Show("Su cuenta ha sido inhabilitada por realizar 3 intentos incorrectos, comúniquese con un administrador", "ALERTA");
                    }
                    else if (result == 5)
                    {
                        lblError.Text = "Ha realizado 3 intentos fallidos, el usuario se encuentra\ninhabilitado";
                    }
                    else
                    {
                        lblError.Text = "Error de conexión a la base de datos";
                    }
                }
            }
            lblError.Visible = true;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

    }
}

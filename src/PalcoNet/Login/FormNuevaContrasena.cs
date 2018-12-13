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

using PalcoNet.funciones_utiles;
using PalcoNet.Menu_Principal;
using PalcoNet.Abm_Cliente;
using PalcoNet.Abm_Empresa_Espectaculo;

namespace PalcoNet.Login
{
    public partial class FormNuevaContrasena : Form
    {
        int userID; // user que realiza el cambio
        int rolID; // rol de este user
        bool desde_login; // para saber si es el cambio por ingresar la primera vez o no
        int cambioID; // user que se va a cambiar
        bool cliente;
        bool empresa;

        public FormNuevaContrasena(int userID, int rolID, bool desde_login)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
            this.desde_login = desde_login;
            this.cambioID = userID;
            this.cliente = false;
            this.empresa = false;
        }

        public FormNuevaContrasena(int userID, int rolID, int cambioID, bool cliente, bool empresa)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
            this.cambioID = cambioID;
            this.cliente = cliente;
            this.empresa = empresa;
        }

        // Metodos auxiliares

        private void avanzarDeForm(bool hubo_cambio)
        {
            Form formDestino;
            if (cliente)
            {
                formDestino = new FormABMCliente(userID, rolID);
            }
            else if (empresa)
            {
                formDestino = new FormABMCliente(userID, rolID);
            }
            else if ((desde_login & hubo_cambio) || !desde_login)
            {
                formDestino = new FormMenuPrincipal(userID, rolID);
            }
            else
            {
                formDestino = new FormLogin();
            }
            this.Hide();
            formDestino.Show();
        }

        // -------------------

        private void FormMiUsuario_Load(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = "SELECT nombre_de_usuario FROM PEAKY_BLINDERS.usuarios WHERE id_usuario = '" + cambioID + "'";
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();
            if (lector.Read())
            {
                lblUsuario.Text = "Usuario: " + lector["nombre_de_usuario"].ToString();
            }
            gestor.desconectar();

            if (cliente || empresa)
            {
                txtPassActual.Enabled = false;
                txtPassNueva.Select();
            }
            else
            {
                txtPassActual.Select();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.avanzarDeForm(false);
        }

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtPassNueva.Text != txtPassNueva2.Text)
            {
                MessageBox.Show("La nueva contraseña no coincide.", "Alerta");
            }
            else
            {
                GestorDB gestor = new GestorDB();

                if (!cliente && !empresa)
                {
                    gestor.conectar();
                    string query = "SELECT PEAKY_BLINDERS.verificar_contrasenna (" + cambioID + ", '" + txtPassActual.Text + "') AS encontro";
                    gestor.consulta(query);
                    SqlDataReader lector = gestor.obtenerRegistros();
                    bool encontro = false;
                    if (lector.Read())
                    {
                        encontro = Convert.ToBoolean(lector["encontro"]);
                    }

                    gestor.desconectar();

                    if (!encontro)
                    {
                        MessageBox.Show("La actual contraseña es incorrecta.", "Alerta");
                        return;
                    }
                }

                gestor.conectar();
                gestor.generarStoredProcedure("actualizar_contrasenna");
                gestor.parametroPorValor("id_usuario", cambioID);
                gestor.parametroPorValor("contrasenna", txtPassNueva.Text);
                gestor.ejecutarStoredProcedure();
                gestor.desconectar();

                MessageBox.Show("La contraseña ha sido actualizada.");

                this.avanzarDeForm(true);
            }            
        }

    }
}

﻿using System;
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

namespace PalcoNet.Login
{
    public partial class FormNuevaContrasena : Form
    {
        int userID; // user que realiza el cambio
        int rolID; // rol de este user
        int cambioID; // user que se va a cambiar
        bool cliente;
        bool empresa;

        public FormNuevaContrasena(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
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

        private void avanzarDeForm(bool loginCargado)
        {
            Form formDestino;
            if (cliente)
            {
                formDestino = new FormMenuCliente(userID);
            }
            else if (empresa)
            {
                formDestino = new FormMenuEmpresa(userID);
            }
            else if (login)
            {
                if (loginCargado)
                {
                    formDestino = new FormLogin(userID);
                }
                else
                {
                    formDestino = new FormLogin();
                }
            }
            else
            {
                formDestino = new FormABMUsuario(adminID);
            }
            this.Hide();
            formDestino.Show();
        }

        // -------------------

        private void FormMiUsuario_Load(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = "SELECT nombre_de_usuario FROM PEAKY_BLINDERS.usuarios WHERE id_usuario = '" + userID + "'";
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();
            if (lector.Read())
            {
                lblUsuario.Text = "Usuario: " + lector["nombre_de_usuario"].ToString();
            }
            gestor.desconectar();

            txtPassActual.Select();
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

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = "SELECT PEAKY_BLINDERS.verificar_contrasenna (" + userID + ", '" + txtPassActual.Text + "') AS passok";
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();
            bool passok = false;
            if (lector.Read())
            {
                passok = Convert.ToBoolean(lector["passok"]);
            }

            gestor.desconectar();
            gestor.conectar();

            if (!passok)
            {
                MessageBox.Show("La actual contraseña es incorrecta.", "Alerta");
            }
            else
            {
                gestor.generarStoredProcedure("actualizar_contrasenna");
                gestor.parametroPorValor("id_usuario", userID);
                gestor.parametroPorValor("contrasenna", txtPassNueva.Text);
                gestor.ejecutarStoredProcedure();
                gestor.desconectar();

                MessageBox.Show("La contraseña ha sido actualizada.");

                this.avanzarDeForm(true);
            }            
        }

    }
}

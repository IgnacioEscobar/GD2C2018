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

using PalcoNet.Login;
using PalcoNet.funciones_utiles;
using PalcoNet.Abm_Rol;
using PalcoNet.Abm_Cliente;
using PalcoNet.Abm_Empresa_Espectaculo;
using PalcoNet.Abm_Rubro;
using PalcoNet.Abm_Grado;
using PalcoNet.Generar_Publicacion;
using PalcoNet.Editar_Publicacion;
using PalcoNet.Historial_Cliente;
using PalcoNet.Canje_Puntos;
using PalcoNet.Generar_Rendicion_Comisiones;
using PalcoNet.Listado_Estadistico;

namespace PalcoNet.Menu_Principal
{
    public partial class FormMenuPrincipal : Form
    {
        int userID;

        public FormMenuPrincipal(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        // Metodos auxiliares

        private void agregarButtonColumn(string header)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = header;
            column.Text = "-->";
            column.UseColumnTextForButtonValue = true;
            dgvFuncionalidades.Columns.Add(column);
        }

        // -------------------

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            dgvFuncionalidades.ColumnCount = 1;
            dgvFuncionalidades.ColumnHeadersVisible = true;
            dgvFuncionalidades.Columns[0].Name = "FUNCIONALIDAD";
            agregarButtonColumn("SELECCIONAR");

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query = "SELECT DISTINCT F.descripcion " +
                "FROM PEAKY_BLINDERS.roles_por_usuario RU " +
                    "JOIN PEAKY_BLINDERS.roles R ON RU.id_rol = R.id_rol " +
                    "JOIN PEAKY_BLINDERS.funcionalidades_por_rol FR ON R.id_rol = FR.id_rol " +
                    "JOIN PEAKY_BLINDERS.funcionalidades F ON FR.id_funcionalidad = F.id_funcionalidad ";/* +
                "WHERE RU.id_usuario = '" + userID + "'";*/
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();

            while (lector.Read())
            {
                dgvFuncionalidades.Rows.Add(lector["descripcion"].ToString().ToUpper());
            }

            dgvFuncionalidades.AutoResizeColumns();
            gestor.desconectar();
        }

        private void dgvFuncionalidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                Form formDestino = new FormLogin();

                switch (dgvFuncionalidades.CurrentRow.Cells[0].Value.ToString())
                {
                    case "ABM DE ROL":
                        formDestino = new FormABMRol(userID);
                        break;
                    case "ABM DE CLIENTE":
                        formDestino = new FormABMCliente(userID);
                        break;
                    case "ABM DE EMPRESA DE ESPECTÁCULOS":
                        formDestino = new FormABMEmpresa(userID);
                        break;
                    case "ABM DE CATEGORÍA":
                        formDestino = new FormABMRubro(userID);
                        break;
                    case "ABM GRADO DE PUBLICACIÓN":
                        formDestino = new FormABMGrado(userID);
                        break;
                    case "GENERAR PUBLICACIÓN":
                        //formDestino = new FormGenerarPublicacion(userID);
                        break;
                    case "EDITAR PUBLICACIÓN":
                        break;
                    case "HISTORIAL DE CLIENTE":
                        formDestino = new FormHistorialCliente(userID);
                        break;
                    case "CANJE Y ADMINISTRACIÓN DE PUNTOS":
                        break;
                    case "GENERAR PAGO DE COMISIONES":
                        break;
                    case "LISTADO ESTADÍSTICO":
                        formDestino = new FormListadoEstadistico();
                        break;
                }

                this.Hide();
                formDestino.Show();
            }
        }

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formDestino = new FormLogin();
            this.Hide();
            formDestino.Show();
        }

    }
}

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

namespace PalcoNet.Historial_Cliente
{
    public partial class FormHistorialCliente : Form
    {
        int userID;
        int rolID;

        public FormHistorialCliente(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
        }

        private void mostrarRegistros(SqlDataReader lector)
        {
            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["descripcion"].ToString(),
                    lector["fecha"].ToString(),
                    lector["cantidad"].ToString(),
                    lector["monto"].ToString(),
                    lector["medio_de_pago"].ToString()
                };
                dgvHistorial.Rows.Add(row);
            }
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            dgvHistorial.ColumnCount = 5;
            dgvHistorial.ColumnHeadersVisible = true;
            dgvHistorial.Columns[0].Name = "PUBLICACION";
            dgvHistorial.Columns[1].Name = "FECHA";
            dgvHistorial.Columns[2].Name = "CANTIDAD";
            dgvHistorial.Columns[3].Name = "MONTO";
            dgvHistorial.Columns[4].Name = "MEDIO DE PAGO";

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT id_cliente FROM PEAKY_BLINDERS.clientes WHERE id_usuario = '" + userID + "'");
            SqlDataReader lector = gestor.obtenerRegistros();
            int clienteID;
            if (lector.Read())
            {
                clienteID = Convert.ToInt32(lector["id_cliente"].ToString());
            }
            else
            {
                clienteID = -1;
                MessageBox.Show("No hay compras en el historial.", "Alerta");
            }
            gestor.desconectar();

            gestor.conectar();
            string query = "SELECT ISNULL(P.descripcion, '---') AS descripcion, " +
                    "CO.fecha, " +
                    "CO.cantidad, " +
                    "CO.monto, " +
                    "MP.descripcion AS medio_de_pago " +
                "FROM PEAKY_BLINDERS.compras CO " +
                    "JOIN PEAKY_BLINDERS.clientes CL ON CO.id_cliente = CL.id_cliente " +
                    "JOIN PEAKY_BLINDERS.publicaciones P ON CO.id_publicacion = P.id_publicacion " +
                    "JOIN PEAKY_BLINDERS.medios_de_pago MP ON CO.id_medio_de_pago = MP.id_medio_de_pago " +
                "WHERE Cl.id_cliente = '" + clienteID + "' " +
                "ORDER BY CO.fecha DESC";
            gestor.consulta(query);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMenuPrincipal.Show();
        }

    }
}

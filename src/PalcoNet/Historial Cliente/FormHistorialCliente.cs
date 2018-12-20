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

namespace PalcoNet.Historial_Cliente
{
    public partial class FormHistorialCliente : Form
    {
        int userID;
        int rolID;
        int pagina;
        int maxPaginas;
        string condicion;
        GestorDB gestor = new GestorDB();

        public FormHistorialCliente(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
        }

        private void mostrarRegistros(string query)
        {
            gestor.conectar();
            gestor.consulta(query);
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["descripcion"].ToString(),
                    lector["fecha_presentacion"].ToString(),
                    lector["cantidad"].ToString(),
                    lector["monto"].ToString(),
                    lector["medio_de_pago"].ToString()
                };
                dgvHistorial.Rows.Add(row);
            }
            dgvHistorial.AutoResizeColumns();
            gestor.desconectar();
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            dgvHistorial.ColumnCount = 5;
            dgvHistorial.ColumnHeadersVisible = true;
            dgvHistorial.Columns[0].Name = "PUBLICACION";
            dgvHistorial.Columns[1].Name = "FECHA DE PRESENTACION";
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
                gestor.desconectar();
            }
            else
            {
                clienteID = -1;
                MessageBox.Show("No hay compras en el historial.", "Alerta");
                gestor.desconectar();
                return;
            }

            string select = "SELECT ISNULL(PU.descripcion, '---') AS descripcion, " +
                    "PR.fecha_presentacion, " +
                    "SUM(CO.cantidad) AS cantidad, " +
                    "SUM(CO.monto) AS monto, " +
                    "MP.descripcion AS medio_de_pago " +
                "FROM PEAKY_BLINDERS.compras CO ";
            string joins = "JOIN PEAKY_BLINDERS.clientes CL ON CO.id_cliente = CL.id_cliente " +
                    "JOIN PEAKY_BLINDERS.publicaciones PU ON CO.id_publicacion = PU.id_publicacion " +
                    "JOIN PEAKY_BLINDERS.presentaciones PR ON CO.id_presentacion = PR.id_presentacion " +
                    "JOIN PEAKY_BLINDERS.medios_de_pago MP ON CO.id_medio_de_pago = MP.id_medio_de_pago ";
            string filtro = "WHERE Cl.id_cliente = '" + clienteID + "' ";
            string agrupacion = "GROUP BY PU.descripcion, PR.fecha_presentacion, MP.descripcion ";
            string order = "ORDER BY PR.fecha_presentacion DESC";

            condicion = select + joins + filtro + agrupacion + order;
            pagina = 1;
            string query = aplicarPagina(condicion, pagina);
            maxPaginas = maximoPaginas(joins, filtro);
            this.mostrarRegistros(query);
            showPageNum();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMenuPrincipal.Show();
        }

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formDestino = new FormLogin();
            this.Hide();
            formDestino.Show();
        }

        private string aplicarPagina(string condicion, int pagina, int tamanio_pagina = 18)
        {
            int offset = (pagina - 1) * tamanio_pagina;
            string complemento = " OFFSET " + offset + " ROWS FETCH NEXT " + tamanio_pagina + " ROWS ONLY";
            return condicion + complemento;
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            pagina = Math.Min(maxPaginas, pagina + 1);
            paginarYCorrer();
        }

        private void anterior_Click(object sender, EventArgs e)
        {
            pagina = Math.Max(1, pagina - 1);
            paginarYCorrer();
        }

        private void paginarYCorrer()
        {
            string condicion_paginada = aplicarPagina(condicion, pagina);
            correrQuery(condicion_paginada);
            showPageNum();
        }

        private void showPageNum()
        {
            paginaLabel.Text = pagina + " / " + maxPaginas;
        }

        private void correrQuery(string condicion_paginada)
        {
            dgvHistorial.Rows.Clear();
            this.mostrarRegistros(condicion_paginada);
        }

        private void Ultima_Click(object sender, EventArgs e)
        {
            pagina = maxPaginas;
            paginarYCorrer();
        }

        private void Primera_Click(object sender, EventArgs e)
        {
            pagina = 1;
            paginarYCorrer();
        }

        private int maximoPaginas(string joins_defecto, string filtro, int tamanio_pagina = 18)
        {
            string count_querry = "SELECT count(distinct CO.id_compra) as compras FROM PEAKY_BLINDERS.compras CO ";
            count_querry += joins_defecto;
            count_querry += filtro;
            gestor.conectar();
            gestor.consulta(count_querry);
            SqlDataReader lector = gestor.obtenerRegistros();
            lector.Read();
            int count = lector.GetInt32(0);
            gestor.desconectar();
            return Math.Max(1, (count + tamanio_pagina - 1) / tamanio_pagina);
        }

    }
}

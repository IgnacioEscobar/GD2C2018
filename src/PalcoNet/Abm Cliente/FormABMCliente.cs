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
using PalcoNet.Registro_de_Usuario;
using PalcoNet.Menu_Principal;

namespace PalcoNet.Abm_Cliente
{
    public partial class FormABMCliente : Form
    {
        int userID;
        int rolID;
        string query_defecto = "SELECT nombre, apellido, numero_de_documento, mail FROM PEAKY_BLINDERS.clientes";
        ValidadorDeDatos validador;

        public FormABMCliente(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
        }

        // Metodos auxiliares

        private void mostrarRegistros(SqlDataReader lector)
        {
            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["nombre"].ToString(),
                    lector["apellido"].ToString(),
                    lector["numero_de_documento"].ToString(),
                    lector["mail"].ToString()
                };
                dgvClientes.Rows.Add(row);
            }
        }

        // -------------------

        private void FormABMCliente_Load(object sender, EventArgs e)
        {
            dgvClientes.ColumnCount = 4;
            dgvClientes.ColumnHeadersVisible = true;
            dgvClientes.Columns[0].Name = "NOMBRE";
            dgvClientes.Columns[1].Name = "APELLIDO";
            dgvClientes.Columns[2].Name = "DOCUMENTO";
            dgvClientes.Columns[3].Name = "MAIL";

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta(query_defecto);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();

            dgvClientes.AutoResizeColumns();
            validador = new ValidadorDeDatos();
            txtNombre.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string documento = txtDocumento.Text;
            string mail = txtMail.Text;

            List<object[]> listaCampos = new List<object[]>();

            if (nombre != "")
            {
                object[] tuplaNombre = { "nombre", nombre, false };
                listaCampos.Add(tuplaNombre);
            }
            if (apellido != "")
            {
                object[] tuplaApellido = { "apellido", apellido, false };
                listaCampos.Add(tuplaApellido);
            }
            if (documento != "")
            {
                object[] tuplaDocumento = { "numero_de_documento", documento, true };
                listaCampos.Add(tuplaDocumento);
            }
            if (mail != "")
            {
                object[] tuplaEmail = { "mail", mail, true };
                listaCampos.Add(tuplaEmail);
            }

            int cant_filtros = listaCampos.Count();
            if (cant_filtros > 0) dgvClientes.Rows.Clear();

            string filtro = "";
            for (int i = 0; i < cant_filtros; i++)
            {
                object[] tuplaCampos = listaCampos[i];
                string comparacion, cierre;
                if (Convert.ToBoolean(tuplaCampos[2])) // busqueda exacta
                {
                    comparacion = " = '";
                    cierre = "'";
                }
                else // busqueda aproximada
                {
                    comparacion = " LIKE '%";
                    cierre = "%'";
                }
                filtro += tuplaCampos[0] + comparacion + tuplaCampos[1] + cierre;
                if (i != listaCampos.Count() - 1) filtro += " AND ";
            }

            GestorDB gestor = new GestorDB();
            gestor.conectar();

            string query = query_defecto;
            if (cant_filtros > 0) query += " WHERE " + filtro;
            gestor.consulta(query);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
            txtMail.Text = "";
            txtNombre.Select();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormRegistroCliente formRegistroCliente = new FormRegistroCliente(userID, true);
            this.Hide();
            formRegistroCliente.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string[] param = new string[3];
            int i = 0;
            foreach (DataGridViewCell item in dgvClientes.CurrentRow.Cells)
            {
                param[i] = item.Value.ToString();
                i++;
            }

            string query = "SELECT * FROM PEAKY_BLINDERS.clientes C "
                           + "LEFT JOIN PEAKY_BLINDERS.tipos_de_documento T "
                                + "ON C.id_tipo_de_documento = T.id_tipo_de_documento "
                           + "WHERE C.numero_de_documento = '" + param[2] + "'";
            FormRegistroCliente formRegistroCliente = new FormRegistroCliente(userID, query);
            this.Hide();
            formRegistroCliente.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string[] datos = new string[3];
            int i = 0;
            foreach (DataGridViewCell item in dgvClientes.CurrentRow.Cells)
            {
                datos[i] = item.Value.ToString();
                i++;
            }
            string mensaje = "¿Confirma que desea eliminar al cliente " + datos[0] + " " + datos[1] + "?";
            DialogResult  respuesta = MessageBox.Show(this, mensaje, "Eliminar cliente", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                /*
                 * INICIO TRANSACCION
                 */
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                gestor.generarStoredProcedure("eliminar_cliente");
                gestor.parametroPorValor("numero_de_documento", datos[2]);
                gestor.ejecutarStoredProcedure();
                gestor.desconectar();
                /*
                 * FIN TRANSACCION
                 */
                MessageBox.Show("¡Cliente eliminado exitosamente!");
            }
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMenuPrincipal.Show();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.texto(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.texto(e);
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

    }
}

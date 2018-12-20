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
using PalcoNet.Registro_de_Usuario;
using PalcoNet.Menu_Principal;
using PalcoNet.Login;

namespace PalcoNet.Abm_Cliente
{
    public partial class FormABMCliente : Form
    {
        int userID;
        int rolID;
        string query_defecto = "SELECT id_cliente, nombre, apellido, numero_de_documento, mail, " +
            "ISNULL(habilitado, 0) AS habilitado FROM PEAKY_BLINDERS.clientes C " +
            "LEFT JOIN PEAKY_BLINDERS.usuarios U ON C.id_usuario = U.id_usuario ";
        string query_actual;
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
            dgvClientes.Rows.Clear();
            while (lector.Read())
            {
                object[] row = new object[]
                {
                    lector["id_cliente"].ToString(),
                    lector["nombre"].ToString(),
                    lector["apellido"].ToString(),
                    lector["numero_de_documento"].ToString(),
                    lector["mail"].ToString(),
                    Convert.ToBoolean(lector["habilitado"])
                };
                dgvClientes.Rows.Add(row);
            }
        }

        private void agregarCheckBoxColumn(string header)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = header;
            dgvClientes.Columns.Add(column);
        }

        private void agregarButtonColumn(string header)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = header;
            column.Text = "-->";
            column.UseColumnTextForButtonValue = true;
            dgvClientes.Columns.Add(column);
        }

        // -------------------

        private void FormABMCliente_Load(object sender, EventArgs e)
        {
            dgvClientes.ColumnCount = 5;
            dgvClientes.ColumnHeadersVisible = true;
            dgvClientes.Columns[0].Name = "ID";
            dgvClientes.Columns[0].Visible = false;
            dgvClientes.Columns[1].Name = "NOMBRE";
            dgvClientes.Columns[2].Name = "APELLIDO";
            dgvClientes.Columns[3].Name = "DOCUMENTO";
            dgvClientes.Columns[4].Name = "MAIL";
            agregarCheckBoxColumn("HABILITADO");
            agregarButtonColumn("CAMBIAR CONTRASEÑA");

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta(query_defecto);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();

            query_actual = query_defecto;

            dgvClientes.AutoResizeColumns();
            validador = new ValidadorDeDatos();
            txtNombre.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string documento = txtDocumento.Text.Trim();
            string mail = txtMail.Text.Trim();

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

            query_actual = query;
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
            FormRegistroCliente formRegistroCliente = new FormRegistroCliente(userID, rolID);
            this.Hide();
            formRegistroCliente.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string clienteID = dgvClientes.CurrentRow.Cells[0].Value.ToString();

            string query = "SELECT * FROM PEAKY_BLINDERS.clientes C "
                           + "LEFT JOIN PEAKY_BLINDERS.tipos_de_documento T "
                                + "ON C.id_tipo_de_documento = T.id_tipo_de_documento "
                           + "WHERE C.id_cliente = '" + clienteID + "'";
            FormRegistroCliente formRegistroCliente = new FormRegistroCliente(userID, rolID, query);
            this.Hide();
            formRegistroCliente.Show();
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            string clienteID = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            string apellido = dgvClientes.CurrentRow.Cells[2].Value.ToString();
            bool habilitado = Convert.ToBoolean(dgvClientes.CurrentRow.Cells[5].Value);

            if (!habilitado)
            {
                MessageBox.Show("El cliente " + nombre + " " + apellido + " ya está dado de baja.", "Alerta");
            }
            else
            {
                string mensaje = "¿Confirma que desea eliminar al cliente " + nombre + " " + apellido + "?";
                DialogResult respuesta = MessageBox.Show(this, mensaje, "Eliminar cliente", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    GestorDB gestor = new GestorDB();
                    gestor.conectar();
                    gestor.generarStoredProcedure("baja_cliente");
                    gestor.parametroPorValor("id_cliente", clienteID);
                    int resultado = gestor.ejecutarStoredProcedure();
                    gestor.desconectar();

                    if (resultado == 0)
                    {
                        MessageBox.Show("El cliente no tiene un usuario asignado por lo que ya está dado de baja.", "Alerta");
                    }
                    else
                    {
                        MessageBox.Show("¡Cliente eliminado exitosamente!");
                        dgvClientes.Rows.Clear();
                        gestor.conectar();
                        gestor.consulta(query_actual);
                        this.mostrarRegistros(gestor.obtenerRegistros());
                        gestor.desconectar();
                    }
                }
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                string nombre = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                string apellido = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                int clienteID = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
                int cambioID = 0;
                bool encontro = false;

                GestorDB gestor = new GestorDB();
                gestor.conectar();
                gestor.consulta(
                    "SELECT ISNULL(id_usuario, 0) AS id_usuario " +
                    "FROM PEAKY_BLINDERS.clientes " +
                    "WHERE id_cliente = '" + clienteID + "'");
                SqlDataReader lector = gestor.obtenerRegistros();
                if (lector.Read())
                {
                    cambioID = Convert.ToInt32(lector["id_usuario"].ToString());
                    if (cambioID > 0)
                    {
                        encontro = true;
                    }
                }
                gestor.desconectar();

                if (encontro)
                {
                    FormNuevaContrasena formMiUsuario = new FormNuevaContrasena(userID, rolID, cambioID, true, false);
                    this.Hide();
                    formMiUsuario.Show();
                }
                else
                {
                    MessageBox.Show("El cliente " + nombre + " " + apellido + " no tiene un usuario asociado.", "Alerta");
                }
            }
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMenuPrincipal.Show();
        }

        private void lklCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.texto_espacio(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.texto_espacio(e);
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

    }
}

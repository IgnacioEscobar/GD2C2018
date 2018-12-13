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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class FormABMEmpresa : Form
    {
        int userID;
        int rolID;
        string query_defecto = "SELECT id_empresa, razon_social, cuit, mail, ISNULL(habilitado, 0) AS habilitado " +
            "FROM PEAKY_BLINDERS.empresas E LEFT JOIN PEAKY_BLINDERS.usuarios U ON E.id_usuario = U.id_usuario ";
        string query_actual;
        ValidadorDeDatos validador;

        public FormABMEmpresa(int userID, int rolID)
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
                object[] row = new object[]
                {
                    lector["id_empresa"].ToString(),
                    lector["razon_social"].ToString(),
                    lector["cuit"].ToString(),
                    lector["mail"].ToString(),
                    Convert.ToBoolean(lector["habilitado"])
                };
                dgvEmpresas.Rows.Add(row);
            }
        }

        private void agregarCheckBoxColumn(string header)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = header;
            dgvEmpresas.Columns.Add(column);
        }

        private void agregarButtonColumn(string header)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = header;
            column.Text = "-->";
            column.UseColumnTextForButtonValue = true;
            dgvEmpresas.Columns.Add(column);
        }

        // -------------------

        private void FormABMEmpresa_Load(object sender, EventArgs e)
        {
            dgvEmpresas.ColumnCount = 4;
            dgvEmpresas.ColumnHeadersVisible = true;
            dgvEmpresas.Columns[0].Name = "ID";
            dgvEmpresas.Columns[0].Visible = false;
            dgvEmpresas.Columns[1].Name = "RAZON SOCIAL";
            dgvEmpresas.Columns[2].Name = "CUIT";
            dgvEmpresas.Columns[3].Name = "MAIL";
            agregarCheckBoxColumn("HABILITADO");
            agregarButtonColumn("CAMBIAR CONTRASEÑA");

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta(query_defecto);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();

            query_actual = query_defecto;

            dgvEmpresas.AutoResizeColumns();
            validador = new ValidadorDeDatos();
            txtRazonSocial.Select();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtRazonSocial.Text = "";
            txtCUIT.Text = "";
            txtMail.Text = "";
            txtRazonSocial.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string razonSocial = txtRazonSocial.Text.Trim();
            string cuit = txtCUIT.Text.Trim();
            string mail = txtMail.Text.Trim();

            List<object[]> listaCampos = new List<object[]>();

            if (razonSocial != "")
            {
                object[] tuplaRazonSocial = { "razon_social", razonSocial, false };
                listaCampos.Add(tuplaRazonSocial);
            }
            if (cuit != "")
            {
                object[] tuplaCUIT = { "cuit", cuit, true };
                listaCampos.Add(tuplaCUIT);
            }
            if (mail != "")
            {
                object[] tuplaMail = { "mail", mail, false };
                listaCampos.Add(tuplaMail);
            }

            int cant_filtros = listaCampos.Count();
            if (cant_filtros > 0) dgvEmpresas.Rows.Clear();

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormRegistroEmpresa formRegistroEmpresa = new FormRegistroEmpresa(userID, rolID);
            this.Hide();
            formRegistroEmpresa.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string empresaID = dgvEmpresas.CurrentRow.Cells[0].Value.ToString();
            string query = "SELECT * FROM PEAKY_BLINDERS.empresas WHERE id_empresa = '" + empresaID + "'";

            FormRegistroEmpresa formRegistroEmpresa = new FormRegistroEmpresa(userID, rolID, query);
            this.Hide();
            formRegistroEmpresa.Show();
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            string empresaID = dgvEmpresas.CurrentRow.Cells[0].Value.ToString();
            string razon_social = dgvEmpresas.CurrentRow.Cells[1].Value.ToString();
            bool habilitado = Convert.ToBoolean(dgvEmpresas.CurrentRow.Cells[4].Value);

            if (!habilitado)
            {
                MessageBox.Show("La empresa " + razon_social + " ya está dada de baja.", "Alerta");
            }
            else
            {
                string mensaje = "¿Confirma que desea eliminar a la empresa " + razon_social + "?";
                DialogResult respuesta = MessageBox.Show(this, mensaje, "Eliminar empresa", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    GestorDB gestor = new GestorDB();
                    gestor.conectar();
                    gestor.generarStoredProcedure("baja_empresa");
                    gestor.parametroPorValor("id_empresa", empresaID);
                    int resultado = gestor.ejecutarStoredProcedure();
                    gestor.desconectar();

                    if (resultado == 0)
                    {
                        MessageBox.Show("La empresa no tiene un usuario asignado por lo que ya está dada de baja.", "Alerta");
                    }
                    else
                    {
                        MessageBox.Show("¡Empresa eliminada exitosamente!");
                        dgvEmpresas.Rows.Clear();
                        gestor.conectar();
                        gestor.consulta(query_actual);
                        this.mostrarRegistros(gestor.obtenerRegistros());
                        gestor.desconectar();
                    }
                }
            }            
        }

        private void dgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                string razon_social = dgvEmpresas.CurrentRow.Cells[1].Value.ToString();
                int empresaID = Convert.ToInt32(dgvEmpresas.CurrentRow.Cells[0].Value);
                int cambioID = 0;
                bool encontro = false;
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                gestor.consulta(
                    "SELECT ISNULL(id_usuario, 0) AS id_empresa " +
                    "FROM PEAKY_BLINDERS.empresas " +
                    "WHERE id_empresa = '" + empresaID + "'");
                SqlDataReader lector = gestor.obtenerRegistros();
                if (lector.Read())
                {
                    cambioID = Convert.ToInt32(lector["id_empresa"].ToString());
                    if (cambioID > 0)
                    {
                        encontro = true;
                    }
                }
                gestor.desconectar();
                if (encontro)
                {
                    FormNuevaContrasena formNuevaContrasena = new FormNuevaContrasena(userID, rolID, cambioID, false, true);
                    this.Hide();
                    formNuevaContrasena.Show();
                }
                else
                {
                    MessageBox.Show("La empresa " + razon_social + " no tiene un usuario asociado.", "Alerta");
                }
            }
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(userID, rolID);
            this.Hide();
            formMenuPrincipal.Show();
        }

        private void txtCUIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

    }
}

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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class FormABMEmpresa : Form
    {
        int userID;
        string query_defecto = "SELECT razon_social, cuit, mail FROM PEAKY_BLINDERS.empresas";
        ValidadorDeDatos validador;

        public FormABMEmpresa(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        // Metodos auxiliares

        private void mostrarRegistros(SqlDataReader lector)
        {
            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["razon_social"].ToString(),
                    lector["cuit"].ToString(),
                    lector["mail"].ToString(),
                };
                dgvEmpresas.Rows.Add(row);
            }
        }

        // -------------------

        private void FormABMEmpresa_Load(object sender, EventArgs e)
        {
            dgvEmpresas.ColumnCount = 3;
            dgvEmpresas.ColumnHeadersVisible = true;
            dgvEmpresas.Columns[0].Name = "RAZON SOCIAL";
            dgvEmpresas.Columns[1].Name = "CUIT";
            dgvEmpresas.Columns[2].Name = "MAIL";

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta(query_defecto);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();

            validador = new ValidadorDeDatos();
            txtRazonSocial.Select();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtRazonSocial.Text = "";
            txtCUIT.Text = "";
            txtMail.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string razonSocial = txtRazonSocial.Text;
            string cuit = txtCUIT.Text;
            string mail = txtMail.Text;

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
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormRegistroEmpresa formRegistroEmpresa = new FormRegistroEmpresa(userID, true);
            this.Hide();
            formRegistroEmpresa.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string[] param = new string[3];
            int i = 0;
            foreach (DataGridViewCell item in dgvEmpresas.CurrentRow.Cells)
            {
                param[i] = item.Value.ToString();
                i++;
            }

            string query = "SELECT * FROM PEAKY_BLINDERS.empresas WHERE cuit = '" + param[1] + "'";
            FormRegistroEmpresa formRegistroEmpresa = new FormRegistroEmpresa(userID, query);
            this.Hide();
            formRegistroEmpresa.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string[] datos = new string[3];
            int i = 0;
            foreach (DataGridViewCell item in dgvEmpresas.CurrentRow.Cells)
            {
                datos[i] = item.Value.ToString();
                i++;
            }
            string mensaje = "¿Confirma que desea eliminar a la empresa " + datos[0] + "?";
            DialogResult respuesta = MessageBox.Show(this, mensaje, "Eliminar empresa", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                /*
                 * INICIO TRANSACCION
                 */
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                gestor.generarStoredProcedure("eliminar_empresa");
                gestor.parametroPorValor("cuit", datos[1]);
                gestor.ejecutarStoredProcedure();
                gestor.desconectar();
                /*
                 * FIN TRANSACCION
                 */
                MessageBox.Show("¡Empresa eliminada exitosamente! (MENTIRA)");
            }
        }

        private void btnPanelDeControl_Click(object sender, EventArgs e)
        {
            FormMenuAdministrador formAbmAdministrador = new FormMenuAdministrador(userID);
            this.Hide();
            formAbmAdministrador.Show();
        }

        private void txtCUIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

    }
}

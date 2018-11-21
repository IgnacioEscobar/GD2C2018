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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class FormABMEmpresa : Form
    {
        public FormABMEmpresa()
        {
            InitializeComponent();
        }

        private void FormABMEmpresa_Load(object sender, EventArgs e)
        {
            dgvEmpresas.ColumnCount = 4;
            dgvEmpresas.ColumnHeadersVisible = true;
            dgvEmpresas.Columns[0].Name = "RAZON SOCIAL";
            dgvEmpresas.Columns[1].Name = "CUIT";
            dgvEmpresas.Columns[2].Name = "EMAIL";
            dgvEmpresas.Columns[3].Name = "TELEFONO";

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT razon_social, cuit, email, telefono FROM PEAKY_BLINDERS.Empresa");
            SqlDataReader lector = gestor.obtenerRegistros();

            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["razon_social"].ToString(),
                    lector["cuit"].ToString(),
                    lector["email"].ToString(),
                    lector["telefono"].ToString()
                };
                dgvEmpresas.Rows.Add(row);
            }
            gestor.desconectar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtRazonSocial.Text = "";
            txtCUIT.Text = "";
            txtEmail.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string razonSocial = txtRazonSocial.Text;
            string cuit = txtCUIT.Text;
            string email = txtEmail.Text;

            List<string[]> listaCampos = new List<string[]>();

            if (razonSocial != "")
            {
                string[] tuplaRazonSocial = { "razon_social", razonSocial };
                listaCampos.Add(tuplaRazonSocial);
            }
            if (cuit != "")
            {
                string[] tuplaCUIT = { "CUIT", cuit };
                listaCampos.Add(tuplaCUIT);
            }
            if (email != "")
            {
                string[] tuplaEmail = { "email", email };
                listaCampos.Add(tuplaEmail);
            }

            string filtro = "";
            for (int i = 0; i < listaCampos.Count(); i++)
            {
                string[] tuplaCampos = listaCampos[i];
                filtro += tuplaCampos[0] + "=" + tuplaCampos[1];
                if (i != listaCampos.Count() - 1) filtro += " AND ";
            }

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT razon_social, CUIT, email, telefono FROM PEAKY_BLINDERS.Cliente WHERE " + filtro);

            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        // Metodos auxiliares

        private void mostrarRegistros(SqlDataReader lector)
        {
            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["razon_social"].ToString(),
                    lector["CUIT"].ToString(),
                    lector["email"].ToString(),
                    lector["telefono"].ToString()
                };
                dgvEmpresas.Rows.Add(row);
            }
        }

    }
}

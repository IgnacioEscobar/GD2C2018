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
            gestor.consulta("select razon_social, cuit, email, telefono from PEAKY_BLINDERS.Empresa");
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
    }
}

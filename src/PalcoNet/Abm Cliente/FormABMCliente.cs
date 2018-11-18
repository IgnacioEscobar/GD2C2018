using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class FormABMCliente : Form
    {
        public FormABMCliente()
        {
            InitializeComponent();
        }

        private void FormABMCliente_Load(object sender, EventArgs e)
        {
            dgvClientes.ColumnCount = 3;
            dgvClientes.ColumnHeadersVisible = true;
            dgvClientes.Columns[0].Name = "Nombre";
            dgvClientes.Columns[1].Name = "Nombre";
            dgvClientes.Columns[2].Name = "CUIL";

            /*
             * Traer clientes de la base
             * Pongo unos de ejemplo
             */

            string[] row1 = new string[] { "Ignacio", "Escobar", "00-12345678-0" };
            string[] row2 = new string[] { "Juan Ignacio", "Cuiule", "00-12345678-0" };
            string[] row3 = new string[] { "Santiago", "Khazki", "00-12345678-0" };
            string[] row4 = new string[] { "Gabriel", "Ruderman", "00-12345678-0" };

            object[] rows = new object[] { row1, row2, row3, row4 };

            foreach (string[] rowArray in rows)
            {
                dgvClientes.Rows.Add(rowArray);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}

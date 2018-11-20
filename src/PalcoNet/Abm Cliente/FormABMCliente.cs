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
            dgvClientes.ColumnCount = 4;
            dgvClientes.ColumnHeadersVisible = true;
            dgvClientes.Columns[0].Name = "NOMBRE";
            dgvClientes.Columns[1].Name = "APELLIDO";
            dgvClientes.Columns[2].Name = "TIPO DOCUMENTO";
            dgvClientes.Columns[3].Name = "DOCUMENTO";

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("select nombre, apellido, tipo_documento, documento from PEAKY_BLINDERS.Cliente");
            SqlDataReader lector = gestor.obtenerRegistros();

            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["nombre"].ToString(),
                    lector["apellido"].ToString(),
                    lector["tipo_documento"].ToString(),
                    lector["documento"].ToString()
                };
                dgvClientes.Rows.Add(row);
            }
            gestor.desconectar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}

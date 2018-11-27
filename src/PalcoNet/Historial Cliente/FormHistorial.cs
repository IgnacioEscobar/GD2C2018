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

namespace PalcoNet.Historial_Cliente
{
    public partial class FormHistorial : Form
    {
        public FormHistorial()
        {
            InitializeComponent();
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {

        }
        /*
                private void mostrarRegistros(SqlDataReader lector)
                {
                    while (lector.Read())
                    {
                        object[] row = new string[]
                        {
                            lector["nombre"].ToString(),
                            lector["apellido"].ToString(),
                            lector["numero_de_documento"].ToString()
                        };
                        dgvHistorial.Rows.Add(row);
                    }
                }

                private void FormHistorial_Load(object sender, EventArgs e)
                {
                    dgvHistorial.ColumnCount = 3;
                    dgvHistorial.ColumnHeadersVisible = true;
                    dgvHistorial.Columns[0].Name = "NOMBRE";
                    dgvHistorial.Columns[1].Name = "APELLIDO";
                    dgvHistorial.Columns[2].Name = "DOCUMENTO";

                    GestorDB gestor = new GestorDB();
                    gestor.conectar();

                    string query = "SELECT * " +
                        "FROM PEAKY_BLINDERS.compras Co " +
                        "JOIN PEAKY_BLINDERS.clientes Cl ON Co.id_cliente = Cl.id_cliente " +
                        "WHERE Cl.id = ";
 
                    ------- TODO: tener registrada la ID del cliente -------

                    gestor.consulta("SELECT descripcion FROM PEAKY_BLINDERS.rubros");
                    this.mostrarRegistros(gestor.obtenerRegistros());
                    gestor.desconectar();
                }
         */
    }
}

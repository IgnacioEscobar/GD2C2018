using PalcoNet.funciones_utiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class FormFiltrarEspectaculos : Form
    {

        int userID;
        int rolID;
        GestorDB gestor = new GestorDB();
        List<string> categorias = new List<string>();


        public FormFiltrarEspectaculos(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
            

            gestor.conectar();
            string query_categorias = "SELECT id_rubro, descripcion FROM PEAKY_BLINDERS.rubros";
            gestor.consulta(query_categorias);
            this.mostrarCategorias(gestor.obtenerRegistros());
            gestor.desconectar();

            this.mostrarPublicaciones();
        }

        private void mostrarCategorias(SqlDataReader lector)
        {
            int i = 0;
            while (lector.Read())
            {
                checkedListBox1.Items.Add(lector["descripcion"]);
                checkedListBox1.SetItemChecked(i, true);
                this.categorias.Add(lector["id_rubro"].ToString());
                i++;
            }
        }

        private void agregarButtonColumn(string header)
        {
            DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            column.HeaderText = header;
            column.Text = "-->";
            column.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(column);
        }

        private void mostrarPublicaciones()
        {
            gestor.conectar();
            string query_presentaciones = "select P.descripcion, PP.fecha_presentacion from PEAKY_BLINDERS.presentaciones PP " 
                + "join PEAKY_BLINDERS.publicaciones P on PP.id_publicacion = P.id_publicacion "
                + "join PEAKY_BLINDERS.estados E on P.id_estado = E.id_estado and E.descripcion = 'Publicada' "
                + "join PEAKY_BLINDERS.grados G on P.id_grado = G.id_grado "
                + "where PP.fecha_vencimiento > GETDATE() and "
                    + "P.id_rubro in (" + String.Join(",", this.categorias.Select(x => x).ToArray()) + ") "
                    // + "PP.fecha_presentacion > " + fechaInicio + " "
                    // + "PP.fecha_presentacion < " + fechaFin + " "
                + "order by G.muliplicador desc, PP.fecha_presentacion asc";
            gestor.consulta(query_presentaciones);
            SqlDataReader lector = gestor.obtenerRegistros();
            
            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["descripcion"].ToString(),
                    lector["fecha_presentacion"].ToString(),
                };
                dataGridView1.Rows.Add(row);
            }

            gestor.desconectar();

            this.agregarButtonColumn("Comprar");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

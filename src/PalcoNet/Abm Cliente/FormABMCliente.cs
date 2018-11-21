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
            gestor.consulta("SELECT nombre, apellido, tipo_documento, documento FROM PEAKY_BLINDERS.Cliente");
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
            txtEmail.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string documento = txtDocumento.Text;
            string email = txtEmail.Text;

            List<string[]> listaCampos = new List<string[]>();
            
            if (nombre != "")
            {
                string[] tuplaNombre = { "nombre", nombre };
                listaCampos.Add(tuplaNombre);
            }
            if (apellido != "")
            {
                string[] tuplaApellido = { "apellido", apellido };
                listaCampos.Add(tuplaApellido);
            }
            if (documento != "")
            {
                string[] tuplaDocumento = { "documento", documento };
                listaCampos.Add(tuplaDocumento);
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
            gestor.consulta("SELECT nombre, apellido, tipo_documento, documento FROM PEAKY_BLINDERS.Cliente WHERE " + filtro);

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
                    lector["nombre"].ToString(),
                    lector["apellido"].ToString(),
                    lector["tipo_documento"].ToString(),
                    lector["documento"].ToString()
                };
                dgvClientes.Rows.Add(row);
            }
        }

    }
}

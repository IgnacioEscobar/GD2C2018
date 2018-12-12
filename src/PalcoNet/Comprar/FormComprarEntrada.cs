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
    public partial class FormComprarEntrada : Form
    {
        int userID;
        int rolID;
        int idPresentacion;
        GestorDB gestor = new GestorDB();
        List<string> ubicaciones = new List<string>();
        List<string> ubicacionesSeleccionadas = new List<string>();
        List<string> premios = new List<string>();
        string premioSeleccionado = "-1";

        public FormComprarEntrada(int userID, int rolID, int idPresentacion)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
            this.idPresentacion = idPresentacion;

            this.mostrarTiposDeUbicacion(idPresentacion);
            this.mostrarPremiosDisponibles();
        }

        private void mostrarPremiosDisponibles()
        {
            gestor.conectar();
            string query_premios = "select P.id_premio, TP.descripcion from PEAKY_BLINDERS.premios P "
                + " join PEAKY_BLINDERS.tipos_de_premios TP on TP.id_tipo_de_premio = P.id_tipo_de_premio "
                + " where P.id_cliente = " + this.userID + " and P.usado = 0";
            gestor.consulta(query_premios);
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                premios.Add(lector["id_premio"].ToString());
                comboPremios.Items.Add(lector["descripcion"]);
            }
            gestor.desconectar();
        }

        private void mostrarTiposDeUbicacion(int idPresentacion)
        {
            gestor.conectar();
            string query_tipos = "select distinct TU.id_tipo_de_ubicacion, TU.descripcion from PEAKY_BLINDERS.ubicaciones U "
                + " join PEAKY_BLINDERS.presentaciones PP on PP.id_publicacion = U.id_publicacion "
                + " join PEAKY_BLINDERS.tipos_de_ubicacion TU on TU.id_tipo_de_ubicacion = U.id_tipo_de_ubicacion "
                + " where PP.id_presentacion = " + idPresentacion + " and "
                + " U.id_ubicacion not in "
                + "     (select C.id_ubicacion from PEAKY_BLINDERS.compras C where C.id_presentacion = " + idPresentacion + ")";
            gestor.consulta(query_tipos);
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                comboTipo.Items.Add(lector["descripcion"]);
            }
            gestor.desconectar();
        }

        private void renovarUbicaciones(string idTipoDeUbicacion)
        {
            ubicacionesListBox.Items.Clear();
            this.ubicaciones.Clear();
            gestor.conectar();
            string query_ubicaciones = "select U.id_ubicacion, U.fila, U.asiento, U.precio from PEAKY_BLINDERS.ubicaciones U "
                + " join PEAKY_BLINDERS.presentaciones PP on PP.id_publicacion = U.id_publicacion"
                + " where U.id_tipo_de_ubicacion = " + idTipoDeUbicacion + " and PP.id_presentacion = " + this.idPresentacion + " and U.id_ubicacion not in (select C.id_ubicacion from PEAKY_BLINDERS.compras C"
                + " where C.id_presentacion = " + this.idPresentacion + ")"
                + " order by U.fila, U.asiento, U.precio";
            gestor.consulta(query_ubicaciones);
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                this.ubicaciones.Add(lector["id_ubicacion"].ToString());
                ubicacionesListBox.Items.Add("Fila " + lector["fila"] + " - Asiento " + lector["asiento"] + " ($" + lector["precio"] + ")" );
            }
            gestor.desconectar();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void numericBtn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCantEntradas_Click(object sender, EventArgs e)
        {

        }

        private string idTipoSegunDescripcion(string descripcion)
        {
            gestor.conectar();
            string query_ubicaciones = "select TU.id_tipo_de_ubicacion from PEAKY_BLINDERS.tipos_de_ubicacion TU where TU.descripcion = '" + descripcion + "'";
            gestor.consulta(query_ubicaciones);
            SqlDataReader lector = gestor.obtenerRegistros();
            lector.Read();
            return lector["id_tipo_de_ubicacion"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string descripcion = comboTipo.Items[comboTipo.SelectedIndex].ToString();
            string idTipo = this.idTipoSegunDescripcion(descripcion);
            gestor.desconectar();
            this.renovarUbicaciones(idTipo);
        }

        private void btnCosto_Click(object sender, EventArgs e)
        {
            this.ubicacionesSeleccionadas.Clear();
            for (int i = 0; i < ubicacionesListBox.Items.Count; i++)
            {
                if (ubicacionesListBox.GetItemChecked(i))
                {
                    this.ubicacionesSeleccionadas.Add(this.ubicaciones[i]);
                }
            }
            
            gestor.conectar();
            string query_ubicaciones = "select sum(U.precio) from PEAKY_BLINDERS.ubicaciones U "
                + " where U.id_ubicacion in (" + String.Join(",", this.ubicacionesSeleccionadas.Select(x => x).ToArray()) + ")";
            gestor.consulta(query_ubicaciones);
            SqlDataReader lector = gestor.obtenerRegistros();
            lector.Read();
            this.label1.Text = "Monto: $" + lector[0].ToString();
            gestor.desconectar();
        }

        private void FormComprarEntrada_Load(object sender, EventArgs e)
        {

        }

        private void btnPremio_Click(object sender, EventArgs e)
        {
            this.premioSeleccionado = premios[this.comboPremios.SelectedIndex];
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            gestor.conectar();
            string query_ubicaciones = "select id_publicacion from PEAKY_BLINDERS.ubicaciones where id_ubicacion = " + ubicacionesSeleccionadas[0];
            gestor.consulta(query_ubicaciones);
            SqlDataReader lector = gestor.obtenerRegistros();
            lector.Read();
            string id_publicacion = lector["id_publicacion"].ToString();
            gestor.desconectar();
            // @id_cliente int,
            // @id_medio_de_pago tinyint,
            // @id_presentacion int,
            // @id_publicacion int,
            // @id_ubicacion int,
            // @id_premio int
            for (int i = 0; i < ubicacionesSeleccionadas.Count; i++)
            {
                gestor.conectar();
                gestor.generarStoredProcedure("registrarCompra");
                gestor.parametroPorValor("id_cliente", this.userID);
                gestor.parametroPorValor("id_medio_de_pago", 1);
                gestor.parametroPorValor("id_presentacion", this.idPresentacion);
                gestor.parametroPorValor("id_publicacion", id_publicacion);
                gestor.parametroPorValor("id_ubicacion", ubicacionesSeleccionadas[i]);
                gestor.parametroPorValor("id_premio", this.premioSeleccionado);
                gestor.ejecutarStoredProcedure();
                gestor.desconectar();
            }
        }
    }
}

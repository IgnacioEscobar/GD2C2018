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

        public FormComprarEntrada(int userID, int rolID, int idPresentacion)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
            this.idPresentacion = idPresentacion;

            this.mostrarTiposDeUbicacion(idPresentacion);
            // Para cada asiento tildado tenemos que hacer lo siguiente
            // insert into PEAKY_BLINDERS.compras (id_cliente, id_medio_de_pago, id_presentacion, id_publicacion, id_ubicacion, monto)
            // values (userId, /*supongo que 2 (? por tarjeta...*/, idPresentacion, idPublicacion /* esto se puede sacar de la  presentacion o del asiento*/, idUbicacion /* tildada */, monto)
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

        private void renovarUbicaciones(int idTipoDeUbicacion)
        {
            ubicacionesListBox.Items.Clear();
            gestor.conectar();
            // pruebo con 4447 porque no se como bindear al evento de elegir del dropdown
            string query_ubicaciones = "select U.id_ubicacion, U.fila, U.asiento, U.precio from PEAKY_BLINDERS.ubicaciones U "
                + " join PEAKY_BLINDERS.presentaciones PP on PP.id_publicacion = U.id_publicacion"
                + " where U.id_tipo_de_ubicacion = 4447 and PP.id_presentacion = " + this.idPresentacion + " and U.id_ubicacion not in (select C.id_ubicacion from PEAKY_BLINDERS.compras C"
                + " where C.id_presentacion = " + this.idPresentacion + ")"
                + " order by U.fila, U.asiento, U.precio";
            gestor.consulta(query_ubicaciones);
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.renovarUbicaciones(1);
        }

        /*
         * Para armar DataGridView paginada (paginando la query para no llenar la memoria):
         * https://www.codeproject.com/Articles/211551/A-Simple-way-for-Paging-in-DataGridView-in-WinForm
         */

    }
}

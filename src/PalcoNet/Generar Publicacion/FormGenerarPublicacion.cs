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
using PalcoNet.Menu_Principal;
using PalcoNet.Editar_Publicacion;

namespace PalcoNet.Generar_Publicacion
{
    public partial class FormGenerarPublicacion : Form
    {
        int userID;
        int rolID;
        int empresaID;
        int publicacionID;
        bool modif;
        ValidadorDeDatos validador;

        public FormGenerarPublicacion(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
            this.modif = false;
        }

        public FormGenerarPublicacion(int userID, int rolID, int publicacionID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
            this.publicacionID = publicacionID;
            this.modif = true;
        }

        // Metodos auxiliares

        private void mostrarRubros(SqlDataReader lector)
        {
            while (lector.Read())
            {
                cmbRubro.Items.Add(lector["descripcion"].ToString());
            }
        }

        private bool validarCampos()
        {
            List<string[]> lista = new List<string[]>();
            lista.Add(new string[] { txtDescripcion.Text, "descripción" });
            lista.Add(new string[] { txtCalle.Text, "calle" });
            lista.Add(new string[] { txtAltura.Text, "altura" });
            lista.Add(new string[] { txtCodigoPostal.Text, "calle" });
            lista.Add(new string[] { txtAltura.Text, "altura" });
            lista.Add(new string[] { txtCodigoPostal.Text, "código postal" });
            lista.Add(new string[] { txtLocalidad.Text, "localidad" });
            lista.Add(new string[] { cmbRubro.Text, "rubro" });

            string mensaje = "";
            bool retorno = validador.validar_campos_obligatorios(lista, ref mensaje);

            if (lsvFechaHora.Items.Count < 1)
            {
                mensaje += "\n\nTiene que ingresar al menos una fecha.";
                retorno = false;
            }

            if (!retorno)
            {
                MessageBox.Show(mensaje, "Alerta");
            }

            return retorno;
        }

        private void enviarPresentancion(GestorDB gestor, int id_publicacion, DateTime fecha_presentacion)
        {
            gestor.conectar();
            gestor.generarStoredProcedure("generar_presentacion");
            gestor.parametroPorValor("id_publicacion", id_publicacion);
            gestor.parametroPorValor("fecha_presentacion", fecha_presentacion);
            gestor.ejecutarStoredProcedure();
            gestor.desconectar();
        }

        private void persistirPublicacion(string procedure, string estado)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT id_empresa FROM PEAKY_BLINDERS.empresas WHERE id_usuario = '" + userID + "'");
            SqlDataReader lector = gestor.obtenerRegistros();
            if (lector.Read())
            {
                empresaID = Convert.ToInt32(lector["id_empresa"].ToString());
            }
            gestor.desconectar();

            gestor.conectar();
            gestor.generarStoredProcedure(procedure);
            if (modif)
            {
                gestor.parametroPorValor("id_publicacion", publicacionID);
            }
            gestor.parametroPorValor("descripcion", txtDescripcion.Text);
            gestor.parametroPorValor("fecha_publicacion", DateTime.Today);
            gestor.parametroPorValor("descripcion_rubro", cmbRubro.Text);
            gestor.parametroPorValor("calle", txtCalle.Text);
            gestor.parametroPorValor("numero", txtAltura.Text);
            gestor.parametroPorValor("codigo_postal", txtCodigoPostal.Text);
            gestor.parametroPorValor("localidad", txtLocalidad.Text);
            if (!modif)
            {
                gestor.parametroPorValor("id_empresa", empresaID);
            }
            gestor.parametroPorValor("descripcion_estado", estado);
            int id_publicacion = gestor.ejecutarStoredProcedure();
            if (modif)
            {
                id_publicacion = publicacionID; // Agarra la ID original
            }
            
            gestor.desconectar();

            foreach (ListViewItem item in lsvFechaHora.Items)
            {
                if (item.SubItems[2].Text == "NUEVO")
                {
                    enviarPresentancion(gestor, id_publicacion, DateTime.Parse(item.Text + " " + item.SubItems[1].Text));
                }
            }
            
            /*
             * FIN TRANSACCION
             */
        }

        // -------------------

        private void FormGenerarPublicacion_Load(object sender, EventArgs e)
        {
            GeneradorDeFechas generador = new GeneradorDeFechas();
            generador.completarDia(cmbDia);
            generador.completarMes(cmbMes, false);
            generador.completarAno(cmbAno, false);

            lsvFechaHora.View = View.Details;
            lsvFechaHora.Columns.Add("FECHA");
            lsvFechaHora.Columns.Add("HORA");
            lsvFechaHora.Columns.Add("");
            lsvFechaHora.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT descripcion FROM PEAKY_BLINDERS.rubros");
            this.mostrarRubros(gestor.obtenerRegistros());
            gestor.desconectar();

            if (modif)
            {
                string estado = "";

                gestor.conectar();
                string query = "SELECT P.descripcion AS descripcionP, P.calle, P.numero, P.codigo_postal, " +
                        "P.localidad, R.descripcion AS descripcionR, E.descripcion AS descripcionE " +
                    "FROM PEAKY_BLINDERS.publicaciones P " +
                        "JOIN PEAKY_BLINDERS.rubros R ON P.id_rubro = R.id_rubro " +
                        "JOIN PEAKY_BLINDERS.estados E ON P.id_estado = E.id_estado " +
                    "WHERE id_publicacion = '" + publicacionID + "'";
                gestor.consulta(query);
                SqlDataReader lector = gestor.obtenerRegistros();
                if (lector.Read())
                {
                    txtDescripcion.Text = lector["descripcionP"].ToString();
                    txtCalle.Text = lector["calle"].ToString();
                    txtAltura.Text = lector["numero"].ToString();
                    txtCodigoPostal.Text = lector["codigo_postal"].ToString();
                    txtLocalidad.Text = lector["localidad"].ToString();
                    cmbRubro.Text = lector["descripcionR"].ToString();
                    estado = lector["descripcionE"].ToString();
                }
                gestor.desconectar();

                gestor.conectar();
                string query2 = "SELECT fecha_presentacion FROM PEAKY_BLINDERS.presentaciones " +
                    "WHERE id_publicacion = '" + publicacionID + "'";
                gestor.consulta(query2);
                SqlDataReader lector2 = gestor.obtenerRegistros();
                while (lector2.Read())
                {
                    DateTime fecha_presentacion = DateTime.Parse(lector2["fecha_presentacion"].ToString());
                    ListViewItem item = new ListViewItem(fecha_presentacion.ToShortDateString());
                    item.SubItems.Add(fecha_presentacion.ToShortTimeString());
                    item.SubItems.Add("");
                    lsvFechaHora.Items.Add(item);
                }
                gestor.desconectar();
                lsvFechaHora.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                if (estado == "Finalizada")
                {
                    txtDescripcion.Enabled = false;
                    txtCalle.Enabled = false;
                    txtAltura.Enabled = false;
                    txtCodigoPostal.Enabled = false;
                    txtLocalidad.Enabled = false;
                    cmbRubro.Enabled = false;

                    btnAgregarFecha.Enabled = false;
                    btnDefinirUbicaciones.Enabled = false;
                    btnPublicar.Enabled = false;
                    btnGuardarBorrador.Enabled = false;
                    btnFinalizarPublicacion.Enabled = false;
                }
                else if (estado == "Publicada")
                {
                    btnGuardarBorrador.Enabled = false;
                }
                else
                {
                    btnFinalizarPublicacion.Enabled = true;
                }
            }
            else
            {
                btnFinalizarPublicacion.Enabled = false;
                txtDescripcion.Select();
            }

            validador = new ValidadorDeDatos();
        }

        private void btnAgregarFecha_Click(object sender, EventArgs e)
        {
            string dia = cmbDia.Text;
            string mes = cmbMes.Text;
            if (dia.Length == 1) dia = "0" + dia;
            if (mes.Length == 1) mes = "0" + mes;
            string campos_fecha = dia + "/" + mes + "/" + cmbAno.Text;
            string fecha = campos_fecha + " " + nudHora.Value.ToString() + ":" + nudMinuto.Value.ToString();
            DateTime fecha_ingresada = DateTime.Parse(campos_fecha);

            int cant_items = lsvFechaHora.Items.Count;
            if (cant_items > 0)
            {
                DateTime ultima_cargada = DateTime.Parse(lsvFechaHora.Items[cant_items - 1].Text + " " + lsvFechaHora.Items[cant_items - 1].SubItems[1].Text);

                if (ultima_cargada > fecha_ingresada)
                {
                    MessageBox.Show("La fecha de presentación ingresada no puede ser anterior a una que ya esté cargada, intente con otra fecha.", "ALERTA");
                    return;
                }
            }

            ListViewItem item = new ListViewItem(campos_fecha);
            string hora = nudHora.Value.ToString();
            string minuto = nudMinuto.Value.ToString();
            if (minuto.Length == 1) minuto = "0" + minuto;
            item.SubItems.Add(hora + ":" + minuto);
            item.SubItems.Add("NUEVO");
            lsvFechaHora.Items.Add(item);
            lsvFechaHora.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            Form formDestino;

            if (this.validarCampos())
            {
                if (!modif)
                {
                    this.persistirPublicacion("generar_publicacion", "Publicada");
                    MessageBox.Show("Publicación registrada existosamente. Ya se encuentra publicada.");
                    formDestino = new FormMenuPrincipal(userID, rolID);
                }
                else
                {
                    this.persistirPublicacion("modificar_publicacion", "Publicada");
                    MessageBox.Show("Publicación actualizada exitosamente. Ya se encuentra publicada.");
                    formDestino = new FormEditarPublicacion(userID, rolID);
                }
                
                this.Hide();
                formDestino.Show();
            }
        }

        private void btnGuardarBorrador_Click(object sender, EventArgs e)
        {
            if (this.validarCampos())
            {
                if (!modif)
                {
                    this.persistirPublicacion("generar_publicacion", "Borrador");
                    MessageBox.Show("Publicación guardada como borrador.");
                }
                else
                {
                    this.persistirPublicacion("modificar_publicacion", "Borrador");
                    MessageBox.Show("Publicación actualizada exitosamente. Se encuentra como borrador.");
                }
            }
        }

        private void btnFinalizarPublicacion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea finalizar la publicación? Este cambio es irreversible.", "Confirmar finalización", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                gestor.generarStoredProcedure("finalizar_publicacion");
                gestor.parametroPorValor("id_publicacion", publicacionID);
                gestor.ejecutarStoredProcedure();
                gestor.desconectar();

                MessageBox.Show("La publicación ha sido finalizada correctamente.");

                FormEditarPublicacion formEditarPublicacion = new FormEditarPublicacion(userID, rolID);
                this.Hide();
                formEditarPublicacion.Show();
            }            
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Form formDestino;
            if (modif)
            {
                formDestino = new FormEditarPublicacion(userID, rolID);
            }
            else
            {
                formDestino = new FormMenuPrincipal(userID, rolID);
            }
            this.Hide();
            formDestino.Show();
        }

        private void btnDefinirUbicaciones_Click(object sender, EventArgs e)
        {
            FormUbicaciones formUbicaciones = new FormUbicaciones(userID, rolID);
            this.Hide();
            formUbicaciones.Show();
        }

        private void cmbDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void cmbMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void cmbAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void nudHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void nudMinuto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.alfanumerico(e);
        }

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void txtCodPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void txtLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.alfanumerico(e);
        }

    }
}

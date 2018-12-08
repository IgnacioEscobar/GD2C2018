﻿using System;
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

namespace PalcoNet.Generar_Publicacion
{
    public partial class FormGenerarPublicacion : Form
    {
        int userID;
        ValidadorDeDatos validador;

        public FormGenerarPublicacion(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        // Metodos auxiliares

        private void mostrarRegistros(SqlDataReader lector)
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
            lista.Add(new string[] { txtStock.Text, "stock" });
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
            /*
             * INICIO TRANSACCION
             */

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.generarStoredProcedure(procedure);
            gestor.parametroPorValor("descripcion", txtDescripcion.Text);
            gestor.parametroPorValor("stock", txtStock.Text);
            gestor.parametroPorValor("fecha_publicacion", DateTime.Today);
            gestor.parametroPorValor("descripcion_rubro", cmbRubro.Text);
            gestor.parametroPorValor("calle", txtCalle.Text);
            gestor.parametroPorValor("numero", txtAltura.Text);
            gestor.parametroPorValor("codigo_postal", txtCodigoPostal.Text);
            gestor.parametroPorValor("localidad", txtLocalidad.Text);
            gestor.parametroPorValor("id_empresa", 1);
            gestor.parametroPorValor("descripcion_estado", estado);
            int id_publicacion = gestor.ejecutarStoredProcedure();
            gestor.desconectar();

            foreach (ListViewItem item in lsvFechaHora.Items)
            {
                enviarPresentancion(gestor, id_publicacion, DateTime.Parse(item.Text + " " + item.SubItems[1].Text));
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
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();

            validador = new ValidadorDeDatos();
            txtDescripcion.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormMenuEmpresa formMenuEmpresa = new FormMenuEmpresa(userID);
            this.Hide();
            formMenuEmpresa.Show();
        }

        private void btnAgregarFecha_Click(object sender, EventArgs e)
        {
            string campos_fecha = cmbAno.Text + "/" + cmbMes.Text + "/" + cmbDia.Text + " " + nudHora.Value.ToString() + ":" + nudMinuto.Value.ToString();
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

            ListViewItem item = new ListViewItem(cmbAno.Text + "/" + cmbMes.Text + "/" + cmbDia.Text);
            string hora = nudHora.Value.ToString();
            string minuto = nudMinuto.Value.ToString();
            if (hora.Length == 1) hora = "0" + hora;
            if (minuto.Length == 1) minuto = "0" + minuto;
            item.SubItems.Add(hora + ":" + minuto);
            item.SubItems.Add("NUEVO");
            lsvFechaHora.Items.Add(item);
            lsvFechaHora.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            if (this.validarCampos())
            {
                this.persistirPublicacion("generar_publicacion", "Publicada");
                MessageBox.Show("Publicación registrada existosamente. Ya se encuentra publicada.");
                FormMenuEmpresa formMenuEmpresa = new FormMenuEmpresa(userID);
                this.Hide();
                formMenuEmpresa.Show();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.validarCampos())
            {
                this.persistirPublicacion("generar_publicacion", "Borrador");
                MessageBox.Show("Publicación guardada como borrador.");
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

    }
}

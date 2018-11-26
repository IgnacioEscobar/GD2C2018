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
using PalcoNet.Abm_Cliente;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class FormRegistroCliente : Form
    {
        bool abm; // si viene del ABM
        bool modif; // si viene por modificar o por agregar
        string query;
        string clienteID;
        FormTarjetaDeCredito formTarjetaDeCredito;
        string numeroTarjeta;

        public FormRegistroCliente(bool abm)
        {
            InitializeComponent();
            this.abm = abm;
            this.modif = false;
            this.numeroTarjeta = "";
        }

        public FormRegistroCliente(string query)
        {

            InitializeComponent();
            this.abm = true;
            this.modif = true;
            this.query = query;
        }

        private bool validarCampos()
        {
            // TODO: chequear que campos son obligatorios
            if (txtCUIL.Text == "")
            {
                lblError.Text = "Complete su CUIL";
                lblError.Visible = true;
                return false;
            }
            return true;
        }

        private void cargarTexto(SqlDataReader lector, TextBox txtCampo, string campo)
        {
            try
            {
                txtCampo.Text = lector[campo].ToString();
            }
            catch
            {
                txtCampo.Text = "";
            }
        }

        private void cargarFecha(SqlDataReader lector, string campo)
        {
            try
            {
                cmbDia.Text = Convert.ToDateTime(lector[campo]).Day.ToString();
                cmbMes.Text = Convert.ToDateTime(lector[campo]).Month.ToString();
                cmbAno.Text = Convert.ToDateTime(lector[campo]).Year.ToString();
            }
            catch
            {
                cmbDia.Text = "";
                cmbMes.Text = "";
                cmbAno.Text = "";
            }
        }

        private void cargarTipoDeDocumento(SqlDataReader lector, string campo)
        {
            try
            {
                cmbTipoDoc.Text = lector[campo].ToString();
            }
            catch
            {
                cmbTipoDoc.Text = "";
            }
        }

        private void cargarListaTiposDocumento()
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT descripcion FROM PEAKY_BLINDERS.tipos_de_documento");
            SqlDataReader lector = gestor.obtenerRegistros();
            while (lector.Read())
            {
                cmbTipoDoc.Items.Add(lector["descripcion"].ToString());
            }
        }

        private void FormRegistroCliente_Load(object sender, EventArgs e)
        {
            cargarListaTiposDocumento();
            GeneradorDeFechas generador = new GeneradorDeFechas();
            generador.completar(cmbDia, cmbMes, cmbAno);

            if (modif)
            {
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                gestor.consulta(query);
                SqlDataReader lector = gestor.obtenerRegistros();
                if (lector.Read())
                {
                    clienteID = lector["id_cliente"].ToString();
                    cargarTexto(lector, txtNombre, "nombre");
                    cargarTexto(lector, txtApellido, "apellido");
                    cargarTipoDeDocumento(lector, "descripcion");
                    cargarTexto(lector, txtNumeroDoc, "numero_de_documento");
                    cargarTexto(lector, txtCUIL, "cuil");
                    cargarTexto(lector, txtMail, "mail");
                    cargarTexto(lector, txtCalle, "calle");
                    cargarTexto(lector, txtAltura, "numero");
                    cargarTexto(lector, txtPiso, "piso");
                    cargarTexto(lector, txtDepto, "depto");
                    cargarTexto(lector, txtCodPostal, "codigo_postal");
                    cargarTexto(lector, txtLocalidad, "localidad");
                    cargarFecha(lector, "fecha_nacimiento");
                    numeroTarjeta = lector["tarjeta_de_credito_asociada"].ToString();
                }
                gestor.desconectar();
            }

            formTarjetaDeCredito = new FormTarjetaDeCredito(this, numeroTarjeta);
            lblError.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Form formDestino;
            if (abm)
            {
                formDestino = new FormABMCliente();
            }
            else
            {
                formDestino = new FormLogin();
            }
            this.Hide();
            formTarjetaDeCredito.Hide();
            formDestino.Show();
        }

        public void cambioNumeroTarjeta(string nuevoNumero)
        {
            this.numeroTarjeta = nuevoNumero;
        }

        private void btnAsociarTarjeta_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                formTarjetaDeCredito.Hide();
                formTarjetaDeCredito.Show();
            }            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                /*
                 * INICIO TRANSACCION
                 */
                GestorDB gestor = new GestorDB();
                gestor.conectar();

                if (!modif)
                {
                    gestor.generarStoredProcedure("crear_cliente");
                }
                else
                {
                    gestor.generarStoredProcedure("modificar_cliente");
                    gestor.parametroPorValor("id_cliente", clienteID);
                }

                gestor.parametroPorValor("nombre", txtNombre.Text);
                gestor.parametroPorValor("apellido", txtApellido.Text);
                gestor.parametroPorValor("tipo_de_documento", cmbTipoDoc.Text);
                gestor.parametroPorValor("numero_de_documento", txtNumeroDoc.Text);
                gestor.parametroPorValor("cuil", txtCUIL.Text);
                gestor.parametroPorValor("dia", cmbDia.Text);
                gestor.parametroPorValor("mes", cmbMes.Text);
                gestor.parametroPorValor("ano", cmbAno.Text);
                DateTime fecha_nacimiento = DateTime.Parse(cmbAno.Text + "/" + cmbMes.Text + "/" + cmbDia.Text);
                gestor.parametroPorValor("fecha_nacimiento", fecha_nacimiento);
                gestor.parametroPorValor("calle", txtCalle.Text);
                gestor.parametroPorValor("numero", txtAltura.Text);
                gestor.parametroPorValor("piso", txtPiso.Text);
                gestor.parametroPorValor("depto", txtDepto.Text);
                gestor.parametroPorValor("codigo_postal", txtCodPostal.Text);
                gestor.parametroPorValor("localidad", txtLocalidad.Text);
                gestor.parametroPorValor("mail", txtMail.Text);
                gestor.parametroPorValor("telefono", txtTelefono.Text);
                MessageBox.Show(numeroTarjeta);
                gestor.parametroPorValor("tarjeta_de_credito_asociada", numeroTarjeta);
                // TODO: interfaz de tarjeta de credito

                gestor.ejecutarStoredProcedure();
                gestor.desconectar();
                /*
                 * FIN TRANSACCION
                 */

                if (!modif)
                {
                    GeneradorDeContrasenasAleatorias generadorDeContrasenas = new GeneradorDeContrasenasAleatorias();
                    MessageBox.Show("Usuario: " + txtCUIL.Text
                        + "\nContraseña: " + generadorDeContrasenas.generar(10)
                        + "\n\n Por favor recuerde la contraseña e inicie sesión para actualizarla.");
                }
                else
                {
                    MessageBox.Show("¡Datos actualizados!");
                }

                Form formDestino;
                if (abm)
                {
                    formDestino = new FormABMCliente();
                }
                else
                {
                    formDestino = new FormLogin();
                }

                this.Hide();
                formTarjetaDeCredito.Hide();
                formDestino.Show();
            }
        }

    }
}

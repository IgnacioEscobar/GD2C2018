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
        bool abm;
        bool modif;
        string query;

        public FormRegistroCliente(bool abm)
        {
            InitializeComponent();
            this.abm = abm;
            this.modif = false;
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
            if (txtCUIL1.Text == "" || txtCUIL2.Text == "" || txtCUIL3.Text == "")
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

        private void FormRegistroCliente_Load(object sender, EventArgs e)
        {
            if (modif)
            {
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                gestor.consulta(query);
                SqlDataReader lector = gestor.obtenerRegistros();
                if (lector.Read())
                {
                    cargarTexto(lector, txtNombre, "nombre");
                    cargarTexto(lector, txtApellido, "apellido");
                    cargarTexto(lector, txtNumeroDoc, "numero_de_documento");
                    cargarTexto(lector, txtMail, "mail");
                    cargarTexto(lector, txtCalle, "calle");
                    cargarTexto(lector, txtAltura, "numero");
                    cargarTexto(lector, txtPiso, "piso");
                    cargarTexto(lector, txtDpto, "depto");
                    cargarTexto(lector, txtCodPostal, "codigo_postal");
                    cargarTexto(lector, txtLocalidad, "localidad");
                    cargarFecha(lector, "fecha_nacimiento");
                }
                gestor.desconectar();
            }

            for (int i = 1; i <= 31; i++)
            {
                cmbDia.Items.Add(i);
            }
            for (int i = DateTime.Today.Year; i >= 1900; i--)
            {
                cmbAno.Items.Add(i);
            }

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
            formDestino.Show();
        }

        private void btnAsociarTarjeta_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                MessageBox.Show("Tarjeta de crédito registrada con éxito.");
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
                    gestor.generarStoredProcedure("actualizar_cliente");
                }

                gestor.parametroPorValor("nombre", txtNombre.Text);
                gestor.parametroPorValor("apellido", txtApellido.Text);
                // ...TODOS LOS CAMPOS...
                gestor.ejecutarStoredProcedure();
                gestor.desconectar();
                /*
                 * FIN TRANSACCION
                 */

                if (!modif)
                {
                    string usuario = txtCUIL1.Text + txtCUIL2.Text + txtCUIL3.Text;
                    GeneradorDeContrasenasAleatorias generadorDeContrasenas = new GeneradorDeContrasenasAleatorias();
                    MessageBox.Show("Usuario: " + usuario
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
                formDestino.Show();
            }
        }

    }
}

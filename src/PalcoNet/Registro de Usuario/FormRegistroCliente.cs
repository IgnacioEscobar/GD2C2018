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
        string query;
        bool modif;

        public FormRegistroCliente()
        {
            InitializeComponent();
            this.modif = false;
        }

        public FormRegistroCliente(string query)
        {

            InitializeComponent();
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

        private void cargartexto(SqlDataReader lector, TextBox txtCampo, string campo)
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
                    cargartexto(lector, txtNombre, "nombre");
                    cargartexto(lector, txtApellido, "apellido");
                    cargartexto(lector, txtNumeroDoc, "numero_de_documento");
                    cargartexto(lector, txtMail, "mail");
                    cargartexto(lector, txtCalle, "calle");
                    cargartexto(lector, txtAltura, "numero");
                    cargartexto(lector, txtPiso, "piso");
                    cargartexto(lector, txtDpto, "depto");
                    cargartexto(lector, txtCodPostal, "codigo_postal");
                    cargartexto(lector, txtLocalidad, "localidad");
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
            if (modif)
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

                Form formDestino;

                if (!modif)
                {
                    string usuario = txtCUIL1.Text + txtCUIL2.Text + txtCUIL3.Text;
                    GeneradorDeContrasenasAleatorias generadorDeContrasenas = new GeneradorDeContrasenasAleatorias();
                    MessageBox.Show("Usuario: " + usuario
                        + "\nContraseña: " + generadorDeContrasenas.generar(10)
                        + "\n\n Por favor recuerde la contraseña e inicie sesión para actualizarla.");

                    formDestino = new FormLogin();
                }
                else
                {
                    MessageBox.Show("¡Datos actualizados! (MENTIRA)");
                    formDestino = new FormABMCliente();
                }

                this.Hide();
                formDestino.Show();
            }
        }


    }
}

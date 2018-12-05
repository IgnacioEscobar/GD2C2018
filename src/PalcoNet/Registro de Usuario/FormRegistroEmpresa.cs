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
using PalcoNet.Abm_Empresa_Espectaculo;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class FormRegistroEmpresa : Form
    {
        int userID; // si es registro desde login viene -1
        bool abm; // si viene del ABM
        bool modif; // si viene por modificar o por agregar
        string query;
        string empresaID;
        ValidadorDeDatos validador;

        public FormRegistroEmpresa(bool abm)
        {
            InitializeComponent();
            this.userID = -1;
            this.abm = abm;
            this.modif = false;
            this.query = "";
        }

        public FormRegistroEmpresa(int userID, bool abm)
        {
            InitializeComponent();
            this.userID = userID;
            this.abm = abm;
            this.modif = false;
            this.query = "";
        }

        public FormRegistroEmpresa(int userID, string query)
        {

            InitializeComponent();
            this.userID = userID;
            this.abm = true;
            this.modif = true;
            this.query = query;
        }

        private bool validarCampos()
        {
            // TODO: chequear que campos son obligatorios
            if (!validador.validar_CUIL_CUIT(txtCUIT.Text))
            {
                lblError.Text = "El CUIT es incorrecto";
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Form formDestino;
            if (abm)
            {
                formDestino = new FormABMEmpresa(userID);
            }
            else
            {
                formDestino = new FormLogin();
            }
            this.Hide();
            formDestino.Show();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (this.validarCampos())
            {
                /*
                 * INICIO TRANSACCION
                 */
                GestorDB gestor = new GestorDB();
                gestor.conectar();

                if (!modif)
                {
                    gestor.generarStoredProcedure("crear_empresa");
                }
                else
                {
                    gestor.generarStoredProcedure("actualizar_empresa");
                    gestor.parametroPorValor("id_empresa", empresaID);
                }

                gestor.parametroPorValor("razon_social", txtRazonSocial.Text);
                gestor.parametroPorValor("cuit", txtCUIT.Text);
                gestor.parametroPorValor("calle", txtCalle.Text);
                gestor.parametroPorValor("altura", txtAltura.Text);
                gestor.parametroPorValor("piso", txtPiso.Text);
                gestor.parametroPorValor("depto", txtDepto.Text);
                gestor.parametroPorValor("codigo_postal", txtCodigoPostal.Text);
                gestor.parametroPorValor("localidad", txtLocalidad.Text);
                gestor.parametroPorValor("mail", txtMail.Text);
                gestor.parametroPorValor("telefono", txtTelefono.Text);

                gestor.ejecutarStoredProcedure();
                gestor.desconectar();
                /*
                 * FIN TRANSACCION
                 */

                if (!modif)
                {
                    string usuario = txtCUIT.Text;
                    GeneradorDeContrasenasAleatorias generadorDeContrasenas = new GeneradorDeContrasenasAleatorias();
                    MessageBox.Show("Usuario: " + usuario
                        + "\nContraseña: " + generadorDeContrasenas.generar(10)
                        + "\n\n Por favor recuerde su contraseña e inicie sesión para actualizarla.");
                }
                else
                {
                    MessageBox.Show("¡Datos actualizados!");
                }

                Form formDestino;
                if (abm)
                {
                    formDestino = new FormABMEmpresa(userID);
                }
                else
                {
                    formDestino = new FormLogin();
                }

                this.Hide();
                formDestino.Show();
            }
        }

        private void FormRegistroEmpresa_Load(object sender, EventArgs e)
        {
            if (modif)
            {
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                gestor.consulta(query);
                SqlDataReader lector = gestor.obtenerRegistros();

                if (lector.Read())
                {
                    empresaID = lector["empresa_id"].ToString();
                    cargarTexto(lector, txtRazonSocial, "razon_social");
                    cargarTexto(lector, txtCUIT, "cuit");
                    cargarTexto(lector, txtCalle, "calle");
                    cargarTexto(lector, txtAltura, "numero");
                    cargarTexto(lector, txtPiso, "piso");
                    cargarTexto(lector, txtDepto, "departamento");
                    cargarTexto(lector, txtCodigoPostal, "codigo_postal");
                    cargarTexto(lector, txtLocalidad, "localidad");
                    cargarTexto(lector, txtMail, "mail");
                }
                gestor.desconectar();
            }

            lblError.Visible = false;
            validador = new ValidadorDeDatos();
        }

        private void txtCUIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void txtPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

    }
}

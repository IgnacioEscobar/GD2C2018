using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PalcoNet.funciones_utiles;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class FormRegistroCliente : Form
    {
        string nombre;
        string apellido;
        string documento;

        public FormRegistroCliente()
        {
            InitializeComponent();
            this.nombre = "";
            this.apellido = "";
            this.documento = "";
        }

        public FormRegistroCliente(string nombre, string apellido, string documento)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
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

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                /*
                 * INICIO TRANSACCION
                 */
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                gestor.generarStoredProcedure("crear_cliente");
                gestor.parametroPorValor("nombre", txtNombre.Text);
                gestor.parametroPorValor("apellido", txtApellido.Text);
                // ...TODOS LOS CAMPOS...
                gestor.ejecutarStoredProcedure();
                gestor.desconectar();
                /*
                 * FIN TRANSACCION
                 */

                string usuario = txtCUIL1.Text + txtCUIL2.Text + txtCUIL3.Text;
                GeneradorDeContrasenasAleatorias generadorDeContrasenas = new GeneradorDeContrasenasAleatorias();
                MessageBox.Show("Usuario: " + usuario
                    + "\nContraseña: " + generadorDeContrasenas.generar(10)
                    + "\n\n Por favor recuerde su contraseña e inicie sesión para actualizarla.");

                FormLogin formLogin = new FormLogin(usuario);
                this.Hide();
                formLogin.Show();
            }
        }

        private void FormRegistroCliente_Load(object sender, EventArgs e)
        {
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtNumeroDoc.Text = documento;

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
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void btnAsociarTarjeta_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                MessageBox.Show("Tarjeta de crédito registrada con éxito.");
            }            
        }
    }
}

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
    public partial class FormRegistroEmpresa : Form
    {
        string razonSocial;
        string cuit;
        string mail;

        public FormRegistroEmpresa()
        {
            InitializeComponent();
            this.razonSocial = "";
            this.cuit = "";
            this.mail = "";
        }

        public FormRegistroEmpresa(string razonSocial, string cuit, string mail)
        {
            InitializeComponent();
            this.razonSocial = razonSocial;
            this.cuit = cuit;
            this.mail = mail;
        }

        private bool validarCampos()
        {
            // TODO: chequear que campos son obligatorios
            if (txtCUIT.Text == "")
            {
                lblError.Text = "Complete el CUIT";
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
                gestor.generarStoredProcedure("crear_empresa");
                gestor.parametroPorValor("razon_social", txtRazonSocial.Text);
                gestor.parametroPorValor("cuit", txtCUIT.Text);
                // ...TODOS LOS CAMPOS...
                gestor.ejecutarStoredProcedure();
                gestor.desconectar();
                /*
                 * FIN TRANSACCION
                 */

                string usuario = txtCUIT.Text;
                GeneradorDeContrasenasAleatorias generadorDeContrasenas = new GeneradorDeContrasenasAleatorias();
                MessageBox.Show("Usuario: " + usuario
                    + "\nContraseña: " + generadorDeContrasenas.generar(10)
                    + "\n\n Por favor recuerde su contraseña e inicie sesión para actualizarla.");

                FormLogin formLogin = new FormLogin(usuario);
                this.Hide();
                formLogin.Show();
            }
        }

        private void FormRegistroEmpresa_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            txtRazonSocial.Text = razonSocial;
            txtCUIT.Text = cuit;
            txtMail.Text = mail;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

    }
}

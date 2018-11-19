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
        public FormRegistroEmpresa()
        {
            InitializeComponent();
        }

        private bool validarCampos()
        {
            // TODO: chequear que campos son obligatorios
            if (txtCUIT1.Text == "" || txtCUIT2.Text == "" || txtCUIT3.Text == "")
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
                string usuario = txtCUIT1.Text + txtCUIT2.Text + txtCUIT3.Text;
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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }
    }
}

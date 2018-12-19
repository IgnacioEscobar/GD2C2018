using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PalcoNet.Registro_de_Usuario;
using PalcoNet.funciones_utiles;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class FormTarjetaDeCredito : Form
    {
        string numeroDeTarjeta;
        FormRegistroCliente formRegistroCliente;
        ValidadorDeDatos validador;
        bool registroNuevo;

        public FormTarjetaDeCredito(FormRegistroCliente formRegistroCliente, string numeroDeTarjeta)
        {
            InitializeComponent();
            this.formRegistroCliente = formRegistroCliente;
            this.numeroDeTarjeta = numeroDeTarjeta;
            this.registroNuevo = true;
        }

        public FormTarjetaDeCredito()
        {
            InitializeComponent();
            this.numeroDeTarjeta = "";
            this.registroNuevo = false;
        }

        public string getNumeroDeTarjeta()
        {
            return txtNumeroDeTarjeta.Text;
        }

        private void FormTarjetaDeCredito_Load(object sender, EventArgs e)
        {
            txtNumeroDeTarjeta.Text = numeroDeTarjeta;
            if (this.numeroDeTarjeta == "") txtNumeroDeTarjeta.Select();
            validador = new ValidadorDeDatos();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtNumeroDeTarjeta.Text != "")
            {
                if (registroNuevo)
                {
                    formRegistroCliente.cambioNumeroTarjeta(txtNumeroDeTarjeta.Text);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tarjeta de crédito registrada exitosamente.");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtNumeroTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }
    }
}

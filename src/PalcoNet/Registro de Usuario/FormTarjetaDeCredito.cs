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
        string numeroTarjeta;
        FormRegistroCliente formRegistroCliente;
        ValidadorDeDatos validador;

        public FormTarjetaDeCredito(FormRegistroCliente formRegistroCliente, string numeroTarjeta)
        {
            InitializeComponent();
            this.formRegistroCliente = formRegistroCliente;
            this.numeroTarjeta = numeroTarjeta;
        }

        private void FormTarjetaDeCredito_Load(object sender, EventArgs e)
        {
            txtNumeroTarjeta.Text = numeroTarjeta;
            validador = new ValidadorDeDatos();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            formRegistroCliente.cambioNumeroTarjeta(txtNumeroTarjeta.Text);
            this.Hide();
            MessageBox.Show("Tarjeta de crédito registrada exitosamente.");
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

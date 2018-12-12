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
using System.Globalization;

using PalcoNet.funciones_utiles;
using PalcoNet.Abm_Cliente;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class FormRegistroCliente : Form
    {
        int userID; // user encargado de abm
        int rolID; // rol de user encargado
        bool abm; // si viene del ABM
        bool modif; // si viene por modificar o por agregar
        string query;
        string clienteID;
        FormTarjetaDeCredito formTarjetaDeCredito;
        string numeroTarjeta;
        ValidadorDeDatos validador;

        public FormRegistroCliente()
        {
            InitializeComponent();
            this.abm = false;
            this.modif = false;
            this.numeroTarjeta = "";
        }

        public FormRegistroCliente(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
            this.abm = true;
            this.modif = false;
            this.numeroTarjeta = "";
        }

        public FormRegistroCliente(int userID, int rolID, string query)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
            this.abm = true;
            this.modif = true;
            this.query = query;
        }

        private bool validarCampos()
        {
            List<string[]> lista = new List<string[]>();
            lista.Add(new string[] { txtNombre.Text, "nombre" });
            lista.Add(new string[] { txtApellido.Text, "apellido" });
            string tipoDoc = validador.atraparValorCombo(cmbTipoDoc);
            lista.Add(new string[] { tipoDoc, "tipo de documento" });
            lista.Add(new string[] { txtNumeroDoc.Text, "número de documento" });
            lista.Add(new string[] { txtCUIL.Text, "CUIL" });
            string dia = validador.atraparValorCombo(cmbDia);
            lista.Add(new string[] { dia, "día (fecha de nacimiento)" });
            string mes = validador.atraparValorCombo(cmbMes);
            lista.Add(new string[] { mes, "mes (fecha de nacimiento)" });
            string ano = validador.atraparValorCombo(cmbAno);
            lista.Add(new string[] { ano, "año (fecha de nacimiento)" });
            lista.Add(new string[] { txtCalle.Text, "calle" });
            lista.Add(new string[] { txtAltura.Text, "altura" });
            lista.Add(new string[] { txtCodigoPostal.Text, "código postal" });
            lista.Add(new string[] { txtMail.Text, "mail" });
            lista.Add(new string[] { txtTelefono.Text, "teléfono" });

            string mensaje = "";
            bool retorno = validador.validar_campos_obligatorios(lista, ref mensaje);

            if (txtCUIL.Text.Length > 0 && !validador.validar_CUIL_CUIT(txtCUIL.Text))
            {
                mensaje += "\n\nEl CUIL es incorrecto";
                retorno = false;
            }

            if (!retorno)
            {
                MessageBox.Show(mensaje, "Alerta");
            }

            return retorno;
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
                cmbMes.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToDateTime(lector[campo]).Month);
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
            generador.completarDia(cmbDia);
            generador.completarMes(cmbMes, true);
            generador.completarAno(cmbAno, true);

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
                    cargarFecha(lector, "fecha_nacimiento");
                    cargarTexto(lector, txtCalle, "calle");
                    cargarTexto(lector, txtAltura, "numero");
                    cargarTexto(lector, txtPiso, "piso");
                    cargarTexto(lector, txtDepto, "depto");
                    cargarTexto(lector, txtCodigoPostal, "codigo_postal");
                    cargarTexto(lector, txtLocalidad, "localidad");
                    cargarTexto(lector, txtMail, "mail");
                    cargarTexto(lector, txtTelefono, "telefono");
                    numeroTarjeta = lector["tarjeta_de_credito_asociada"].ToString();
                }
                gestor.desconectar();
            }
            else
            {
                txtNombre.Select();
            }

            formTarjetaDeCredito = new FormTarjetaDeCredito(this, numeroTarjeta);

            validador = new ValidadorDeDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Form formDestino;
            if (abm)
            {
                formDestino = new FormABMCliente(userID, rolID);
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
            if (this.validarCampos())
            {
                formTarjetaDeCredito.Hide();
                formTarjetaDeCredito.Show();
            }            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (this.validarCampos())
            {
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                bool creacion = false;
                string usuario = "";
                string contrasena = "";

                if (!modif)
                {
                    usuario = txtCUIL.Text;
                    GeneradorDeContrasenasAleatorias generadorDeContrasenas = new GeneradorDeContrasenasAleatorias();
                    contrasena = generadorDeContrasenas.generar(4);

                    gestor.generarStoredProcedure("crear_cliente");
                    gestor.parametroPorValor("usuario", usuario);
                    gestor.parametroPorValor("contrasenna", contrasena);
                }
                else
                {
                    gestor.generarStoredProcedure("modificar_cliente");
                    gestor.parametroPorValor("id_cliente", clienteID);
                }

                gestor.parametroPorValor("nombre", txtNombre.Text);
                gestor.parametroPorValor("apellido", txtApellido.Text);
                gestor.parametroPorValor("descripcion_tipo_de_documento", cmbTipoDoc.Text);
                gestor.parametroPorValor("numero_de_documento", txtNumeroDoc.Text);
                gestor.parametroPorValor("cuil", txtCUIL.Text);
                DateTime fecha_nacimiento = DateTime.Parse(cmbAno.Text + "/" + cmbMes.Text + "/" + cmbDia.Text);
                gestor.parametroPorValor("fecha_nacimiento", fecha_nacimiento);
                gestor.parametroPorValor("calle", txtCalle.Text);
                gestor.parametroPorValor("numero", txtAltura.Text);
                gestor.parametroPorValor("piso", txtPiso.Text);
                gestor.parametroPorValor("depto", txtDepto.Text);
                gestor.parametroPorValor("codigo_postal", txtCodigoPostal.Text);
                gestor.parametroPorValor("localidad", txtLocalidad.Text);
                gestor.parametroPorValor("mail", txtMail.Text);
                gestor.parametroPorValor("telefono", txtTelefono.Text);
                gestor.parametroPorValor("tarjeta_de_credito_asociada", numeroTarjeta);
                if (!modif)
                {
                    gestor.parametroPorValor("fecha_creacion", DateTime.Today);
                }

                int resultado = gestor.ejecutarStoredProcedure();
                gestor.desconectar();

                if (resultado == 0)
                {
                    MessageBox.Show("Ya existe un usuario con ese número de CUIL.", "Alerta");
                }
                else
                {
                    if (!modif)
                    {
                        MessageBox.Show("Usuario: " + usuario
                            + "\nContraseña: " + contrasena
                            + "\n\n Por favor recuerde la contraseña e inicie sesión para actualizarla.");

                        creacion = true;
                    }
                    else
                    {
                        MessageBox.Show("¡Datos actualizados!");
                    }

                    Form formDestino;
                    if (abm)
                    {
                        formDestino = new FormABMCliente(userID, rolID);
                    }
                    else if (creacion)
                    {
                        formDestino = new FormLogin(usuario);
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.texto_espacio(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.texto_espacio(e);
        }

        private void txtNumeroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void txtCUIL_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void cmbDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void cmbMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.texto(e);
        }

        private void cmbAno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCodPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.numero(e);
        }

        private void cmbTipoDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.texto(e);
        }

        private void txtDepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.texto(e);
        }

    }
}

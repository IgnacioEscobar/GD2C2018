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

        // Metodos auxiliares

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

        private bool validarRepeticiones()
        {
            GestorDB gestor = new GestorDB();
            string tipo_doc = cmbTipoDoc.Text;
            string nro_doc = txtNumeroDoc.Text;
            string cuil = txtCUIL.Text;

            string query_doc = 
                "SELECT TD.descripcion, C.numero_de_documento " +
                "FROM PEAKY_BLINDERS.clientes C " +
                    "JOIN PEAKY_BLINDERS.tipos_de_documento TD ON C.id_tipo_de_documento = TD.id_tipo_de_documento " +
                "WHERE TD.descripcion = '" + tipo_doc + "' " +
                    "AND C.numero_de_documento = '" + nro_doc + "' ";
            string query_cuil =
                "SELECT cuil " +
                "FROM PEAKY_BLINDERS.clientes " +
                "WHERE cuil = '" + cuil + "' ";

            string mensaje = "Ya existe un cliente con estos datos:";
            bool hubo_repeticion = false; ;

            gestor.conectar();
            if (modif)
            {
                gestor.consulta(query_doc + "AND NOT id_cliente = '" + clienteID + "'");
            }
            else
            {
                gestor.consulta(query_doc);
            }

            if (gestor.obtenerRegistros().Read())
            {
                mensaje += "\n- Tipo y número de documento: " + tipo_doc + " - " + nro_doc;
                hubo_repeticion = true;
            }
            gestor.desconectar();
            gestor.conectar();
            if (modif)
            {
                gestor.consulta(query_cuil + "AND NOT id_cliente = '" + clienteID + "'");
            }
            else
            {
                gestor.consulta(query_cuil);
            }

            if (gestor.obtenerRegistros().Read())
            {
                mensaje += "\n- CUIL: " + cuil;
                hubo_repeticion = true;
            }
            gestor.desconectar();

            if (hubo_repeticion)
            {
                MessageBox.Show(mensaje, "Alerta");
            }

            return !hubo_repeticion;
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

        // -------------------

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

                gestor.conectar();
                gestor.consulta("SELECT PEAKY_BLINDERS.cliente_habilitado(" + clienteID + ") AS esta_habilitado");
                SqlDataReader lector2 = gestor.obtenerRegistros();
                if (lector2.Read())
                {
                    int resultado = Convert.ToInt32(lector2["esta_habilitado"]);

                    if (resultado != -1) // el cliente tiene usuario generado
                    {
                        ckbHabilitado.Visible = true;
                        ckbHabilitado.Checked = Convert.ToBoolean(resultado);
                    }
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
                bool user_autogenerado = true;

                if (this.validarRepeticiones())
                {
                    if (!modif)
                    {
                        if (abm)
                        {
                            FormNombreUsuario formNombreDeUsuario = new FormNombreUsuario();
                            if (formNombreDeUsuario.ShowDialog(this) == DialogResult.OK)
                            {
                                usuario = formNombreDeUsuario.getNombreUsuario();
                                user_autogenerado = false;
                            }
                            formNombreDeUsuario.Dispose();
                        }

                        if (user_autogenerado)
                        
                        {
                            gestor.conectar();
                            gestor.consulta("SELECT ISNULL(MAX(id_usuario), 0) AS id_ultimo FROM PEAKY_BLINDERS.usuarios");
                            SqlDataReader lector = gestor.obtenerRegistros();
                            if (lector.Read())
                            {
                                usuario = "user" + (Convert.ToInt32(lector["id_ultimo"]) + 1);
                            }
                            gestor.desconectar();
                        }

                        GeneradorDeContrasenasAleatorias generadorDeContrasenas = new GeneradorDeContrasenasAleatorias();
                        contrasena = generadorDeContrasenas.generar(4);

                        gestor.conectar();
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
                        gestor.parametroPorValor("fecha_creacion", Config.dateTime);
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
                            if (ckbHabilitado.Visible)
                            {
                                int cambioID = -1;
                                gestor.conectar();
                                gestor.consulta(
                                    "SELECT id_usuario FROM PEAKY_BLINDERS.clientes WHERE id_cliente = '" + clienteID + "'");
                                SqlDataReader lector = gestor.obtenerRegistros();
                                if (lector.Read())
                                {
                                    cambioID = Convert.ToInt32(lector["id_usuario"]);
                                }
                                gestor.desconectar();

                                gestor.conectar();
                                gestor.generarStoredProcedure("actualizar_estado_usuario");
                                gestor.parametroPorValor("id_usuario", cambioID);
                                gestor.parametroPorValor("habilitado", Convert.ToInt32(ckbHabilitado.Checked));
                                gestor.ejecutarStoredProcedure();
                                gestor.desconectar();
                            }

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

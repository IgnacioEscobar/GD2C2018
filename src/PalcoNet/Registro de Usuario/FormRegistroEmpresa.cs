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
using PalcoNet.Registro_de_Usuario;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class FormRegistroEmpresa : Form
    {
        int userID; // user encargado de abm
        int rolID; // rol de user encargado
        bool abm; // si viene del ABM
        bool modif; // si viene por modificar o por agregar
        string query;
        string empresaID;
        ValidadorDeDatos validador;

        public FormRegistroEmpresa()
        {
            InitializeComponent();
            this.abm = false;
            this.modif = false;
        }

        public FormRegistroEmpresa(int userID, int rolID)
        {
            InitializeComponent();
            this.userID = userID;
            this.rolID = rolID;
            this.abm = true;
            this.modif = false;
        }

        public FormRegistroEmpresa(int userID, int rolID, string query)
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
            lista.Add(new string[] { txtRazonSocial.Text, "razon social" });
            lista.Add(new string[] { txtCUIT.Text, "CUIT" });
            lista.Add(new string[] { txtCalle.Text, "calle" });
            lista.Add(new string[] { txtAltura.Text, "altura" });
            lista.Add(new string[] { txtCodigoPostal.Text, "código postal" });
            lista.Add(new string[] { txtMail.Text, "mail" });
            lista.Add(new string[] { txtTelefono.Text, "teléfono" });

            string mensaje = "";
            bool retorno = validador.validar_campos_obligatorios(lista, ref mensaje);

            if (txtCUIT.Text.Length > 0 && !validador.validar_CUIL_CUIT(txtCUIT.Text))
            {
                mensaje += "\n\nEl CUIT es incorrecto";
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
            string razon_social = txtRazonSocial.Text;
            string cuit = txtCUIT.Text;

            string query_razon_social =
                "SELECT razon_social " +
                "FROM PEAKY_BLINDERS.empresas " +
                "WHERE razon_social = '" + razon_social + "' ";
            string query_cuit =
                "SELECT cuit " +
                "FROM PEAKY_BLINDERS.empresas " +
                "WHERE cuit = '" + cuit + "' ";

            string mensaje = "Ya existe una empresa con estos datos:";
            bool hubo_repeticion = false; ;

            gestor.conectar();
            if (modif)
            {
                gestor.consulta(query_razon_social + "AND NOT id_empresa = '" + empresaID + "'");
            }
            else
            {
                gestor.consulta(query_razon_social);
            }

            if (gestor.obtenerRegistros().Read())
            {
                mensaje += "\n- Razón social: " + razon_social;
                hubo_repeticion = true;
            }
            gestor.desconectar();
            gestor.conectar();
            if (modif)
            {
                gestor.consulta(query_cuit + "AND NOT id_empresa = '" + empresaID + "'");
            }
            else
            {
                gestor.consulta(query_cuit);
            }

            if (gestor.obtenerRegistros().Read())
            {
                mensaje += "\n- CUIT: " + cuit;
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

        // -------------------

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Form formDestino;
            if (abm)
            {
                formDestino = new FormABMEmpresa(userID, rolID);
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
                        gestor.generarStoredProcedure("crear_empresa");
                        gestor.parametroPorValor("usuario", usuario);
                        gestor.parametroPorValor("contrasenna", contrasena);
                    }
                    else
                    {
                        gestor.generarStoredProcedure("modificar_empresa");
                        gestor.parametroPorValor("id_empresa", empresaID);
                    }

                    gestor.parametroPorValor("razon_social", txtRazonSocial.Text);
                    gestor.parametroPorValor("cuit", txtCUIT.Text);
                    gestor.parametroPorValor("calle", txtCalle.Text);
                    gestor.parametroPorValor("numero", txtAltura.Text);
                    gestor.parametroPorValor("piso", txtPiso.Text);
                    gestor.parametroPorValor("depto", txtDepto.Text);
                    gestor.parametroPorValor("codigo_postal", txtCodigoPostal.Text);
                    gestor.parametroPorValor("localidad", txtLocalidad.Text);
                    gestor.parametroPorValor("mail", txtMail.Text);
                    gestor.parametroPorValor("telefono", txtTelefono.Text);

                    int resultado = gestor.ejecutarStoredProcedure();
                    gestor.desconectar();

                    if (resultado == 0)
                    {
                        MessageBox.Show("Ya existe un usuario con ese número de CUIT.", "Alerta");
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
                                    "SELECT id_usuario FROM PEAKY_BLINDERS.empresas WHERE id_empresa = '" + empresaID + "'");
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
                            formDestino = new FormABMEmpresa(userID, rolID);
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
                        formDestino.Show();
                    }
                }
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
                    empresaID = lector["id_empresa"].ToString();
                    cargarTexto(lector, txtRazonSocial, "razon_social");
                    cargarTexto(lector, txtCUIT, "cuit");
                    cargarTexto(lector, txtCalle, "calle");
                    cargarTexto(lector, txtAltura, "numero");
                    cargarTexto(lector, txtPiso, "piso");
                    cargarTexto(lector, txtDepto, "depto");
                    cargarTexto(lector, txtCodigoPostal, "codigo_postal");
                    cargarTexto(lector, txtLocalidad, "localidad");
                    cargarTexto(lector, txtMail, "mail");
                    cargarTexto(lector, txtTelefono, "telefono");
                }
                gestor.desconectar();

                gestor.conectar();
                gestor.consulta("SELECT PEAKY_BLINDERS.empresa_habilitada(" + empresaID + ") AS esta_habilitada");
                SqlDataReader lector2 = gestor.obtenerRegistros();
                if (lector2.Read())
                {
                    int resultado = Convert.ToInt32(lector2["esta_habilitada"]);

                    if (resultado != -1) // la empresa tiene usuario generado
                    {
                        ckbHabilitado.Visible = true;
                        ckbHabilitado.Checked = Convert.ToBoolean(resultado);
                    }
                }
                gestor.desconectar();
            }
            else
            {
                txtRazonSocial.Select();
            }

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

        private void txtDepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validador.texto(e);
        }

    }
}

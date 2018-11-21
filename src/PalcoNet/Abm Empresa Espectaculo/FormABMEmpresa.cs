﻿using System;
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
using PalcoNet.Registro_de_Usuario;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class FormABMEmpresa : Form
    {
        string query_defecto = "SELECT razon_social, cuit, mail FROM dbo.empresas";

        public FormABMEmpresa()
        {
            InitializeComponent();
        }

        // Metodos auxiliares

        private void mostrarRegistros(SqlDataReader lector)
        {
            while (lector.Read())
            {
                object[] row = new string[]
                {
                    lector["razon_social"].ToString(),
                    lector["cuit"].ToString(),
                    lector["mail"].ToString(),
                };
                dgvEmpresas.Rows.Add(row);
            }
        }

        // -------------------

        private void FormABMEmpresa_Load(object sender, EventArgs e)
        {
            dgvEmpresas.ColumnCount = 3;
            dgvEmpresas.ColumnHeadersVisible = true;
            dgvEmpresas.Columns[0].Name = "RAZON SOCIAL";
            dgvEmpresas.Columns[1].Name = "CUIT";
            dgvEmpresas.Columns[2].Name = "MAIL";

            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta(query_defecto);
            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtRazonSocial.Text = "";
            txtCUIT.Text = "";
            txtMail.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string razonSocial = txtRazonSocial.Text;
            string cuit = txtCUIT.Text;
            string mail = txtMail.Text;

            List<object[]> listaCampos = new List<object[]>();

            if (razonSocial != "")
            {
                object[] tuplaRazonSocial = { "razon_social", razonSocial, false };
                listaCampos.Add(tuplaRazonSocial);
            }
            if (cuit != "")
            {
                object[] tuplaCUIT = { "cuit", cuit, true };
                listaCampos.Add(tuplaCUIT);
            }
            if (mail != "")
            {
                object[] tuplaMail = { "mail", mail, false };
                listaCampos.Add(tuplaMail);
            }

            int cant_filtros = listaCampos.Count();
            if (cant_filtros > 0) dgvEmpresas.Rows.Clear();

            string filtro = "";
            for (int i = 0; i < cant_filtros; i++)
            {
                object[] tuplaCampos = listaCampos[i];
                string comparacion, cierre;
                if (Convert.ToBoolean(tuplaCampos[2])) // busqueda exacta
                {
                    comparacion = " = '";
                    cierre = "'";
                }
                else // busqueda aproximada
                {
                    comparacion = " LIKE '%";
                    cierre = "%'";
                }
                filtro += tuplaCampos[0] + comparacion + tuplaCampos[1] + cierre;
                if (i != listaCampos.Count() - 1) filtro += " AND ";
            }

            GestorDB gestor = new GestorDB();
            gestor.conectar();

            string query = query_defecto;
            if (cant_filtros > 0) query += " WHERE " + filtro;
            gestor.consulta(query);

            this.mostrarRegistros(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormRegistroEmpresa formRegistroEmpresa = new FormRegistroEmpresa();
            this.Hide();
            formRegistroEmpresa.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string[] param = new string[3];
            int i = 0;
            foreach (DataGridViewCell item in dgvEmpresas.CurrentRow.Cells)
            {
                param[i] = item.Value.ToString();
                i++;
            }

            FormRegistroEmpresa formRegistroEmpresa = new FormRegistroEmpresa(param[0], param[1], param[2]);
            this.Hide();
            formRegistroEmpresa.Show();
        }

    }
}

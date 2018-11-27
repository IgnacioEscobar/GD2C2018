using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Data.SqlClient;

using PalcoNet.funciones_utiles;

namespace PalcoNet.Abm_Rol
{
    public partial class FormABMRol : Form
    {
        public FormABMRol()
        {
            InitializeComponent();
        }

        private void mostrarRoles(SqlDataReader lector)
        {
            while (lector.Read())
            {
                lsbRoles.Items.Add(lector["descripcion"].ToString());
            }
        }

        private void mostrarFuncionalidades(SqlDataReader lector)
        {
            while (lector.Read())
            {
                clbFuncionalidades.Items.Add(lector["descripcion"].ToString());
            }
        }

        private void tildarFuncionalidadesActivas(SqlDataReader lector)
        {
            while (lector.Read())
            {
                for (int i = 0; i < clbFuncionalidades.Items.Count; i++)
                {
                    if (clbFuncionalidades.Items[i].ToString() == lector["descripcion"].ToString())
                    {
                        clbFuncionalidades.SetItemChecked(i, true);
                    }
                }
                
            }
        }

        private void mostrarRolHabilitado(SqlDataReader lector)
        {
            if (lector.Read())
            {
                ckbActivo.Checked = Convert.ToBoolean(lector["habilitado"]);
            }
        }

        private void FormABMRol_Load(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            gestor.consulta("SELECT descripcion FROM roles");
            this.mostrarRoles(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            GestorDB gestor = new GestorDB();
            gestor.conectar();
            string query1 = "SELECT habilitado FROM PEAKY_BLINDERS.roles WHERE descripcion = '" + lsbRoles.SelectedItem.ToString() + "'";
            gestor.consulta(query1);
            this.mostrarRolHabilitado(gestor.obtenerRegistros());
            gestor.desconectar();
            gestor.conectar();
            string query2 = "SELECT descripcion FROM PEAKY_BLINDERS.funcionalidades";
            gestor.consulta(query2);
            this.mostrarFuncionalidades(gestor.obtenerRegistros());
            gestor.desconectar();
            gestor.conectar();
            string query3 = "SELECT F.descripcion FROM PEAKY_BLINDERS.roles R "
                            + "JOIN PEAKY_BLINDERS.funcionalidades_por_rol FR ON R.id_rol = FR.id_rol "
                            + "JOIN PEAKY_BLINDERS.funcionalidades F ON FR.id_funcionalidad = F.id_funcionalidad "
                            + "WHERE R.descripcion = '" + lsbRoles.SelectedItem.ToString() + "'";
            gestor.consulta(query3);
            this.tildarFuncionalidadesActivas(gestor.obtenerRegistros());
            gestor.desconectar();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
        }

        private void clbFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }
}

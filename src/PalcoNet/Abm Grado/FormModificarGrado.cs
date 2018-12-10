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

namespace PalcoNet.Abm_Grado
{
    public partial class FormModificarGrado : Form
    {
        FormABMGrado formABMGrado;
        int publicacionID;
        string grado_actual;

        public FormModificarGrado(FormABMGrado formABMGrado, int publicacionID, string grado_actual)
        {
            InitializeComponent();
            this.formABMGrado = formABMGrado;
            this.publicacionID = publicacionID;
            this.grado_actual = grado_actual;
        }

        private void FormModificarGrado_Load(object sender, EventArgs e)
        {
            switch (grado_actual)
            {
                case "ALTO":
                    rdbAlto.Checked = true;
                    break;
                case "MEDIO":
                    rdbMedio.Checked = true;
                    break;
                case "BAJO":
                    rdbBajo.Checked = true;
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string grado_seleccionado = "";
            if (rdbAlto.Checked) grado_seleccionado = rdbAlto.Text;
            if (rdbMedio.Checked) grado_seleccionado = rdbMedio.Text;
            if (rdbBajo.Checked) grado_seleccionado = rdbBajo.Text;

            if (grado_seleccionado != grado_actual)
            {
                GestorDB gestor = new GestorDB();
                gestor.conectar();
                gestor.generarStoredProcedure("actualizar_grado");
                gestor.parametroPorValor("id_publicacion", publicacionID);
                gestor.parametroPorValor("descripcion_grado", grado_seleccionado);
                gestor.ejecutarStoredProcedure();
                gestor.desconectar();

                formABMGrado.actualizar();
            }
            this.Hide();
        }

    }
}

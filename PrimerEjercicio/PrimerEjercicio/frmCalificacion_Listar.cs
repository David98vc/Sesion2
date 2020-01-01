using Semana_Dos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semana_dos
{
    public partial class frmCalificacion_Listar : Form
    {
        public frmCalificacion_Listar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstvDatos.Items.Clear();
            int contador = 0;
            foreach (Cliente elemento in Cliente.Listar())
            {
                lstvDatos.Items.Add(Convert.ToString(contador+1));
                lstvDatos.Items[contador].SubItems.Add(elemento.Codigo);
                lstvDatos.Items[contador].SubItems.Add(elemento.Nombre);
                lstvDatos.Items[contador].SubItems.Add(elemento.Apellidos);
                lstvDatos.Items[contador].SubItems.Add(elemento.Descripcion);
                lstvDatos.Items[contador].SubItems.Add(Convert.ToString(elemento.FechaHoraRegistro));
                contador += 1;
            }
            


        }
    }
}

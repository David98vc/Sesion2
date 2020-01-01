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
    public partial class frmCalificacion_Insertar : Form
    {
        public frmCalificacion_Insertar()
        {
            InitializeComponent();
        }

        private void frmCalificacion_Insertar_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Guardar los datos del cliente
                Cliente nuevo;
                nuevo = new Cliente(txtCodigo.Text,
                                    txtNombre.Text,
                                    txtApellido.Text,
                                    txtDescripcion.Text,
                                   DateTime.Now);

                if (
                        MessageBox.Show("¿Desea registrar la calificacion?",
                                "Atención", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) ==
                                System.Windows.Forms.DialogResult.Yes
                   )
                {
                    nuevo.Insertar();
                }
                else
                {
                    //Cortar el programa
                    //VB .NEt => Exit Sub
                    return;
                }
                MessageBox.Show("Calificacion registrado.");       
            }
            catch (Exception elERROR)
            {
                MessageBox.Show(elERROR.Message,
                                "Aviso del sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);                   
            }
            
            
            
                
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAG___Diploma.Vista
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }



        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGestionarClientes_Click(object sender, EventArgs e)
        {
            FormGestionarClientes vistaClientes = new FormGestionarClientes();
            vistaClientes.ShowDialog();

        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            panelApp.Visible = true;
        }

        private void btnGestionarRutinas_Click(object sender, EventArgs e)
        {
            FormGestionarRutinas vistaRutinas = new FormGestionarRutinas();
            vistaRutinas.ShowDialog();
        }

        private void btnGestionarPlanes_Click(object sender, EventArgs e)
        {
            FormGestionarPlanes vistaPlanes = new FormGestionarPlanes();
            vistaPlanes.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}

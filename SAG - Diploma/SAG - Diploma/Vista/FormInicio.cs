
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

        //metodo para poner los forms en el panel

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelForm.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la coleccion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelForm.Controls.Add(formulario);
                panelForm.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
                formulario.BringToFront();
                lblTitulo.Text= formulario.Text;
        }

        private void btnGestionarClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormGestionarClientes>();
            btnGestionarClientes.BackColor = Color.FromArgb(12, 61, 92);
            btnGestionarRutinas.BackColor = Color.Black;
            btnGestionarPlanes.BackColor = Color.Black;
            btnGestionarClases.BackColor = Color.Black;
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            panelForm.Visible = true;
        }

        private void btnGestionarRutinas_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormGestionarRutinas>();
            
            btnGestionarRutinas.BackColor = Color.FromArgb(12, 61, 92);
            btnGestionarClientes.BackColor = Color.Black;
            btnGestionarPlanes.BackColor = Color.Black;
            btnGestionarClases.BackColor = Color.Black;
        }

        private void btnGestionarPlanes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormGestionarPlanes>();

            btnGestionarClientes.BackColor = Color.Black;
            btnGestionarRutinas.BackColor = Color.Black;
            btnGestionarPlanes.BackColor = Color.FromArgb(12, 61, 92);
            btnGestionarClases.BackColor = Color.Black;

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnGestionarClases_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormGestionarClases>();

            btnGestionarClientes.BackColor = Color.Black;
            btnGestionarRutinas.BackColor = Color.Black;
            btnGestionarPlanes.BackColor = Color.Black;
            btnGestionarClases.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }
    }
}

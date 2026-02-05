
using Controlador;
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

        #region métodos para poner los forms en el panel

        public void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelForm.Controls.OfType<MiForm>().FirstOrDefault();
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
            lblTitulo.Text = formulario.Text;
        }

        public void AbrirFormularioPanel(Form formularioHijo)
        {
            if (panelForm.Controls.Count > 0)
            {
                panelForm.Controls.RemoveAt(0);
            }

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            panelForm.Controls.Add(formularioHijo);
            panelForm.Tag = formularioHijo;

            formularioHijo.Show();
            formularioHijo.BringToFront();

            lblTitulo.Text = formularioHijo.Text;
        }

        #endregion


        private bool ValidarPermiso(string nombreAccion)
        {

            if (CtrlGestionarSesiones.Sesion.NombreRol == "Administrador" ||
                CtrlGestionarSesiones.Sesion.NombreRol == "Admin")
            {
                return true;
            }

            if (CtrlGestionarSesiones.Sesion.TienePermiso(nombreAccion))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a esta función.",
                                "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
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
            if(ValidarPermiso("Abrir Gestionar Rutinas"))
            {
                AbrirFormulario<FormGestionarRutinas>();

                btnGestionarRutinas.BackColor = Color.FromArgb(12, 61, 92);
                btnGestionarClientes.BackColor = Color.Black;
                btnGestionarPlanes.BackColor = Color.Black;
                btnGestionarClases.BackColor = Color.Black;
            }
        }

        private void btnGestionarPlanes_Click(object sender, EventArgs e)
        {
            if (ValidarPermiso("Abrir Gestionar Planes"))
            {
                AbrirFormulario<FormGestionarPlanes>();

                btnGestionarClientes.BackColor = Color.Black;
                btnGestionarRutinas.BackColor = Color.Black;
                btnGestionarPlanes.BackColor = Color.FromArgb(12, 61, 92);
                btnGestionarClases.BackColor = Color.Black;
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnGestionarClases_Click(object sender, EventArgs e)
        {
            if (ValidarPermiso("Abrir Gestionar Clases"))
            {
                AbrirFormulario<FormGestionarClases>();

                btnGestionarClientes.BackColor = Color.Black;
                btnGestionarRutinas.BackColor = Color.Black;
                btnGestionarPlanes.BackColor = Color.Black;
                btnGestionarClases.BackColor = Color.FromArgb(12, 61, 92);
            }
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            if (ValidarPermiso("Abrir Gestionar Grupos"))
            {
                AbrirFormulario<FormGestionarGrupos>();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (ValidarPermiso("Abrir Gestionar Usuarios"))
            {
                AbrirFormulario<FormGestionarUsuarios>();

                // Manejo visual de botones (resaltar el activo)
                btnUsuarios.BackColor = Color.FromArgb(12, 61, 92);
                // ... poner los otros en negro ...
            }
        }
    }
}

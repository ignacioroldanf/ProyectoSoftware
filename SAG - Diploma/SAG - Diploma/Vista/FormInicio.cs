using Controlador;
using Modelo; // Para acceder a Sesion
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SAG___Diploma.Vista
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            // 1. Ocultar botones según permisos al cargar
            AplicarSeguridad();
            panelForm.Visible = true;
        }

        private void AplicarSeguridad()
        {

            btnGestionarClientes.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarClientes");
            btnGestionarPlanes.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarPlanes");
            btnGestionarClases.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarClases");
            btnGestionarRutinas.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarRutinas");
            btnUsuarios.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarUsuarios");
            btnGrupos.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarGrupos");
        }

        #region Clicks dependientes de los permisos

        private void btnGestionarClientes_Click(object sender, EventArgs e)
        {
            if (Sesion.Instancia.PuedeAccederFormulario("FormGestionarClientes"))
            {
                AbrirFormulario<FormGestionarClientes>();
                ResaltarBoton(btnGestionarClientes);
            }
        }

        private void btnGestionarRutinas_Click(object sender, EventArgs e)
        {
            if (Sesion.Instancia.PuedeAccederFormulario("FormGestionarRutinas"))
            {
                AbrirFormulario<FormGestionarRutinas>();
                ResaltarBoton(btnGestionarRutinas);
            }
        }

        private void btnGestionarPlanes_Click(object sender, EventArgs e)
        {
            if (Sesion.Instancia.PuedeAccederFormulario("FormGestionarPlanes"))
            {
                AbrirFormulario<FormGestionarPlanes>();
                ResaltarBoton(btnGestionarPlanes);
            }
        }

        private void btnGestionarClases_Click(object sender, EventArgs e)
        {
            if (Sesion.Instancia.PuedeAccederFormulario("FormGestionarClases"))
            {
                AbrirFormulario<FormGestionarClases>();
                ResaltarBoton(btnGestionarClases);
            }
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            if (Sesion.Instancia.PuedeAccederFormulario("FormGestionarGrupos"))
            {
                AbrirFormulario<FormGestionarGrupos>();
                ResaltarBoton(btnGrupos);
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (Sesion.Instancia.PuedeAccederFormulario("FormGestionarUsuarios"))
            {
                AbrirFormulario<FormGestionarUsuarios>();
                ResaltarBoton(btnUsuarios);
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (Sesion.Instancia.PuedeAccederFormulario("FormGestionarReportes"))
            {
                AbrirFormulario<FormGestionarReportes>();
                ResaltarBoton(btnReportes);
            }
        }

        #endregion

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Sesion.Instancia.Logout();
            this.Close();
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            // Lógica para volver al home si tienes un dashboard
        }

        #region Métodos Auxiliares y Diseño

        // Método centralizado para manejar colores (más prolijo)
        private void ResaltarBoton(Button botonActivo)
        {
            btnGestionarClientes.BackColor = Color.Black;
            btnGestionarRutinas.BackColor = Color.Black;
            btnGestionarPlanes.BackColor = Color.Black;
            btnGestionarClases.BackColor = Color.Black;
            btnGrupos.BackColor = Color.Black;
            btnUsuarios.BackColor = Color.Black;

            if (botonActivo != null)
            {
                botonActivo.BackColor = Color.FromArgb(12, 61, 92);
            }
        }

        public void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario = panelForm.Controls.OfType<MiForm>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelForm.Controls.Add(formulario);
                panelForm.Tag = formulario;
                formulario.Show();
            }
            formulario.BringToFront();

            if (lblTitulo != null) lblTitulo.Text = formulario.Text;
        }

        public void AbrirFormularioPanel(Form formularioHijo)
        {
            if (panelForm.Controls.Count > 0)
                panelForm.Controls.RemoveAt(0);

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panelForm.Controls.Add(formularioHijo);
            panelForm.Tag = formularioHijo;
            formularioHijo.Show();
            formularioHijo.BringToFront();

            if (lblTitulo != null) lblTitulo.Text = formularioHijo.Text;
        }

        #endregion



    }
}
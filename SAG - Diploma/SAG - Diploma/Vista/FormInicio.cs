using Controlador;
using Modelo; // Para acceder a Sesion
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SAG___Diploma.Vista.Theme;

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

            // Aplicar tema futurista
            FuturisticTheme.ApplyToForm(this);

            // Asegurar que el título empiece en blanco al iniciar sesión
            if (lblTitulo != null) lblTitulo.ForeColor = Color.White;

            // Mostrar el FormHome dentro del panel y pasar saludo
            AbrirFormulario<FormHome>();
            var homeOnLoad = panelForm.Controls.OfType<FormHome>().FirstOrDefault();
            if (homeOnLoad != null)
                homeOnLoad.SetWelcomeText($"Bienvenido, {GetNombreUsuarioParaSaludo()}");
            ResaltarBoton(btnInicio);
        }

        private void AplicarSeguridad()
        {

            btnGestionarClientes.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarClientes");
            btnGestionarPlanes.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarPlanes");
            btnGestionarClases.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarClases");
            btnGestionarRutinas.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarRutinas");
            btnUsuarios.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarUsuarios");
            btnGrupos.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarGrupos");
            btnGestionarClases.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarClases");
            btnReportes.Visible = Sesion.Instancia.PuedeAccederFormulario("FormGestionarReportes");
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
            try
            {
                Sesion.Instancia.Logout();
            }
            catch { }

            // Intentar mostrar el formulario de login existente antes de cerrar el main
            try
            {
                var login = Application.OpenForms.OfType<FormInicioSesion>().FirstOrDefault();
                if (login != null)
                {
                    // Limpiar credenciales y mostrar
                    login.Invoke((Action)(() => {
                        login.ClearCredentials();
                        login.Show();
                        login.BringToFront();
                    }));
                }
                else
                {
                    // Si no existe, crear uno nuevo
                    var nuevo = new FormInicioSesion();
                    nuevo.Show();
                }
            }
            catch { }

            // Cerrar el formulario principal
            this.Close();
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormHome>();
            ResaltarBoton(btnInicio);
        }

        private string GetNombreUsuarioParaSaludo()
        {
            try
            {
                var usuario = Sesion.Instancia.UsuarioActual;
                if (usuario != null)
                {
                    var persona = usuario.IdPersonaNavigation;
                    if (persona != null)
                    {
                        var nom = string.IsNullOrWhiteSpace(persona.Nombre) ? usuario.NombreUsuario : persona.Nombre;
                        var ape = string.IsNullOrWhiteSpace(persona.Apellido) ? string.Empty : " " + persona.Apellido;
                        return (nom + ape).Trim();
                    }

                    return usuario.NombreUsuario ?? "Usuario";
                }

                return "Usuario";
            }
            catch
            {
                return "Usuario";
            }
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
                botonActivo.BackColor = FuturisticTheme.Accent;
                botonActivo.ForeColor = Color.Black;
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
            if (lblTitulo != null) { lblTitulo.Text = formulario.Text; lblTitulo.ForeColor = Color.White; }
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
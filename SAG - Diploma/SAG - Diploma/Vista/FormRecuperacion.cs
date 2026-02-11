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
    public partial class FormRecuperacion : Form
    {
        private CtrlGestionarSesiones _controlador;
        private bool _verClave = false;
        public FormRecuperacion()
        {
            InitializeComponent();
            _controlador = new CtrlGestionarSesiones();

            txtNuevaClave.UseSystemPasswordChar = true;
            txtConfirmar.UseSystemPasswordChar = true;

            gbClave.Enabled = false;
        }
        private void btnVerificarToken_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtToken.Text))
            {
                MessageBox.Show("Por favor, ingrese el código recibido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _controlador.ValidarToken(txtToken.Text.Trim());

                MessageBox.Show("Código correcto. Ingrese su nueva contraseña.", "Validado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtToken.Enabled = false;
                btnVerificarToken.Enabled = false;

                gbClave.Enabled = true;

                txtNuevaClave.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Código", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtToken.SelectAll();
                txtToken.Focus();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtToken.Text) ||
                string.IsNullOrWhiteSpace(txtNuevaClave.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmar.Text))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Llamamos al método que creamos hoy en el controlador
                _controlador.RestablecerContrasena(txtToken.Text.Trim(), txtNuevaClave.Text, txtConfirmar.Text);

                MessageBox.Show("¡Contraseña restablecida con éxito!\nAhora puedes iniciar sesión con tu nueva clave.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); // Cerramos esta ventana para volver al Login
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cambiar clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerClave_Click(object sender, EventArgs e)
        {
            _verClave = !_verClave; 

            if (_verClave)
            {
                txtNuevaClave.UseSystemPasswordChar = false;
                txtConfirmar.UseSystemPasswordChar = false;
                btnVerClave.Text = "Ocultar"; 
            }
            else
            {
                txtNuevaClave.UseSystemPasswordChar = true;
                txtConfirmar.UseSystemPasswordChar = true;
                btnVerClave.Text = "Ver";
            }
        }
    }
}

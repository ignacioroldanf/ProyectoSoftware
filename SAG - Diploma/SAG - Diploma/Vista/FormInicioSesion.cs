using Controlador;
using Modelo.Modelo;
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
    public partial class FormInicioSesion : Form
    {
        private CtrlGestionarSesiones _controlador;
        public FormInicioSesion()
        {
            InitializeComponent();
            _controlador = new CtrlGestionarSesiones();
        }

        // Método público para limpiar los campos de usuario/contraseña desde otro formulario
        public void LimpiarCredenciales()
        {
            try
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;

                txtContra.Text = "CONTRASEÑA";
                txtContra.ForeColor = Color.DimGray;
                txtContra.UseSystemPasswordChar = false;

                this.ActiveControl = null;
            }
            catch { }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO" || txtContra.Text == "CONTRASEÑA")
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.");
                return;
            }

            try
            {

                var usuario = _controlador.IniciarSesion(txtUsuario.Text, txtContra.Text);

                if (usuario != null)
                {
                    FormInicio frmInicio = new FormInicio();

                    this.Hide();

                    // Cuando el formulario principal se cierre, mostrar nuevamente el login para permitir reingresar
                    frmInicio.FormClosed += (s, args) =>
                    {
                        // Limpiar credenciales cuando se muestre el formulario de login nuevamente
                        this.LimpiarCredenciales();
                        this.Show();
                    };

                    frmInicio.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Text = "USUARIO";
                    txtContra.Text = "CONTRASEÑA";
                    txtContra.UseSystemPasswordChar = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray; 
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            if (txtContra.Text == "CONTRASEÑA")
            {
                txtContra.Text = "";
                txtContra.ForeColor = Color.LightGray;
                txtContra.UseSystemPasswordChar = true;
            }
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (txtContra.Text == "")
            {
                txtContra.Text = "CONTRASEÑA";
                txtContra.ForeColor = Color.DimGray;
                txtContra.UseSystemPasswordChar = false;
            }
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LabelContra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string emailIngresado = MostrarDialogoInput("Recuperación de Cuenta", "Por favor, ingresa tu email asociado:");

            if (string.IsNullOrWhiteSpace(emailIngresado)) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _controlador.SolicitarRecuperacion(emailIngresado);

                Cursor.Current = Cursors.Default;

                MessageBox.Show("Se ha enviado un código de recuperación a tu correo electrónico.\n\nRevisa tu bandeja de entrada (y spam).",
                                "Correo Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormRecuperacion frmRecuperacion = new FormRecuperacion();
                frmRecuperacion.ShowDialog();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string MostrarDialogoInput(string titulo, string texto)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = titulo,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = texto, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button confirmation = new Button() { Text = "Enviar", Left = 250, Width = 100, Top = 90, DialogResult = DialogResult.OK };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
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

                    frmInicio.FormClosed += (s, args) => this.Close();

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
            MessageBox.Show("Funcionalidad de recuperación de contraseña.\nEl sistema enviará una nueva clave a su email registrado.", "Recuperar Clave");
        }
    }
}
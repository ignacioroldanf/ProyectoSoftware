using Controlador; 
using System;
using System.Windows.Forms;

namespace SAG___Diploma.Vista
{
    public partial class FormContra : Form
    {
        // Propiedad pública: Así el formulario padre (Usuario) puede leer lo que quedó en el txt
        public string ClaveFinal
        {
            get { return txtContra.Text; }
        }

        // Constructor que recibe la clave sugerida (la aleatoria)
        public FormContra(string claveSugerida)
        {
            InitializeComponent();

            txtContra.Text = claveSugerida;

            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Confirmar Contraseña";
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtContra.Text);
            MessageBox.Show("Contraseña copiada al portapapeles.");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (!Seguridad.ValidarClave(txtContra.Text))
            {
                MessageBox.Show("La clave no es segura.\nDebe tener:\n- 8 caracteres\n- Mayúscula y Minúscula\n- Número\n- Símbolo", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
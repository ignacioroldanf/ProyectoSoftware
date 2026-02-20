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
    public partial class FormDetalleClase : Form
    {
        private CtrlGestionarClases _controlador;
        public Clase ClaseCreada { get; private set; }
        public FormDetalleClase()
        {
            InitializeComponent();
            _controlador = new CtrlGestionarClases(new DiplomaContext());
        }

        private void FormDetalleClase_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarProfesores();

        }

        private void ConfigurarControles()
        {
            nudCupo.Minimum = 1;
            nudCupo.Maximum = 100;
            nudCupo.Value = 20;
        }

        private void CargarProfesores()
        {
            try
            {
                var listaProfes = _controlador.ListarProfesores();

                var comboSource = listaProfes.Select(p => new
                {
                    Id = p.IdProfesor,
                    NombreCompleto = p.IdPersonaNavigation.Nombre + " " + p.IdPersonaNavigation.Apellido
                }).ToList();

                cmbProfesor.DisplayMember = "NombreCompleto";
                cmbProfesor.ValueMember = "Id";
                cmbProfesor.DataSource = comboSource;
                cmbProfesor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar profesores: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la clase es obligatorio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbProfesor.SelectedIndex == -1)
            {
                MessageBox.Show("Debe asignar un profesor a la clase.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClaseCreada = new Clase
            {
                NombreClase = txtNombre.Text.Trim(),
                DescripcionClase = txtDescripcion.Text.Trim(),
                CupoMaximo = (int)nudCupo.Value,
                IdProfesor = (int)cmbProfesor.SelectedValue
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

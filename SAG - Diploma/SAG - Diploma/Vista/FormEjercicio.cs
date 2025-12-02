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
    public partial class FormEjercicio : Form
    {
        private readonly CtrlGestionarRutinasyProgresos _controlador;
        private readonly int _idDiaRutina;
        private readonly EjerciciosAsignado? _ejercicioEditando;

        public FormEjercicio(CtrlGestionarRutinasyProgresos controlador, int idDiaRutina)
        {
            InitializeComponent();
            _controlador = controlador;
            _idDiaRutina = idDiaRutina;
            _ejercicioEditando = null;
        }

        public FormEjercicio(CtrlGestionarRutinasyProgresos controlador, EjerciciosAsignado ejercicioExistente)
        {
            InitializeComponent();
            _controlador = controlador;
            _ejercicioEditando = ejercicioExistente;
            _idDiaRutina = ejercicioExistente.IdDiaRutina ?? 0;

            cmbEjercicio.SelectedValue = ejercicioExistente.IdEjercicio;
            nudSeries.Value = (decimal)ejercicioExistente.Series;
            nudRepes.Value = (decimal)ejercicioExistente.Repeticiones;
            txtPeso.Text = ejercicioExistente.Peso.ToString();
            nudOrden.Value = (decimal)ejercicioExistente.Orden;
        }
        private void FormEjercicio_Load(object sender, EventArgs e)
        {
            using (var context = new DiplomaContext())
            {
                var ejercicios = context.Ejercicios
                    .Select(e => new { e.IdEjercicio, e.NombreEjercicio })
                    .ToList();
                cmbEjercicio.DataSource = ejercicios;
                cmbEjercicio.DisplayMember = "NombreEjercicio";
                cmbEjercicio.ValueMember = "IdEjercicio";
            }

            if (_ejercicioEditando != null)
            {
                cmbEjercicio.SelectedValue = _ejercicioEditando.IdEjercicio;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idEjercicio = (int)cmbEjercicio.SelectedValue;
                int series = (int)nudSeries.Value;
                int repes = (int)nudRepes.Value;
                float peso = float.Parse(txtPeso.Text);
                int orden = (int)nudOrden.Value;

                if (_ejercicioEditando == null)
                {
                    _controlador.AgregarEjADia(_idDiaRutina, idEjercicio, series, repes, peso, orden);
                }
                else
                {
                    _controlador.ModificarEjAsignado(idEjercicio, series, repes, peso, orden);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el ejercicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

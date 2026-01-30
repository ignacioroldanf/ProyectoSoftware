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
    public partial class FormGestionarProgresos : Form
    {
        private readonly CtrlGestionarRutinasyProgresos _controlador;
        private readonly int _idCliente;
        private readonly bool _modoLectura;
        private Rutina _rutinaSeleccionada;
        private DiasRutina _diaSeleccionado;
        private EjerciciosAsignado _ejercicioSeleccionado;


        public FormGestionarProgresos(CtrlGestionarRutinasyProgresos controlador, int idCliente, bool modoLectura)
        {
            InitializeComponent();
            _controlador = controlador;
            _idCliente = idCliente;
            _modoLectura = modoLectura;
        }



        private void FormGestionarProgresos_Load(object sender, EventArgs e)
        {
            _rutinaSeleccionada = _controlador.ConsultarRutinaActual(_idCliente);

            if (_rutinaSeleccionada == null)
            {
                MessageBox.Show("El cliente no tiene una rutina asignada.");
                Close();
                return;
            }
            
            grpNuevoProgreso.Enabled = !_modoLectura;

            CargarDiasRutina();


            if (cmbDiaRutina.Items.Count > 0)
            {
                _diaSeleccionado = _rutinaSeleccionada.DiasRutinas.OrderBy(d => d.NumeroDia).FirstOrDefault();

                CargarEjDelDia();

                if (cmbEjercicio.Items.Count > 0)
                {
                    cmbEjercicio.SelectedIndex = 0;
                }
            }


            CargarHistorialProgresos();
        }

        private void cmbDiaRutina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDiaRutina.SelectedIndex < 0 || _rutinaSeleccionada == null) return;


            string selectedText = cmbDiaRutina.SelectedItem.ToString();
            if (string.IsNullOrEmpty(selectedText)) return;

            int numeroDia;
            var parts = selectedText.Split(' ');
            if (parts.Length < 2 || int.TryParse(parts[1], out numeroDia) == false)
                return;

            _diaSeleccionado = _rutinaSeleccionada.DiasRutinas
                                                .FirstOrDefault(d => d.NumeroDia == numeroDia);

            CargarEjDelDia();
        }
        private void cmbEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_diaSeleccionado == null || cmbEjercicio.SelectedIndex < 0)
            {                 
                _ejercicioSeleccionado = null;
                return;
            }

            var listaOrdenada = _diaSeleccionado.EjerciciosAsignados
                                        .OrderBy(ea => ea.Orden)
                                        .ToList();
            if(cmbEjercicio.SelectedIndex >= 0 && cmbEjercicio.SelectedIndex < listaOrdenada.Count)
            {
                _ejercicioSeleccionado = listaOrdenada[cmbEjercicio.SelectedIndex];
                CargarHistorialProgresos();
            }
            else
            {
                _ejercicioSeleccionado = null;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            FormInicio principal = (FormInicio)this.TopLevelControl;
            principal.AbrirFormulario<FormGestionarRutinas>();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(_ejercicioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un ejercicio antes de registrar el progreso.");
                return;
            }

            int series = (int)NUDSeriesHechas.Value;
            int repes = (int)NUDRepesHechas.Value;
            float peso = float.TryParse(txtPesoUsado.Text, out float p) ? p:0;
            string observaciones = txtObservaciones.Text.Trim();

            try
            {
                _controlador.RegistrarProgreso(_idCliente, _ejercicioSeleccionado.IdEjercicioAsignado, series, repes, peso, observaciones);
                MessageBox.Show("Progreso registrado correctamente.");
                LimpiarCampos();
                CargarHistorialProgresos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el progreso: {ex.Message}");
            }
        }

        private void CargarDiasRutina()
        {
            cmbDiaRutina.SelectedIndexChanged -= cmbDiaRutina_SelectedIndexChanged;

            cmbDiaRutina.Items.Clear();

            if (_rutinaSeleccionada == null)
                _rutinaSeleccionada = _controlador.ConsultarRutinaActual(_idCliente);

            if (_rutinaSeleccionada != null)
            {
                foreach (var dia in _rutinaSeleccionada.DiasRutinas.OrderBy(d => d.NumeroDia))
                    cmbDiaRutina.Items.Add($"Día {dia.NumeroDia}");

                if (cmbDiaRutina.Items.Count > 0)
                    cmbDiaRutina.SelectedIndex = 0;
            }

            cmbDiaRutina.SelectedIndexChanged += cmbDiaRutina_SelectedIndexChanged;
        }

        private void CargarEjDelDia()
        {
            cmbEjercicio.SelectedIndexChanged -= cmbEjercicio_SelectedIndexChanged;

            cmbEjercicio.Items.Clear();
            _ejercicioSeleccionado = null;

            if(_diaSeleccionado == null)
            {
                cmbEjercicio.SelectedIndex = -1;
                cmbEjercicio.SelectedIndexChanged += cmbEjercicio_SelectedIndexChanged;
                return;
            }

            var listaOrdenada = _diaSeleccionado.EjerciciosAsignados
                                        .OrderBy(ea => ea.Orden)
                                        .ToList();
            foreach (var ej in listaOrdenada)
            {
                string nombreEj = ej.IdEjercicioNavigation?.NombreEjercicio ?? $"Ej #{ej.IdEjercicio}";
                cmbEjercicio.Items.Add($"{ej.Orden} - {nombreEj}");
            }

            cmbEjercicio.SelectedIndexChanged += cmbEjercicio_SelectedIndexChanged;

            if (cmbEjercicio.Items.Count > 0)
                cmbEjercicio.SelectedIndex = 0;
            else
                cmbEjercicio.SelectedItem = -1;
        }



        private void CargarHistorialProgresos()
        {
            if (_ejercicioSeleccionado == null)
            {
                dtgvEjercicios.DataSource = null;
                return;
            }

            var progresos = _controlador.ConsultarProgresos(_idCliente)
                .Where(p => p.IdEjercicioAsignado == _ejercicioSeleccionado.IdEjercicioAsignado)
                .OrderByDescending(p => p.Fecha)
                .Select(p => new
                {
                    Fecha = p.Fecha,
                    Ejercicio = p.IdEjercicioAsignadoNavigation.IdEjercicioNavigation.NombreEjercicio,
                    Series_Hechas = p.SeriesHechas,
                    Repeticiones_Hechas = p.RepesHechas,
                    Peso_Usado = p.PesoUsado,
                    Observaciones = p.Observaciones
                })
                .ToList();

            dtgvEjercicios.DataSource = progresos;
        }


        private void LimpiarCampos()
        {
            NUDSeriesHechas.Value = 0;
            NUDRepesHechas.Value = 0;
            txtPesoUsado.Text = "";
            txtObservaciones.Text = "";
        }


    }
}


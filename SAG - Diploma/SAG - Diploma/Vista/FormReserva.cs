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
using Modelo.Modelo;
using SAG___Diploma.Vista.Theme;

namespace SAG___Diploma.Vista
{
    public partial class FormReserva : Form
    {
        private CtrlGestionarClases _controladorClases;
        private CtrlGestionarReservas _controladorReservas;

        private int _idCliente;
        private int _idHorarioSeleccionado = -1;
        public FormReserva(int idCliente, string nombreCompleto)
        {
            InitializeComponent();

            _idCliente = idCliente;
            lblNombreCliente.Text = nombreCompleto;

            _controladorClases = new CtrlGestionarClases(new DiplomaContext());
            _controladorReservas = new CtrlGestionarReservas(new DiplomaContext());
        }
        private void FormReserva_Load(object sender, EventArgs e)
        {
            ConfigurarControlesIniciales();
            CargarClases();
            CargarTipoRecurrencia();
            // Aplicar tema para asegurar estilos (combobox legibles)
            FuturisticTheme.ApplyToForm(this);
        }

        private void ConfigurarControlesIniciales()
        {
            dtpFechaInicio.MinDate = DateTime.Today;
            dtpFechaFin.MinDate = DateTime.Today;

            // Fecha exacta para reservar (por defecto próxima instancia del día seleccionado)
            dtpFechaExacta.MinDate = DateTime.Today;

            gbRecurrencia.Enabled = false;
            lblCuposDisponibles.Text = "Cupos disponibles: -";
        }

        private void CargarClases()
        {
            cmbClase.DisplayMember = "Nombre";
            cmbClase.ValueMember = "IdClase";
            cmbClase.DataSource = _controladorClases.ListarClases();
            cmbClase.SelectedIndex = -1;
        }

        private void CargarTipoRecurrencia()
        {
            cmbTipoRecurrencia.DisplayMember = "Descripcion";

            cmbTipoRecurrencia.ValueMember = "IdTipoRecurrencia";

            cmbTipoRecurrencia.DataSource = _controladorReservas.ListarTipoRecurrencia();

            if (cmbTipoRecurrencia.Items.Count > 0)
            {
                cmbTipoRecurrencia.SelectedIndex = 0;
            }
        }

        private void cmbClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClase.SelectedIndex == -1) return;

            int idClase = (int)cmbClase.SelectedValue;
            var clase = _controladorClases.ObtenerClasePorID(idClase);

            // Obtener los días (desde la BD) que tienen horarios para esta clase
            var diasIds = clase.HorarioClases.Select(h => h.IdDiaSemana).Distinct().ToList();
            var diasFromDb = _controladorClases.ListarDiasSemana()
                .Where(d => diasIds.Contains(d.IdDiaSemana))
                .Select(d => new { Id = d.IdDiaSemana, Nombre = d.NombreDia })
                .OrderBy(d => d.Id)
                .ToList();

            cmbDia.DisplayMember = "Nombre";
            cmbDia.ValueMember = "Id";
            cmbDia.DataSource = diasFromDb;
            cmbDia.SelectedIndex = -1;

            // Reset exact date when class changes
            dtpFechaExacta.Value = DateTime.Today;


            cmbHorario.DataSource = null;
            _idHorarioSeleccionado = -1;
            lblCuposDisponibles.Text = "Cupos disponibles: -";

        }

        private void cmbDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDia.SelectedIndex == -1) return;

            int idClase = (int)cmbClase.SelectedValue;
            int idDiaSemana = (int)cmbDia.SelectedValue;
            var clase = _controladorClases.ObtenerClasePorID(idClase);

            var horarios = clase.HorarioClases
                                .Where(h => h.IdDiaSemana == idDiaSemana)
                                .Select(h => new
                                {
                                    Id = h.IdHorarioClase,
                                    Texto = $"{h.HoraInicio:HH\\:mm} - {h.HoraFin:HH\\:mm}"
                                })
                                .ToList();

            cmbHorario.DisplayMember = "Texto";
            cmbHorario.ValueMember = "Id";
            cmbHorario.DataSource = horarios;
            cmbHorario.SelectedIndex = -1;

            if (cmbDia.SelectedItem != null)
            {
                int diaSemana = (int)cmbDia.SelectedValue;
                var next = ProximaFechaParaDia(diaSemana, DateTime.Today);
                dtpFechaExacta.Value = next;

                dtpFechaExacta.MinDate = DateTime.Today;
                dtpFechaExacta.MaxDate = DateTime.Today.AddDays(7 * 12);

            }
        }

        private void cmbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHorario.SelectedValue == null) return;

            _idHorarioSeleccionado = (int)cmbHorario.SelectedValue;
            ActualizarInformacionCupos();
        }

        private void ActualizarInformacionCupos()
        {
            if (_idHorarioSeleccionado == -1) return;
            try
            {
                // Use the exact selected date to check inscriptos
                var fechaParaConsulta = dtpFechaExacta.Value;
                var inscriptos = _controladorReservas.ObtenerInscriptos(_idHorarioSeleccionado, fechaParaConsulta);

                int idClase = (int)cmbClase.SelectedValue;
                int max = _controladorClases.ObtenerClasePorID(idClase).CupoMaximo;
                int libres = max - inscriptos.Count;

                lblCuposDisponibles.Text = $"Cupos disponibles: {libres}";

                if (libres <= 0)
                {
                    lblCuposDisponibles.ForeColor = Color.Red;
                    btnConfirmarReserva.Enabled = false;
                }
                else
                {
                    lblCuposDisponibles.ForeColor = Color.Green;
                    btnConfirmarReserva.Enabled = true;
                }
            }
            catch (Exception)
            {
                lblCuposDisponibles.Text = "Cupos disponibles: -";
                btnConfirmarReserva.Enabled = false;
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFin.MinDate = dtpFechaInicio.Value;
            ActualizarInformacionCupos();
        }

        private void dtpFechaExacta_ValueChanged(object sender, EventArgs e)
        {
            // When exact date changes, update cupos information
            ActualizarInformacionCupos();
        }

        private DateTime ProximaFechaParaDia(int diaSemana, DateTime desde)
        {
            int hoy = (int)desde.DayOfWeek;
            int target = diaSemana;
            if (diaSemana >= 1 && diaSemana <= 7)
            {
                target = (diaSemana % 7); 
            }

            int delta = ((target - hoy) + 7) % 7;
            if (delta == 0)
                delta = 7;
            return desde.Date.AddDays(delta);
        }

        private void chkEsRecurrente_CheckedChanged(object sender, EventArgs e)
        {
            gbRecurrencia.Enabled = chkEsRecurrente.Checked;

            if (!chkEsRecurrente.Checked)
            {
                dtpFechaFin.Value = dtpFechaInicio.Value;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmarReserva_Click(object sender, EventArgs e)
        {
            if (cmbClase.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una clase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cortamos la ejecución acá
            }
            if (cmbHorario.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DateTime inicio;
                DateTime? fin = null;
                int idRecurrencia = 1; // 1 = Semanal por defecto

                // Si no es recurrente, usamos la fecha exacta que eligió arriba
                if (!chkEsRecurrente.Checked)
                {
                    inicio = dtpFechaExacta.Value.Date;
                }
                else // Si ES recurrente
                {
                    inicio = dtpFechaInicio.Value.Date;

                    // Nos fijamos si eligieron "Mensual" (asumo que es el índice 1 del combo)
                    if (cmbTipoRecurrencia.Text.Contains("Mensual"))
                    {
                        // Magia: Le sumamos a la fecha de inicio la cantidad de meses del control "nudMeses"
                        int cantidadMeses = (int)nudMeses.Value;
                        fin = inicio.AddMonths(cantidadMeses);

                        idRecurrencia = 2; // Asumo que 2 es el ID de Mensual en tu Base de Datos
                    }
                    else // Si es Semanal
                    {
                        // Toma lo que el usuario puso a mano en el calendario de fecha fin
                        fin = dtpFechaFin.Value.Date;
                        idRecurrencia = 1;

                        if (fin < inicio)
                        {
                            MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Llamamos a tu controlador pasando el id de recurrencia que calculamos
                _controladorReservas.CrearReserva(
                    _idCliente,
                    _idHorarioSeleccionado,
                    inicio,
                    fin,
                    chkEsRecurrente.Checked,
                    idRecurrencia);

                MessageBox.Show("Reserva creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la reserva: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbTipoRecurrencia_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbTipoRecurrencia.SelectedIndex == 0)
            {
                dtpFechaFin.Visible = true;
                lblFechaFin.Text = "Fecha de Fin:";

                nudMeses.Visible = false;
            }
            else
            {
                dtpFechaFin.Visible = false;
                lblFechaFin.Text = "Cantidad de Meses:";

                nudMeses.Visible = true;
            }
        }
    }
}

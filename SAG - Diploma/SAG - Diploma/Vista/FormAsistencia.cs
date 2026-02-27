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
    public partial class FormAsistencia : Form
    {
        private CtrlGestionarReservas _controladorReservas;
        private int _idHorarioFijo; // Guardamos el ID que nos pasan
        private HashSet<DateOnly> _fechasDisponibles = new();
        private bool _suppressDateChange = false;

        // Indica si estamos usando un horario fijo pasado desde GestionarClases
        private bool _usarHorarioFijo => _idHorarioFijo > 0;

        // NUEVO CONSTRUCTOR
        public FormAsistencia(int idHorario, string diaSemana, string hora)
        {
            InitializeComponent();
            _controladorReservas = new CtrlGestionarReservas(new DiplomaContext());
            _idHorarioFijo = idHorario;

            // Ponemos de título qué clase estamos evaluando
            this.Text = $"Tomar Asistencia: {diaSemana} a las {hora}";
        }

        private void FormAsistencia_Load(object sender, EventArgs e)
        {
            // iniciar MonthCalendar selection handled in CargarFechasDisponibles

            // No cargar fechas aún aquí: cargar después de inicializar el combo (o para horario fijo)

            // Si venimos con un horario fijo, mostrarlo y no permitir cambiarlo desde el combo
            if (_usarHorarioFijo)
            {
                // Mostrar texto en el combobox y deshabilitar selección
                // Mostrar la descripción de la clase y horario en la etiqueta
                try
                {
                    var horario = _controladorReservas.ObtenerHorarioPorId(_idHorarioFijo);
                    if (horario != null)
                    {
                        string texto = $"{horario.IdClaseNavigation?.NombreClase ?? "Clase"} - {horario.IdDiaSemanaNavigation?.NombreDia ?? horario.IdDiaSemana.ToString()} {horario.HoraInicio:HH:mm}-{horario.HoraFin:HH:mm}";
                        lblClase.Text = texto;
                    }
                    else
                    {
                        lblClase.Text = "Horario seleccionado";
                    }
                }
                catch
                {
                    lblClase.Text = "Horario seleccionado";
                }

                // Cargar fechas disponibles y ajustar DateTimePicker antes de cargar alumnos
                CargarFechasDisponibles();
                ActualizarGrillaAlumnos();
            }
            else
            {
                // Primero cargar la lista de horarios (combo) y sus fechas disponibles
                // Si no hay horario fijo, no hay combo: informar y cerrar
                MessageBox.Show("No se especificó un horario para tomar asistencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            // mcFechas events are wired in designer; nothing else to attach here
        }

        private void CargarFechasDisponibles()
        {
            _fechasDisponibles.Clear();

            if (_usarHorarioFijo)
            {
                var fechas = _controladorReservas.ObtenerFechasConReservasParaHorario(_idHorarioFijo) ?? new List<DateOnly>();
                foreach (var d in fechas)
                    _fechasDisponibles.Add(d);
            }

            // Ajustar DateTimePicker y MonthCalendar según las fechas disponibles
            if (_fechasDisponibles.Count > 0)
            {
                var arr = _fechasDisponibles.Select(d => d.ToDateTime(TimeOnly.MinValue)).ToArray();
                var min = arr.Min();
                var max = arr.Max();
                // configurar rango visual en mcFechas
                try
                {
                    mcFechas.MinDate = min;
                    mcFechas.MaxDate = max;
                }
                catch { }

                // Si la fecha actual no está disponible, seleccionar la primer fecha disponible
                DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
                DateTime seleccionar = arr.Min();
                if (_fechasDisponibles.Contains(hoy))
                    seleccionar = hoy.ToDateTime(TimeOnly.MinValue);

                // sincronizar selección en mcFechas
                try
                {
                    mcFechas.SetSelectionRange(seleccionar.Date, seleccionar.Date);
                }
                catch { }

                // Configurar mcFechas (visual)
                try
                {
                    mcFechas.RemoveAllBoldedDates();
                    foreach (var d in _fechasDisponibles)
                    {
                        mcFechas.AddBoldedDate(d.ToDateTime(TimeOnly.MinValue));
                    }
                    mcFechas.UpdateBoldedDates();
                    try { mcFechas.SelectionStart = seleccionar.Date; } catch { }
                }
                catch { }
            }
            else
            {
                // Si no hay fechas disponibles, limpiar marcados
                try
                {
                    mcFechas.RemoveAllBoldedDates();
                    mcFechas.UpdateBoldedDates();
                }
                catch { }
            }
        }

        private DateOnly? FindNearestAvailable(DateOnly target)
        {
            if (_fechasDisponibles.Count == 0) return null;
            if (_fechasDisponibles.Contains(target)) return target;
            // Buscar la fecha disponible más cercana
            var ordered = _fechasDisponibles.OrderBy(d => Math.Abs((d.ToDateTime(TimeOnly.MinValue) - target.ToDateTime(TimeOnly.MinValue)).Days)).ToList();
            return ordered.FirstOrDefault();
        }

        private void mcFechas_DateSelected(object? sender, DateRangeEventArgs e)
        {
            DateOnly sel = DateOnly.FromDateTime(e.Start.Date);
            if (!_fechasDisponibles.Contains(sel))
            {
                MessageBox.Show("La fecha seleccionada no tiene reservas para este horario.", "Fecha no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ActualizarGrillaAlumnos();
        }

        // Interceptar cambio manual en mcFechas mediante mcFechas_DateSelected
        // Note: selector de horarios eliminado; usamos mcFechas como selector visual.

        private void ActualizarGrillaAlumnos()
        {
            DateTime fecha = mcFechas.SelectionStart.Date;

            int idHorarioAUsar = _idHorarioFijo;

            // Validaciones: verificar que el horario existe
            var horarioInfo = _controladorReservas.ObtenerHorarioPorId(idHorarioAUsar);
            if (horarioInfo == null)
            {
                MessageBox.Show("Horario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardar.Enabled = false;
                dtgvAlumnos.DataSource = null;
                return;
            }

            // Obtener las fechas que tienen reservas para este horario
            var fechasEnHorario = _controladorReservas.ObtenerFechasConReservasParaHorario(idHorarioAUsar);
            if (fechasEnHorario == null || fechasEnHorario.Count == 0)
            {
                MessageBox.Show("No existen reservas registradas para este horario.", "Sin reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = false;
                dtgvAlumnos.DataSource = null;
                return;
            }

            DateOnly fechaSeleccionada = DateOnly.FromDateTime(fecha);
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
            var ahora = TimeOnly.FromDateTime(DateTime.Now);

            // Si la fecha seleccionada no tiene reservas para este horario, avisar y no mostrar el mensaje genérico
            if (!fechasEnHorario.Contains(fechaSeleccionada))
            {
                MessageBox.Show("No hubo reservas para este horario en la fecha seleccionada.", "Sin reservas en fecha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = false;
                dtgvAlumnos.DataSource = null;
                return;
            }

            // Si la fecha es futura, no se puede tomar asistencia
            if (fechaSeleccionada > hoy)
            {
                MessageBox.Show("No se puede tomar asistencia para una fecha futura. Esta clase aún no ocurrió.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnGuardar.Enabled = false;
                dtgvAlumnos.DataSource = null;
                return;
            }

            // Si es hoy pero la clase todavía no comenzó
            if (fechaSeleccionada == hoy && horarioInfo.HoraInicio > ahora)
            {
                MessageBox.Show("La clase en ese horario aún no ha comenzado hoy. No se puede registrar asistencia antes del inicio.", "Horario no ocurrido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = false;
                dtgvAlumnos.DataSource = null;
                return;
            }


            var alumnos = _controladorReservas.ObtenerAlumnosParaAsistencia(idHorarioAUsar, fecha);

            dtgvAlumnos.DataSource = alumnos;

            if (dtgvAlumnos.Columns.Contains("colAsistio"))
                dtgvAlumnos.Columns.Remove("colAsistio");

            if (alumnos.Count == 0)
            {
                btnGuardar.Enabled = false;
                return;
            }

            btnGuardar.Enabled = true;

            if (dtgvAlumnos.Columns["IdReserva"] != null) dtgvAlumnos.Columns["IdReserva"].Visible = false;
            if (dtgvAlumnos.Columns["IdEstadoActual"] != null) dtgvAlumnos.Columns["IdEstadoActual"].Visible = false;

            // Ajustar orden y títulos de columnas: NombreCompleto, DNI, Estado, Asistencia
            if (dtgvAlumnos.Columns["NombreCompleto"] != null)
            {
                dtgvAlumnos.Columns["NombreCompleto"].HeaderText = "Nombre";
                dtgvAlumnos.Columns["NombreCompleto"].DisplayIndex = 0;
            }
            if (dtgvAlumnos.Columns["DNI"] != null)
            {
                dtgvAlumnos.Columns["DNI"].HeaderText = "DNI";
                dtgvAlumnos.Columns["DNI"].DisplayIndex = 1;
            }
            if (dtgvAlumnos.Columns["Estado"] != null)
            {
                dtgvAlumnos.Columns["Estado"].HeaderText = "Estado";
                dtgvAlumnos.Columns["Estado"].DisplayIndex = 2;
            }

            // Agregar columna de checkbox para asistencia
            var existing = dtgvAlumnos.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Name == "colAsistio");
            if (existing != null) dtgvAlumnos.Columns.Remove(existing);

            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.Name = "colAsistio";
            colCheck.HeaderText = "Asistencia";
            colCheck.Width = 80;
            dtgvAlumnos.Columns.Add(colCheck);
            colCheck.DisplayIndex = 3;

            foreach (DataGridViewRow fila in dtgvAlumnos.Rows)
            {
                if (fila.Cells["IdEstadoActual"].Value == null) continue;
                int idEstado = Convert.ToInt32(fila.Cells["IdEstadoActual"].Value);
                fila.Cells["colAsistio"].Value = (idEstado == 2 || idEstado == 4);
            }

            dtgvAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dtgvAlumnos.Rows.Count == 0) return;

            List<int> presentes = new List<int>();
            List<int> ausentes = new List<int>();

            foreach (DataGridViewRow fila in dtgvAlumnos.Rows)
            {
                if (fila.IsNewRow) continue;
                if (fila.Cells["IdReserva"].Value == null) continue;

                if (!int.TryParse(fila.Cells["IdReserva"].Value.ToString(), out int idReserva)) continue;

                bool asistio = false;
                var cell = fila.Cells["colAsistio"];
                if (cell.Value is bool b) asistio = b;
                else if (cell.Value is DBNull) asistio = false;
                else
                {
                    bool.TryParse(Convert.ToString(cell.Value), out asistio);
                }

                if (asistio)
                    presentes.Add(idReserva);
                else
                    ausentes.Add(idReserva);
            }

            try
            {
                _controladorReservas.GuardarAsistencia(presentes, ausentes);
                MessageBox.Show("Asistencia registrada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarGrillaAlumnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la asistencia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

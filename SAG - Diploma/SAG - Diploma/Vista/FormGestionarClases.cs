using Controlador;
using Modelo;
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
    public partial class FormGestionarClases : Form
    {
        private CtrlGestionarClases _controlador;
        private int _idClaseSeleccionada = -1;
        public FormGestionarClases()
        {
            InitializeComponent();
            _controlador = new CtrlGestionarClases(new DiplomaContext());
        }
        private void FormGestionarClases_Load(object sender, EventArgs e)
        {
            CargarGrillaClases();
            dtgvHorarios.DataSource = null;
            ConfigurarControlesHorario();
            AplicarSeguridad();
        }
        private void AplicarSeguridad()
        {
            btnAgregar.Visible = Sesion.Instancia.TienePermiso("AgregarClase");
            btnModificar.Visible = Sesion.Instancia.TienePermiso("ModificarClase");
            btnEliminar.Visible = Sesion.Instancia.TienePermiso("EliminarClase");
            btnAgregarHorario.Visible = Sesion.Instancia.TienePermiso("AgregarHorario");
            btnEliminarHorario.Visible = Sesion.Instancia.TienePermiso("EliminarHorario");
        }
        #region Cargas
        private void CargarGrillaClases()
        {
            dtgvClases.DataSource = null;
            dtgvClases.DataSource = _controlador.ListarClases();

            if (dtgvClases.Columns["IdClase"] != null) dtgvClases.Columns["IdClase"].Visible = false;
            if (dtgvClases.Columns["HorarioClases"] != null) dtgvClases.Columns["HorarioClases"].Visible = false;

            dtgvClases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarGrillaHorarios()
        {
            if (_idClaseSeleccionada == -1) return;

            var clase = _controlador.ObtenerClasePorID(_idClaseSeleccionada);

            if (clase != null && clase.HorarioClases != null)
            {
                var listaHorarios = clase.HorarioClases.Select(h => new
                {
                    Id = h.IdHorarioClase,
                    Dia = h.IdDiaSemanaNavigation != null ? h.IdDiaSemanaNavigation.NombreDia : h.IdDiaSemana.ToString(),
                    Inicio = h.HoraInicio,
                    Fin = h.HoraFin
                }).ToList();

                dtgvHorarios.DataSource = listaHorarios;

                if (dtgvHorarios.Columns["Id"] != null) dtgvHorarios.Columns["Id"].Visible = false;
                dtgvHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                dtgvHorarios.DataSource = null;
            }
        }

        private void ConfigurarControlesHorario()
        {
            cmbDiaSemana.DisplayMember = "NombreDia";
            cmbDiaSemana.ValueMember = "IdDiaSemana";
            cmbDiaSemana.DataSource = _controlador.ListarDiasSemana();

            dtpInicioHorario.Format = DateTimePickerFormat.Time;
            dtpInicioHorario.ShowUpDown = true;
            dtpFinHorario.Format = DateTimePickerFormat.Time;
            dtpFinHorario.ShowUpDown = true;

            dtpInicioHorario.Value = DateTime.Today.AddHours(8);
            dtpFinHorario.Value = DateTime.Today.AddHours(9);
        }
        #endregion
        private void dtgvClases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvClases.CurrentRow != null && e.RowIndex >= 0)
            {
                try
                {
                    _idClaseSeleccionada = Convert.ToInt32(dtgvClases.CurrentRow.Cells["IdClase"].Value);
                    CargarGrillaHorarios();
                }
                catch
                {
                    _idClaseSeleccionada = -1;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormDetalleClase form = new FormDetalleClase();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _controlador.AgregarClase(form.ClaseCreada);
                    CargarGrillaClases();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idClaseSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una clase para eliminar.");
                return;
            }

            if (MessageBox.Show("¿Eliminar clase y todos sus horarios?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _controlador.EliminarClase(_idClaseSeleccionada);
                    CargarGrillaClases();

                    _idClaseSeleccionada = -1;
                    dtgvHorarios.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar: " + ex.Message);
                }
            }
        }

        private void btnAgregarHorario_Click(object sender, EventArgs e)
        {
            if (_idClaseSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una clase arriba para agregarle horarios.");
                return;
            }

            if (dtpFinHorario.Value.TimeOfDay <= dtpInicioHorario.Value.TimeOfDay)
            {
                MessageBox.Show("La hora de fin debe ser mayor a la de inicio.");
                return;
            }

            try
            {
                int dia = (int)cmbDiaSemana.SelectedValue;

                TimeOnly inicio = TimeOnly.FromDateTime(dtpInicioHorario.Value);
                TimeOnly fin = TimeOnly.FromDateTime(dtpFinHorario.Value);

                _controlador.AgregarHorario(_idClaseSeleccionada, dia, inicio, fin);

                CargarGrillaHorarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar horario: " + ex.Message);
            }
        }

        private void btnEliminarHorario_Click(object sender, EventArgs e)
        {
            if (dtgvHorarios.CurrentRow == null) return;

            int idHorario = Convert.ToInt32(dtgvHorarios.CurrentRow.Cells["Id"].Value);

            if (MessageBox.Show("¿Quitar este horario?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _controlador.EliminarHorario(idHorario);
                    CargarGrillaHorarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_idClaseSeleccionada == -1)
            {
                MessageBox.Show("Por favor, seleccione una clase de la grilla para modificar.");
                return;
            }

            var claseObj = _controlador.ObtenerClasePorID(_idClaseSeleccionada);
            if (claseObj == null) return;

            FormDetalleClase form = new FormDetalleClase(claseObj);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _controlador.ModificarClase(form.ClaseCreada);
                    CargarGrillaClases();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar: " + ex.Message);
                }
            }
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            if (dtgvHorarios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un horario de la lista para tomar asistencia.");
                return;
            }

            int idHorario = Convert.ToInt32(dtgvHorarios.CurrentRow.Cells["Id"].Value);
            string diaClase = dtgvHorarios.CurrentRow.Cells["Dia"].Value.ToString();
            string horaClase = dtgvHorarios.CurrentRow.Cells["Inicio"].Value.ToString();

            // Verificar que existan reservas previas para este horario (al menos una fecha <= hoy)
            var ctrlReservas = new CtrlGestionarReservas(new DiplomaContext());
            var fechas = ctrlReservas.ObtenerFechasConReservasParaHorario(idHorario);
            if (fechas == null || fechas.Count == 0)
            {
                MessageBox.Show("No existen reservas registradas para este horario. No se puede abrir la toma de asistencia.", "Sin reservas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
            if (!fechas.Any(f => f <= hoy))
            {
                MessageBox.Show("Este horario no tiene ninguna clase realizada aún. No se puede abrir la toma de asistencia.", "Horario no ocurrido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FormAsistencia form = new FormAsistencia(idHorario, diaClase, horaClase);
            form.ShowDialog();
        }
    }
}

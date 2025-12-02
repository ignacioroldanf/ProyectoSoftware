using Controlador;
using Microsoft.EntityFrameworkCore;
using Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAG___Diploma.Vista
{
    public partial class FormRutinas : Form
    {
        private readonly Rutina _rutina;
        private readonly CtrlGestionarRutinasyProgresos _controlador;
        private readonly bool _modoLectura;

        public FormRutinas(Rutina rutina, CtrlGestionarRutinasyProgresos controlador, bool modoLectura = false)
        {
            InitializeComponent();
            _rutina = rutina;
            _controlador = controlador;
            _modoLectura = modoLectura;
        }

        private void FormRutinas_Load(object sender, EventArgs e)
        {
            cmbDia.Items.Clear();
            foreach (var dia in _rutina.DiasRutinas.OrderBy(d => d.NumeroDia))
                cmbDia.Items.Add($"Día {dia.NumeroDia}");

            if (cmbDia.Items.Count > 0)
                cmbDia.SelectedIndex = 0;

            if (_modoLectura)
            {
                btnAgregar.Enabled = false;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void cmbDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEjerciciosDelDia();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int diaSeleccionado = cmbDia.SelectedIndex + 1;
            var dia = _rutina.DiasRutinas.FirstOrDefault(d => d.NumeroDia == diaSeleccionado);

            if (dia == null) return;

            using (var form = new FormEjercicio(_controlador, dia.IdDiaRutina))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    CargarEjerciciosDelDia();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgvEjercicios.SelectedRows.Count == 0) return;

            int idEjercicioAsignado = (int)dtgvEjercicios.SelectedRows[0].Cells["ID"].Value;

            using (var form = new FormEjercicio(_controlador, idEjercicioAsignado))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    CargarEjerciciosDelDia();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgvEjercicios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un ejercicio de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEjAsignado = Convert.ToInt32(dtgvEjercicios.SelectedRows[0].Cells["ID"].Value);

            var confirm = MessageBox.Show("¿Está seguro que desea eliminar este ejercicio?",
                                          "Confirmar eliminación",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (var context = new DiplomaContext())
                {
                    var controlador = new CtrlGestionarRutinasyProgresos(context);
                    var ejercicio = context.EjerciciosAsignados.Find(idEjAsignado);

                    if (ejercicio != null)
                    {
                        context.EjerciciosAsignados.Remove(ejercicio);
                        context.SaveChanges();
                    }
                }

                CargarEjerciciosDelDia();
            }
        }

        private void CargarEjerciciosDelDia()
        {
            if (cmbDia.SelectedIndex < 0) return;

            int diaSeleccionado = cmbDia.SelectedIndex + 1;
            var dia = _rutina.DiasRutinas.FirstOrDefault(d => d.NumeroDia == diaSeleccionado);

            using (var context = new DiplomaContext())
            {
                dia = context.DiasRutinas
                    .Include(d => d.EjerciciosAsignados)
                        .ThenInclude(ea => ea.IdEjercicioNavigation)
                    .FirstOrDefault(d => d.IdDiaRutina == dia.IdDiaRutina);

                if (dia != null)
                {
                    dtgvEjercicios.DataSource = dia.EjerciciosAsignados.Select(ea => new
                    {
                        ID = ea.IdEjercicioAsignado,
                        Ejercicio = ea.IdEjercicioNavigation?.NombreEjercicio,
                        Series = ea.Series,
                        Repeticiones = ea.Repeticiones,
                        Peso = ea.Peso,
                        Orden = ea.Orden
                    }).ToList();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DiplomaContext())
                {
                    // Cargar la rutina actualizada desde la BD
                    var rutinaDb = context.Rutinas
                        .Include(r => r.DiasRutinas)
                            .ThenInclude(d => d.EjerciciosAsignados)
                        .FirstOrDefault(r => r.IdRutina == _rutina.IdRutina);

                    if (rutinaDb == null)
                    {
                        MessageBox.Show("No se encontró la rutina en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (rutinaDb.DiasRutinas.Any(d => d.EjerciciosAsignados.Count == 0))
                    {
                        MessageBox.Show("Todos los días deben tener al menos un ejercicio asignado antes de guardar.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    // Actualizamos la fecha de asignación, por si se desea marcar modificación
                    rutinaDb.FechaAsignacion = DateOnly.FromDateTime(DateTime.Now);

                    // Guardamos los cambios de los ejercicios que puedan haberse hecho
                    context.SaveChanges();

                    MessageBox.Show("Rutina guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la rutina: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

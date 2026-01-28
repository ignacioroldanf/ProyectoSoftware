using Controlador;
using Microsoft.EntityFrameworkCore;
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
    public partial class FormGestionarSuscripciones : Form
    {
        private int _idCliente;
        private CtrlGestionarSuscripciones _ctrlSuscripciones;
        private CtrlGestionarClientes _ctrlClientes;

        public FormGestionarSuscripciones(int idCliente)
        {
            InitializeComponent();
            _idCliente = idCliente;
            _ctrlSuscripciones = new CtrlGestionarSuscripciones(new DiplomaContext());
        }

        private void FormGestionarSuscripciones_Load(object sender, EventArgs e)
        {
            CargarCliente();
            CargarSuscripciones();
            CargarPlanes();

            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
            grupoNuevaSuscripcion.Enabled = false;
        }
        private void CargarCliente()
        {
            var cliente = _ctrlSuscripciones.ObtenerCliente(_idCliente);
            if (cliente != null)
            {
                lblCliente.Text = $"{cliente.IdPersonaNavigation.Nombre} {cliente.IdPersonaNavigation.Apellido}";
            }
            else
            {
                lblCliente.Text = "Cliente no encontrado";
            }
        }
        private void CargarSuscripciones()
        {
            var suscripciones = _ctrlSuscripciones.ListarPorCliente(_idCliente)
                .Select(s => new
                {
                    ID = s.IdSuscripcion,
                    Plan = s.IdPlanNavigation.NombrePlan,
                    Estado = s.IdEstadoSuscripcionNavigation.Descripcion,
                    Inicio = s.Inicio,
                    Fin = s.Fin
                })
                .ToList();

            dtgvSuscripciones.DataSource = suscripciones;

            lblEstadoActual.Text = suscripciones.Any(s => s.Estado == "Vigente")
                ? "Tiene una suscripción activa"
                : "No tiene suscripción activa";
        }

        private void CargarPlanes()
        {
            var planes = _ctrlSuscripciones.ObtenerPlanes();

            cmbPlanes.DataSource = planes;
            cmbPlanes.DisplayMember = "NombrePlan";
            cmbPlanes.ValueMember = "IdPlan";
            cmbPlanes.SelectedIndex = -1; // No seleccionar ningún plan por defecto

        }

        private void CalcularFin()
        {
            if (cmbPlanes.SelectedValue is int idPlan)
            {
                DateOnly inicio = DateOnly.FromDateTime(dtpInicio.Value);

                var fin = _ctrlSuscripciones.CalcularFechaFin(idPlan, inicio);

                dtpFin.Value = fin.ToDateTime(TimeOnly.MinValue);
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            grupoNuevaSuscripcion.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgvSuscripciones.CurrentRow != null)
            {
                int idSuscripcion = (int)dtgvSuscripciones.CurrentRow.Cells["ID"].Value;

                var result = MessageBox.Show(
                    "¿Está seguro que desea cancelar la suscripción seleccionada?",
                    "Confirmar cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _ctrlSuscripciones.CancelarSuscripcion(idSuscripcion);
                        MessageBox.Show("Suscripción cancelada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarSuscripciones(); // refrescar grilla
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cancelar la suscripción: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una suscripción.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            CalcularFin();
        }
        private void cmbPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularFin();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbPlanes.SelectedValue is int idPlan)
            {
                DateOnly inicio = DateOnly.FromDateTime(dtpInicio.Value);
                DateOnly fin = DateOnly.FromDateTime(dtpFin.Value);

                try
                {
                    _ctrlSuscripciones.AsignarSuscripcion(_idCliente, idPlan, inicio, fin);

                    MessageBox.Show("Suscripción asignada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    grupoNuevaSuscripcion.Enabled = false;
                    cmbPlanes.SelectedIndex = -1;
                    dtpInicio.Value = DateTime.Now;
                    dtpFin.Value = DateTime.Now;

                    CargarSuscripciones(); // Actualiza la grilla
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al asignar la suscripción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un plan.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}

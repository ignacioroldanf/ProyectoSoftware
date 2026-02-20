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
    public partial class FormReservasCliente : Form
    {
        private CtrlGestionarClases _ctrlClases;
        private int _idCliente;
        private string _nombreCliente;
        private CtrlGestionarReservas _controlador;
        private List<dynamic> _listaOriginal = new List<dynamic>();
        public FormReservasCliente(int idCliente, string nombreCompleto)
        {
            InitializeComponent();
            _idCliente = idCliente;
            _nombreCliente = nombreCompleto;
            lblCliente.Text = $"Reservas de: {nombreCompleto}";
            _controlador = new CtrlGestionarReservas(new DiplomaContext());
            _ctrlClases = new CtrlGestionarClases(new DiplomaContext());
        }

        private static DateOnly GetMemberDate(object item, string memberName)
        {
            try
            {
                var type = item.GetType();
                var prop = type.GetProperty(memberName);
                if (prop != null)
                {
                    var val = prop.GetValue(item);
                    if (val is DateOnly d) return d;
                    if (val is DateTime dt) return DateOnly.FromDateTime(dt);
                    if (DateOnly.TryParse(val?.ToString(), out var parsed)) return parsed;
                }

                // If it's an IDictionary-like dynamic (ExpandoObject) try that
                if (item is System.Collections.IDictionary dict && dict.Contains(memberName))
                {
                    var v = dict[memberName];
                    if (v is DateOnly dd) return dd;
                    if (v is DateTime dtt) return DateOnly.FromDateTime(dtt);
                    if (DateOnly.TryParse(v?.ToString(), out var parsed2)) return parsed2;
                }
            }
            catch { }
            return DateOnly.FromDateTime(DateTime.MaxValue);
        }

        private void CargarComboClase()
        {
            try
            {
                cmbClase.DataSource = null;
                cmbClase.Items.Clear();

                var clases = _ctrlClases.ListarClases();
                cmbClase.DisplayMember = "Nombre";
                cmbClase.ValueMember = "IdClase";
                cmbClase.DataSource = clases;
                cmbClase.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando clases: " + ex.Message);
            }
        }

        private void FormReservasCliente_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
            CargarComboEstado();
            SAG___Diploma.Vista.Theme.FuturisticTheme.ApplyToForm(this);
            // Cargar clases para filtro (filtrado se aplicará al presionar 'Filtrar')
            CargarComboClase();

            btnNuevaReserva.Enabled= Sesion.Instancia.TienePermiso("NuevaReserva");
        }

        private void ActualizarGrilla()
        {
            _listaOriginal = _controlador.ObtenerReservasPorCliente(_idCliente);

            FiltrarGrilla();
        }
        private void FiltrarGrilla()
        {
            // Si la lista no cargó todavía, salimos
            if (_listaOriginal == null) return;

            var listaFiltrada = _listaOriginal;

            if (cmbEstado.SelectedItem != null && cmbEstado.SelectedIndex != -1)
            {
                // Use GetItemText to respect DisplayMember or simple string items
                string estadoSeleccionado = cmbEstado.GetItemText(cmbEstado.SelectedItem);

                listaFiltrada = _listaOriginal
                                .Where(x => string.Equals(GetMemberString(x, "Estado"), estadoSeleccionado, StringComparison.OrdinalIgnoreCase))
                                .ToList();
            }

            // Filtrar por clase si se seleccionó una
            if (cmbClase.SelectedItem != null && cmbClase.SelectedIndex != -1)
            {
                var claseTexto = cmbClase.GetItemText(cmbClase.SelectedItem);
                listaFiltrada = listaFiltrada
                    .Where(x => string.Equals(GetMemberString(x, "Clase"), claseTexto, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Order from closest to farthest relative to today
            try
            {
                var hoy = DateOnly.FromDateTime(DateTime.Today);
                listaFiltrada = listaFiltrada
                    .OrderBy(x => Math.Abs((GetMemberDate(x, "Fecha") - hoy).Days))
                    .ToList();
            }
            catch { /* ignore ordering errors, keep original order */ }

            dtgvReservas.DataSource = null; 
            dtgvReservas.DataSource = listaFiltrada;

            // Ocultar columnas internas
            if (dtgvReservas.Columns["IdReserva"] != null) dtgvReservas.Columns["IdReserva"].Visible = false;
            if (dtgvReservas.Columns["IdReservaPadre"] != null) dtgvReservas.Columns["IdReservaPadre"].Visible = false;
            dtgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void CargarComboEstado()
        {
            try
            {
                cmbEstado.DataSource = null;
                cmbEstado.Items.Clear();

                var estados = _controlador.ListarEstadosReserva();

                cmbEstado.DisplayMember = "Descripcion";
                cmbEstado.ValueMember = "IdEstadoReserva";

                cmbEstado.DataSource = estados;
                cmbEstado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando estados: " + ex.Message);
            }
        }

        // Helper: obtiene una propiedad por nombre desde un objeto dinámico de forma segura y la devuelve como string
        private static string GetMemberString(object item, string memberName)
        {
            if (item == null) return string.Empty;

            try
            {
                var type = item.GetType();
                var prop = type.GetProperty(memberName);
                if (prop != null)
                {
                    var val = prop.GetValue(item);
                    return val?.ToString() ?? string.Empty;
                }

                // If it's an IDictionary-like dynamic (ExpandoObject) try that
                if (item is System.Collections.IDictionary dict && dict.Contains(memberName))
                {
                    var v = dict[memberName];
                    return v?.ToString() ?? string.Empty;
                }

                // As a last resort, try to use dynamic binder safely
                try
                {
                    var dyn = item as dynamic;
                    object? maybe = null;
                    try { maybe = dyn.Estado; } catch { }
                    if (maybe != null) return maybe.ToString();
                }
                catch { }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private void dtgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvReservas.CurrentRow == null) return;

            var celdaPadre = dtgvReservas.CurrentRow.Cells["IdReservaPadre"].Value;

            string estado = dtgvReservas.CurrentRow.Cells["Estado"].Value.ToString();

            if (estado == "Cancelada")
            {
                btnCancelarClase.Enabled = false;
                btnCancelarSuscripcion.Enabled = false;
                return;
            }

            btnCancelarClase.Enabled = true;

            if (celdaPadre != null)
            {
                btnCancelarSuscripcion.Enabled = true;
                btnCancelarSuscripcion.BackColor = Color.LightCoral;
            }
            else
            {
                btnCancelarSuscripcion.Enabled = false;
                btnCancelarSuscripcion.BackColor = SystemColors.Control;
            }
        }

        private void btnCancelarClase_Click(object sender, EventArgs e)
        {
            if (dtgvReservas.CurrentRow == null) return;

            int idReserva = (int)dtgvReservas.CurrentRow.Cells["IdReserva"].Value;

            if (MessageBox.Show("¿Seguro que deseas cancelar la clase de este día?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _controlador.DarBajaReservaIndividual(idReserva);
                    ActualizarGrilla();
                    MessageBox.Show("Reserva cancelada.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cancelar la reserva: {ex.Message}");
                }
            }
        }

        private void btnCancelarSuscripcion_Click(object sender, EventArgs e)
        {
            if (dtgvReservas.CurrentRow == null) return;

            var celdaPadre = dtgvReservas.CurrentRow.Cells["IdReservaPadre"].Value;

            if (celdaPadre == null)
            {
                MessageBox.Show("No se puede cancelar la suscripción porque esta clase no forma parte de una suscripción.");
                return;
            }

            int idPadre = (int)celdaPadre;

            if (MessageBox.Show("ATENCIÓN: Esto cancelará TODAS las clases futuras asociadas a esta suscripción.\n¿Está seguro?", "Confirmar Baja Total", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _controlador.DarBajaReservaRecurrente(idPadre);
                    ActualizarGrilla();
                    MessageBox.Show("Suscripción completa dada de baja.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            FormReserva frmAlta = new FormReserva(_idCliente, _nombreCliente);

            if (frmAlta.ShowDialog() == DialogResult.OK)
            {
                ActualizarGrilla();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FormInicio principal = (FormInicio)this.TopLevelControl;
            principal.AbrirFormulario<FormGestionarClientes>();
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarGrilla();

        }

        private void btnBorrarFiltros_Click(object sender, EventArgs e)
        {
            if (cmbEstado.Items.Count > 0)
            {
                cmbEstado.SelectedValue = -1;
            }
            if (cmbClase.Items.Count > 0)
            {
                cmbClase.SelectedIndex = -1;
            }
            FiltrarGrilla();
        }
    }
}

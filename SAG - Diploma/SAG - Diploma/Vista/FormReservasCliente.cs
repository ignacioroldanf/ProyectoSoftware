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

        private void FormReservasCliente_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
            CargarComboEstado();
            SAG___Diploma.Vista.Theme.FuturisticTheme.ApplyToForm(this);
            CargarComboClase();

            // Seguridad: Oculta los botones si el usuario no tiene los permisos
            AplicarSeguridad();
        }

        private void AplicarSeguridad()
        {
            btnNuevaReserva.Visible = Sesion.Instancia.TienePermiso("NuevaReserva");
            btnCancelarClase.Visible = Sesion.Instancia.TienePermiso("CancelarClaseIndividual");
            btnCancelarSuscripcion.Visible = Sesion.Instancia.TienePermiso("CancelarSuscripcionCompleta");
        }

        #region Carga de Datos y Grilla

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

        private void ActualizarGrilla()
        {
            _listaOriginal = _controlador.ObtenerReservasPorCliente(_idCliente);
            FiltrarGrilla();
        }

        private void FiltrarGrilla()
        {
            if (_listaOriginal == null) return;

            var listaFiltrada = _listaOriginal;

            // Filtro por Estado
            if (cmbEstado.SelectedItem != null && cmbEstado.SelectedIndex != -1)
            {
                string estadoSeleccionado = cmbEstado.GetItemText(cmbEstado.SelectedItem);
                listaFiltrada = _listaOriginal
                                .Where(x => string.Equals(ObtenerCadenaPropiedad(x, "Estado"), estadoSeleccionado, StringComparison.OrdinalIgnoreCase))
                                .ToList();
            }

            // Filtro por Clase
            if (cmbClase.SelectedItem != null && cmbClase.SelectedIndex != -1)
            {
                var claseTexto = cmbClase.GetItemText(cmbClase.SelectedItem);
                listaFiltrada = listaFiltrada
                    .Where(x => string.Equals(ObtenerCadenaPropiedad(x, "Clase"), claseTexto, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Ordenar por cercanía a la fecha de hoy
            try
            {
                var hoy = DateOnly.FromDateTime(DateTime.Today);
                listaFiltrada = listaFiltrada
                    .OrderBy(x => Math.Abs((ObtenerFechaPropiedad(x, "Fecha") - hoy).Days))
                    .ToList();
            }
            catch { /* Si falla el ordenamiento, mantiene el original */ }

            dtgvReservas.DataSource = null;
            dtgvReservas.DataSource = listaFiltrada;

            // Ocultar columnas internas
            if (dtgvReservas.Columns["IdReserva"] != null) dtgvReservas.Columns["IdReserva"].Visible = false;
            if (dtgvReservas.Columns["IdReservaPadre"] != null) dtgvReservas.Columns["IdReservaPadre"].Visible = false;
            dtgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #endregion

        #region Métodos de Ayuda (Reflexión)

        // Traducción y limpieza del GetMemberDate
        private static DateOnly ObtenerFechaPropiedad(object objeto, string nombrePropiedad)
        {
            try
            {
                var tipo = objeto.GetType();
                var propiedad = tipo.GetProperty(nombrePropiedad);

                if (propiedad != null)
                {
                    var valor = propiedad.GetValue(objeto);
                    if (valor is DateOnly d) return d;
                    if (valor is DateTime dt) return DateOnly.FromDateTime(dt);
                    if (DateOnly.TryParse(valor?.ToString(), out var fechaParseada)) return fechaParseada;
                }

                if (objeto is System.Collections.IDictionary diccionario && diccionario.Contains(nombrePropiedad))
                {
                    var valor = diccionario[nombrePropiedad];
                    if (valor is DateOnly dd) return dd;
                    if (valor is DateTime dtt) return DateOnly.FromDateTime(dtt);
                    if (DateOnly.TryParse(valor?.ToString(), out var fechaParseada2)) return fechaParseada2;
                }
            }
            catch { }
            return DateOnly.FromDateTime(DateTime.MaxValue);
        }

        // Traducción y limpieza del GetMemberString (se eliminó código basura)
        private static string ObtenerCadenaPropiedad(object objeto, string nombrePropiedad)
        {
            if (objeto == null) return string.Empty;

            try
            {
                var tipo = objeto.GetType();
                var propiedad = tipo.GetProperty(nombrePropiedad);

                if (propiedad != null)
                {
                    var valor = propiedad.GetValue(objeto);
                    return valor?.ToString() ?? string.Empty;
                }

                if (objeto is System.Collections.IDictionary diccionario && diccionario.Contains(nombrePropiedad))
                {
                    var valor = diccionario[nombrePropiedad];
                    return valor?.ToString() ?? string.Empty;
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion

        #region Eventos de Botones y Grilla

        private void dtgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvReservas.CurrentRow == null) return;

            var celdaPadre = dtgvReservas.CurrentRow.Cells["IdReservaPadre"].Value;
            string estado = dtgvReservas.CurrentRow.Cells["Estado"].Value.ToString();

            // Lógica de habilitación de botones (Seguro porque si el usuario no tiene permisos, 
            // el botón directamente está INVISIBLE gracias a AplicarSeguridad)
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }

        private void btnBorrarFiltros_Click(object sender, EventArgs e)
        {
            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedValue = -1;
            if (cmbClase.Items.Count > 0) cmbClase.SelectedIndex = -1;

            FiltrarGrilla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FormInicio principal = (FormInicio)this.TopLevelControl;
            principal.AbrirFormulario<FormGestionarClientes>();
            this.Close();
        }

        #endregion
    }
}
using Controlador;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Modelo;
using Modelo.Modelo;
using SAG___Diploma.Vista.Theme;
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
    public partial class FormGestionarRutinas : Form
    {
        private readonly DiplomaContext _context;
        private readonly CtrlGestionarRutinasyProgresos _controlador;
        private readonly CtrlGestionarClientes _ctrlClientes;

        public FormGestionarRutinas()
        {
            InitializeComponent();
            _context = new DiplomaContext();
            _controlador = new CtrlGestionarRutinasyProgresos(_context);
            _ctrlClientes = new CtrlGestionarClientes(_context);
        }

        private void CargarClientesPremium()
        {
            var clientesPremium = _context.Clientes
                .Include(c => c.IdPersonaNavigation)
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdEstadoSuscripcionNavigation)
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdPlanNavigation)
                .Where(c => c.Suscripciones.Any(s => s.IdEstadoSuscripcionNavigation.Descripcion == "Vigente"))
                .Select(c => new
                {
                    ID = c.IdCliente,
                    DNI = c.IdPersonaNavigation.Dni,
                    Nombre = c.IdPersonaNavigation != null ? c.IdPersonaNavigation.Nombre : "",
                    Apellido = c.IdPersonaNavigation != null ? c.IdPersonaNavigation.Apellido : "",
                })
                .ToList();
            dtgvClientesPremium.DataSource = clientesPremium;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void AplicarSeguridad()
        {
            btnConsultarRutina.Visible = Sesion.Instancia.TienePermiso("ConsultarRutina");
            btnCrearRutina.Visible = Sesion.Instancia.TienePermiso("CrearRutina");
            btnModificar.Visible = Sesion.Instancia.TienePermiso("ModificarRutina");

            btnRegistrar.Visible = Sesion.Instancia.TienePermiso("RegistrarProgreso");
            btnConsultarHistorial.Visible = Sesion.Instancia.TienePermiso("ConsultarHistorial");
        }

        private void FormGestionarRutinas_Load(object sender, EventArgs e)
        {
            dtgvClientesPremium.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvClientesPremium.MultiSelect = false;

            CargarClientesPremium();

            FuturisticTheme.ApplyToForm(this);
            AplicarSeguridad();
        }

        private void btnCrearRutina_Click(object sender, EventArgs e)
        {
            if (dtgvClientesPremium.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            int idCliente = Convert.ToInt32(dtgvClientesPremium.CurrentRow.Cells["ID"].Value);

            var rutinaExistente = _controlador.ConsultarRutinaActual(idCliente);
            if (rutinaExistente != null)
            {
                var rta = MessageBox.Show(
                    "El cliente ya tiene una rutina asignada. \n¿Desea crear una nueva rutina de todas formas?",
                    "Cliente con rutina existente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );
                if (rta == DialogResult.No) return;
            }

            using FormCantDias formDias = new FormCantDias();
            if (formDias.ShowDialog() != DialogResult.OK) return;

            int dias = formDias.CantDiasSeleccionada;

            var rutina = _controlador.CrearRutina(idCliente, dias);

            if (rutina == null)
            {
                MessageBox.Show("No se pudo crear la rutina.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormRutinas formRutina = new FormRutinas(rutina, _controlador, false);

            FormInicio principal = (FormInicio)this.TopLevelControl;
            principal.AbrirFormularioPanel(formRutina);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgvClientesPremium.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            int idCliente = Convert.ToInt32(dtgvClientesPremium.CurrentRow.Cells["ID"].Value);
            var rutina = _controlador.ConsultarRutinaActual(idCliente);

            if (rutina == null)
            {
                MessageBox.Show("El cliente no tiene una rutina asignada.");
                return;
            }

            FormRutinas frmRutinas = new FormRutinas(rutina, _controlador, false);

            FormInicio principal = (FormInicio)this.TopLevelControl;
            principal.AbrirFormularioPanel(frmRutinas);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (dtgvClientesPremium.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            int idCliente = Convert.ToInt32(dtgvClientesPremium.CurrentRow.Cells["ID"].Value);

            var rutina = _controlador.ConsultarRutinaActual(idCliente);
            if (rutina == null)
            {
                MessageBox.Show("El cliente seleccionado no tiene una rutina asignada.\nNo se pueden registrar progresos.", "Sin Rutina", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Modo edición
            FormGestionarProgresos formProgresos = new FormGestionarProgresos(_controlador, idCliente, false);

            FormInicio principal = (FormInicio)this.TopLevelControl;
            principal.AbrirFormularioPanel(formProgresos);
        }

        private void btnConsultarHistorial_Click(object sender, EventArgs e)
        {
            if (dtgvClientesPremium.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            int idCliente = Convert.ToInt32(dtgvClientesPremium.CurrentRow.Cells["ID"].Value);

            var rutina = _controlador.ConsultarRutinaActual(idCliente);
            if (rutina == null)
            {
                MessageBox.Show("El cliente seleccionado no tiene historial de rutinas activas.", "Sin Rutina", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }

            // Modo lectura
            FormGestionarProgresos formProgresos = new FormGestionarProgresos(_controlador, idCliente, true);

            FormInicio principal = (FormInicio)this.TopLevelControl;
            principal.AbrirFormularioPanel(formProgresos);
        }

        private void btnConsultarRutina_Click(object sender, EventArgs e)
        {
            if (dtgvClientesPremium.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            int idCliente = Convert.ToInt32(dtgvClientesPremium.CurrentRow.Cells["ID"].Value);
            var rutina = _controlador.ConsultarRutinaActual(idCliente);

            if (rutina == null)
            {
                MessageBox.Show("El cliente no tiene una rutina asignada.");
                return;
            }

            // Modo lectura
            FormRutinas frmRutinas = new FormRutinas(rutina, _controlador, true);

            FormInicio principal = (FormInicio)this.TopLevelControl;
            principal.AbrirFormularioPanel(frmRutinas);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int dni = Convert.ToInt32(txtFiltrar.Text.Trim());

                var clientesFiltrados = _ctrlClientes.FiltrarClientesPremiumPorDNI(dni);

                var listadoGrilla = clientesFiltrados.Select(c => new
                {
                    ID = c.IdCliente,
                    DNI = c.IdPersonaNavigation.Dni,
                    Nombre = c.IdPersonaNavigation.Nombre,
                    Apellido = c.IdPersonaNavigation.Apellido,
                }).ToList();

                if (listadoGrilla.Count > 0)
                {
                    dtgvClientesPremium.DataSource = listadoGrilla;
                }
                else
                {
                    MessageBox.Show("No se encontró ningún cliente Premium Vigente con ese DNI.");
                    dtgvClientesPremium.DataSource = null;
                }

            txtFiltrar.Text = "";

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarClientesPremium();
            txtFiltrar.Text = "";
        }
    }
}

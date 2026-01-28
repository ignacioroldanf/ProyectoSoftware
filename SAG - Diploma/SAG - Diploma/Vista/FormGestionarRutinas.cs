using Controlador;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
    public partial class FormGestionarRutinas : Form
    {
        private readonly DiplomaContext _context;
        private readonly CtrlGestionarRutinasyProgresos _controlador;

        public FormGestionarRutinas()
        {
            InitializeComponent();
            _context = new DiplomaContext();
            _controlador = new CtrlGestionarRutinasyProgresos(_context);
        }

        public void CargarClientesPremium()
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
                    DNI = c.IdPersonaNavigation != null ? c.IdPersonaNavigation.Dni : "",
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

        private void FormGestionarRutinas_Load(object sender, EventArgs e)
        {
            dtgvClientesPremium.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvClientesPremium.MultiSelect = false;

            CargarClientesPremium();
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
            if(formDias.ShowDialog() != DialogResult.OK) return;

            int dias = formDias.CantDiasSeleccionada;
            
            var rutina = _controlador.CrearRutina(idCliente, dias);

            if(rutina == null)
            {
                MessageBox.Show("No se pudo crear la rutina.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            FormRutinas formRutina = new FormRutinas(rutina, _controlador, false);
            formRutina.ShowDialog();
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
            frmRutinas.ShowDialog();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (dtgvClientesPremium.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            int idCliente = Convert.ToInt32(dtgvClientesPremium.CurrentRow.Cells["ID"].Value);

            // Modo edición
            FormGestionarProgresos formProgresos = new FormGestionarProgresos(_controlador, idCliente, false);
            formProgresos.ShowDialog();
        }

        private void btnConsultarHistorial_Click(object sender, EventArgs e)
        {
            if (dtgvClientesPremium.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            int idCliente = Convert.ToInt32(dtgvClientesPremium.CurrentRow.Cells["ID"].Value);

            // Modo lectura
            FormGestionarProgresos formProgresos = new FormGestionarProgresos(_controlador, idCliente, true);
            formProgresos.ShowDialog();
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
            frmRutinas.ShowDialog();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

        }
    }
}

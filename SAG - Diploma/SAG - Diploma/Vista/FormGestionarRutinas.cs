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
        DiplomaContext context = new DiplomaContext();
        
        private readonly CtrlGestionarRutinasyProgresos _controlador;
        
        public FormGestionarRutinas()
        {
            InitializeComponent();
            _controlador = new CtrlGestionarRutinasyProgresos(new DiplomaContext());
        }

        public void CargarClientesPremium()
        {
            var clientesPremium = context.Clientes
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdEstadoSuscripcionNavigation)
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdPlanNavigation)
                .Where(c => c.Suscripciones.Any(s => s.IdEstadoSuscripcionNavigation.Descripcion == "Vigente"))
                .Select(c => new
                {
                    ID = c.IdCliente,
                    DNI = c.DniCliente,
                    Nombre = c.NombreCliente,
                    Apellido = c.ApellidoCliente
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

            using FormCantDias formDias = new FormCantDias();

            if (formDias.ShowDialog() != DialogResult.OK) return;

            int dias = formDias.CantDiasSeleccionada;

            var rutina = _controlador.CrearRutina(idCliente, dias);

            if (rutina == null)
            {
                MessageBox.Show("no se pudo crear");
                return;
            }

            FormRutinas frmRutinas = new FormRutinas(rutina, _controlador, false);
            frmRutinas.ShowDialog();
        }


    }
}

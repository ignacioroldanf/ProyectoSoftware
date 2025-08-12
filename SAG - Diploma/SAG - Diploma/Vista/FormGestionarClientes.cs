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
    public partial class FormGestionarClientes : Form
    {
        DiplomaContext context = new DiplomaContext();
        private readonly CtrlGestionarClientes _controladorCliente;

        public FormGestionarClientes()
        {
            InitializeComponent();
            _controladorCliente = new CtrlGestionarClientes(new DiplomaContext());
        }
        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        public void CargarClientes()
        {
            var clientes = context.Clientes
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdEstadoSuscripcionNavigation)
                .Include(c => c.Suscripciones)
                    .ThenInclude(s => s.IdPlanNavigation)
                .Select(c => new
                {
                    ID = c.IdCliente,
                    DNI = c.DniCliente,
                    Nombre = c.NombreCliente,
                    Apellido = c.ApellidoCliente,
                    Fecha_Alta = c.FechaAlta
                })
                .ToList();
            dtgvClientes.DataSource = clientes;
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            FormCliente vistaCliente = new FormCliente();

            if (vistaCliente.ShowDialog() == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        private void FormGestionarClientes_Load(object sender, EventArgs e)
        {
            dtgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvClientes.MultiSelect = false;

            CargarClientes();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (dtgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un cliente para modificar.");
                return;
            }

            int clienteId = (int)dtgvClientes.SelectedRows[0].Cells["Id"].Value;
            Cliente ClienteSeleccionado = _controladorCliente.BuscarPorID(clienteId);

            FormCliente vistaCliente = new FormCliente();
            vistaCliente.CargarCliente(ClienteSeleccionado);

            if (vistaCliente.ShowDialog() == DialogResult.OK)
            {
                CargarClientes();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgvClientes.SelectedRows.Count > 0)
            {

                int clienteId = (int)dtgvClientes.SelectedRows[0].Cells["Id"].Value;
                var resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    _controladorCliente.EliminarCliente(clienteId);
                    CargarClientes();
                    MessageBox.Show("Cliente eliminado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
            }
        }

        private void btnAsignarSuscripcion_Click(object sender, EventArgs e)
        {

        }
    }
}

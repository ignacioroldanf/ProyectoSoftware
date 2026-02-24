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
    public partial class FormGestionarPlanes : Form
    {
        private readonly CtrlGestionarPlanes _controladorPlanes;
        DiplomaContext _context = new DiplomaContext();
        public bool ModoAsignacion { get; set; } = false;
        private Cliente _clienteSeleccionado;


        public FormGestionarPlanes()
        {
            InitializeComponent();
            _controladorPlanes = new CtrlGestionarPlanes(_context);
        }
        public void IniciarModoAsignacion(Cliente cliente)
        {
            ModoAsignacion = true;
            _clienteSeleccionado = cliente;
        }

        private void FormGestionarPlanes_Load(object sender, EventArgs e)
        {
            CargarPlanes();
            AplicarSeguridad();
        }

        private void CargarPlanes()
        {
            var planes = _controladorPlanes.Listar()
                .Select(p => new
                {
                    p.IdPlan,
                    p.NombrePlan,
                    p.DuracionMeses,
                    Soporte = p.Soporte == true ? "Sí" : "No",
                    p.PrecioMensual,
                    p.DescripPlan
                })
                .ToList();

            dtgvPlanes.DataSource = planes;
        }
        private void AplicarSeguridad()
        {
            btnAgregar.Visible = Sesion.Instancia.TienePermiso("AgregarPlan");
            btnModificar.Visible = Sesion.Instancia.TienePermiso("ModificarPrecio");
            btnEliminar.Visible = Sesion.Instancia.TienePermiso("EliminarPlan");
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormPlan formPlan = new FormPlan();
            if (formPlan.ShowDialog() == DialogResult.OK)
            {
                _controladorPlanes.AgregarPlan(formPlan.PlanEditado);
                CargarPlanes();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgvPlanes.CurrentRow != null)
            {
                int id = (int)dtgvPlanes.CurrentRow.Cells["IdPlan"].Value;
                var planExistente = _controladorPlanes.Listar().FirstOrDefault(p => p.IdPlan == id);

                if (planExistente != null)
                {
                    FormPlan formPlan = new FormPlan(planExistente);
                    if (formPlan.ShowDialog() == DialogResult.OK)
                    {
                        _controladorPlanes.ModificarPrecio(formPlan.PlanEditado);
                        CargarPlanes();
                    }
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgvPlanes.CurrentRow != null)
            {
                int id = (int)dtgvPlanes.CurrentRow.Cells["IdPlan"].Value;

                if (MessageBox.Show("¿Está seguro de eliminar este plan?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _controladorPlanes.EliminarPlan(id);
                    CargarPlanes();
                }
            }
        }
    }
}


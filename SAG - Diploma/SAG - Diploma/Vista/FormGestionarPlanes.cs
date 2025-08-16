using Controlador;
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
        }
        public void IniciarModoAsignacion(Cliente cliente)
        {
            ModoAsignacion = true;
            _clienteSeleccionado = cliente;
        }

        private void FormGestionarPlanes_Load(object sender, EventArgs e)
        {
            CargarPlanes();

            if (ModoAsignacion)
            {
                btnAgregar.Visible = false;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
                btnAsignar.Visible = true; // Este botón lo agregás para asignar
            }
            else
            {
                btnAsignar.Visible = false;
            }
        }

        public void CargarPlanes()
        {
            var planes = _context.Planes
                .Select(c => new
                {
                    ID = c.IdPlan,
                    Nombre = c.NombrePlan,
                    Duracion = c.DuracionMeses,
                    PrecioMensual = c.PrecioMensual,
                    Soporte = c.Soporte,
                    Descripcion = c.DescripPlan
                })
                .ToList();
            dtgvPlanes.DataSource = planes;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormPlan vistaPlan = new FormPlan();
            vistaPlan.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}


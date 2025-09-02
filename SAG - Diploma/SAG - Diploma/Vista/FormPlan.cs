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
    public partial class FormPlan : Form
    {
        public Plane PlanEditado { get; private set; }
        private bool _esModificacion;



        private readonly CtrlGestionarPlanes _controlador;
        public FormPlan()
        {
            InitializeComponent();
            PlanEditado = new Plane();
            _esModificacion = false;
        }

        public FormPlan(Plane planExistente) : this()
        {
            if (planExistente != null)
            {
                PlanEditado = planExistente;
                txtNombre.Text = planExistente.NombrePlan;
                nudDuracion.Value = planExistente.DuracionMeses;
                chkSoporte.Checked = planExistente.Soporte ?? false;
                txtPrecio.Text = planExistente.PrecioMensual?.ToString() ?? string.Empty;
                txtDescripcion.Text = planExistente.DescripPlan;
            }
            txtNombre.Text = PlanEditado.NombrePlan;
            nudDuracion.Value = PlanEditado.DuracionMeses;
            chkSoporte.Checked = PlanEditado.Soporte ?? false;
            txtPrecio.Text = PlanEditado.PrecioMensual?.ToString("0.00");
            txtDescripcion.Text = PlanEditado.DescripPlan;

            txtNombre.Enabled = false;
            nudDuracion.Enabled = false;
            chkSoporte.Enabled = false;
            txtDescripcion.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormPlan_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_esModificacion)
                {
                    PlanEditado.NombrePlan = txtNombre.Text;
                    PlanEditado.DuracionMeses = (int)nudDuracion.Value;
                    PlanEditado.Soporte = chkSoporte.Checked;
                    PlanEditado.DescripPlan = txtDescripcion.Text;
                }

                PlanEditado.PrecioMensual = decimal.Parse(txtPrecio.Text);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

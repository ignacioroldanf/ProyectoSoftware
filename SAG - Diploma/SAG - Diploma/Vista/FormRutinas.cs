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
    public partial class FormRutinas : Form
    {
        private readonly Rutina _rutina;
        private readonly CtrlGestionarRutinasyProgresos _controlador;
        private readonly bool _modoLectura;

        public FormRutinas(Rutina rutina, CtrlGestionarRutinasyProgresos controlador, bool modoLectura = false)
        {
            InitializeComponent();
            _rutina = rutina;
            _controlador = controlador;
            _modoLectura = modoLectura;
        }

        private void FormRutinas_Load(object sender, EventArgs e)
        {
            cmbDia.Items.Clear();
            foreach (var dia in _rutina.DiasRutinas.OrderBy(d => d.NumeroDia))
                cmbDia.Items.Add($"Día {dia.NumeroDia}");

            if (cmbDia.Items.Count > 0)
                cmbDia.SelectedIndex = 0;

            if (_modoLectura)
            {
                btnAgregar.Enabled = false;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void cmbDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int diaSeleccionado = cmbDia.SelectedIndex + 1;
            var dia = _rutina.DiasRutinas.FirstOrDefault(d => d.NumeroDia == diaSeleccionado);

            if (dia == null) return;

            dtgvEjercicios.DataSource = dia.EjerciciosAsignados.Select(ea => new
            {
                ID = ea.IdEjercicioAsignado,
                Ejercicio = ea.IdEjercicioNavigation?.NombreEjercicio,
                Series = ea.Series,
                Repeticiones = ea.Repeticiones,
                Peso = ea.Peso,
                Orden = ea.Orden
            }).ToList();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

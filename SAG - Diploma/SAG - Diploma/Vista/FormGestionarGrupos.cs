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
    public partial class FormGestionarGrupos : Form
    {
        private CtrlGestionarGrupos _controlador;
        public FormGestionarGrupos()
        {
            InitializeComponent();
            _controlador = new CtrlGestionarGrupos(new DiplomaContext());
        }

        private void FormGestionarGrupos_Load(object sender, EventArgs e)
        {
            CargarGrupos();
            AplicarSeguridad();
        }

        private void CargarGrupos()
        {
            var grupos = _controlador.ListarGrupos();

            var lista = grupos.Select(g => new
            {
                g.IdGrupo,
                g.NombreGrupo,
                g.Descripcion,
                Estado = g.IdEstadoGrupoNavigation.Descripcion
            }).ToList();

            dtgvGrupos.DataSource = lista;
        }
        private void AplicarSeguridad()
        {
            bool puedeGestionar = Sesion.Instancia.TienePermiso("GestionarRoles");

            btnAgregar.Visible = puedeGestionar;
            btnModificar.Visible = puedeGestionar;
            btnEliminar.Visible = puedeGestionar;

         }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormGrupo formGrupo = new FormGrupo(null);

            if (formGrupo.ShowDialog() == DialogResult.OK)
            {
                CargarGrupos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgvGrupos.CurrentRow == null) return;

            int id = (int)dtgvGrupos.CurrentRow.Cells["IdGrupo"].Value;

            FormGrupo frm = new FormGrupo(id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarGrupos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgvGrupos.CurrentRow == null) return;

            int id = (int)dtgvGrupos.CurrentRow.Cells["IdGrupo"].Value;
            var confirm = MessageBox.Show("¿Seguro que desea dar de baja este grupo?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _controlador.EliminarGrupo(id);
                    CargarGrupos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

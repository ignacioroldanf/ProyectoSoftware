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
    public partial class FormGestionarUsuarios : Form
    {
        private CtrlGestionarUsuarios _controlador;

        private List<Usuario> _listaOriginal;

        public FormGestionarUsuarios()
        {
            InitializeComponent();
            _controlador = new CtrlGestionarUsuarios(new DiplomaContext());
            dtgvUsuarios.AutoGenerateColumns = true;
        }


        private void FormGestionarUsuarios_Load(object sender, EventArgs e)
        {
            CargarCombosFiltro();
            CargarUsuarios();
        }

        // 1. CONFIGURACIÓN VISUAL

        private void CargarCombosFiltro()
        {
            var listaEstados = _controlador.ListarEstados();

            EstadoUsuario opcionTodos = new EstadoUsuario
            {
                IdEstadoUsuario = -1,
                Descripcion = "Todos"
            };

            listaEstados.Insert(0, opcionTodos);

            cmbEstado.DataSource = listaEstados;
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "IdEstadoUsuario";

            cmbEstado.SelectedValue = -1;
        }
        private void CargarUsuarios()
        {
            try
            {
                _listaOriginal = _controlador.ListarUsuarios();

                var listaVisual = _listaOriginal.Select(u => new
                {
                    Id = u.IdUsuario,                
                    Usuario = u.NombreUsuario,       
                    Nombre = u.IdPersonaNavigation != null
                             ? $"{u.IdPersonaNavigation.Apellido}, {u.IdPersonaNavigation.Nombre}"
                             : "-",                  
                    Email = u.IdPersonaNavigation != null ? u.IdPersonaNavigation.Email : "-", 
                    Estado = u.IdEstadoUsuarioNavigation != null ? u.IdEstadoUsuarioNavigation.Descripcion : "-" 
                }).ToList();

                dtgvUsuarios.DataSource = listaVisual;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FiltrarGrilla()
        {
            if (_listaOriginal == null) return;

            var listaFiltrada = _listaOriginal;


            if (cmbEstado.SelectedValue != null && int.TryParse(cmbEstado.SelectedValue.ToString(), out int idEstado))
            {
                if (idEstado != -1)
                {
                    listaFiltrada = listaFiltrada.Where(u => u.IdEstadoUsuario == idEstado).ToList();
                }
            }

            var listaVisual = listaFiltrada.Select(u => new
            {
                Id = u.IdUsuario,
                Usuario = u.NombreUsuario,
                Nombre = u.IdPersonaNavigation != null
                         ? $"{u.IdPersonaNavigation.Apellido}, {u.IdPersonaNavigation.Nombre}"
                         : "-",
                Email = u.IdPersonaNavigation != null ? u.IdPersonaNavigation.Email : "-",
                Estado = u.IdEstadoUsuarioNavigation != null ? u.IdEstadoUsuarioNavigation.Descripcion : "-"
            }).ToList();

            dtgvUsuarios.DataSource = listaVisual;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormUsuario frm = new FormUsuario();
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario para modificar.");
                return;
            }

            int id = (int)dtgvUsuarios.CurrentRow.Cells["Id"].Value;

            FormUsuario frm = new FormUsuario(id);

            if(frm.ShowDialog() == DialogResult.OK)
            {
                _listaOriginal = _controlador.ListarUsuarios();

                FiltrarGrilla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
                return;
            }

            int id = (int)dtgvUsuarios.CurrentRow.Cells["Id"].Value;
            string nombre = dtgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
            string estado = dtgvUsuarios.CurrentRow.Cells["Estado"].Value.ToString();

            if (estado == "Baja" || estado == "Inactivo") 
            {
                MessageBox.Show("El usuario ya se encuentra inactivo.");
                return;
            }

            if (MessageBox.Show($"¿Está seguro que desea desactivar al usuario '{nombre}'?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _controlador.DesactivarUsuario(id);
                    CargarUsuarios(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            if (dtgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario para resetear su clave.");
                return;
            }
            int id = (int)dtgvUsuarios.CurrentRow.Cells["Id"].Value;
            string nombre = dtgvUsuarios.CurrentRow.Cells["Usuario"].Value.ToString();

            if (MessageBox.Show($"¿Desea restablecer la contraseña del usuario '{nombre}'?", "Resetear Clave", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string claveSugerida = Seguridad.GenerarClaveAleatoria();

                    FormContra frm = new FormContra(claveSugerida);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string claveFinal = frm.ClaveFinal;
                        _controlador.GuardarNuevaClave(id, claveFinal);

                        MessageBox.Show("La contraseña ha sido actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al resetear clave: " + ex.Message);
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }

        private void btnBorrarFiltros_Click(object sender, EventArgs e)
        {
            if (cmbEstado.Items.Count > 0)
            {
                cmbEstado.SelectedValue = -1; 
            }
            FiltrarGrilla();
        }
    }
}

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
    public partial class FormUsuario : Form
    {
        private CtrlGestionarUsuarios _ctrlUsuarios;
        private CtrlGestionarGrupos _ctrlGrupos;
        private int? _idUsuario;
        private Usuario _usuarioActual;

        public FormUsuario(int? idUsuario)
        {
            InitializeComponent();
            _ctrlUsuarios = new CtrlGestionarUsuarios(new DiplomaContext());
            _ctrlGrupos = new CtrlGestionarGrupos(new DiplomaContext());
            _idUsuario = idUsuario;
        }

        public FormUsuario() : this(null)
        {
        }


        private void FormUsuario_Load(object sender, EventArgs e)
        {
            CargarListaGrupos();
            CargarArbolAcciones();

            if (_idUsuario.HasValue)
            {
                this.Text = "Modificar Usuario";
                txtUsuario.Enabled = false;
                CargarDatosUsuario(_idUsuario.Value);
            }
            else
            {
                this.Text = "Nuevo Usuario";
            }
        }

        private void CargarListaGrupos()
        {
            var grupos = _ctrlGrupos.ListarGrupos().Where(g => g.IdEstadoGrupo == 1).ToList();
            clbGrupos.DataSource = grupos;
            clbGrupos.DisplayMember = "NombreGrupo";
            clbGrupos.ValueMember = "IdGrupo";
        }

        private void CargarArbolAcciones()
        {
            tvAccion.Nodes.Clear();
            var todasLasAcciones = _ctrlGrupos.ListarAcciones();

            // DEBUG: Si esto salta, es que la base de datos está vacía
            if (todasLasAcciones.Count == 0) return;

            // 1. Agrupar por MÓDULO (Nivel 1)
            var accionesPorModulo = todasLasAcciones
                .GroupBy(a => a.IdFormularioNavigation?.IdModuloNavigation?.NombreModulo ?? "Módulos Generales")
                .OrderBy(g => g.Key);

            foreach (var grupoModulo in accionesPorModulo)
            {
                TreeNode nodoModulo = new TreeNode(grupoModulo.Key);

                // 2. Agrupar por FORMULARIO (Nivel 2)
                var accionesPorFormulario = grupoModulo
                    .GroupBy(a => a.IdFormularioNavigation?.NombreFormulario ?? "Acciones Sueltas")
                    .OrderBy(g => g.Key);

                foreach (var grupoForm in accionesPorFormulario)
                {
                    TreeNode nodoFormulario = new TreeNode(grupoForm.Key);

                    // 3. ACCIONES (Nivel 3)
                    foreach (var accion in grupoForm)
                    {
                        TreeNode nodoAccion = new TreeNode(accion.NombreAccion);
                        nodoAccion.Tag = accion.IdAccion; // <--- VITAL PARA GUARDAR

                        // Si quieres que el checkbox aparezca marcado por defecto en algún caso, va aquí.

                        nodoFormulario.Nodes.Add(nodoAccion);
                    }
                    nodoModulo.Nodes.Add(nodoFormulario);
                }
                tvAccion.Nodes.Add(nodoModulo);
            }

            // Expandir todo para ver si cargó
            tvAccion.ExpandAll();
        }

        private void CargarDatosUsuario(int id)
        {
            using (var db = new DiplomaContext())
            {
                _usuarioActual = db.Usuarios
                                   .Include(u => u.IdPersonaNavigation) 
                                   .FirstOrDefault(u => u.IdUsuario == id);
            }

            if (_usuarioActual != null)
            {
                txtUsuario.Text = _usuarioActual.NombreUsuario;

                if (_usuarioActual.IdPersonaNavigation != null)
                {
                    txtNombre.Text = _usuarioActual.IdPersonaNavigation.Nombre;
                    txtApellido.Text = _usuarioActual.IdPersonaNavigation.Apellido;
                    txtDNI.Text = _usuarioActual.IdPersonaNavigation.Dni.ToString();
                    txtEmail.Text = _usuarioActual.IdPersonaNavigation.Email;
                }

                var gruposDelUser = _ctrlUsuarios.ObtenerGruposDelUsuario(id);
                var idsGrupos = gruposDelUser.Select(g => g.IdGrupo).ToList();

                for (int i = 0; i < clbGrupos.Items.Count; i++)
                {
                    var item = (Grupo)clbGrupos.Items[i];
                    if (idsGrupos.Contains(item.IdGrupo))
                    {
                        clbGrupos.SetItemChecked(i, true);
                    }
                }

                MarcarArbolUsuario(id);
            }
        }
        private void MarcarArbolUsuario(int idUsuario)
        {
            var accionesUser = _ctrlUsuarios.ObtenerAccionesDelUsuario(idUsuario);
            var idsQueTiene = accionesUser.Select(a => a.IdAccion).ToList();

            foreach (TreeNode nodoModulo in tvAccion.Nodes)
            {
                foreach (TreeNode nodoFormulario in nodoModulo.Nodes)
                {
                    foreach (TreeNode nodoAccion in nodoFormulario.Nodes)
                    {
                        if (nodoAccion.Tag != null && idsQueTiene.Contains((int)nodoAccion.Tag))
                        {
                            nodoAccion.Checked = true;
                            nodoFormulario.Expand();
                            nodoModulo.Expand();
                        }
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("Complete los datos.");
                    return;
                }

                // --- CASO 1: USUARIO NUEVO ---
                if (_idUsuario == null)
                {
                    // 1. Generamos la aleatoria primero
                    string clavePropuesta = Seguridad.GenerarClaveAleatoria();

                    // 2. Abrimos el Dialogo para que el usuario la vea/copie/cambie
                    FormContra frmClave = new FormContra(clavePropuesta);

                    if (frmClave.ShowDialog() != DialogResult.OK)
                    {
                        return; // Si cancela, no guardamos nada
                    }

                    // 3. Obtenemos la clave final (sea la aleatoria o la manual)
                    string claveFinal = frmClave.ClaveFinal;

                    // 4. Creamos el objeto
                    Usuario nuevo = new Usuario();
                    nuevo.NombreUsuario = txtUsuario.Text;

                    nuevo.IdPersonaNavigation = new Persona();
                    nuevo.IdPersonaNavigation.Nombre = txtNombre.Text;
                    nuevo.IdPersonaNavigation.Apellido = txtApellido.Text;
                    nuevo.IdPersonaNavigation.Dni = Convert.ToInt32(txtDNI.Text);
                    nuevo.IdPersonaNavigation.Email = txtEmail.Text;

                    // 5. Guardamos pasando la clave final
                    _ctrlUsuarios.AgregarUsuario(nuevo, claveFinal);

                    _usuarioActual = nuevo;

                    // Ya no hace falta mostrar el MessageBox con la clave aquí 
                    // porque el usuario ya la copió en el paso 2.
                    MessageBox.Show("Usuario creado correctamente.");
                }
                // --- CASO 2: MODIFICAR ---
                else
                {
                    // (El código de modificar queda IGUAL que antes, no toca la clave)
                    _usuarioActual.NombreUsuario = txtUsuario.Text;
                    // ... actualizar persona ...
                    _ctrlUsuarios.ModificarUsuario(_usuarioActual);
                }

                // --- GUARDADO DE GRUPOS Y PERMISOS (Igual que antes) ---
                List<int> idsGrupos = new List<int>();
                foreach (Grupo g in clbGrupos.CheckedItems) idsGrupos.Add(g.IdGrupo);
                _ctrlUsuarios.GuardarGruposUsuario(_usuarioActual.IdUsuario, idsGrupos);

                List<int> idsAcciones = new List<int>();
                // ... (tu lógica de recorrer treeview) ...
                // ... (llenar idsAcciones) ...
                _ctrlUsuarios.GuardarPermisosDelUsuario(_usuarioActual.IdUsuario, idsAcciones);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

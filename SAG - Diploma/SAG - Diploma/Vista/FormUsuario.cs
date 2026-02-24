using Controlador;
using Microsoft.EntityFrameworkCore;
using Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
            var listaEstados = _ctrlUsuarios.ListarEstados();
            comboBox1.DataSource = listaEstados;
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "IdEstadoUsuario";

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
            clbGrupos.ItemCheck += new ItemCheckEventHandler(clbGrupos_ItemCheck);
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
                        nodoFormulario.Nodes.Add(nodoAccion);
                    }
                    nodoModulo.Nodes.Add(nodoFormulario);
                }
                tvAccion.Nodes.Add(nodoModulo);
            }

            tvAccion.ExpandAll();
            if (tvAccion.Nodes.Count > 0) tvAccion.Nodes[0].EnsureVisible();
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
                    comboBox1.SelectedValue = _usuarioActual.IdEstadoUsuario;
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
            _validando = true;

            try
            {

                foreach (TreeNode n1 in tvAccion.Nodes)
                {
                    n1.Checked = false;
                    foreach (TreeNode n2 in n1.Nodes)
                    {
                        n2.Checked = false;
                        foreach (TreeNode n3 in n2.Nodes)
                        {
                            n3.Checked = false;
                            n3.ForeColor = Color.Black;
                            n3.NodeFont = new Font(tvAccion.Font, FontStyle.Regular);
                        }
                    }
                }


                var accionesDirectas = _ctrlUsuarios.ObtenerAccionesDelUsuario(idUsuario);
                var idsDirectos = accionesDirectas.Select(a => a.IdAccion).ToList();

                List<int> idsHeredados = new List<int>();
                foreach (var item in clbGrupos.CheckedItems)
                {
                    Grupo g = (Grupo)item;
                    var accionesDelGrupo = _ctrlGrupos.ListarAccionesPorGrupo(g.IdGrupo);
                    idsHeredados.AddRange(accionesDelGrupo.Select(a => a.IdAccion));
                }

                foreach (TreeNode nodoModulo in tvAccion.Nodes)
                {
                    foreach (TreeNode nodoFormulario in nodoModulo.Nodes)
                    {
                        bool estanTodosLosHijosTildados = true;
                        bool tieneHijos = nodoFormulario.Nodes.Count > 0;

                        foreach (TreeNode nodoAccion in nodoFormulario.Nodes)
                        {
                            if (nodoAccion.Tag != null)
                            {
                                int idAccion = Convert.ToInt32(nodoAccion.Tag);
                                bool tienePermiso = false;

                                if (idsDirectos.Contains(idAccion) || idsHeredados.Contains(idAccion))
                                {
                                    tienePermiso = true;
                                }

                                if (tienePermiso)
                                {
                                    nodoAccion.Checked = true;
                                }
                                else
                                {
                                    estanTodosLosHijosTildados = false;
                                }
                            }
                        }

                        if (tieneHijos && estanTodosLosHijosTildados)
                        {
                            nodoFormulario.Checked = true;
                        }
                        else
                        {
                            nodoFormulario.Checked = false;
                        }
                    }

                    bool todosLosFormsTildados = true;
                    foreach (TreeNode nodoFormulario in nodoModulo.Nodes)
                    {
                        if (!nodoFormulario.Checked)
                        {
                            todosLosFormsTildados = false;
                            break;
                        }
                    }
                    nodoModulo.Checked = nodoModulo.Nodes.Count > 0 && todosLosFormsTildados;
                }
            }
            finally
            {
                _validando = false;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("El nombre de usuario y el correo electrónico son obligatorios.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_idUsuario == null) 
                {
                    Usuario nuevo = new Usuario();
                    nuevo.NombreUsuario = txtUsuario.Text;

                    nuevo.IdEstadoUsuario = (int)comboBox1.SelectedValue;

                    nuevo.IdPersonaNavigation = new Persona();
                    nuevo.IdPersonaNavigation.Nombre = txtNombre.Text;
                    nuevo.IdPersonaNavigation.Apellido = txtApellido.Text;
                    nuevo.IdPersonaNavigation.Email = txtEmail.Text; 

                    if (int.TryParse(txtDNI.Text, out int dni))
                        nuevo.IdPersonaNavigation.Dni = dni;

                    _ctrlUsuarios.AgregarUsuario(nuevo);

                    _usuarioActual = nuevo; // Guardamos la referencia para asignarle grupos/permisos abajo

                    MessageBox.Show("Usuario creado correctamente.\n\n" +
                        "IMPORTANTE: El usuario se ha generado con una contraseña aleatoria.\n" +
                        "Por favor, utilice la opción 'Olvidé mi contraseña' en la pantalla de login para configurar su acceso personal.",
                        "Usuario Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _usuarioActual.NombreUsuario = txtUsuario.Text;

                    if (_usuarioActual.IdPersonaNavigation != null)
                    {
                        _usuarioActual.IdPersonaNavigation.Nombre = txtNombre.Text;
                        _usuarioActual.IdPersonaNavigation.Apellido = txtApellido.Text;
                        _usuarioActual.IdPersonaNavigation.Dni = Convert.ToInt32(txtDNI.Text);
                        _usuarioActual.IdPersonaNavigation.Email = txtEmail.Text;
                    }

                    _usuarioActual.IdEstadoUsuario = (int)comboBox1.SelectedValue;

                    _ctrlUsuarios.ModificarUsuario(_usuarioActual);
                    MessageBox.Show("Usuario modificado correctamente.");
                }


                List<int> idsGrupos = new List<int>();
                foreach (Grupo g in clbGrupos.CheckedItems) idsGrupos.Add(g.IdGrupo);
                _ctrlUsuarios.GuardarGruposUsuario(_usuarioActual.IdUsuario, idsGrupos);

                List<int> idsAcciones = new List<int>();
                foreach (TreeNode nodoModulo in tvAccion.Nodes)
                {
                    foreach (TreeNode nodoForm in nodoModulo.Nodes)
                    {
                        foreach (TreeNode nodoAccion in nodoForm.Nodes)
                        {
                            if (nodoAccion.Checked && nodoAccion.Tag != null)
                            {
                                idsAcciones.Add(Convert.ToInt32(nodoAccion.Tag));
                            }
                        }
                    }
                }
                _ctrlUsuarios.GuardarPermisosDelUsuario(_usuarioActual.IdUsuario, idsAcciones);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void clbGrupos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (_idUsuario.HasValue)
                {
                    MarcarArbolUsuario(_idUsuario.Value);
                }
            }));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Lógica de selección de nodos (Marcar padres e hijos)
        private bool _validando = false;
        private void tvAccion_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (_validando) return;

            try
            {
                _validando = true; 

                ActualizarHijos(e.Node, e.Node.Checked);

                ActualizarPadre(e.Node);
            }
            finally
            {
                _validando = false; 
            }
        }

        private void ActualizarHijos(TreeNode nodoPadre, bool estado)
        {
            foreach (TreeNode nodoHijo in nodoPadre.Nodes)
            {
                nodoHijo.Checked = estado;
                ActualizarHijos(nodoHijo, estado);
            }
        }

        private void ActualizarPadre(TreeNode nodoHijo)
        {
            if (nodoHijo.Parent == null) return;

            TreeNode padre = nodoHijo.Parent;
            bool todosLosHermanosMarcados = true;

            foreach (TreeNode hermano in padre.Nodes)
            {
                if (!hermano.Checked)
                {
                    todosLosHermanosMarcados = false;
                    break;
                }
            }

            padre.Checked = todosLosHermanosMarcados;

            ActualizarPadre(padre);
        }

        #endregion
    }
}
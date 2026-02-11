using Controlador;
using Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SAG___Diploma.Vista
{
    public partial class FormGrupo : Form
    {
        private CtrlGestionarGrupos _controlador;
        private int? _idGrupo;
        private Grupo _grupoActual;

        public FormGrupo(int? idGrupo)
        {
            InitializeComponent();
            _controlador = new CtrlGestionarGrupos(new DiplomaContext());
            _idGrupo = idGrupo;
        }

        private void FormGrupo_Load(object sender, EventArgs e)
        {
            CargarComboEstados();
            CargarArbolAcciones();

            if (_idGrupo.HasValue)
            {
                this.Text = "Modificar Grupo";
                CargarDatosGrupo(_idGrupo.Value);
            }
            else
            {
                this.Text = "Nuevo Grupo";
                if (cmbEstadoGrupo.Items.Count > 0) cmbEstadoGrupo.SelectedIndex = 0;
            }
        }

        private void CargarComboEstados()
        {
            var listaEstados = _controlador.ListarEstados();
            cmbEstadoGrupo.DataSource = listaEstados;
            cmbEstadoGrupo.DisplayMember = "Descripcion";
            cmbEstadoGrupo.ValueMember = "IdEstadoGrupo";
        }

        private void CargarArbolAcciones()
        {
            tvAcciones.Nodes.Clear();
            var todasLasAcciones = _controlador.ListarAcciones();

            if (todasLasAcciones.Count == 0) return;

            // 1. Agrupamos primero por MÓDULO (Nivel 1)
            var accionesPorModulo = todasLasAcciones
                .GroupBy(a => a.IdFormularioNavigation?.IdModuloNavigation?.NombreModulo ?? "Sin Módulo")
                .OrderBy(g => g.Key);

            foreach (var grupoModulo in accionesPorModulo)
            {
                TreeNode nodoModulo = new TreeNode(grupoModulo.Key);

                // 2. Agrupar por FORMULARIO (Nivel 2)
                var accionesPorFormulario = grupoModulo
                    .GroupBy(a => a.IdFormularioNavigation?.NombreFormulario ?? "Varios")
                    .OrderBy(g => g.Key);

                foreach (var grupoForm in accionesPorFormulario)
                {
                    TreeNode nodoFormulario = new TreeNode(grupoForm.Key);

                    // 3. ACCIONES (Nivel 3)
                    foreach (var accion in grupoForm)
                    {
                        TreeNode nodoAccion = new TreeNode(accion.NombreAccion);
                        nodoAccion.Tag = accion.IdAccion;
                        nodoFormulario.Nodes.Add(nodoAccion);
                    }
                    nodoModulo.Nodes.Add(nodoFormulario);
                }
                tvAcciones.Nodes.Add(nodoModulo);
            }

            // Expandimos para que se vea
            if (tvAcciones.Nodes.Count > 0) tvAcciones.Nodes[0].Expand();
        }

        private void CargarDatosGrupo(int id)
        {
            // Usamos Find directamente para ser más eficientes, o tu método ListarGrupos
            var lista = _controlador.ListarGrupos();
            _grupoActual = lista.FirstOrDefault(g => g.IdGrupo == id);

            if (_grupoActual != null)
            {
                txtNombre.Text = _grupoActual.NombreGrupo;
                txtDescripcion.Text = _grupoActual.Descripcion; // Corregí txtDNI por txtDescripcion
                cmbEstadoGrupo.SelectedValue = _grupoActual.IdEstadoGrupo;
                MarcarPermisosAsignados(id);
            }
        }

        private void MarcarPermisosAsignados(int idGrupo)
        {
            // 1. Limpieza
            foreach (TreeNode n1 in tvAcciones.Nodes)
            {
                n1.Checked = false;
                foreach (TreeNode n2 in n1.Nodes)
                {
                    n2.Checked = false;
                    foreach (TreeNode n3 in n2.Nodes) n3.Checked = false;
                }
            }

            // 2. Traer permisos de BD
            var accionesDelGrupo = _controlador.ListarAccionesPorGrupo(idGrupo);
            var idsQueTiene = accionesDelGrupo.Select(a => a.IdAccion).ToList();

            // 3. Recorrer y marcar
            foreach (TreeNode nodoModulo in tvAcciones.Nodes)
            {
                foreach (TreeNode nodoFormulario in nodoModulo.Nodes)
                {
                    foreach (TreeNode nodoAccion in nodoFormulario.Nodes)
                    {
                        if (nodoAccion.Tag != null && idsQueTiene.Contains(Convert.ToInt32(nodoAccion.Tag)))
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
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre es obligatorio.");
                    return;
                }

                // --- 1. GUARDAR DATOS DEL GRUPO ---
                if (_idGrupo == null) // ALTA (NUEVO)
                {
                    Grupo nuevo = new Grupo();
                    nuevo.NombreGrupo = txtNombre.Text;
                    nuevo.Descripcion = txtDescripcion.Text; // Corregido txtDNI

                    // Aseguramos un estado válido (si el combo está vacío, forzamos 1)
                    if (cmbEstadoGrupo.SelectedValue != null)
                        nuevo.IdEstadoGrupo = (int)cmbEstadoGrupo.SelectedValue;
                    else
                        nuevo.IdEstadoGrupo = 1;

                    _controlador.AgregarGrupo(nuevo);
                    _grupoActual = nuevo; // ¡IMPORTANTE! Ahora _grupoActual tiene el ID generado
                }
                else // MODIFICACION
                {
                    _grupoActual.NombreGrupo = txtNombre.Text;
                    _grupoActual.Descripcion = txtDescripcion.Text;
                    if (cmbEstadoGrupo.SelectedValue != null)
                        _grupoActual.IdEstadoGrupo = (int)cmbEstadoGrupo.SelectedValue;

                    _controlador.ModificarGrupo(_grupoActual);
                }

                // --- 2. GUARDAR PERMISOS ---
                // Ahora que seguro tenemos un _grupoActual válido (con ID), guardamos el árbol
                GuardarSeleccionArbol(_grupoActual.IdGrupo);

                MessageBox.Show("Grupo guardado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GuardarSeleccionArbol(int idGrupo)
        {
            List<int> idsParaGuardar = new List<int>();

            foreach (TreeNode nodoModulo in tvAcciones.Nodes)
            {
                foreach (TreeNode nodoFormulario in nodoModulo.Nodes)
                {
                    foreach (TreeNode nodoAccion in nodoFormulario.Nodes)
                    {
                        if (nodoAccion.Checked && nodoAccion.Tag != null)
                        {
                            idsParaGuardar.Add(Convert.ToInt32(nodoAccion.Tag));
                        }
                    }
                }
            }

            _controlador.GuardarPermisosGrupo(idGrupo, idsParaGuardar);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Manejo de Checkboxes en Árbol (Cascada)

        private bool _validando = false;
        private void tvAcciones_AfterCheck(object sender, TreeViewEventArgs e)
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

        // Función Recursiva para subir (Verificar padre, abuelo, etc.)
        private void ActualizarPadre(TreeNode nodoHijo)
        {
            if (nodoHijo.Parent == null) return; // Llegamos a la raíz, fin.

            TreeNode padre = nodoHijo.Parent;
            bool todosLosHermanosMarcados = true;

            // Revisamos si TODOS los hijos de ese padre están marcados
            foreach (TreeNode hermano in padre.Nodes)
            {
                if (!hermano.Checked)
                {
                    todosLosHermanosMarcados = false;
                    break;
                }
            }

            // Si todos están marcados, marcamos al padre. Si falta uno, lo desmarcamos.
            padre.Checked = todosLosHermanosMarcados;

            // Seguimos subiendo al abuelo
            ActualizarPadre(padre);
        }
    }
    #endregion
}
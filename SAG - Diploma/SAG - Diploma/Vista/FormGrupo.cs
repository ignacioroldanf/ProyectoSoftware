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
                txtCodigo.Text = "AUTO";
                txtCodigo.Enabled = false;

                cmbEstado.SelectedValue = 1;
            }
        }
        private void CargarComboEstados()
        {
            var listaEstados = _controlador.ListarEstados();

            cmbEstado.DataSource = listaEstados;
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "IdEstadoGrupo";
        }
        private void CargarArbolAcciones()
        {
            tvAcciones.Nodes.Clear();
            var todasLasAcciones = _controlador.ListarAcciones();

            // 1. Agrupamos primero por MÓDULO (Nivel 1)
            // Usamos el operador ?. para evitar errores si hay datos nulos en la BD
            var accionesPorModulo = todasLasAcciones
                .GroupBy(a => a.IdFormularioNavigation?.IdModuloNavigation?.NombreModulo ?? "Sin Módulo")
                .OrderBy(g => g.Key);

            foreach (var grupoModulo in accionesPorModulo)
            {
                TreeNode nodoModulo = new TreeNode(grupoModulo.Key); // Nodo Ventas, Compras, etc.

                // 2. Dentro del Módulo, agrupamos por FORMULARIO (Nivel 2)
                var accionesPorFormulario = grupoModulo
                    .GroupBy(a => a.IdFormularioNavigation?.NombreFormulario ?? "Varios")
                    .OrderBy(g => g.Key);

                foreach (var grupoForm in accionesPorFormulario)
                {
                    TreeNode nodoFormulario = new TreeNode(grupoForm.Key); // Nodo Clientes, Facturas, etc.

                    // 3. Finalmente agregamos las ACCIONES (Nivel 3)
                    foreach (var accion in grupoForm)
                    {
                        TreeNode nodoAccion = new TreeNode(accion.NombreAccion); // Agregar, Eliminar, etc.
                        nodoAccion.Tag = accion.IdAccion; // Guardamos el ID para usarlo al guardar

                        // Opcional: Ponemos el checkbox solo en las acciones
                        // (Aunque el TreeView suele ponerlo en todos, la lógica de guardar solo mira los que tienen Tag)

                        nodoFormulario.Nodes.Add(nodoAccion);
                    }

                    nodoModulo.Nodes.Add(nodoFormulario);
                }

                tvAcciones.Nodes.Add(nodoModulo);
            }

            // Expandimos solo el primer nivel o todo según prefieras
            // tvAcciones.ExpandAll(); 
            tvAcciones.Nodes[0].Expand();
        }

        private void CargarDatosGrupo(int id)
        {
            var lista = _controlador.ListarGrupos();
            _grupoActual = lista.FirstOrDefault(g => g.IdGrupo == id);

            if (_grupoActual != null)
            {
                txtNombre.Text = _grupoActual.NombreGrupo;
                txtDNI.Text = _grupoActual.Descripcion;


                cmbEstado.SelectedValue = _grupoActual.IdEstadoGrupo;

                MarcarPermisosAsignados(id);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarSeleccionArbol(_grupoActual.IdGrupo);
        }
        private void GuardarSeleccionArbol(int idGrupo)
        {
            List<int> idsParaGuardar = new List<int>();

            // Recorremos Nodos Nivel 1 (Módulos)
            foreach (TreeNode nodoModulo in tvAcciones.Nodes)
            {
                // Recorremos Nodos Nivel 2 (Formularios)
                foreach (TreeNode nodoFormulario in nodoModulo.Nodes)
                {
                    // Recorremos Nodos Nivel 3 (Acciones) -> ESTOS SON LOS QUE IMPORTAN
                    foreach (TreeNode nodoAccion in nodoFormulario.Nodes)
                    {
                        if (nodoAccion.Checked && nodoAccion.Tag != null)
                        {
                            idsParaGuardar.Add((int)nodoAccion.Tag);
                        }
                    }
                }
            }

            _controlador.GuardarPermisosGrupo(idGrupo, idsParaGuardar);
        }
        private void MarcarPermisosAsignados(int idGrupo)
        {
            var accionesDelGrupo = _controlador.ListarAccionesPorGrupo(idGrupo);
            var idsQueTiene = accionesDelGrupo.Select(a => a.IdAccion).ToList();

            foreach (TreeNode nodoModulo in tvAcciones.Nodes)
            {
                foreach (TreeNode nodoFormulario in nodoModulo.Nodes)
                {
                    foreach (TreeNode nodoAccion in nodoFormulario.Nodes)
                    {
                        if (nodoAccion.Tag != null && idsQueTiene.Contains((int)nodoAccion.Tag))
                        {
                            nodoAccion.Checked = true;

                            // Truco visual: Expandir el padre para que se vea que tiene algo seleccionado
                            nodoFormulario.Expand();
                            nodoModulo.Expand();
                        }
                    }
                }
            }
        }
    }
}

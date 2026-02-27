using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAG___Diploma
{
    public partial class FormAuditoria : Form
    {
        private CtrlAuditoria _controlador;
        public FormAuditoria()
        {
            InitializeComponent();
            _controlador = new CtrlAuditoria();
        }

        private void FormAuditoria_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ConfigurarGrilla(dtgvLogins);
                ConfigurarGrilla(dtgvClases);

                dtgvLogins.DataSource = _controlador.ObtenerAuditoriaLogins();
                dtgvClases.DataSource = _controlador.ObtenerAuditoriaClases();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de auditoría: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ConfigurarGrilla(DataGridView dtgv)
        {
            if (dtgv != null)
            {
                dtgv.ReadOnly = true;
                dtgv.AllowUserToAddRows = false;
                dtgv.AllowUserToDeleteRows = false;
                dtgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dtgv.RowHeadersVisible = false;
                dtgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

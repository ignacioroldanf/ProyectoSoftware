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
    public partial class FormBackup : Form
    {
        private CtrlBackup _controlador;

        public FormBackup()
        {
            InitializeComponent();
            _controlador = new CtrlBackup();
        }

        private void btnGenerarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string rutaGenerada = _controlador.GenerarBackup();

                MessageBox.Show($"¡Backup generado con éxito!\n\nSe guardó de forma segura en:\n{rutaGenerada}",
                                "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el backup: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            DialogResult advertencia = MessageBox.Show(
                "ADVERTENCIA: Restaurar un backup sobreescribirá todos los datos actuales del sistema. \n\n¿Estás completamente seguro de continuar?",
                "Peligro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (advertencia == DialogResult.Yes)
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.InitialDirectory = @"C:\Backups\";
                dialog.Filter = "SQL Server Backup (*.bak)|*.bak";
                dialog.Title = "Seleccionar Copia de Seguridad para Restaurar";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        _controlador.RestaurarBackup(dialog.FileName);

                        MessageBox.Show("¡Base de datos restaurada con éxito! El sistema se reiniciará para aplicar los cambios y limpiar las conexiones.",
                                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Application.Restart();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al restaurar: " + ex.Message,
                                        "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }
    }
}

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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            CenterInicioLabel();
        }

        public void SetWelcomeText(string text)
        {
            if (lblInicio != null)
            {
                lblInicio.Text = text;
                CenterInicioLabel();
            }
        }

        private void CenterInicioLabel()
        {
            if (lblInicio == null || this.ClientSize.Width == 0) return;
            lblInicio.AutoSize = true;
            var px = Math.Max(0, (this.ClientSize.Width - lblInicio.PreferredWidth) / 2);
            var py = Math.Max(0, (this.ClientSize.Height - lblInicio.PreferredHeight) / 2);
            lblInicio.Location = new System.Drawing.Point(px, py);
        }
    }
}

namespace SAG___Diploma
{
    partial class FormAuditoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label3 = new Label();
            dtgvLogins = new DataGridView();
            dtgvClases = new DataGridView();
            btnSalir = new Button();
            label1 = new Label();
            label2 = new Label();
            cmbFiltroLogins = new ComboBox();
            cmbFiltroClases = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvLogins).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvClases).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1565, 82);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 25);
            label3.Name = "label3";
            label3.Size = new Size(123, 28);
            label3.TabIndex = 42;
            label3.Text = "AUDITORÍAS";
            // 
            // dtgvLogins
            // 
            dtgvLogins.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dtgvLogins.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvLogins.Location = new Point(12, 140);
            dtgvLogins.Name = "dtgvLogins";
            dtgvLogins.RowHeadersWidth = 51;
            dtgvLogins.Size = new Size(800, 507);
            dtgvLogins.TabIndex = 1;
            // 
            // dtgvClases
            // 
            dtgvClases.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dtgvClases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvClases.Location = new Point(810, 140);
            dtgvClases.Name = "dtgvClases";
            dtgvClases.RowHeadersWidth = 51;
            dtgvClases.Size = new Size(743, 507);
            dtgvClases.TabIndex = 2;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Font = new Font("Segoe UI", 12F);
            btnSalir.Location = new Point(1433, 704);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 68);
            btnSalir.TabIndex = 39;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 98);
            label1.Name = "label1";
            label1.Size = new Size(258, 28);
            label1.TabIndex = 40;
            label1.Text = "Auditoría de Login y Logout";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(810, 98);
            label2.Name = "label2";
            label2.Size = new Size(293, 28);
            label2.TabIndex = 41;
            label2.Text = "Auditoría de Trazabilidad (Clase)";
            // 
            // cmbFiltroLogins
            // 
            cmbFiltroLogins.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cmbFiltroLogins.Font = new Font("Segoe UI", 12F);
            cmbFiltroLogins.FormattingEnabled = true;
            cmbFiltroLogins.Location = new Point(615, 95);
            cmbFiltroLogins.Name = "cmbFiltroLogins";
            cmbFiltroLogins.Size = new Size(197, 36);
            cmbFiltroLogins.TabIndex = 42;
            cmbFiltroLogins.SelectedIndexChanged += cmbFiltroLogins_SelectedIndexChanged;
            // 
            // cmbFiltroClases
            // 
            cmbFiltroClases.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cmbFiltroClases.Font = new Font("Segoe UI", 12F);
            cmbFiltroClases.FormattingEnabled = true;
            cmbFiltroClases.Location = new Point(1356, 95);
            cmbFiltroClases.Name = "cmbFiltroClases";
            cmbFiltroClases.Size = new Size(197, 36);
            cmbFiltroClases.TabIndex = 43;
            cmbFiltroClases.SelectedIndexChanged += cmbFiltroClases_SelectedIndexChanged;
            // 
            // FormAuditoria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1565, 782);
            Controls.Add(cmbFiltroClases);
            Controls.Add(cmbFiltroLogins);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSalir);
            Controls.Add(dtgvClases);
            Controls.Add(dtgvLogins);
            Controls.Add(panel1);
            Name = "FormAuditoria";
            Text = "FormAuditoria";
            Load += FormAuditoria_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvLogins).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvClases).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ComboBox cmbTipoAuditoria;
        private DataGridView dtgvLogins;
        private DataGridView dtgvClases;
        private Button btnSalir;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmbFiltroLogins;
        private ComboBox cmbFiltroClases;
    }
}
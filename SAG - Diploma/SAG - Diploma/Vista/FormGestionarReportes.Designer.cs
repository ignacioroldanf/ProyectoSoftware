namespace SAG___Diploma.Vista
{
    partial class FormGestionarReportes
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
            panelSuperior = new Panel();
            btnGenerar = new Button();
            btnExportar = new Button();
            dtgvIngresos = new DataGridView();
            dtgvEstados = new DataGridView();
            panelEstados = new Panel();
            panelIngresos = new Panel();
            cmbIngresos = new ComboBox();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvIngresos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvEstados).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(btnGenerar);
            panelSuperior.Controls.Add(btnExportar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1427, 82);
            panelSuperior.TabIndex = 35;
            // 
            // btnGenerar
            // 
            btnGenerar.Anchor = AnchorStyles.Left;
            btnGenerar.BackColor = SystemColors.GradientActiveCaption;
            btnGenerar.Font = new Font("Segoe UI", 12F);
            btnGenerar.Location = new Point(12, 3);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(120, 68);
            btnGenerar.TabIndex = 20;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Anchor = AnchorStyles.Left;
            btnExportar.BackColor = SystemColors.GradientActiveCaption;
            btnExportar.Font = new Font("Segoe UI", 12F);
            btnExportar.Location = new Point(138, 3);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(120, 68);
            btnExportar.TabIndex = 21;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // dtgvIngresos
            // 
            dtgvIngresos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvIngresos.Location = new Point(12, 149);
            dtgvIngresos.Name = "dtgvIngresos";
            dtgvIngresos.RowHeadersWidth = 51;
            dtgvIngresos.Size = new Size(596, 239);
            dtgvIngresos.TabIndex = 0;
            // 
            // dtgvEstados
            // 
            dtgvEstados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvEstados.Location = new Point(12, 539);
            dtgvEstados.Name = "dtgvEstados";
            dtgvEstados.RowHeadersWidth = 51;
            dtgvEstados.Size = new Size(596, 239);
            dtgvEstados.TabIndex = 37;
            // 
            // panelEstados
            // 
            panelEstados.Location = new Point(740, 539);
            panelEstados.Name = "panelEstados";
            panelEstados.Size = new Size(453, 410);
            panelEstados.TabIndex = 37;
            // 
            // panelIngresos
            // 
            panelIngresos.Location = new Point(740, 101);
            panelIngresos.Name = "panelIngresos";
            panelIngresos.Size = new Size(453, 410);
            panelIngresos.TabIndex = 38;
            // 
            // cmbIngresos
            // 
            cmbIngresos.FormattingEnabled = true;
            cmbIngresos.Location = new Point(457, 115);
            cmbIngresos.Name = "cmbIngresos";
            cmbIngresos.Size = new Size(151, 28);
            cmbIngresos.TabIndex = 39;
            // 
            // FormGestionarReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1427, 961);
            Controls.Add(cmbIngresos);
            Controls.Add(panelIngresos);
            Controls.Add(panelEstados);
            Controls.Add(dtgvEstados);
            Controls.Add(dtgvIngresos);
            Controls.Add(panelSuperior);
            Name = "FormGestionarReportes";
            Text = "FormGestionarReportes";
            Load += FormGestionarReportes_Load;
            panelSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvIngresos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvEstados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Button btnGestionarSuscripcion;
        private Button btnGenerar;
        private Button btnEliminar;
        private Button btnExportar;
        private Panel panelGrafico;
        private ComboBox cmbReporte;
        private DataGridView dtgvIngresos;
        private DataGridView dtgvEstados;
        private Panel panelEstados;
        private Panel panelIngresos;
        private ComboBox cmbIngresos;
    }
}
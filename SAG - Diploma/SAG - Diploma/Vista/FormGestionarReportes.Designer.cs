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
            label2 = new Label();
            label1 = new Label();
            dtpFechaHasta = new DateTimePicker();
            dtpFechaDesde = new DateTimePicker();
            btnGenerar = new Button();
            btnExportar = new Button();
            dtgvIngresos = new DataGridView();
            dtgvInasistencias = new DataGridView();
            panelInasistencias = new Panel();
            panelIngresos = new Panel();
            cmbIngresos = new ComboBox();
            panelEjercicios = new Panel();
            dtgvEjercicios = new DataGridView();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvIngresos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvInasistencias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvEjercicios).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(label2);
            panelSuperior.Controls.Add(label1);
            panelSuperior.Controls.Add(dtpFechaHasta);
            panelSuperior.Controls.Add(dtpFechaDesde);
            panelSuperior.Controls.Add(btnGenerar);
            panelSuperior.Controls.Add(btnExportar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1427, 82);
            panelSuperior.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(269, 49);
            label2.Name = "label2";
            label2.Size = new Size(65, 28);
            label2.TabIndex = 25;
            label2.Text = "Hasta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(264, 9);
            label1.Name = "label1";
            label1.Size = new Size(70, 28);
            label1.TabIndex = 24;
            label1.Text = "Desde:";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Font = new Font("Segoe UI", 12F);
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(340, 44);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(149, 34);
            dtpFechaHasta.TabIndex = 23;
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Font = new Font("Segoe UI", 12F);
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(340, 4);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(149, 34);
            dtpFechaDesde.TabIndex = 22;
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
            dtgvIngresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvIngresos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvIngresos.Location = new Point(138, 122);
            dtgvIngresos.Name = "dtgvIngresos";
            dtgvIngresos.RowHeadersWidth = 51;
            dtgvIngresos.Size = new Size(596, 239);
            dtgvIngresos.TabIndex = 0;
            // 
            // dtgvInasistencias
            // 
            dtgvInasistencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvInasistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvInasistencias.Location = new Point(138, 762);
            dtgvInasistencias.Name = "dtgvInasistencias";
            dtgvInasistencias.RowHeadersWidth = 51;
            dtgvInasistencias.Size = new Size(596, 239);
            dtgvInasistencias.TabIndex = 37;
            // 
            // panelInasistencias
            // 
            panelInasistencias.Location = new Point(861, 728);
            panelInasistencias.Name = "panelInasistencias";
            panelInasistencias.Size = new Size(543, 314);
            panelInasistencias.TabIndex = 37;
            // 
            // panelIngresos
            // 
            panelIngresos.Location = new Point(861, 88);
            panelIngresos.Name = "panelIngresos";
            panelIngresos.Size = new Size(543, 314);
            panelIngresos.TabIndex = 38;
            // 
            // cmbIngresos
            // 
            cmbIngresos.FormattingEnabled = true;
            cmbIngresos.Location = new Point(492, 88);
            cmbIngresos.Name = "cmbIngresos";
            cmbIngresos.Size = new Size(242, 28);
            cmbIngresos.TabIndex = 39;
            // 
            // panelEjercicios
            // 
            panelEjercicios.Location = new Point(861, 408);
            panelEjercicios.Name = "panelEjercicios";
            panelEjercicios.Size = new Size(543, 314);
            panelEjercicios.TabIndex = 38;
            // 
            // dtgvEjercicios
            // 
            dtgvEjercicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvEjercicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvEjercicios.Location = new Point(138, 442);
            dtgvEjercicios.Name = "dtgvEjercicios";
            dtgvEjercicios.RowHeadersWidth = 51;
            dtgvEjercicios.Size = new Size(596, 239);
            dtgvEjercicios.TabIndex = 40;
            // 
            // FormGestionarReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1427, 1110);
            Controls.Add(dtgvEjercicios);
            Controls.Add(panelEjercicios);
            Controls.Add(panelIngresos);
            Controls.Add(cmbIngresos);
            Controls.Add(panelInasistencias);
            Controls.Add(dtgvInasistencias);
            Controls.Add(dtgvIngresos);
            Controls.Add(panelSuperior);
            Name = "FormGestionarReportes";
            Text = "GESTIONAR REPORTES";
            Load += FormGestionarReportes_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvIngresos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvInasistencias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvEjercicios).EndInit();
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
        private DataGridView dtgvInasistencias;
        private Panel panelInasistencias;
        private Panel panelIngresos;
        private ComboBox cmbIngresos;
        private Panel panelEjercicios;
        private DataGridView dtgvEjercicios;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpFechaHasta;
        private DateTimePicker dtpFechaDesde;
    }
}
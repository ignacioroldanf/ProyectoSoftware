namespace SAG___Diploma.Vista
{
    partial class FormGestionarProgresos
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
            cmbEjercicio = new ComboBox();
            cmbDiaRutina = new ComboBox();
            label1 = new Label();
            dtgvEjercicios = new DataGridView();
            btnSalir = new Button();
            grpNuevoProgreso = new GroupBox();
            txtObservaciones = new TextBox();
            txtPesoUsado = new TextBox();
            NUDRepesHechas = new NumericUpDown();
            NUDSeriesHechas = new NumericUpDown();
            btnAgregar = new Button();
            lblObservaciones = new Label();
            lblPesoUsado = new Label();
            lblRepesHechas = new Label();
            lblSeries = new Label();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvEjercicios).BeginInit();
            grpNuevoProgreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUDRepesHechas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUDSeriesHechas).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(label2);
            panelSuperior.Controls.Add(cmbEjercicio);
            panelSuperior.Controls.Add(cmbDiaRutina);
            panelSuperior.Controls.Add(label1);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1427, 82);
            panelSuperior.TabIndex = 38;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(299, 27);
            label2.Name = "label2";
            label2.Size = new Size(198, 28);
            label2.TabIndex = 34;
            label2.Text = "Nombre del ejercicio:";
            // 
            // cmbEjercicio
            // 
            cmbEjercicio.Anchor = AnchorStyles.Left;
            cmbEjercicio.Font = new Font("Segoe UI", 12F);
            cmbEjercicio.FormattingEnabled = true;
            cmbEjercicio.Location = new Point(503, 24);
            cmbEjercicio.Name = "cmbEjercicio";
            cmbEjercicio.Size = new Size(151, 36);
            cmbEjercicio.TabIndex = 33;
            cmbEjercicio.SelectedIndexChanged += cmbEjercicio_SelectedIndexChanged;
            // 
            // cmbDiaRutina
            // 
            cmbDiaRutina.Anchor = AnchorStyles.Left;
            cmbDiaRutina.Font = new Font("Segoe UI", 12F);
            cmbDiaRutina.FormattingEnabled = true;
            cmbDiaRutina.Location = new Point(142, 24);
            cmbDiaRutina.Name = "cmbDiaRutina";
            cmbDiaRutina.Size = new Size(151, 36);
            cmbDiaRutina.TabIndex = 32;
            cmbDiaRutina.SelectedIndexChanged += cmbDiaRutina_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(124, 28);
            label1.TabIndex = 31;
            label1.Text = "Ejercicios del";
            // 
            // dtgvEjercicios
            // 
            dtgvEjercicios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvEjercicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvEjercicios.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvEjercicios.BorderStyle = BorderStyle.None;
            dtgvEjercicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvEjercicios.Location = new Point(12, 140);
            dtgvEjercicios.Name = "dtgvEjercicios";
            dtgvEjercicios.RowHeadersWidth = 51;
            dtgvEjercicios.Size = new Size(935, 493);
            dtgvEjercicios.TabIndex = 37;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = SystemColors.GradientActiveCaption;
            btnSalir.Font = new Font("Segoe UI", 12F);
            btnSalir.Location = new Point(1295, 704);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 68);
            btnSalir.TabIndex = 36;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // grpNuevoProgreso
            // 
            grpNuevoProgreso.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpNuevoProgreso.BackColor = Color.White;
            grpNuevoProgreso.Controls.Add(txtObservaciones);
            grpNuevoProgreso.Controls.Add(txtPesoUsado);
            grpNuevoProgreso.Controls.Add(NUDRepesHechas);
            grpNuevoProgreso.Controls.Add(NUDSeriesHechas);
            grpNuevoProgreso.Controls.Add(btnAgregar);
            grpNuevoProgreso.Controls.Add(lblObservaciones);
            grpNuevoProgreso.Controls.Add(lblPesoUsado);
            grpNuevoProgreso.Controls.Add(lblRepesHechas);
            grpNuevoProgreso.Controls.Add(lblSeries);
            grpNuevoProgreso.Font = new Font("Segoe UI", 12F);
            grpNuevoProgreso.Location = new Point(1131, 140);
            grpNuevoProgreso.Name = "grpNuevoProgreso";
            grpNuevoProgreso.Size = new Size(284, 464);
            grpNuevoProgreso.TabIndex = 39;
            grpNuevoProgreso.TabStop = false;
            grpNuevoProgreso.Text = "Asignar Nuevo Progreso";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtObservaciones.BackColor = SystemColors.Window;
            txtObservaciones.Location = new Point(6, 178);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(272, 150);
            txtObservaciones.TabIndex = 42;
            // 
            // txtPesoUsado
            // 
            txtPesoUsado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPesoUsado.Location = new Point(202, 103);
            txtPesoUsado.Name = "txtPesoUsado";
            txtPesoUsado.Size = new Size(76, 34);
            txtPesoUsado.TabIndex = 41;
            // 
            // NUDRepesHechas
            // 
            NUDRepesHechas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            NUDRepesHechas.Location = new Point(202, 69);
            NUDRepesHechas.Name = "NUDRepesHechas";
            NUDRepesHechas.Size = new Size(76, 34);
            NUDRepesHechas.TabIndex = 40;
            // 
            // NUDSeriesHechas
            // 
            NUDSeriesHechas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            NUDSeriesHechas.Location = new Point(202, 34);
            NUDSeriesHechas.Name = "NUDSeriesHechas";
            NUDSeriesHechas.Size = new Size(76, 34);
            NUDSeriesHechas.TabIndex = 39;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAgregar.BackColor = SystemColors.GradientActiveCaption;
            btnAgregar.Location = new Point(173, 402);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(105, 49);
            btnAgregar.TabIndex = 20;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblObservaciones
            // 
            lblObservaciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(6, 147);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(143, 28);
            lblObservaciones.TabIndex = 38;
            lblObservaciones.Text = "Observaciones:";
            // 
            // lblPesoUsado
            // 
            lblPesoUsado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPesoUsado.AutoSize = true;
            lblPesoUsado.Location = new Point(6, 106);
            lblPesoUsado.Name = "lblPesoUsado";
            lblPesoUsado.Size = new Size(113, 28);
            lblPesoUsado.TabIndex = 37;
            lblPesoUsado.Text = "Peso Usado";
            // 
            // lblRepesHechas
            // 
            lblRepesHechas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblRepesHechas.AutoSize = true;
            lblRepesHechas.Location = new Point(6, 71);
            lblRepesHechas.Name = "lblRepesHechas";
            lblRepesHechas.Size = new Size(189, 28);
            lblRepesHechas.TabIndex = 36;
            lblRepesHechas.Text = "Repeticiones Hechas";
            // 
            // lblSeries
            // 
            lblSeries.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSeries.AutoSize = true;
            lblSeries.Location = new Point(6, 36);
            lblSeries.Name = "lblSeries";
            lblSeries.Size = new Size(63, 28);
            lblSeries.TabIndex = 35;
            lblSeries.Text = "Series";
            // 
            // FormGestionarProgresos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1427, 782);
            Controls.Add(grpNuevoProgreso);
            Controls.Add(panelSuperior);
            Controls.Add(dtgvEjercicios);
            Controls.Add(btnSalir);
            Name = "FormGestionarProgresos";
            Text = "GESTIONAR PROGRESOS";
            Load += FormGestionarProgresos_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvEjercicios).EndInit();
            grpNuevoProgreso.ResumeLayout(false);
            grpNuevoProgreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUDRepesHechas).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUDSeriesHechas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private ComboBox cmbDiaRutina;
        private Label label1;
        private DataGridView dtgvEjercicios;
        private Button btnSalir;
        private GroupBox grpNuevoProgreso;
        private Label lblPesoUsado;
        private Label lblRepesHechas;
        private Button btnAgregar;
        private Label lblSeries;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private TextBox txtPesoUsado;
        private NumericUpDown NUDRepesHechas;
        private NumericUpDown NUDSeriesHechas;
        private Label label2;
        private ComboBox cmbEjercicio;
    }
}
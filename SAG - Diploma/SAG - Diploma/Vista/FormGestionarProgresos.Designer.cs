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
            cmbDiaRutina = new ComboBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
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
            cmbEjercicio = new ComboBox();
            label2 = new Label();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            panelSuperior.Controls.Add(pictureBox1);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1131, 61);
            panelSuperior.TabIndex = 38;
            // 
            // cmbDiaRutina
            // 
            cmbDiaRutina.FormattingEnabled = true;
            cmbDiaRutina.Location = new Point(213, 14);
            cmbDiaRutina.Name = "cmbDiaRutina";
            cmbDiaRutina.Size = new Size(151, 28);
            cmbDiaRutina.TabIndex = 32;
            cmbDiaRutina.SelectedIndexChanged += cmbDiaRutina_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 17);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 31;
            label1.Text = "Ejercicios del";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.bodybuilding_emblem_and_gym_logo_design_template_vector;
            pictureBox1.Location = new Point(-20, -6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // dtgvEjercicios
            // 
            dtgvEjercicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvEjercicios.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvEjercicios.BorderStyle = BorderStyle.None;
            dtgvEjercicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvEjercicios.Location = new Point(17, 87);
            dtgvEjercicios.Name = "dtgvEjercicios";
            dtgvEjercicios.RowHeadersWidth = 51;
            dtgvEjercicios.Size = new Size(825, 479);
            dtgvEjercicios.TabIndex = 37;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = SystemColors.GradientActiveCaption;
            btnSalir.Location = new Point(1018, 522);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(101, 44);
            btnSalir.TabIndex = 36;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // grpNuevoProgreso
            // 
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
            grpNuevoProgreso.Location = new Point(848, 87);
            grpNuevoProgreso.Name = "grpNuevoProgreso";
            grpNuevoProgreso.Size = new Size(271, 318);
            grpNuevoProgreso.TabIndex = 39;
            grpNuevoProgreso.TabStop = false;
            grpNuevoProgreso.Text = "Asignar Nuevo Progreso";
            // 
            // txtObservaciones
            // 
            txtObservaciones.BackColor = SystemColors.Window;
            txtObservaciones.Location = new Point(6, 165);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(259, 85);
            txtObservaciones.TabIndex = 42;
            // 
            // txtPesoUsado
            // 
            txtPesoUsado.Location = new Point(202, 103);
            txtPesoUsado.Name = "txtPesoUsado";
            txtPesoUsado.Size = new Size(63, 27);
            txtPesoUsado.TabIndex = 41;
            // 
            // NUDRepesHechas
            // 
            NUDRepesHechas.Location = new Point(202, 69);
            NUDRepesHechas.Name = "NUDRepesHechas";
            NUDRepesHechas.Size = new Size(63, 27);
            NUDRepesHechas.TabIndex = 40;
            // 
            // NUDSeriesHechas
            // 
            NUDSeriesHechas.Location = new Point(202, 34);
            NUDSeriesHechas.Name = "NUDSeriesHechas";
            NUDSeriesHechas.Size = new Size(63, 27);
            NUDSeriesHechas.TabIndex = 39;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = SystemColors.GradientActiveCaption;
            btnAgregar.Location = new Point(160, 256);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(105, 49);
            btnAgregar.TabIndex = 20;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(6, 142);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(108, 20);
            lblObservaciones.TabIndex = 38;
            lblObservaciones.Text = "Observaciones:";
            // 
            // lblPesoUsado
            // 
            lblPesoUsado.AutoSize = true;
            lblPesoUsado.Location = new Point(6, 106);
            lblPesoUsado.Name = "lblPesoUsado";
            lblPesoUsado.Size = new Size(85, 20);
            lblPesoUsado.TabIndex = 37;
            lblPesoUsado.Text = "Peso Usado";
            // 
            // lblRepesHechas
            // 
            lblRepesHechas.AutoSize = true;
            lblRepesHechas.Location = new Point(6, 71);
            lblRepesHechas.Name = "lblRepesHechas";
            lblRepesHechas.Size = new Size(146, 20);
            lblRepesHechas.TabIndex = 36;
            lblRepesHechas.Text = "Repeticiones Hechas";
            // 
            // lblSeries
            // 
            lblSeries.AutoSize = true;
            lblSeries.Location = new Point(6, 36);
            lblSeries.Name = "lblSeries";
            lblSeries.Size = new Size(48, 20);
            lblSeries.TabIndex = 35;
            lblSeries.Text = "Series";
            // 
            // cmbEjercicio
            // 
            cmbEjercicio.FormattingEnabled = true;
            cmbEjercicio.Location = new Point(553, 14);
            cmbEjercicio.Name = "cmbEjercicio";
            cmbEjercicio.Size = new Size(151, 28);
            cmbEjercicio.TabIndex = 33;
            cmbEjercicio.SelectedIndexChanged += cmbEjercicio_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(395, 17);
            label2.Name = "label2";
            label2.Size = new Size(152, 20);
            label2.TabIndex = 34;
            label2.Text = "Nombre del ejercicio:";
            // 
            // FormGestionarProgresos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1131, 579);
            Controls.Add(grpNuevoProgreso);
            Controls.Add(panelSuperior);
            Controls.Add(dtgvEjercicios);
            Controls.Add(btnSalir);
            Name = "FormGestionarProgresos";
            Text = "FormGestionarProgresos";
            Load += FormGestionarProgresos_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
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
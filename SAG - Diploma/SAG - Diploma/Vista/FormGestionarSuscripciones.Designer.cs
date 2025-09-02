namespace SAG___Diploma.Vista
{
    partial class FormGestionarSuscripciones
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
            label1 = new Label();
            label2 = new Label();
            btnAsignar = new Button();
            lblEstadoActual = new Label();
            lblCliente = new Label();
            pictureBox1 = new PictureBox();
            btnEliminar = new Button();
            cmbPlanes = new ComboBox();
            btnAgregar = new Button();
            dtgvSuscripciones = new DataGridView();
            btnSalir = new Button();
            grupoNuevaSuscripcion = new GroupBox();
            dtpFin = new DateTimePicker();
            dtpInicio = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            lblPlanes = new Label();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvSuscripciones).BeginInit();
            grupoNuevaSuscripcion.SuspendLayout();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(label1);
            panelSuperior.Controls.Add(label2);
            panelSuperior.Controls.Add(btnAsignar);
            panelSuperior.Controls.Add(lblEstadoActual);
            panelSuperior.Controls.Add(lblCliente);
            panelSuperior.Controls.Add(pictureBox1);
            panelSuperior.Controls.Add(btnEliminar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1217, 61);
            panelSuperior.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 35;
            label1.Text = "Cliente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(111, 32);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 34;
            label2.Text = "Estado Actual:";
            // 
            // btnAsignar
            // 
            btnAsignar.BackColor = SystemColors.GradientActiveCaption;
            btnAsignar.Location = new Point(969, 3);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(105, 49);
            btnAsignar.TabIndex = 32;
            btnAsignar.Text = "Nueva Suscripcion";
            btnAsignar.UseVisualStyleBackColor = false;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // lblEstadoActual
            // 
            lblEstadoActual.AutoSize = true;
            lblEstadoActual.Location = new Point(220, 32);
            lblEstadoActual.Name = "lblEstadoActual";
            lblEstadoActual.Size = new Size(54, 20);
            lblEstadoActual.TabIndex = 33;
            lblEstadoActual.Text = "Estado";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(175, 9);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(55, 20);
            lblCliente.TabIndex = 32;
            lblCliente.Text = "Cliente";
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
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.GradientActiveCaption;
            btnEliminar.Location = new Point(1080, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(105, 49);
            btnEliminar.TabIndex = 22;
            btnEliminar.Text = "Cancelar Suscripción";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // cmbPlanes
            // 
            cmbPlanes.FormattingEnabled = true;
            cmbPlanes.Location = new Point(110, 55);
            cmbPlanes.Name = "cmbPlanes";
            cmbPlanes.Size = new Size(148, 28);
            cmbPlanes.TabIndex = 18;
            cmbPlanes.SelectedIndexChanged += cmbPlanes_SelectedIndexChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = SystemColors.GradientActiveCaption;
            btnAgregar.Location = new Point(153, 169);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(105, 49);
            btnAgregar.TabIndex = 20;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dtgvSuscripciones
            // 
            dtgvSuscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvSuscripciones.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvSuscripciones.BorderStyle = BorderStyle.None;
            dtgvSuscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvSuscripciones.Location = new Point(12, 77);
            dtgvSuscripciones.Name = "dtgvSuscripciones";
            dtgvSuscripciones.RowHeadersWidth = 51;
            dtgvSuscripciones.Size = new Size(896, 479);
            dtgvSuscripciones.TabIndex = 35;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = SystemColors.GradientActiveCaption;
            btnSalir.Location = new Point(1084, 512);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(101, 44);
            btnSalir.TabIndex = 34;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // grupoNuevaSuscripcion
            // 
            grupoNuevaSuscripcion.Controls.Add(dtpFin);
            grupoNuevaSuscripcion.Controls.Add(dtpInicio);
            grupoNuevaSuscripcion.Controls.Add(label4);
            grupoNuevaSuscripcion.Controls.Add(label3);
            grupoNuevaSuscripcion.Controls.Add(btnAgregar);
            grupoNuevaSuscripcion.Controls.Add(lblPlanes);
            grupoNuevaSuscripcion.Controls.Add(cmbPlanes);
            grupoNuevaSuscripcion.Location = new Point(914, 77);
            grupoNuevaSuscripcion.Name = "grupoNuevaSuscripcion";
            grupoNuevaSuscripcion.Size = new Size(271, 224);
            grupoNuevaSuscripcion.TabIndex = 37;
            grupoNuevaSuscripcion.TabStop = false;
            grupoNuevaSuscripcion.Text = "Asignar Nueva Suscripcion";
            // 
            // dtpFin
            // 
            dtpFin.Enabled = false;
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(110, 128);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(148, 27);
            dtpFin.TabIndex = 39;
            dtpFin.Value = new DateTime(2025, 8, 16, 15, 41, 58, 0);
            // 
            // dtpInicio
            // 
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(110, 93);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(148, 27);
            dtpInicio.TabIndex = 38;
            dtpInicio.Value = new DateTime(2025, 8, 16, 15, 41, 58, 0);
            dtpInicio.ValueChanged += dtpInicio_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 133);
            label4.Name = "label4";
            label4.Size = new Size(28, 20);
            label4.TabIndex = 37;
            label4.Text = "Fin";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 98);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 36;
            label3.Text = "Inicio";
            // 
            // lblPlanes
            // 
            lblPlanes.AutoSize = true;
            lblPlanes.Location = new Point(6, 63);
            lblPlanes.Name = "lblPlanes";
            lblPlanes.Size = new Size(37, 20);
            lblPlanes.TabIndex = 35;
            lblPlanes.Text = "Plan";
            // 
            // FormGestionarSuscripciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 778);
            Controls.Add(grupoNuevaSuscripcion);
            Controls.Add(panelSuperior);
            Controls.Add(dtgvSuscripciones);
            Controls.Add(btnSalir);
            Name = "FormGestionarSuscripciones";
            Text = "FormGestionarSuscripciones";
            Load += FormGestionarSuscripciones_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvSuscripciones).EndInit();
            grupoNuevaSuscripcion.ResumeLayout(false);
            grupoNuevaSuscripcion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Button btnAsignar;
        private ComboBox cmbPlanes;
        private PictureBox pictureBox1;
        private Button btnAgregar;
        private Button btnEliminar;
        private DataGridView dtgvSuscripciones;
        private Button btnSalir;
        private Label lblEstadoActual;
        private Label lblCliente;
        private Label label2;
        private GroupBox grupoNuevaSuscripcion;
        private DateTimePicker dtpInicio;
        private Label label4;
        private Label label3;
        private Label lblPlanes;
        private DateTimePicker dtpFin;
        private Label label1;
    }
}
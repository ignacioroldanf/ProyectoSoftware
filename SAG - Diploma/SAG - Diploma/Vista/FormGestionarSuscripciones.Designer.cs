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
            panelSuperior.Controls.Add(btnEliminar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1427, 82);
            panelSuperior.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(76, 28);
            label1.TabIndex = 35;
            label1.Text = "Cliente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 37);
            label2.Name = "label2";
            label2.Size = new Size(135, 28);
            label2.TabIndex = 34;
            label2.Text = "Estado Actual:";
            // 
            // btnAsignar
            // 
            btnAsignar.Anchor = AnchorStyles.Right;
            btnAsignar.BackColor = SystemColors.GradientActiveCaption;
            btnAsignar.Font = new Font("Segoe UI", 12F);
            btnAsignar.Location = new Point(1169, 3);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(120, 68);
            btnAsignar.TabIndex = 32;
            btnAsignar.Text = "Nueva Suscripción";
            btnAsignar.UseVisualStyleBackColor = false;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // lblEstadoActual
            // 
            lblEstadoActual.AutoSize = true;
            lblEstadoActual.Font = new Font("Segoe UI", 12F);
            lblEstadoActual.Location = new Point(153, 37);
            lblEstadoActual.Name = "lblEstadoActual";
            lblEstadoActual.Size = new Size(71, 28);
            lblEstadoActual.TabIndex = 33;
            lblEstadoActual.Text = "Estado";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 12F);
            lblCliente.Location = new Point(94, 9);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(72, 28);
            lblCliente.TabIndex = 32;
            lblCliente.Text = "Cliente";
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Right;
            btnEliminar.BackColor = SystemColors.GradientActiveCaption;
            btnEliminar.Font = new Font("Segoe UI", 12F);
            btnEliminar.Location = new Point(1295, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 68);
            btnEliminar.TabIndex = 22;
            btnEliminar.Text = "Cancelar Suscripción";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // cmbPlanes
            // 
            cmbPlanes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbPlanes.FormattingEnabled = true;
            cmbPlanes.Location = new Point(110, 55);
            cmbPlanes.Name = "cmbPlanes";
            cmbPlanes.Size = new Size(148, 36);
            cmbPlanes.TabIndex = 18;
            cmbPlanes.SelectedIndexChanged += cmbPlanes_SelectedIndexChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAgregar.BackColor = SystemColors.GradientActiveCaption;
            btnAgregar.Location = new Point(153, 915);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(105, 49);
            btnAgregar.TabIndex = 20;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dtgvSuscripciones
            // 
            dtgvSuscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvSuscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvSuscripciones.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvSuscripciones.BorderStyle = BorderStyle.None;
            dtgvSuscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvSuscripciones.Location = new Point(12, 140);
            dtgvSuscripciones.Name = "dtgvSuscripciones";
            dtgvSuscripciones.RowHeadersWidth = 51;
            dtgvSuscripciones.Size = new Size(935, 493);
            dtgvSuscripciones.TabIndex = 35;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = SystemColors.GradientActiveCaption;
            btnSalir.Font = new Font("Segoe UI", 12F);
            btnSalir.Location = new Point(1295, 704);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 68);
            btnSalir.TabIndex = 34;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // grupoNuevaSuscripcion
            // 
            grupoNuevaSuscripcion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            grupoNuevaSuscripcion.AutoSize = true;
            grupoNuevaSuscripcion.BackColor = SystemColors.ControlLightLight;
            grupoNuevaSuscripcion.Controls.Add(dtpFin);
            grupoNuevaSuscripcion.Controls.Add(dtpInicio);
            grupoNuevaSuscripcion.Controls.Add(label4);
            grupoNuevaSuscripcion.Controls.Add(label3);
            grupoNuevaSuscripcion.Controls.Add(btnAgregar);
            grupoNuevaSuscripcion.Controls.Add(lblPlanes);
            grupoNuevaSuscripcion.Controls.Add(cmbPlanes);
            grupoNuevaSuscripcion.Font = new Font("Segoe UI", 12F);
            grupoNuevaSuscripcion.Location = new Point(1131, 140);
            grupoNuevaSuscripcion.Name = "grupoNuevaSuscripcion";
            grupoNuevaSuscripcion.Size = new Size(284, 997);
            grupoNuevaSuscripcion.TabIndex = 37;
            grupoNuevaSuscripcion.TabStop = false;
            grupoNuevaSuscripcion.Text = "Asignar Nueva Suscripcion";
            // 
            // dtpFin
            // 
            dtpFin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtpFin.Enabled = false;
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(110, 157);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(148, 34);
            dtpFin.TabIndex = 39;
            dtpFin.Value = new DateTime(2025, 8, 16, 15, 41, 58, 0);
            // 
            // dtpInicio
            // 
            dtpInicio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(110, 108);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(148, 34);
            dtpInicio.TabIndex = 38;
            dtpInicio.Value = new DateTime(2025, 8, 16, 15, 41, 58, 0);
            dtpInicio.ValueChanged += dtpInicio_ValueChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(16, 163);
            label4.Name = "label4";
            label4.Size = new Size(38, 28);
            label4.TabIndex = 37;
            label4.Text = "Fin";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(16, 113);
            label3.Name = "label3";
            label3.Size = new Size(59, 28);
            label3.TabIndex = 36;
            label3.Text = "Inicio";
            // 
            // lblPlanes
            // 
            lblPlanes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPlanes.AutoSize = true;
            lblPlanes.Location = new Point(16, 58);
            lblPlanes.Name = "lblPlanes";
            lblPlanes.Size = new Size(49, 28);
            lblPlanes.TabIndex = 35;
            lblPlanes.Text = "Plan";
            // 
            // FormGestionarSuscripciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1427, 782);
            Controls.Add(grupoNuevaSuscripcion);
            Controls.Add(panelSuperior);
            Controls.Add(dtgvSuscripciones);
            Controls.Add(btnSalir);
            Name = "FormGestionarSuscripciones";
            Text = "GESTIONAR SUSCRIPCIONES";
            Load += FormGestionarSuscripciones_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvSuscripciones).EndInit();
            grupoNuevaSuscripcion.ResumeLayout(false);
            grupoNuevaSuscripcion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSuperior;
        private Button btnAsignar;
        private ComboBox cmbPlanes;
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
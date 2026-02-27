namespace SAG___Diploma.Vista
{
    partial class FormGestionarClases
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
            btnAgregarHorario = new Button();
            dtpFinHorario = new DateTimePicker();
            label2 = new Label();
            cmbDiaSemana = new ComboBox();
            dtpInicioHorario = new DateTimePicker();
            btnEliminarHorario = new Button();
            label1 = new Label();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            btnSalir = new Button();
            dtgvClases = new DataGridView();
            dtgvHorarios = new DataGridView();
            btnAsistencia = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvClases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvHorarios).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAsistencia);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnAgregarHorario);
            panel1.Controls.Add(dtpFinHorario);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbDiaSemana);
            panel1.Controls.Add(dtpInicioHorario);
            panel1.Controls.Add(btnEliminarHorario);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnModificar);
            panel1.Controls.Add(btnAgregar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1427, 82);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(1028, 46);
            label3.Name = "label3";
            label3.Size = new Size(110, 28);
            label3.TabIndex = 10;
            label3.Text = "Horario Fin";
            // 
            // btnAgregarHorario
            // 
            btnAgregarHorario.Anchor = AnchorStyles.Right;
            btnAgregarHorario.Font = new Font("Segoe UI", 12F);
            btnAgregarHorario.Location = new Point(572, 3);
            btnAgregarHorario.Name = "btnAgregarHorario";
            btnAgregarHorario.Size = new Size(120, 68);
            btnAgregarHorario.TabIndex = 8;
            btnAgregarHorario.Text = "Agregar Horario";
            btnAgregarHorario.UseVisualStyleBackColor = true;
            btnAgregarHorario.Click += btnAgregarHorario_Click;
            // 
            // dtpFinHorario
            // 
            dtpFinHorario.Anchor = AnchorStyles.Right;
            dtpFinHorario.Font = new Font("Segoe UI", 12F);
            dtpFinHorario.Format = DateTimePickerFormat.Time;
            dtpFinHorario.Location = new Point(1165, 40);
            dtpFinHorario.Name = "dtpFinHorario";
            dtpFinHorario.Size = new Size(124, 34);
            dtpFinHorario.TabIndex = 7;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(1028, 9);
            label2.Name = "label2";
            label2.Size = new Size(131, 28);
            label2.TabIndex = 9;
            label2.Text = "Horario Inicio";
            // 
            // cmbDiaSemana
            // 
            cmbDiaSemana.Anchor = AnchorStyles.Right;
            cmbDiaSemana.Font = new Font("Segoe UI", 12F);
            cmbDiaSemana.FormattingEnabled = true;
            cmbDiaSemana.Location = new Point(865, 3);
            cmbDiaSemana.Name = "cmbDiaSemana";
            cmbDiaSemana.Size = new Size(157, 36);
            cmbDiaSemana.TabIndex = 5;
            // 
            // dtpInicioHorario
            // 
            dtpInicioHorario.Anchor = AnchorStyles.Right;
            dtpInicioHorario.Font = new Font("Segoe UI", 12F);
            dtpInicioHorario.Format = DateTimePickerFormat.Time;
            dtpInicioHorario.Location = new Point(1165, 0);
            dtpInicioHorario.Name = "dtpInicioHorario";
            dtpInicioHorario.Size = new Size(124, 34);
            dtpInicioHorario.TabIndex = 6;
            // 
            // btnEliminarHorario
            // 
            btnEliminarHorario.Anchor = AnchorStyles.Right;
            btnEliminarHorario.Font = new Font("Segoe UI", 12F);
            btnEliminarHorario.Location = new Point(1295, 3);
            btnEliminarHorario.Name = "btnEliminarHorario";
            btnEliminarHorario.Size = new Size(120, 68);
            btnEliminarHorario.TabIndex = 9;
            btnEliminarHorario.Text = "Eliminar Horario";
            btnEliminarHorario.UseVisualStyleBackColor = true;
            btnEliminarHorario.Click += btnEliminarHorario_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(698, 9);
            label1.Name = "label1";
            label1.Size = new Size(159, 28);
            label1.TabIndex = 8;
            label1.Text = "Dia de la semana";
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Left;
            btnEliminar.Font = new Font("Segoe UI", 12F);
            btnEliminar.Location = new Point(264, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 68);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Left;
            btnModificar.Font = new Font("Segoe UI", 12F);
            btnModificar.Location = new Point(138, 3);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 68);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Left;
            btnAgregar.Font = new Font("Segoe UI", 12F);
            btnAgregar.Location = new Point(12, 3);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 68);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = SystemColors.GradientActiveCaption;
            btnSalir.Font = new Font("Segoe UI", 12F);
            btnSalir.Location = new Point(1295, 704);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 68);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // dtgvClases
            // 
            dtgvClases.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvClases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvClases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvClases.Location = new Point(12, 154);
            dtgvClases.Name = "dtgvClases";
            dtgvClases.RowHeadersWidth = 51;
            dtgvClases.Size = new Size(821, 544);
            dtgvClases.TabIndex = 3;
            dtgvClases.CellClick += dtgvClases_CellClick;
            // 
            // dtgvHorarios
            // 
            dtgvHorarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvHorarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvHorarios.Location = new Point(1028, 154);
            dtgvHorarios.Name = "dtgvHorarios";
            dtgvHorarios.RowHeadersWidth = 51;
            dtgvHorarios.Size = new Size(387, 544);
            dtgvHorarios.TabIndex = 4;
            // 
            // btnAsistencia
            // 
            btnAsistencia.Anchor = AnchorStyles.Left;
            btnAsistencia.Font = new Font("Segoe UI", 12F);
            btnAsistencia.Location = new Point(390, 3);
            btnAsistencia.Name = "btnAsistencia";
            btnAsistencia.Size = new Size(120, 68);
            btnAsistencia.TabIndex = 5;
            btnAsistencia.Text = "Tomar Asistencia";
            btnAsistencia.UseVisualStyleBackColor = true;
            btnAsistencia.Click += btnAsistencia_Click;
            // 
            // FormGestionarClases
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1427, 782);
            Controls.Add(dtgvHorarios);
            Controls.Add(dtgvClases);
            Controls.Add(btnSalir);
            Controls.Add(panel1);
            Name = "FormGestionarClases";
            Text = "GESTIONAR CLASES";
            Load += FormGestionarClases_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvClases).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvHorarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnSalir;
        private DataGridView dtgvClases;
        private DataGridView dtgvHorarios;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private ComboBox cmbDiaSemana;
        private DateTimePicker dtpInicioHorario;
        private DateTimePicker dtpFinHorario;
        private Button btnAgregarHorario;
        private Button btnEliminarHorario;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAsistencia;
    }
}
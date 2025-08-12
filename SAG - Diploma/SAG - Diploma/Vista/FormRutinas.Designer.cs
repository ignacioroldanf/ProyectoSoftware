namespace SAG___Diploma.Vista
{
    partial class FormRutinas
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
            cmbDia = new ComboBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnAgregar = new Button();
            btnCerrar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnModificar = new Button();
            dtgvEjercicios = new DataGridView();
            btnSalir = new Button();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvEjercicios).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(cmbDia);
            panelSuperior.Controls.Add(label1);
            panelSuperior.Controls.Add(pictureBox1);
            panelSuperior.Controls.Add(btnAgregar);
            panelSuperior.Controls.Add(btnCerrar);
            panelSuperior.Controls.Add(btnEliminar);
            panelSuperior.Controls.Add(btnGuardar);
            panelSuperior.Controls.Add(btnModificar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1126, 61);
            panelSuperior.TabIndex = 35;
            // 
            // cmbDia
            // 
            cmbDia.FormattingEnabled = true;
            cmbDia.Location = new Point(877, 14);
            cmbDia.Name = "cmbDia";
            cmbDia.Size = new Size(151, 28);
            cmbDia.TabIndex = 32;
            cmbDia.SelectedIndexChanged += cmbDia_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(775, 17);
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
            // btnAgregar
            // 
            btnAgregar.BackColor = SystemColors.GradientActiveCaption;
            btnAgregar.Location = new Point(111, 3);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(105, 49);
            btnAgregar.TabIndex = 20;
            btnAgregar.Text = "Agregar Ejercicio";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = SystemColors.GradientActiveCaption;
            btnCerrar.Location = new Point(555, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(105, 49);
            btnCerrar.TabIndex = 28;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.GradientActiveCaption;
            btnEliminar.Location = new Point(333, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(105, 49);
            btnEliminar.TabIndex = 22;
            btnEliminar.Text = "Eliminar Ejercicio";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.GradientActiveCaption;
            btnGuardar.Location = new Point(444, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 49);
            btnGuardar.TabIndex = 27;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.GradientActiveCaption;
            btnModificar.Location = new Point(222, 3);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(105, 49);
            btnModificar.TabIndex = 21;
            btnModificar.Text = "Modificar Ejercicio";
            btnModificar.UseVisualStyleBackColor = false;
            // 
            // dtgvEjercicios
            // 
            dtgvEjercicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvEjercicios.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvEjercicios.BorderStyle = BorderStyle.None;
            dtgvEjercicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvEjercicios.Location = new Point(0, 119);
            dtgvEjercicios.Name = "dtgvEjercicios";
            dtgvEjercicios.RowHeadersWidth = 51;
            dtgvEjercicios.Size = new Size(1110, 479);
            dtgvEjercicios.TabIndex = 34;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = SystemColors.GradientActiveCaption;
            btnSalir.Location = new Point(1009, 604);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(101, 44);
            btnSalir.TabIndex = 33;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // FormRutinas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1126, 691);
            Controls.Add(panelSuperior);
            Controls.Add(dtgvEjercicios);
            Controls.Add(btnSalir);
            Name = "FormRutinas";
            Text = "FormRutinas";
            Load += FormRutinas_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvEjercicios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private ComboBox cmbDia;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnAgregar;
        private Button btnCerrar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnModificar;
        private DataGridView dtgvEjercicios;
        private Button btnSalir;
    }
}
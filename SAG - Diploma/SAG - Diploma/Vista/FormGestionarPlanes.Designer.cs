namespace SAG___Diploma.Vista
{
    partial class FormGestionarPlanes
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
            dtgvPlanes = new DataGridView();
            btnFiltrar = new Button();
            comboBox1 = new ComboBox();
            panelSuperior = new Panel();
            btnAsignar = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgvPlanes).BeginInit();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dtgvPlanes
            // 
            dtgvPlanes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvPlanes.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvPlanes.BorderStyle = BorderStyle.None;
            dtgvPlanes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvPlanes.Location = new Point(0, 77);
            dtgvPlanes.Name = "dtgvPlanes";
            dtgvPlanes.RowHeadersWidth = 51;
            dtgvPlanes.Size = new Size(1110, 479);
            dtgvPlanes.TabIndex = 14;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(1016, 23);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(94, 29);
            btnFiltrar.TabIndex = 15;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(831, 24);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(179, 28);
            comboBox1.TabIndex = 18;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(btnAsignar);
            panelSuperior.Controls.Add(comboBox1);
            panelSuperior.Controls.Add(label1);
            panelSuperior.Controls.Add(btnFiltrar);
            panelSuperior.Controls.Add(pictureBox1);
            panelSuperior.Controls.Add(btnAgregar);
            panelSuperior.Controls.Add(btnEliminar);
            panelSuperior.Controls.Add(btnModificar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1139, 61);
            panelSuperior.TabIndex = 33;
            // 
            // btnAsignar
            // 
            btnAsignar.BackColor = SystemColors.GradientActiveCaption;
            btnAsignar.Enabled = false;
            btnAsignar.Location = new Point(586, 3);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(105, 49);
            btnAsignar.TabIndex = 32;
            btnAsignar.Text = "Asignar Suscripcion";
            btnAsignar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(831, 1);
            label1.Name = "label1";
            label1.Size = new Size(159, 20);
            label1.TabIndex = 31;
            label1.Text = "Filtrar por tipo de plan";
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
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.GradientActiveCaption;
            btnEliminar.Location = new Point(333, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(105, 49);
            btnEliminar.TabIndex = 22;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.GradientActiveCaption;
            btnModificar.Location = new Point(222, 3);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(105, 49);
            btnModificar.TabIndex = 21;
            btnModificar.Text = "Modificar Precio";
            btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = SystemColors.GradientActiveCaption;
            btnSalir.Location = new Point(1009, 562);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(101, 44);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // FormGestionarPlanes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1139, 630);
            Controls.Add(panelSuperior);
            Controls.Add(dtgvPlanes);
            Controls.Add(btnSalir);
            Name = "FormGestionarPlanes";
            Text = "Gestionar Planes";
            Load += FormGestionarPlanes_Load;
            ((System.ComponentModel.ISupportInitialize)dtgvPlanes).EndInit();
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dtgvPlanes;
        private Button btnFiltrar;
        private ComboBox comboBox1;
        private Panel panelSuperior;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnSalir;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAsignar;
    }
}
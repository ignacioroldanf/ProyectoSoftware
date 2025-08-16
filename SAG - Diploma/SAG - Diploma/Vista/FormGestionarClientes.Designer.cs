namespace SAG___Diploma.Vista
{
    partial class FormGestionarClientes
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
            btnGestionarSuscripcion = new Button();
            dtgvClientes = new DataGridView();
            textBox1 = new TextBox();
            lblFiltrar = new Label();
            panelSuperior = new Panel();
            btnFiltrar = new Button();
            pictureBox1 = new PictureBox();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgvClientes).BeginInit();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnGestionarSuscripcion
            // 
            btnGestionarSuscripcion.BackColor = SystemColors.GradientActiveCaption;
            btnGestionarSuscripcion.Location = new Point(444, 3);
            btnGestionarSuscripcion.Name = "btnGestionarSuscripcion";
            btnGestionarSuscripcion.Size = new Size(105, 49);
            btnGestionarSuscripcion.TabIndex = 4;
            btnGestionarSuscripcion.Text = "Gestionar Suscripcion";
            btnGestionarSuscripcion.UseVisualStyleBackColor = false;
            btnGestionarSuscripcion.Click += btnGestionarSuscripcion_Click;
            // 
            // dtgvClientes
            // 
            dtgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvClientes.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvClientes.BorderStyle = BorderStyle.None;
            dtgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvClientes.Location = new Point(0, 77);
            dtgvClientes.Name = "dtgvClientes";
            dtgvClientes.RowHeadersWidth = 51;
            dtgvClientes.Size = new Size(1110, 479);
            dtgvClientes.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(780, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(230, 27);
            textBox1.TabIndex = 7;
            // 
            // lblFiltrar
            // 
            lblFiltrar.AutoSize = true;
            lblFiltrar.Location = new Point(780, 0);
            lblFiltrar.Name = "lblFiltrar";
            lblFiltrar.Size = new Size(230, 20);
            lblFiltrar.TabIndex = 8;
            lblFiltrar.Text = "Filtrar por número de documento";
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(btnFiltrar);
            panelSuperior.Controls.Add(lblFiltrar);
            panelSuperior.Controls.Add(btnGestionarSuscripcion);
            panelSuperior.Controls.Add(pictureBox1);
            panelSuperior.Controls.Add(textBox1);
            panelSuperior.Controls.Add(btnAgregar);
            panelSuperior.Controls.Add(btnEliminar);
            panelSuperior.Controls.Add(btnModificar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1147, 61);
            panelSuperior.TabIndex = 34;
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
            btnAgregar.Click += btnAgregar_Click;
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
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.GradientActiveCaption;
            btnModificar.Location = new Point(222, 3);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(105, 49);
            btnModificar.TabIndex = 21;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
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
            // FormGestionarClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1147, 673);
            Controls.Add(panelSuperior);
            Controls.Add(dtgvClientes);
            Controls.Add(btnSalir);
            Name = "FormGestionarClientes";
            Text = "Gestionar Clientes";
            Load += FormGestionarClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dtgvClientes).EndInit();
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnGestionarSuscripcion;
        private DataGridView dtgvClientes;
        private TextBox textBox1;
        private Label lblFiltrar;
        private Panel panelSuperior;
        private Button btnFiltrar;
        private PictureBox pictureBox1;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnSalir;
    }
}
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
            txtFiltrar = new TextBox();
            lblFiltrar = new Label();
            panelSuperior = new Panel();
            btnGestionarReservas = new Button();
            btnCargar = new Button();
            btnFiltrar = new Button();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgvClientes).BeginInit();
            panelSuperior.SuspendLayout();
            SuspendLayout();
            // 
            // btnGestionarSuscripcion
            // 
            btnGestionarSuscripcion.Anchor = AnchorStyles.Left;
            btnGestionarSuscripcion.BackColor = SystemColors.GradientActiveCaption;
            btnGestionarSuscripcion.Font = new Font("Segoe UI", 12F);
            btnGestionarSuscripcion.Location = new Point(390, 3);
            btnGestionarSuscripcion.Name = "btnGestionarSuscripcion";
            btnGestionarSuscripcion.Size = new Size(120, 68);
            btnGestionarSuscripcion.TabIndex = 4;
            btnGestionarSuscripcion.Text = "Gestionar Suscripcion";
            btnGestionarSuscripcion.UseVisualStyleBackColor = false;
            btnGestionarSuscripcion.Click += btnGestionarSuscripcion_Click;
            // 
            // dtgvClientes
            // 
            dtgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvClientes.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvClientes.BorderStyle = BorderStyle.None;
            dtgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvClientes.Location = new Point(12, 140);
            dtgvClientes.Name = "dtgvClientes";
            dtgvClientes.RowHeadersWidth = 51;
            dtgvClientes.Size = new Size(1403, 558);
            dtgvClientes.TabIndex = 5;
            // 
            // txtFiltrar
            // 
            txtFiltrar.Anchor = AnchorStyles.Right;
            txtFiltrar.Location = new Point(1059, 44);
            txtFiltrar.Name = "txtFiltrar";
            txtFiltrar.Size = new Size(230, 27);
            txtFiltrar.TabIndex = 7;
            // 
            // lblFiltrar
            // 
            lblFiltrar.Anchor = AnchorStyles.Right;
            lblFiltrar.AutoSize = true;
            lblFiltrar.Location = new Point(1059, 9);
            lblFiltrar.Name = "lblFiltrar";
            lblFiltrar.Size = new Size(230, 20);
            lblFiltrar.TabIndex = 8;
            lblFiltrar.Text = "Filtrar por número de documento";
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(btnGestionarReservas);
            panelSuperior.Controls.Add(btnCargar);
            panelSuperior.Controls.Add(lblFiltrar);
            panelSuperior.Controls.Add(btnFiltrar);
            panelSuperior.Controls.Add(btnGestionarSuscripcion);
            panelSuperior.Controls.Add(txtFiltrar);
            panelSuperior.Controls.Add(btnAgregar);
            panelSuperior.Controls.Add(btnEliminar);
            panelSuperior.Controls.Add(btnModificar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1427, 82);
            panelSuperior.TabIndex = 34;
            // 
            // btnGestionarReservas
            // 
            btnGestionarReservas.Font = new Font("Segoe UI", 12F);
            btnGestionarReservas.Location = new Point(516, 3);
            btnGestionarReservas.Name = "btnGestionarReservas";
            btnGestionarReservas.Size = new Size(120, 68);
            btnGestionarReservas.TabIndex = 24;
            btnGestionarReservas.Text = "Gestionar Reservas";
            btnGestionarReservas.UseVisualStyleBackColor = true;
            btnGestionarReservas.Click += btnGestionarReservas_Click;
            // 
            // btnCargar
            // 
            btnCargar.Anchor = AnchorStyles.Right;
            btnCargar.BackColor = SystemColors.GradientActiveCaption;
            btnCargar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCargar.Location = new Point(933, 3);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(120, 68);
            btnCargar.TabIndex = 23;
            btnCargar.Text = "Borrar Filtros";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Anchor = AnchorStyles.Right;
            btnFiltrar.Font = new Font("Segoe UI", 12F);
            btnFiltrar.Location = new Point(1295, 3);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(120, 68);
            btnFiltrar.TabIndex = 15;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Left;
            btnAgregar.BackColor = SystemColors.GradientActiveCaption;
            btnAgregar.Font = new Font("Segoe UI", 12F);
            btnAgregar.Location = new Point(12, 3);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 68);
            btnAgregar.TabIndex = 20;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Left;
            btnEliminar.BackColor = SystemColors.GradientActiveCaption;
            btnEliminar.Font = new Font("Segoe UI", 12F);
            btnEliminar.Location = new Point(264, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 68);
            btnEliminar.TabIndex = 22;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Left;
            btnModificar.BackColor = SystemColors.GradientActiveCaption;
            btnModificar.Font = new Font("Segoe UI", 12F);
            btnModificar.Location = new Point(138, 3);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 68);
            btnModificar.TabIndex = 21;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = SystemColors.GradientActiveCaption;
            btnSalir.Font = new Font("Segoe UI", 12F);
            btnSalir.Location = new Point(1295, 704);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 68);
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
            ClientSize = new Size(1427, 782);
            Controls.Add(panelSuperior);
            Controls.Add(btnSalir);
            Controls.Add(dtgvClientes);
            Name = "FormGestionarClientes";
            Text = "GESTIONAR CLIENTES";
            Load += FormGestionarClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dtgvClientes).EndInit();
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnGestionarSuscripcion;
        private DataGridView dtgvClientes;
        private TextBox txtFiltrar;
        private Label lblFiltrar;
        private Panel panelSuperior;
        private Button btnFiltrar;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnSalir;
        private Button btnCargar;
        private Button btnGestionarReservas;
    }
}
namespace SAG___Diploma.Vista
{
    partial class FormGestionarRutinas
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
            btnSalir = new Button();
            dtgvClientesPremium = new DataGridView();
            btnRegistrar = new Button();
            btnModificar = new Button();
            btnCrearRutina = new Button();
            btnConsultarHistorial = new Button();
            btnConsultarRutina = new Button();
            lblFiltrar = new Label();
            txtFiltrar = new TextBox();
            btnFiltrar = new Button();
            panelSuperior = new Panel();
            btnCargar = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgvClientesPremium).BeginInit();
            panelSuperior.SuspendLayout();
            SuspendLayout();
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
            btnSalir.Click += btnSalir_Click;
            // 
            // dtgvClientesPremium
            // 
            dtgvClientesPremium.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvClientesPremium.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvClientesPremium.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvClientesPremium.BorderStyle = BorderStyle.None;
            dtgvClientesPremium.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvClientesPremium.Location = new Point(12, 140);
            dtgvClientesPremium.Name = "dtgvClientesPremium";
            dtgvClientesPremium.RowHeadersWidth = 51;
            dtgvClientesPremium.Size = new Size(1403, 567);
            dtgvClientesPremium.TabIndex = 23;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Left;
            btnRegistrar.BackColor = SystemColors.GradientActiveCaption;
            btnRegistrar.Font = new Font("Segoe UI", 12F);
            btnRegistrar.Location = new Point(264, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(120, 68);
            btnRegistrar.TabIndex = 22;
            btnRegistrar.Text = "Registrar Progreso";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Left;
            btnModificar.BackColor = SystemColors.GradientActiveCaption;
            btnModificar.Font = new Font("Segoe UI", 12F);
            btnModificar.Location = new Point(516, 3);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 68);
            btnModificar.TabIndex = 21;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnCrearRutina
            // 
            btnCrearRutina.Anchor = AnchorStyles.Left;
            btnCrearRutina.BackColor = SystemColors.GradientActiveCaption;
            btnCrearRutina.Font = new Font("Segoe UI", 12F);
            btnCrearRutina.Location = new Point(390, 3);
            btnCrearRutina.Name = "btnCrearRutina";
            btnCrearRutina.Size = new Size(120, 68);
            btnCrearRutina.TabIndex = 20;
            btnCrearRutina.Text = "Crear Rutina";
            btnCrearRutina.UseVisualStyleBackColor = false;
            btnCrearRutina.Click += btnCrearRutina_Click;
            // 
            // btnConsultarHistorial
            // 
            btnConsultarHistorial.Anchor = AnchorStyles.Left;
            btnConsultarHistorial.BackColor = SystemColors.GradientActiveCaption;
            btnConsultarHistorial.Font = new Font("Segoe UI", 12F);
            btnConsultarHistorial.Location = new Point(138, 3);
            btnConsultarHistorial.Name = "btnConsultarHistorial";
            btnConsultarHistorial.Size = new Size(120, 68);
            btnConsultarHistorial.TabIndex = 27;
            btnConsultarHistorial.Text = "Consultar Historial";
            btnConsultarHistorial.UseVisualStyleBackColor = false;
            btnConsultarHistorial.Click += btnConsultarHistorial_Click;
            // 
            // btnConsultarRutina
            // 
            btnConsultarRutina.Anchor = AnchorStyles.Left;
            btnConsultarRutina.BackColor = SystemColors.GradientActiveCaption;
            btnConsultarRutina.Font = new Font("Segoe UI", 12F);
            btnConsultarRutina.Location = new Point(12, 3);
            btnConsultarRutina.Name = "btnConsultarRutina";
            btnConsultarRutina.Size = new Size(120, 68);
            btnConsultarRutina.TabIndex = 28;
            btnConsultarRutina.Text = "Consultar Rutina";
            btnConsultarRutina.UseVisualStyleBackColor = false;
            btnConsultarRutina.Click += btnConsultarRutina_Click;
            // 
            // lblFiltrar
            // 
            lblFiltrar.Anchor = AnchorStyles.Right;
            lblFiltrar.AutoSize = true;
            lblFiltrar.Location = new Point(1059, 9);
            lblFiltrar.Name = "lblFiltrar";
            lblFiltrar.Size = new Size(230, 20);
            lblFiltrar.TabIndex = 31;
            lblFiltrar.Text = "Filtrar por número de documento";
            // 
            // txtFiltrar
            // 
            txtFiltrar.Anchor = AnchorStyles.Right;
            txtFiltrar.Location = new Point(1059, 44);
            txtFiltrar.Name = "txtFiltrar";
            txtFiltrar.Size = new Size(230, 27);
            txtFiltrar.TabIndex = 30;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Anchor = AnchorStyles.Right;
            btnFiltrar.Font = new Font("Segoe UI", 12F);
            btnFiltrar.Location = new Point(1295, 3);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(120, 68);
            btnFiltrar.TabIndex = 29;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(btnCargar);
            panelSuperior.Controls.Add(btnFiltrar);
            panelSuperior.Controls.Add(lblFiltrar);
            panelSuperior.Controls.Add(btnCrearRutina);
            panelSuperior.Controls.Add(btnConsultarRutina);
            panelSuperior.Controls.Add(txtFiltrar);
            panelSuperior.Controls.Add(btnRegistrar);
            panelSuperior.Controls.Add(btnConsultarHistorial);
            panelSuperior.Controls.Add(btnModificar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1427, 82);
            panelSuperior.TabIndex = 32;
            // 
            // btnCargar
            // 
            btnCargar.Anchor = AnchorStyles.Right;
            btnCargar.BackColor = SystemColors.GradientActiveCaption;
            btnCargar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCargar.Location = new Point(933, 3);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(120, 68);
            btnCargar.TabIndex = 33;
            btnCargar.Text = "Borrar Filtros";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // FormGestionarRutinas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1427, 782);
            Controls.Add(panelSuperior);
            Controls.Add(dtgvClientesPremium);
            Controls.Add(btnSalir);
            MinimizeBox = false;
            Name = "FormGestionarRutinas";
            Text = "GESTIONAR RUTINAS Y PROGRESOS";
            Load += FormGestionarRutinas_Load;
            ((System.ComponentModel.ISupportInitialize)dtgvClientesPremium).EndInit();
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private DataGridView dtgvClientesPremium;
        private Button btnRegistrar;
        private Button btnModificar;
        private Button btnCrearRutina;
        private Button btnConsultarHistorial;
        private Button btnConsultarRutina;
        private Label lblFiltrar;
        private TextBox txtFiltrar;
        private Button btnFiltrar;
        private Panel panelSuperior;
        private Button btnCargar;
    }
}
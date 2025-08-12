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
            textBox1 = new TextBox();
            btnFiltrar = new Button();
            panelSuperior = new Panel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dtgvClientesPremium).BeginInit();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            btnSalir.Click += btnSalir_Click;
            // 
            // dtgvClientesPremium
            // 
            dtgvClientesPremium.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvClientesPremium.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvClientesPremium.BorderStyle = BorderStyle.None;
            dtgvClientesPremium.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvClientesPremium.Location = new Point(0, 77);
            dtgvClientesPremium.Name = "dtgvClientesPremium";
            dtgvClientesPremium.RowHeadersWidth = 51;
            dtgvClientesPremium.Size = new Size(1110, 479);
            dtgvClientesPremium.TabIndex = 23;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = SystemColors.GradientActiveCaption;
            btnRegistrar.Location = new Point(333, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(105, 49);
            btnRegistrar.TabIndex = 22;
            btnRegistrar.Text = "Registrar Progreso";
            btnRegistrar.UseVisualStyleBackColor = false;
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
            // 
            // btnCrearRutina
            // 
            btnCrearRutina.BackColor = SystemColors.GradientActiveCaption;
            btnCrearRutina.Location = new Point(111, 3);
            btnCrearRutina.Name = "btnCrearRutina";
            btnCrearRutina.Size = new Size(105, 49);
            btnCrearRutina.TabIndex = 20;
            btnCrearRutina.Text = "Crear Rutina";
            btnCrearRutina.UseVisualStyleBackColor = false;
            btnCrearRutina.Click += btnCrearRutina_Click;
            // 
            // btnConsultarHistorial
            // 
            btnConsultarHistorial.BackColor = SystemColors.GradientActiveCaption;
            btnConsultarHistorial.Location = new Point(444, 3);
            btnConsultarHistorial.Name = "btnConsultarHistorial";
            btnConsultarHistorial.Size = new Size(105, 49);
            btnConsultarHistorial.TabIndex = 27;
            btnConsultarHistorial.Text = "Consultar Historial";
            btnConsultarHistorial.UseVisualStyleBackColor = false;
            // 
            // btnConsultarRutina
            // 
            btnConsultarRutina.BackColor = SystemColors.GradientActiveCaption;
            btnConsultarRutina.Location = new Point(555, 3);
            btnConsultarRutina.Name = "btnConsultarRutina";
            btnConsultarRutina.Size = new Size(105, 49);
            btnConsultarRutina.TabIndex = 28;
            btnConsultarRutina.Text = "Consultar Rutina";
            btnConsultarRutina.UseVisualStyleBackColor = false;
            // 
            // lblFiltrar
            // 
            lblFiltrar.AutoSize = true;
            lblFiltrar.Location = new Point(780, 0);
            lblFiltrar.Name = "lblFiltrar";
            lblFiltrar.Size = new Size(230, 20);
            lblFiltrar.TabIndex = 31;
            lblFiltrar.Text = "Filtrar por número de documento";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(780, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(230, 27);
            textBox1.TabIndex = 30;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(1016, 23);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(94, 29);
            btnFiltrar.TabIndex = 29;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(btnFiltrar);
            panelSuperior.Controls.Add(lblFiltrar);
            panelSuperior.Controls.Add(pictureBox1);
            panelSuperior.Controls.Add(textBox1);
            panelSuperior.Controls.Add(btnCrearRutina);
            panelSuperior.Controls.Add(btnConsultarRutina);
            panelSuperior.Controls.Add(btnRegistrar);
            panelSuperior.Controls.Add(btnConsultarHistorial);
            panelSuperior.Controls.Add(btnModificar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1139, 61);
            panelSuperior.TabIndex = 32;
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
            // FormGestionarRutinas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1139, 650);
            Controls.Add(panelSuperior);
            Controls.Add(dtgvClientesPremium);
            Controls.Add(btnSalir);
            MinimizeBox = false;
            Name = "FormGestionarRutinas";
            Text = "Gestionar Rutinas y Progresos";
            Load += FormGestionarRutinas_Load;
            ((System.ComponentModel.ISupportInitialize)dtgvClientesPremium).EndInit();
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private TextBox textBox1;
        private Button btnFiltrar;
        private Panel panelSuperior;
        private PictureBox pictureBox1;
    }
}
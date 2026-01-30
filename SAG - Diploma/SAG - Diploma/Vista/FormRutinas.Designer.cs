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
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnModificar = new Button();
            dtgvEjercicios = new DataGridView();
            btnSalir = new Button();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvEjercicios).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(cmbDia);
            panelSuperior.Controls.Add(label1);
            panelSuperior.Controls.Add(btnAgregar);
            panelSuperior.Controls.Add(btnEliminar);
            panelSuperior.Controls.Add(btnGuardar);
            panelSuperior.Controls.Add(btnModificar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1427, 82);
            panelSuperior.TabIndex = 35;
            // 
            // cmbDia
            // 
            cmbDia.Anchor = AnchorStyles.Right;
            cmbDia.Font = new Font("Segoe UI", 12F);
            cmbDia.FormattingEnabled = true;
            cmbDia.Location = new Point(1264, 20);
            cmbDia.Name = "cmbDia";
            cmbDia.Size = new Size(151, 36);
            cmbDia.TabIndex = 32;
            cmbDia.SelectedIndexChanged += cmbDia_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(1134, 23);
            label1.Name = "label1";
            label1.Size = new Size(124, 28);
            label1.TabIndex = 31;
            label1.Text = "Ejercicios del";
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
            btnAgregar.Text = "Agregar Ejercicio";
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
            btnEliminar.Text = "Eliminar Ejercicio";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Left;
            btnGuardar.BackColor = SystemColors.GradientActiveCaption;
            btnGuardar.Font = new Font("Segoe UI", 12F);
            btnGuardar.Location = new Point(390, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 68);
            btnGuardar.TabIndex = 27;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
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
            btnModificar.Text = "Modificar Ejercicio";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // dtgvEjercicios
            // 
            dtgvEjercicios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvEjercicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvEjercicios.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvEjercicios.BorderStyle = BorderStyle.None;
            dtgvEjercicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvEjercicios.Location = new Point(12, 140);
            dtgvEjercicios.Name = "dtgvEjercicios";
            dtgvEjercicios.RowHeadersWidth = 51;
            dtgvEjercicios.Size = new Size(1403, 558);
            dtgvEjercicios.TabIndex = 34;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = SystemColors.GradientActiveCaption;
            btnSalir.Location = new Point(1295, 704);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 68);
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
            ClientSize = new Size(1427, 782);
            Controls.Add(panelSuperior);
            Controls.Add(dtgvEjercicios);
            Controls.Add(btnSalir);
            Name = "FormRutinas";
            Text = "GESTIONAR RUTINA";
            Load += FormRutinas_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvEjercicios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private ComboBox cmbDia;
        private Label label1;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnModificar;
        private DataGridView dtgvEjercicios;
        private Button btnSalir;
    }
}
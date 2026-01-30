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
            panelSuperior = new Panel();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgvPlanes).BeginInit();
            panelSuperior.SuspendLayout();
            SuspendLayout();
            // 
            // dtgvPlanes
            // 
            dtgvPlanes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvPlanes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvPlanes.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvPlanes.BorderStyle = BorderStyle.None;
            dtgvPlanes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvPlanes.Location = new Point(12, 140);
            dtgvPlanes.Name = "dtgvPlanes";
            dtgvPlanes.RowHeadersWidth = 51;
            dtgvPlanes.Size = new Size(1256, 479);
            dtgvPlanes.TabIndex = 14;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(btnAgregar);
            panelSuperior.Controls.Add(btnModificar);
            panelSuperior.Controls.Add(btnEliminar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1280, 82);
            panelSuperior.TabIndex = 33;
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
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Left;
            btnModificar.BackColor = SystemColors.GradientActiveCaption;
            btnModificar.Font = new Font("Segoe UI", 12F);
            btnModificar.Location = new Point(138, 3);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 68);
            btnModificar.TabIndex = 21;
            btnModificar.Text = "Modificar Precio";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
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
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = SystemColors.GradientActiveCaption;
            btnSalir.Font = new Font("Segoe UI", 12F);
            btnSalir.Location = new Point(1148, 674);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 68);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // FormGestionarPlanes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1280, 754);
            Controls.Add(panelSuperior);
            Controls.Add(btnSalir);
            Controls.Add(dtgvPlanes);
            Name = "FormGestionarPlanes";
            Text = "GESTIONAR PLANES";
            Load += FormGestionarPlanes_Load;
            ((System.ComponentModel.ISupportInitialize)dtgvPlanes).EndInit();
            panelSuperior.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dtgvPlanes;
        private Panel panelSuperior;
        private Button btnSalir;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificar;
    }
}
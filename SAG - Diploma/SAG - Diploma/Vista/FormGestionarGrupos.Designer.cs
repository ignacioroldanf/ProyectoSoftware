namespace SAG___Diploma.Vista
{
    partial class FormGestionarGrupos
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
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            dtgvGrupos = new DataGridView();
            btnSalir = new Button();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvGrupos).BeginInit();
            SuspendLayout();
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
            panelSuperior.TabIndex = 34;
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
            btnModificar.Text = "Modificar";
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
            // dtgvGrupos
            // 
            dtgvGrupos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvGrupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvGrupos.BackgroundColor = SystemColors.GradientActiveCaption;
            dtgvGrupos.BorderStyle = BorderStyle.None;
            dtgvGrupos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvGrupos.Location = new Point(12, 140);
            dtgvGrupos.Name = "dtgvGrupos";
            dtgvGrupos.RowHeadersWidth = 51;
            dtgvGrupos.Size = new Size(1256, 479);
            dtgvGrupos.TabIndex = 35;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = SystemColors.GradientActiveCaption;
            btnSalir.Font = new Font("Segoe UI", 12F);
            btnSalir.Location = new Point(1148, 674);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 68);
            btnSalir.TabIndex = 36;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // FormGestionarGrupos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1280, 754);
            Controls.Add(btnSalir);
            Controls.Add(dtgvGrupos);
            Controls.Add(panelSuperior);
            Name = "FormGestionarGrupos";
            Text = "FormGestionarGrupos";
            Load += FormGestionarGrupos_Load;
            panelSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvGrupos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private DataGridView dtgvGrupos;
        private Button btnSalir;
    }
}
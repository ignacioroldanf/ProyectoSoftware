namespace SAG___Diploma.Vista
{
    partial class FormGestionarUsuarios
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
            btnBorrarFiltros = new Button();
            btnFiltrar = new Button();
            label1 = new Label();
            cmbEstado = new ComboBox();
            btnModificar = new Button();
            btnResetear = new Button();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            dtgvUsuarios = new DataGridView();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(btnBorrarFiltros);
            panelSuperior.Controls.Add(btnFiltrar);
            panelSuperior.Controls.Add(label1);
            panelSuperior.Controls.Add(cmbEstado);
            panelSuperior.Controls.Add(btnModificar);
            panelSuperior.Controls.Add(btnResetear);
            panelSuperior.Controls.Add(btnAgregar);
            panelSuperior.Controls.Add(btnEliminar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1427, 82);
            panelSuperior.TabIndex = 33;
            // 
            // btnBorrarFiltros
            // 
            btnBorrarFiltros.Anchor = AnchorStyles.Right;
            btnBorrarFiltros.BackColor = SystemColors.GradientActiveCaption;
            btnBorrarFiltros.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBorrarFiltros.Location = new Point(1000, 3);
            btnBorrarFiltros.Name = "btnBorrarFiltros";
            btnBorrarFiltros.Size = new Size(120, 68);
            btnBorrarFiltros.TabIndex = 40;
            btnBorrarFiltros.Text = "Borrar Filtros";
            btnBorrarFiltros.UseVisualStyleBackColor = false;
            btnBorrarFiltros.Click += btnBorrarFiltros_Click;
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
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(1126, 12);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 37;
            label1.Text = "Estado";
            // 
            // cmbEstado
            // 
            cmbEstado.Anchor = AnchorStyles.Right;
            cmbEstado.Font = new Font("Segoe UI", 12F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(1126, 35);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(163, 36);
            cmbEstado.TabIndex = 36;
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
            // btnResetear
            // 
            btnResetear.Anchor = AnchorStyles.Left;
            btnResetear.BackColor = SystemColors.GradientActiveCaption;
            btnResetear.Font = new Font("Segoe UI", 12F);
            btnResetear.Location = new Point(390, 3);
            btnResetear.Name = "btnResetear";
            btnResetear.Size = new Size(120, 68);
            btnResetear.TabIndex = 20;
            btnResetear.Text = "Resetear Clave";
            btnResetear.UseVisualStyleBackColor = false;
            btnResetear.Click += btnResetear_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Left;
            btnAgregar.BackColor = SystemColors.GradientActiveCaption;
            btnAgregar.Font = new Font("Segoe UI", 12F);
            btnAgregar.Location = new Point(12, 3);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 68);
            btnAgregar.TabIndex = 28;
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
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(1295, 704);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 68);
            btnCancelar.TabIndex = 38;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dtgvUsuarios
            // 
            dtgvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvUsuarios.BorderStyle = BorderStyle.None;
            dtgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvUsuarios.Location = new Point(12, 140);
            dtgvUsuarios.Name = "dtgvUsuarios";
            dtgvUsuarios.RowHeadersWidth = 51;
            dtgvUsuarios.Size = new Size(1403, 531);
            dtgvUsuarios.TabIndex = 39;
            // 
            // FormGestionarUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1427, 782);
            Controls.Add(dtgvUsuarios);
            Controls.Add(btnCancelar);
            Controls.Add(panelSuperior);
            Name = "FormGestionarUsuarios";
            Text = "GESTIONAR USUARIOS";
            Load += FormGestionarUsuarios_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Button btnModificar;
        private Button btnFiltrar;
        private Button btnResetear;
        private Button btnAgregar;
        private Button btnEliminar;
        private Label label1;
        private ComboBox cmbEstado;
        private Button btnCancelar;
        private DataGridView dtgvClientes;
        private Button btnBorrarFiltros;
        private DataGridView dtgvUsuarios;
    }
}
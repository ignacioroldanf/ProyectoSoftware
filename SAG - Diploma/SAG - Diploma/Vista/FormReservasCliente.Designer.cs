namespace SAG___Diploma.Vista
{
    partial class FormReservasCliente
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
            panel1 = new Panel();
            btnBorrarFiltros = new Button();
            btnNuevaReserva = new Button();
            btnFiltrar = new Button();
            label1 = new Label();
            btnCancelarSuscripcion = new Button();
            cmbEstado = new ComboBox();
            btnCancelarClase = new Button();
            lblCliente = new Label();
            dtgvReservas = new DataGridView();
            btnCerrar = new Button();
            label2 = new Label();
            cmbClase = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvReservas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbClase);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnBorrarFiltros);
            panel1.Controls.Add(btnNuevaReserva);
            panel1.Controls.Add(btnFiltrar);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnCancelarSuscripcion);
            panel1.Controls.Add(cmbEstado);
            panel1.Controls.Add(btnCancelarClase);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1286, 82);
            panel1.TabIndex = 0;
            // 
            // btnBorrarFiltros
            // 
            btnBorrarFiltros.Anchor = AnchorStyles.Right;
            btnBorrarFiltros.BackColor = SystemColors.GradientActiveCaption;
            btnBorrarFiltros.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBorrarFiltros.Location = new Point(690, 3);
            btnBorrarFiltros.Name = "btnBorrarFiltros";
            btnBorrarFiltros.Size = new Size(120, 68);
            btnBorrarFiltros.TabIndex = 44;
            btnBorrarFiltros.Text = "Borrar Filtros";
            btnBorrarFiltros.UseVisualStyleBackColor = false;
            btnBorrarFiltros.Click += btnBorrarFiltros_Click;
            // 
            // btnNuevaReserva
            // 
            btnNuevaReserva.Font = new Font("Segoe UI", 12F);
            btnNuevaReserva.Location = new Point(25, 3);
            btnNuevaReserva.Name = "btnNuevaReserva";
            btnNuevaReserva.Size = new Size(120, 68);
            btnNuevaReserva.TabIndex = 5;
            btnNuevaReserva.Text = "Nueva Reserva";
            btnNuevaReserva.UseVisualStyleBackColor = true;
            btnNuevaReserva.Click += btnNuevaReserva_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Anchor = AnchorStyles.Right;
            btnFiltrar.Font = new Font("Segoe UI", 12F);
            btnFiltrar.Location = new Point(1154, 3);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(120, 68);
            btnFiltrar.TabIndex = 41;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(985, 12);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 43;
            label1.Text = "Estado";
            // 
            // btnCancelarSuscripcion
            // 
            btnCancelarSuscripcion.Font = new Font("Segoe UI", 12F);
            btnCancelarSuscripcion.Location = new Point(277, 3);
            btnCancelarSuscripcion.Name = "btnCancelarSuscripcion";
            btnCancelarSuscripcion.Size = new Size(120, 68);
            btnCancelarSuscripcion.TabIndex = 3;
            btnCancelarSuscripcion.Text = "Cancelar Suscripción";
            btnCancelarSuscripcion.UseVisualStyleBackColor = true;
            btnCancelarSuscripcion.Click += btnCancelarSuscripcion_Click;
            // 
            // cmbEstado
            // 
            cmbEstado.Anchor = AnchorStyles.Right;
            cmbEstado.Font = new Font("Segoe UI", 12F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(985, 35);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(163, 36);
            cmbEstado.TabIndex = 42;
            // 
            // btnCancelarClase
            // 
            btnCancelarClase.Font = new Font("Segoe UI", 12F);
            btnCancelarClase.Location = new Point(151, 3);
            btnCancelarClase.Name = "btnCancelarClase";
            btnCancelarClase.Size = new Size(120, 68);
            btnCancelarClase.TabIndex = 2;
            btnCancelarClase.Text = "Cancelar Clase";
            btnCancelarClase.UseVisualStyleBackColor = true;
            btnCancelarClase.Click += btnCancelarClase_Click;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 12F);
            lblCliente.Location = new Point(25, 85);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(117, 28);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Reservas de:";
            // 
            // dtgvReservas
            // 
            dtgvReservas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvReservas.Location = new Point(25, 116);
            dtgvReservas.Name = "dtgvReservas";
            dtgvReservas.RowHeadersWidth = 51;
            dtgvReservas.Size = new Size(1249, 271);
            dtgvReservas.TabIndex = 1;
            dtgvReservas.SelectionChanged += dtgvReservas_SelectionChanged;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.Font = new Font("Segoe UI", 12F);
            btnCerrar.Location = new Point(1154, 390);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(120, 68);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(816, 12);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 45;
            label2.Text = "Clase";
            // 
            // cmbClase
            // 
            cmbClase.Anchor = AnchorStyles.Right;
            cmbClase.Font = new Font("Segoe UI", 12F);
            cmbClase.FormattingEnabled = true;
            cmbClase.Location = new Point(816, 35);
            cmbClase.Name = "cmbClase";
            cmbClase.Size = new Size(163, 36);
            cmbClase.TabIndex = 46;
            // 
            // FormReservasCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 470);
            Controls.Add(btnCerrar);
            Controls.Add(dtgvReservas);
            Controls.Add(lblCliente);
            Controls.Add(panel1);
            Name = "FormReservasCliente";
            Text = "FormReservasCliente";
            Load += FormReservasCliente_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvReservas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblCliente;
        private DataGridView dtgvReservas;
        private Button btnCancelarClase;
        private Button btnCancelarSuscripcion;
        private Button btnCerrar;
        private Button btnNuevaReserva;
        private Button btnBorrarFiltros;
        private Button btnFiltrar;
        private Label label1;
        private ComboBox cmbEstado;
        private ComboBox cmbClase;
        private Label label2;
    }
}
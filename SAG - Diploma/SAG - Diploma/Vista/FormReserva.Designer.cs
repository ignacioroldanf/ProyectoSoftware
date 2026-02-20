namespace SAG___Diploma.Vista
{
    partial class FormReserva
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
            lblNombreCliente = new Label();
            btnConfirmarReserva = new Button();
            lblHorarioSeleccionado = new Label();
            chkEsRecurrente = new CheckBox();
            btnCancelar = new Button();
            cmbClase = new ComboBox();
            cmbDia = new ComboBox();
            dtpFechaExacta = new DateTimePicker();
            cmbHorario = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            lblCuposDisponibles = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            gbRecurrencia = new GroupBox();
            cmbTipoRecurrencia = new ComboBox();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            labelFecha = new Label();
            panelSuperior.SuspendLayout();
            gbRecurrencia.SuspendLayout();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.Controls.Add(lblNombreCliente);
            panelSuperior.Controls.Add(btnConfirmarReserva);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(491, 82);
            panelSuperior.TabIndex = 0;
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Location = new Point(28, 33);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(55, 20);
            lblNombreCliente.TabIndex = 14;
            lblNombreCliente.Text = "Cliente";
            // 
            // btnConfirmarReserva
            // 
            btnConfirmarReserva.Font = new Font("Segoe UI", 12F);
            btnConfirmarReserva.Location = new Point(347, 6);
            btnConfirmarReserva.Name = "btnConfirmarReserva";
            btnConfirmarReserva.Size = new Size(120, 68);
            btnConfirmarReserva.TabIndex = 3;
            btnConfirmarReserva.Text = "Confirmar Reserva";
            btnConfirmarReserva.UseVisualStyleBackColor = true;
            btnConfirmarReserva.Click += btnConfirmarReserva_Click;
            // 
            // lblHorarioSeleccionado
            // 
            lblHorarioSeleccionado.AutoSize = true;
            lblHorarioSeleccionado.Location = new Point(28, 159);
            lblHorarioSeleccionado.Name = "lblHorarioSeleccionado";
            lblHorarioSeleccionado.Size = new Size(60, 20);
            lblHorarioSeleccionado.TabIndex = 2;
            lblHorarioSeleccionado.Text = "Horario";
            // 
            // chkEsRecurrente
            // 
            chkEsRecurrente.AutoSize = true;
            chkEsRecurrente.Location = new Point(310, 197);
            chkEsRecurrente.Name = "chkEsRecurrente";
            chkEsRecurrente.Size = new Size(157, 24);
            chkEsRecurrente.TabIndex = 4;
            chkEsRecurrente.Text = "Reserva Recurrente";
            chkEsRecurrente.UseVisualStyleBackColor = true;
            chkEsRecurrente.CheckedChanged += chkEsRecurrente_CheckedChanged;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(347, 370);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 68);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cmbClase
            // 
            cmbClase.FormattingEnabled = true;
            cmbClase.Location = new Point(89, 89);
            cmbClase.Name = "cmbClase";
            cmbClase.Size = new Size(151, 28);
            cmbClase.TabIndex = 7;
            cmbClase.SelectedIndexChanged += cmbClase_SelectedIndexChanged;
            // 
            // cmbDia
            // 
            cmbDia.FormattingEnabled = true;
            cmbDia.Location = new Point(316, 89);
            cmbDia.Name = "cmbDia";
            cmbDia.Size = new Size(151, 28);
            cmbDia.TabIndex = 8;
            cmbDia.SelectedIndexChanged += cmbDia_SelectedIndexChanged;
            // 
            // dtpFechaExacta
            // 
            dtpFechaExacta.Location = new Point(89, 123);
            dtpFechaExacta.Name = "dtpFechaExacta";
            dtpFechaExacta.Size = new Size(378, 27);
            dtpFechaExacta.TabIndex = 8;
            dtpFechaExacta.ValueChanged += dtpFechaExacta_ValueChanged;
            // 
            // cmbHorario
            // 
            cmbHorario.FormattingEnabled = true;
            cmbHorario.Location = new Point(89, 156);
            cmbHorario.Name = "cmbHorario";
            cmbHorario.Size = new Size(151, 28);
            cmbHorario.TabIndex = 9;
            cmbHorario.SelectedIndexChanged += cmbHorario_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(255, 92);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 10;
            label1.Text = "Dia";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 92);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 11;
            label2.Text = "Clase";
            // 
            // lblCuposDisponibles
            // 
            lblCuposDisponibles.AutoSize = true;
            lblCuposDisponibles.Location = new Point(255, 159);
            lblCuposDisponibles.Name = "lblCuposDisponibles";
            lblCuposDisponibles.Size = new Size(135, 20);
            lblCuposDisponibles.TabIndex = 12;
            lblCuposDisponibles.Text = "Cupos Disponibles:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 48);
            label3.Name = "label3";
            label3.Size = new Size(141, 20);
            label3.TabIndex = 13;
            label3.Text = "Tipo de Recurrencia";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 81);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 14;
            label4.Text = "Fecha de Inicio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 112);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 15;
            label5.Text = "Fecha de Fin";
            // 
            // gbRecurrencia
            // 
            gbRecurrencia.Controls.Add(cmbTipoRecurrencia);
            gbRecurrencia.Controls.Add(dtpFechaInicio);
            gbRecurrencia.Controls.Add(dtpFechaFin);
            gbRecurrencia.Controls.Add(label8);
            gbRecurrencia.Controls.Add(label7);
            gbRecurrencia.Controls.Add(label6);
            gbRecurrencia.Location = new Point(28, 227);
            gbRecurrencia.Name = "gbRecurrencia";
            gbRecurrencia.Size = new Size(455, 137);
            gbRecurrencia.TabIndex = 13;
            gbRecurrencia.TabStop = false;
            gbRecurrencia.Text = "Recurrencia";
            // 
            // cmbTipoRecurrencia
            // 
            cmbTipoRecurrencia.FormattingEnabled = true;
            cmbTipoRecurrencia.Location = new Point(288, 26);
            cmbTipoRecurrencia.Name = "cmbTipoRecurrencia";
            cmbTipoRecurrencia.Size = new Size(151, 28);
            cmbTipoRecurrencia.TabIndex = 5;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(150, 60);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(289, 27);
            dtpFechaInicio.TabIndex = 4;
            dtpFechaInicio.ValueChanged += dtpFechaInicio_ValueChanged;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Location = new Point(150, 93);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(289, 27);
            dtpFechaFin.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 98);
            label8.Name = "label8";
            label8.Size = new Size(91, 20);
            label8.TabIndex = 2;
            label8.Text = "Fecha de Fin";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 65);
            label7.Name = "label7";
            label7.Size = new Size(108, 20);
            label7.TabIndex = 1;
            label7.Text = "Fecha de Inicio";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 29);
            label6.Name = "label6";
            label6.Size = new Size(141, 20);
            label6.TabIndex = 0;
            label6.Text = "Tipo de Recurrencia";
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.Location = new Point(28, 127);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(47, 20);
            labelFecha.TabIndex = 11;
            labelFecha.Text = "Fecha";
            // 
            // FormReserva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 446);
            Controls.Add(gbRecurrencia);
            Controls.Add(lblCuposDisponibles);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbHorario);
            Controls.Add(cmbDia);
            Controls.Add(dtpFechaExacta);
            Controls.Add(labelFecha);
            Controls.Add(cmbClase);
            Controls.Add(btnCancelar);
            Controls.Add(lblHorarioSeleccionado);
            Controls.Add(chkEsRecurrente);
            Controls.Add(panelSuperior);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormReserva";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormReserva";
            Load += FormReserva_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            gbRecurrencia.ResumeLayout(false);
            gbRecurrencia.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSuperior;
        private Label lblHorarioSeleccionado;
        private Label lblCliente;
        private CheckBox chkEsRecurrente;
        private GroupBox gbRecurrencia;
        private Button btnConfirmarReserva;
        private Button btnCancelar;
        private ComboBox cmbClase;
        private ComboBox cmbDia;
        private ComboBox cmbHorario;
        private Label label1;
        private Label label2;
        private Label lblCuposDisponibles;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label lblNombreCliente;
        private ComboBox cmbTipoRecurrencia;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private DateTimePicker dtpFechaExacta;
        private Label labelFecha;
        private Label label8;
        private Label label7;
        private Label label6;
    }
}
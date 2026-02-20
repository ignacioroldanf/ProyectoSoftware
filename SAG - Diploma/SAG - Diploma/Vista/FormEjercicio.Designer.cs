namespace SAG___Diploma.Vista
{
    partial class FormEjercicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEjercicio));
            panelSuperior = new Panel();
            pictureBox1 = new PictureBox();
            btnCancelar = new Button();
            label1 = new Label();
            btnGuardar = new Button();
            lblPeso = new Label();
            lblRepes = new Label();
            lblSeries = new Label();
            lblEjercicio = new Label();
            cmbEjercicio = new ComboBox();
            lblOrden = new Label();
            nudSeries = new NumericUpDown();
            nudRepes = new NumericUpDown();
            txtPeso = new TextBox();
            nudOrden = new NumericUpDown();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSeries).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRepes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudOrden).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(pictureBox1);
            panelSuperior.Controls.Add(btnCancelar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(422, 61);
            panelSuperior.TabIndex = 46;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.GradientActiveCaption;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(301, 7);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 49);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 77);
            label1.Name = "label1";
            label1.Size = new Size(376, 20);
            label1.TabIndex = 45;
            label1.Text = "Ingrese los datos del ejercicio y haga click en \"Guardar\"";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.GradientActiveCaption;
            btnGuardar.DialogResult = DialogResult.OK;
            btnGuardar.Location = new Point(301, 188);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 49);
            btnGuardar.TabIndex = 36;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Location = new Point(12, 188);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(39, 20);
            lblPeso.TabIndex = 44;
            lblPeso.Text = "Peso";
            // 
            // lblRepes
            // 
            lblRepes.AutoSize = true;
            lblRepes.Location = new Point(125, 143);
            lblRepes.Name = "lblRepes";
            lblRepes.Size = new Size(94, 20);
            lblRepes.TabIndex = 43;
            lblRepes.Text = "Repeticiones";
            // 
            // lblSeries
            // 
            lblSeries.AutoSize = true;
            lblSeries.Location = new Point(12, 143);
            lblSeries.Name = "lblSeries";
            lblSeries.Size = new Size(48, 20);
            lblSeries.TabIndex = 42;
            lblSeries.Text = "Series";
            // 
            // lblEjercicio
            // 
            lblEjercicio.AutoSize = true;
            lblEjercicio.Location = new Point(12, 110);
            lblEjercicio.Name = "lblEjercicio";
            lblEjercicio.Size = new Size(65, 20);
            lblEjercicio.TabIndex = 41;
            lblEjercicio.Text = "Ejercicio";
            // 
            // cmbEjercicio
            // 
            cmbEjercicio.BackColor = SystemColors.GradientActiveCaption;
            cmbEjercicio.FormattingEnabled = true;
            cmbEjercicio.Location = new Point(122, 107);
            cmbEjercicio.Name = "cmbEjercicio";
            cmbEjercicio.Size = new Size(271, 28);
            cmbEjercicio.TabIndex = 47;
            // 
            // lblOrden
            // 
            lblOrden.AutoSize = true;
            lblOrden.Location = new Point(284, 143);
            lblOrden.Name = "lblOrden";
            lblOrden.Size = new Size(50, 20);
            lblOrden.TabIndex = 48;
            lblOrden.Text = "Orden";
            // 
            // nudSeries
            // 
            nudSeries.BackColor = SystemColors.GradientActiveCaption;
            nudSeries.Location = new Point(66, 141);
            nudSeries.Name = "nudSeries";
            nudSeries.Size = new Size(53, 27);
            nudSeries.TabIndex = 49;
            // 
            // nudRepes
            // 
            nudRepes.BackColor = SystemColors.GradientActiveCaption;
            nudRepes.Location = new Point(225, 141);
            nudRepes.Name = "nudRepes";
            nudRepes.Size = new Size(53, 27);
            nudRepes.TabIndex = 50;
            // 
            // txtPeso
            // 
            txtPeso.BackColor = SystemColors.GradientActiveCaption;
            txtPeso.Location = new Point(66, 185);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(67, 27);
            txtPeso.TabIndex = 51;
            // 
            // nudOrden
            // 
            nudOrden.BackColor = SystemColors.GradientActiveCaption;
            nudOrden.Location = new Point(340, 141);
            nudOrden.Name = "nudOrden";
            nudOrden.Size = new Size(53, 27);
            nudOrden.TabIndex = 52;
            // 
            // FormEjercicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(422, 298);
            Controls.Add(nudOrden);
            Controls.Add(txtPeso);
            Controls.Add(nudRepes);
            Controls.Add(nudSeries);
            Controls.Add(lblOrden);
            Controls.Add(cmbEjercicio);
            Controls.Add(panelSuperior);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Controls.Add(lblPeso);
            Controls.Add(lblRepes);
            Controls.Add(lblSeries);
            Controls.Add(lblEjercicio);
            Name = "FormEjercicio";
            Text = "GESTIONAR EJERCICIO";
            Load += FormEjercicio_Load;
            panelSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSeries).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRepes).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudOrden).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSuperior;
        private PictureBox pictureBox1;
        private Button btnCancelar;
        private Label label1;
        private Button btnGuardar;
        private Label lblPeso;
        private Label lblRepes;
        private Label lblSeries;
        private Label lblEjercicio;
        private ComboBox cmbEjercicio;
        private Label lblOrden;
        private NumericUpDown nudSeries;
        private NumericUpDown nudRepes;
        private TextBox txtPeso;
        private NumericUpDown nudOrden;
    }
}
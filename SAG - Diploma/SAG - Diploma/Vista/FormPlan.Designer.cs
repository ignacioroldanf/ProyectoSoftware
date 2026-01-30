namespace SAG___Diploma.Vista
{
    partial class FormPlan
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
            lblDescripcion = new Label();
            lblNombre = new Label();
            lblPrecio = new Label();
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            panelSuperior = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            nudDuracion = new NumericUpDown();
            txtDuracion = new Label();
            chkSoporte = new CheckBox();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDuracion).BeginInit();
            SuspendLayout();
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(12, 217);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(87, 20);
            lblDescripcion.TabIndex = 20;
            lblDescripcion.Text = "Descripcion";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 118);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 19;
            lblNombre.Text = "Nombre";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(12, 184);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(109, 20);
            lblPrecio.TabIndex = 18;
            lblPrecio.Text = "Precio Mensual";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = SystemColors.GradientActiveCaption;
            txtDescripcion.Location = new Point(127, 214);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(187, 27);
            txtDescripcion.TabIndex = 16;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.GradientActiveCaption;
            txtNombre.Location = new Point(127, 115);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(187, 27);
            txtNombre.TabIndex = 15;
            // 
            // txtPrecio
            // 
            txtPrecio.BackColor = SystemColors.GradientActiveCaption;
            txtPrecio.Location = new Point(127, 181);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(187, 27);
            txtPrecio.TabIndex = 14;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.GradientActiveCaption;
            btnCancelar.Location = new Point(320, 277);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 49);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.GradientActiveCaption;
            btnGuardar.Location = new Point(209, 277);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 49);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(pictureBox1);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(434, 61);
            panelSuperior.TabIndex = 36;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 74);
            label1.Name = "label1";
            label1.Size = new Size(349, 20);
            label1.TabIndex = 37;
            label1.Text = "Ingrese los datos del plan y haga click en \"Guardar\"";
            // 
            // nudDuracion
            // 
            nudDuracion.BackColor = SystemColors.GradientActiveCaption;
            nudDuracion.Location = new Point(127, 148);
            nudDuracion.Name = "nudDuracion";
            nudDuracion.Size = new Size(187, 27);
            nudDuracion.TabIndex = 38;
            // 
            // txtDuracion
            // 
            txtDuracion.AutoSize = true;
            txtDuracion.Location = new Point(12, 150);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.Size = new Size(69, 20);
            txtDuracion.TabIndex = 39;
            txtDuracion.Text = "Duracion";
            // 
            // chkSoporte
            // 
            chkSoporte.AutoSize = true;
            chkSoporte.Location = new Point(230, 247);
            chkSoporte.Name = "chkSoporte";
            chkSoporte.Size = new Size(84, 24);
            chkSoporte.TabIndex = 40;
            chkSoporte.Text = "Soporte";
            chkSoporte.UseVisualStyleBackColor = true;
            // 
            // FormPlan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 353);
            Controls.Add(chkSoporte);
            Controls.Add(btnCancelar);
            Controls.Add(txtDuracion);
            Controls.Add(nudDuracion);
            Controls.Add(label1);
            Controls.Add(panelSuperior);
            Controls.Add(lblDescripcion);
            Controls.Add(lblNombre);
            Controls.Add(lblPrecio);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(txtPrecio);
            Controls.Add(btnGuardar);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormPlan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PLAN";
            Load += FormPlan_Load;
            panelSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDuracion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDescripcion;
        private Label lblNombre;
        private Label lblPrecio;
        private TextBox txtDescripcion;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private Button btnCancelar;
        private Button btnGuardar;
        private Panel panelSuperior;
        private PictureBox pictureBox1;
        private Label label1;
        private NumericUpDown nudDuracion;
        private Label txtDuracion;
        private CheckBox chkSoporte;
    }
}
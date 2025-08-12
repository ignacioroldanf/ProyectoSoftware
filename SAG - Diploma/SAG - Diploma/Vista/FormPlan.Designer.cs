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
            txtTipo = new Label();
            txtMail = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            cmbTipo = new ComboBox();
            panelSuperior = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(12, 218);
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
            lblPrecio.Location = new Point(12, 151);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(50, 20);
            lblPrecio.TabIndex = 18;
            lblPrecio.Text = "Precio";
            // 
            // txtTipo
            // 
            txtTipo.AutoSize = true;
            txtTipo.Location = new Point(12, 184);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(39, 20);
            txtTipo.TabIndex = 17;
            txtTipo.Text = "Tipo";
            // 
            // txtMail
            // 
            txtMail.BackColor = SystemColors.GradientActiveCaption;
            txtMail.Location = new Point(103, 215);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(187, 27);
            txtMail.TabIndex = 16;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.GradientActiveCaption;
            txtNombre.Location = new Point(103, 115);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(187, 27);
            txtNombre.TabIndex = 15;
            // 
            // txtPrecio
            // 
            txtPrecio.BackColor = SystemColors.GradientActiveCaption;
            txtPrecio.Location = new Point(103, 148);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(187, 27);
            txtPrecio.TabIndex = 14;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.GradientActiveCaption;
            btnCancelar.Location = new Point(296, 7);
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
            btnGuardar.Location = new Point(296, 193);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 49);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // cmbTipo
            // 
            cmbTipo.BackColor = SystemColors.GradientActiveCaption;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(103, 181);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(187, 28);
            cmbTipo.TabIndex = 21;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(pictureBox1);
            panelSuperior.Controls.Add(btnCancelar);
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
            // FormPlan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 450);
            Controls.Add(label1);
            Controls.Add(panelSuperior);
            Controls.Add(cmbTipo);
            Controls.Add(lblDescripcion);
            Controls.Add(lblNombre);
            Controls.Add(lblPrecio);
            Controls.Add(txtTipo);
            Controls.Add(txtMail);
            Controls.Add(txtNombre);
            Controls.Add(txtPrecio);
            Controls.Add(btnGuardar);
            Name = "FormPlan";
            Text = "Plan";
            panelSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDescripcion;
        private Label lblNombre;
        private Label lblPrecio;
        private Label txtTipo;
        private TextBox txtMail;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private Button btnCancelar;
        private Button btnGuardar;
        private ComboBox cmbTipo;
        private Panel panelSuperior;
        private PictureBox pictureBox1;
        private Label label1;
    }
}
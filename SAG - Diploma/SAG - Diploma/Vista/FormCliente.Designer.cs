namespace SAG___Diploma.Vista
{
    partial class FormCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCliente));
            btnGuardar = new Button();
            btnCancelar = new Button();
            txtDocumento = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            txtMail = new TextBox();
            lblDocumento = new Label();
            lblApellido = new Label();
            lblNombre = new Label();
            lblMail = new Label();
            label1 = new Label();
            panelSuperior = new Panel();
            pictureBox1 = new PictureBox();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.GradientActiveCaption;
            btnGuardar.DialogResult = DialogResult.OK;
            btnGuardar.Location = new Point(301, 185);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 49);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
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
            // txtDocumento
            // 
            txtDocumento.BackColor = SystemColors.GradientActiveCaption;
            txtDocumento.Location = new Point(105, 108);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(187, 27);
            txtDocumento.TabIndex = 3;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = SystemColors.GradientActiveCaption;
            txtApellido.Location = new Point(105, 141);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(187, 27);
            txtApellido.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.GradientActiveCaption;
            txtNombre.Location = new Point(105, 174);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(187, 27);
            txtNombre.TabIndex = 5;
            // 
            // txtMail
            // 
            txtMail.BackColor = SystemColors.GradientActiveCaption;
            txtMail.Location = new Point(105, 207);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(187, 27);
            txtMail.TabIndex = 6;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(12, 111);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(87, 20);
            lblDocumento.TabIndex = 7;
            lblDocumento.Text = "Documento";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(12, 144);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(66, 20);
            lblApellido.TabIndex = 8;
            lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 177);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Nombre";
            // 
            // lblMail
            // 
            lblMail.AutoSize = true;
            lblMail.Location = new Point(12, 210);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(38, 20);
            lblMail.TabIndex = 10;
            lblMail.Text = "Mail";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 78);
            label1.Name = "label1";
            label1.Size = new Size(364, 20);
            label1.TabIndex = 11;
            label1.Text = "Ingrese los datos del cliente y haga click en \"Guardar\"";
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(pictureBox1);
            panelSuperior.Controls.Add(btnCancelar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(418, 61);
            panelSuperior.TabIndex = 35;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // FormCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 278);
            Controls.Add(panelSuperior);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Controls.Add(lblMail);
            Controls.Add(lblNombre);
            Controls.Add(lblApellido);
            Controls.Add(lblDocumento);
            Controls.Add(txtMail);
            Controls.Add(txtNombre);
            Controls.Add(txtApellido);
            Controls.Add(txtDocumento);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cliente";
            panelSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnGuardar;
        private Button btnCancelar;
        private TextBox txtDocumento;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private TextBox txtMail;
        private Label lblDocumento;
        private Label lblApellido;
        private Label lblNombre;
        private Label lblMail;
        private Label label1;
        private Panel panelSuperior;
        private PictureBox pictureBox1;
    }
}
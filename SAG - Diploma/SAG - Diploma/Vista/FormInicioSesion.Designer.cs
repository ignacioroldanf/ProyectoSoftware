namespace SAG___Diploma.Vista
{
    partial class FormInicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicioSesion));
            panel1 = new Panel();
            pbCerrar = new PictureBox();
            pictureBox1 = new PictureBox();
            txtUsuario = new TextBox();
            txtContra = new TextBox();
            label1 = new Label();
            btnIniciarSesion = new Button();
            LabelContra = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pbCerrar);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(433, 178);
            panel1.TabIndex = 0;
            // 
            // pbCerrar
            // 
            pbCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbCerrar.Image = (Image)resources.GetObject("pbCerrar.Image");
            pbCerrar.Location = new Point(405, 12);
            pbCerrar.Name = "pbCerrar";
            pbCerrar.Size = new Size(16, 16);
            pbCerrar.TabIndex = 1;
            pbCerrar.TabStop = false;
            pbCerrar.Click += pbCerrar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(15, 15, 15);
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(433, 178);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtUsuario.BackColor = Color.FromArgb(15, 15, 15);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Segoe UI", 12F);
            txtUsuario.ForeColor = Color.DimGray;
            txtUsuario.Location = new Point(47, 282);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(339, 27);
            txtUsuario.TabIndex = 1;
            txtUsuario.Text = "USUARIO";
            txtUsuario.Enter += txtUsuario_Enter;
            txtUsuario.Leave += txtUsuario_Leave;
            // 
            // txtContra
            // 
            txtContra.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtContra.BackColor = Color.FromArgb(15, 15, 15);
            txtContra.BorderStyle = BorderStyle.None;
            txtContra.Font = new Font("Segoe UI", 12F);
            txtContra.ForeColor = Color.DimGray;
            txtContra.Location = new Point(47, 330);
            txtContra.Name = "txtContra";
            txtContra.Size = new Size(339, 27);
            txtContra.TabIndex = 2;
            txtContra.Text = "CONTRASEÑA";
            txtContra.Enter += txtContra_Enter;
            txtContra.Leave += txtContra_Leave;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(145, 202);
            label1.Name = "label1";
            label1.Size = new Size(139, 54);
            label1.TabIndex = 3;
            label1.Text = "LOGIN";
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnIniciarSesion.BackColor = Color.FromArgb(40, 40, 40);
            btnIniciarSesion.FlatAppearance.BorderSize = 0;
            btnIniciarSesion.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            btnIniciarSesion.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.Font = new Font("Segoe UI", 12F);
            btnIniciarSesion.ForeColor = Color.LightGray;
            btnIniciarSesion.Location = new Point(47, 381);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(339, 40);
            btnIniciarSesion.TabIndex = 3;
            btnIniciarSesion.Text = "INICIAR SESIÓN";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // LabelContra
            // 
            LabelContra.AutoSize = true;
            LabelContra.Font = new Font("Segoe UI", 10F);
            LabelContra.Location = new Point(131, 438);
            LabelContra.Name = "LabelContra";
            LabelContra.Size = new Size(171, 23);
            LabelContra.TabIndex = 4;
            LabelContra.TabStop = true;
            LabelContra.Text = "Restaurar contraseña";
            LabelContra.LinkClicked += LabelContra_LinkClicked;
            // 
            // FormInicioSesion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(433, 492);
            Controls.Add(LabelContra);
            Controls.Add(btnIniciarSesion);
            Controls.Add(label1);
            Controls.Add(txtContra);
            Controls.Add(txtUsuario);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormInicioSesion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormInicioSesion";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtUsuario;
        private TextBox txtContra;
        private Label label1;
        private Button btnIniciarSesion;
        private PictureBox pictureBox1;
        private PictureBox pbCerrar;
        private LinkLabel LabelContra;
    }
}
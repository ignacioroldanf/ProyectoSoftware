namespace SAG___Diploma.Vista
{
    partial class FormRecuperacion
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
            label1 = new Label();
            txtNuevaClave = new TextBox();
            txtToken = new TextBox();
            btnConfirmar = new Button();
            txtConfirmar = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnVerificarToken = new Button();
            gbClave = new GroupBox();
            btnVerClave = new Button();
            gbClave.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 39);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 0;
            label1.Text = "Token";
            // 
            // txtNuevaClave
            // 
            txtNuevaClave.Location = new Point(194, 39);
            txtNuevaClave.Name = "txtNuevaClave";
            txtNuevaClave.Size = new Size(156, 27);
            txtNuevaClave.TabIndex = 1;
            // 
            // txtToken
            // 
            txtToken.Location = new Point(225, 32);
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(156, 27);
            txtToken.TabIndex = 2;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(256, 140);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(94, 29);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // txtConfirmar
            // 
            txtConfirmar.Location = new Point(194, 87);
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.Size = new Size(156, 27);
            txtConfirmar.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 46);
            label2.Name = "label2";
            label2.Size = new Size(129, 20);
            label2.TabIndex = 5;
            label2.Text = "Nueva Contraseña";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 94);
            label3.Name = "label3";
            label3.Size = new Size(153, 20);
            label3.TabIndex = 6;
            label3.Text = "Confirmar Contraseña";
            // 
            // btnVerificarToken
            // 
            btnVerificarToken.Location = new Point(387, 25);
            btnVerificarToken.Name = "btnVerificarToken";
            btnVerificarToken.Size = new Size(97, 48);
            btnVerificarToken.TabIndex = 7;
            btnVerificarToken.Text = "Verificar Token";
            btnVerificarToken.UseVisualStyleBackColor = true;
            btnVerificarToken.Click += btnVerificarToken_Click;
            // 
            // gbClave
            // 
            gbClave.Controls.Add(btnVerClave);
            gbClave.Controls.Add(label2);
            gbClave.Controls.Add(txtNuevaClave);
            gbClave.Controls.Add(label3);
            gbClave.Controls.Add(btnConfirmar);
            gbClave.Controls.Add(txtConfirmar);
            gbClave.Location = new Point(31, 96);
            gbClave.Name = "gbClave";
            gbClave.Size = new Size(453, 190);
            gbClave.TabIndex = 8;
            gbClave.TabStop = false;
            gbClave.Text = "Restablecer Contraseña";
            // 
            // btnVerClave
            // 
            btnVerClave.Location = new Point(356, 39);
            btnVerClave.Name = "btnVerClave";
            btnVerClave.Size = new Size(79, 27);
            btnVerClave.TabIndex = 7;
            btnVerClave.Text = "Ver";
            btnVerClave.UseVisualStyleBackColor = true;
            btnVerClave.Click += btnVerClave_Click;
            // 
            // FormRecuperacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 334);
            Controls.Add(gbClave);
            Controls.Add(btnVerificarToken);
            Controls.Add(txtToken);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormRecuperacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Restablecer Contraseña";
            gbClave.ResumeLayout(false);
            gbClave.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNuevaClave;
        private TextBox txtToken;
        private Button btnConfirmar;
        private TextBox txtConfirmar;
        private Label label2;
        private Label label3;
        private Button btnVerificarToken;
        private GroupBox gbClave;
        private Button btnVerClave;
    }
}
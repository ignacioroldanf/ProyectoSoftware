namespace SAG___Diploma.Vista
{
    partial class FormContra
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
            btnCopiar = new Button();
            btnAceptar = new Button();
            txtContra = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCopiar
            // 
            btnCopiar.Location = new Point(25, 77);
            btnCopiar.Name = "btnCopiar";
            btnCopiar.Size = new Size(94, 29);
            btnCopiar.TabIndex = 0;
            btnCopiar.Text = "Copiar";
            btnCopiar.UseVisualStyleBackColor = true;
            btnCopiar.Click += btnCopiar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(125, 77);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtContra
            // 
            txtContra.Location = new Point(25, 44);
            txtContra.Name = "txtContra";
            txtContra.Size = new Size(194, 27);
            txtContra.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(226, 20);
            label1.TabIndex = 3;
            label1.Text = "Contraseña aleatoria establecida";
            // 
            // FormContra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 126);
            Controls.Add(label1);
            Controls.Add(txtContra);
            Controls.Add(btnAceptar);
            Controls.Add(btnCopiar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormContra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormContra";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCopiar;
        private Button btnAceptar;
        private TextBox txtContra;
        private Label label1;
    }
}
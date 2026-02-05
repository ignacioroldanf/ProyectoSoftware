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
            SuspendLayout();
            // 
            // btnCopiar
            // 
            btnCopiar.Location = new Point(137, 224);
            btnCopiar.Name = "btnCopiar";
            btnCopiar.Size = new Size(94, 29);
            btnCopiar.TabIndex = 0;
            btnCopiar.Text = "Copiar";
            btnCopiar.UseVisualStyleBackColor = true;
            btnCopiar.Click += btnCopiar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(253, 224);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtContra
            // 
            txtContra.Location = new Point(137, 176);
            txtContra.Name = "txtContra";
            txtContra.Size = new Size(125, 27);
            txtContra.TabIndex = 2;
            // 
            // FormContra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtContra);
            Controls.Add(btnAceptar);
            Controls.Add(btnCopiar);
            Name = "FormContra";
            Text = "FormContra";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCopiar;
        private Button btnAceptar;
        private TextBox txtContra;
    }
}
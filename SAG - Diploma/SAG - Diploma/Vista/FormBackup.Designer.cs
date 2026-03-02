namespace SAG___Diploma
{
    partial class FormBackup
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
            btnGenerarBackup = new Button();
            btnRestaurar = new Button();
            panel1 = new Panel();
            btnSalir = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenerarBackup
            // 
            btnGenerarBackup.Font = new Font("Segoe UI", 12F);
            btnGenerarBackup.Location = new Point(12, 124);
            btnGenerarBackup.Name = "btnGenerarBackup";
            btnGenerarBackup.Size = new Size(120, 68);
            btnGenerarBackup.TabIndex = 0;
            btnGenerarBackup.Text = "Generar Backup";
            btnGenerarBackup.UseVisualStyleBackColor = true;
            btnGenerarBackup.Click += btnGenerarBackup_Click;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Font = new Font("Segoe UI", 12F);
            btnRestaurar.Location = new Point(12, 249);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(120, 68);
            btnRestaurar.TabIndex = 1;
            btnRestaurar.Text = "Restaurar Backup";
            btnRestaurar.UseVisualStyleBackColor = true;
            btnRestaurar.Click += btnRestaurar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSalir);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(378, 82);
            panel1.TabIndex = 2;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.Font = new Font("Segoe UI", 12F);
            btnSalir.Location = new Point(246, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 68);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FormBackup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 353);
            Controls.Add(btnRestaurar);
            Controls.Add(btnGenerarBackup);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormBackup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BACKUP";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnGenerarBackup;
        private Button btnRestaurar;
        private Panel panel1;
        private Button btnSalir;
    }
}
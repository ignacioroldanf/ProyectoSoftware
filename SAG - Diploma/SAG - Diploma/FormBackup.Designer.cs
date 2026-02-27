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
            SuspendLayout();
            // 
            // btnGenerarBackup
            // 
            btnGenerarBackup.Location = new Point(232, 183);
            btnGenerarBackup.Name = "btnGenerarBackup";
            btnGenerarBackup.Size = new Size(94, 29);
            btnGenerarBackup.TabIndex = 0;
            btnGenerarBackup.Text = "Generar Backup";
            btnGenerarBackup.UseVisualStyleBackColor = true;
            btnGenerarBackup.Click += btnGenerarBackup_Click;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Location = new Point(361, 183);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(107, 45);
            btnRestaurar.TabIndex = 1;
            btnRestaurar.Text = "button1";
            btnRestaurar.UseVisualStyleBackColor = true;
            btnRestaurar.Click += btnRestaurar_Click;
            // 
            // FormBackup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRestaurar);
            Controls.Add(btnGenerarBackup);
            Name = "FormBackup";
            Text = "FormBackup";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGenerarBackup;
        private Button btnRestaurar;
    }
}
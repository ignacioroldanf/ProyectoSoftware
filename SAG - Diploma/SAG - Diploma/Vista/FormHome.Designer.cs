namespace SAG___Diploma.Vista
{
    partial class FormHome
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
            lblInicio = new Label();
            SuspendLayout();
            // 
            // lblInicio
            // 
            lblInicio.Anchor = AnchorStyles.None;
            lblInicio.AutoSize = true;
            lblInicio.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblInicio.Location = new Point(0, 0);
            lblInicio.Name = "lblInicio";
            lblInicio.Size = new Size(259, 62);
            lblInicio.TabIndex = 0;
            lblInicio.Text = "Bienvenido";
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(lblInicio);
            Name = "FormHome";
            Text = "INICIO";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblInicio;
    }
}
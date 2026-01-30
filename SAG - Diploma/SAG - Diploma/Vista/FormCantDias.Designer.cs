namespace SAG___Diploma.Vista
{
    partial class FormCantDias
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
            NmrCantDias = new NumericUpDown();
            BtnAceptar = new Button();
            BtnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)NmrCantDias).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 44);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(270, 28);
            label1.TabIndex = 0;
            label1.Text = "Cuantos días tendrá la rutina?";
            // 
            // NmrCantDias
            // 
            NmrCantDias.Location = new Point(13, 96);
            NmrCantDias.Margin = new Padding(4);
            NmrCantDias.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            NmrCantDias.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            NmrCantDias.Name = "NmrCantDias";
            NmrCantDias.Size = new Size(120, 34);
            NmrCantDias.TabIndex = 1;
            NmrCantDias.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // BtnAceptar
            // 
            BtnAceptar.BackColor = SystemColors.GradientActiveCaption;
            BtnAceptar.DialogResult = DialogResult.OK;
            BtnAceptar.Location = new Point(323, 92);
            BtnAceptar.Margin = new Padding(4);
            BtnAceptar.Name = "BtnAceptar";
            BtnAceptar.Size = new Size(129, 41);
            BtnAceptar.TabIndex = 2;
            BtnAceptar.Text = "Aceptar";
            BtnAceptar.UseVisualStyleBackColor = false;
            BtnAceptar.Click += BtnAceptar_Click;
            // 
            // BtnCancelar
            // 
            BtnCancelar.BackColor = SystemColors.GradientActiveCaption;
            BtnCancelar.DialogResult = DialogResult.Cancel;
            BtnCancelar.Location = new Point(323, 38);
            BtnCancelar.Margin = new Padding(4);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(129, 41);
            BtnCancelar.TabIndex = 3;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = false;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // FormCantDias
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(458, 193);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnAceptar);
            Controls.Add(NmrCantDias);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "FormCantDias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CANTIDAD DE DÍAS";
            ((System.ComponentModel.ISupportInitialize)NmrCantDias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown NmrCantDias;
        private Button BtnAceptar;
        private Button BtnCancelar;
    }
}
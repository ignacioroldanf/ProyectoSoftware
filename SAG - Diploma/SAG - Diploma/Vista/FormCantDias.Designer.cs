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
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(205, 20);
            label1.TabIndex = 0;
            label1.Text = "Cuantos días tendrá la rutina?";
            // 
            // NmrCantDias
            // 
            NmrCantDias.Location = new Point(67, 66);
            NmrCantDias.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            NmrCantDias.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            NmrCantDias.Name = "NmrCantDias";
            NmrCantDias.Size = new Size(150, 27);
            NmrCantDias.TabIndex = 1;
            NmrCantDias.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // BtnAceptar
            // 
            BtnAceptar.DialogResult = DialogResult.OK;
            BtnAceptar.Location = new Point(235, 66);
            BtnAceptar.Name = "BtnAceptar";
            BtnAceptar.Size = new Size(94, 29);
            BtnAceptar.TabIndex = 2;
            BtnAceptar.Text = "Aceptar";
            BtnAceptar.UseVisualStyleBackColor = true;
            BtnAceptar.Click += BtnAceptar_Click;
            // 
            // BtnCancelar
            // 
            BtnCancelar.DialogResult = DialogResult.Cancel;
            BtnCancelar.Location = new Point(235, 27);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(94, 29);
            BtnCancelar.TabIndex = 3;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // FormCantDias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(415, 171);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnAceptar);
            Controls.Add(NmrCantDias);
            Controls.Add(label1);
            Name = "FormCantDias";
            Text = "FormCantDias";
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
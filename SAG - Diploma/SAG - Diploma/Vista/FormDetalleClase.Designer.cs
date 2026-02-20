namespace SAG___Diploma.Vista
{
    partial class FormDetalleClase
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
            panel1 = new Panel();
            btnCancelar = new Button();
            btnGuardar = new Button();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            nudCupo = new NumericUpDown();
            cmbProfesor = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCupo).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(466, 82);
            panel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(334, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 68);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.Font = new Font("Segoe UI", 12F);
            btnGuardar.Location = new Point(334, 325);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 68);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 12F);
            txtNombre.Location = new Point(262, 88);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(192, 34);
            txtNombre.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Font = new Font("Segoe UI", 12F);
            txtDescripcion.Location = new Point(262, 128);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(192, 109);
            txtDescripcion.TabIndex = 3;
            // 
            // nudCupo
            // 
            nudCupo.Font = new Font("Segoe UI", 12F);
            nudCupo.Location = new Point(262, 243);
            nudCupo.Name = "nudCupo";
            nudCupo.Size = new Size(192, 34);
            nudCupo.TabIndex = 4;
            // 
            // cmbProfesor
            // 
            cmbProfesor.Font = new Font("Segoe UI", 12F);
            cmbProfesor.FormattingEnabled = true;
            cmbProfesor.Location = new Point(262, 283);
            cmbProfesor.Name = "cmbProfesor";
            cmbProfesor.Size = new Size(192, 36);
            cmbProfesor.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(29, 91);
            label1.Name = "label1";
            label1.Size = new Size(85, 28);
            label1.TabIndex = 6;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(29, 131);
            label2.Name = "label2";
            label2.Size = new Size(106, 28);
            label2.TabIndex = 7;
            label2.Text = "Decripción";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(29, 245);
            label3.Name = "label3";
            label3.Size = new Size(135, 28);
            label3.TabIndex = 8;
            label3.Text = "Cupo Máximo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(29, 286);
            label4.Name = "label4";
            label4.Size = new Size(85, 28);
            label4.TabIndex = 9;
            label4.Text = "Profesor";
            // 
            // FormDetalleClase
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 416);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbProfesor);
            Controls.Add(nudCupo);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(btnGuardar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormDetalleClase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DETALLE CLASE";
            Load += FormDetalleClase_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudCupo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnCancelar;
        private Button btnGuardar;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private NumericUpDown nudCupo;
        private ComboBox cmbProfesor;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
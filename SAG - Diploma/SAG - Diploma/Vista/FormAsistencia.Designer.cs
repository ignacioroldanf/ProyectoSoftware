namespace SAG___Diploma.Vista
{
    partial class FormAsistencia
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
            lblClase = new Label();
            btnGuardar = new Button();
            mcFechas = new MonthCalendar();
            label2 = new Label();
            dtgvAlumnos = new DataGridView();
            btnSalir = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvAlumnos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblClase);
            panel1.Controls.Add(btnGuardar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(866, 82);
            panel1.TabIndex = 0;
            // 
            // lblClase
            // 
            lblClase.AutoSize = true;
            lblClase.Font = new Font("Segoe UI", 12F);
            lblClase.Location = new Point(12, 23);
            lblClase.Name = "lblClase";
            lblClase.Size = new Size(57, 28);
            lblClase.TabIndex = 2;
            lblClase.Text = "Clase";
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Right;
            btnGuardar.Font = new Font("Segoe UI", 12F);
            btnGuardar.Location = new Point(732, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 68);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar Asistencia";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // mcFechas
            // 
            mcFechas.Location = new Point(583, 153);
            mcFechas.MaxSelectionCount = 1;
            mcFechas.Name = "mcFechas";
            mcFechas.TabIndex = 4;
            mcFechas.DateSelected += mcFechas_DateSelected;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(583, 116);
            label2.Name = "label2";
            label2.Size = new Size(62, 28);
            label2.TabIndex = 3;
            label2.Text = "Fecha";
            // 
            // dtgvAlumnos
            // 
            dtgvAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvAlumnos.Location = new Point(12, 153);
            dtgvAlumnos.Name = "dtgvAlumnos";
            dtgvAlumnos.RowHeadersWidth = 51;
            dtgvAlumnos.Size = new Size(559, 544);
            dtgvAlumnos.TabIndex = 1;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Font = new Font("Segoe UI", 12F);
            btnSalir.Location = new Point(732, 629);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 68);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 122);
            label1.Name = "label1";
            label1.Size = new Size(89, 28);
            label1.TabIndex = 5;
            label1.Text = "Alumnos";
            // 
            // FormAsistencia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(866, 716);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(btnSalir);
            Controls.Add(dtgvAlumnos);
            Controls.Add(panel1);
            Controls.Add(mcFechas);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormAsistencia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tomar Asistencia";
            Load += FormAsistencia_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvAlumnos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dtgvAlumnos;
        private Button btnGuardar;
        private ComboBox cmbClasesDelDia;
        private Label lblClase;
        private Label label2;
        private Button btnSalir;
        private MonthCalendar mcFechas;
        private Label label1;
    }
}
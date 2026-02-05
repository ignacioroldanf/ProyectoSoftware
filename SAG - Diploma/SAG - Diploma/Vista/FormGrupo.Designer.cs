namespace SAG___Diploma.Vista
{
    partial class FormGrupo
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
            panelSuperior = new Panel();
            btnGuardar = new Button();
            btnCancelar = new Button();
            tabControl = new TabControl();
            tpDatos = new TabPage();
            label4 = new Label();
            txtDNI = new TextBox();
            label3 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tpAcciones = new TabPage();
            tvAcciones = new TreeView();
            txtMail = new TextBox();
            panelSuperior.SuspendLayout();
            tabControl.SuspendLayout();
            tpDatos.SuspendLayout();
            tpAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(btnGuardar);
            panelSuperior.Controls.Add(btnCancelar);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1280, 82);
            panelSuperior.TabIndex = 35;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Left;
            btnGuardar.BackColor = SystemColors.GradientActiveCaption;
            btnGuardar.Font = new Font("Segoe UI", 12F);
            btnGuardar.Location = new Point(12, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 68);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Left;
            btnCancelar.BackColor = SystemColors.GradientActiveCaption;
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(1148, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 68);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tpDatos);
            tabControl.Controls.Add(tpAcciones);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 82);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1280, 672);
            tabControl.TabIndex = 36;
            // 
            // tpDatos
            // 
            tpDatos.Controls.Add(txtMail);
            tpDatos.Controls.Add(label4);
            tpDatos.Controls.Add(txtDNI);
            tpDatos.Controls.Add(label3);
            tpDatos.Controls.Add(txtNombre);
            tpDatos.Controls.Add(label2);
            tpDatos.Controls.Add(label1);
            tpDatos.Font = new Font("Segoe UI", 12F);
            tpDatos.Location = new Point(4, 29);
            tpDatos.Name = "tpDatos";
            tpDatos.Padding = new Padding(3);
            tpDatos.Size = new Size(1272, 639);
            tpDatos.TabIndex = 0;
            tpDatos.Text = "Datos";
            tpDatos.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 240);
            label4.Name = "label4";
            label4.Size = new Size(50, 28);
            label4.TabIndex = 6;
            label4.Text = "Mail";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(166, 174);
            txtDNI.Multiline = true;
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(176, 34);
            txtDNI.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 180);
            label3.Name = "label3";
            label3.Size = new Size(46, 28);
            label3.TabIndex = 4;
            label3.Text = "DNI";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(166, 63);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(176, 34);
            txtNombre.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 69);
            label2.Name = "label2";
            label2.Size = new Size(85, 28);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 120);
            label1.Name = "label1";
            label1.Size = new Size(86, 28);
            label1.TabIndex = 0;
            label1.Text = "Apellido";
            // 
            // tpAcciones
            // 
            tpAcciones.Controls.Add(tvAcciones);
            tpAcciones.Font = new Font("Segoe UI", 12F);
            tpAcciones.Location = new Point(4, 29);
            tpAcciones.Name = "tpAcciones";
            tpAcciones.Padding = new Padding(3);
            tpAcciones.Size = new Size(1272, 639);
            tpAcciones.TabIndex = 1;
            tpAcciones.Text = "Acciones";
            tpAcciones.UseVisualStyleBackColor = true;
            // 
            // tvAcciones
            // 
            tvAcciones.CheckBoxes = true;
            tvAcciones.Dock = DockStyle.Fill;
            tvAcciones.Location = new Point(3, 3);
            tvAcciones.Name = "tvAcciones";
            tvAcciones.Size = new Size(1266, 633);
            tvAcciones.TabIndex = 0;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(166, 234);
            txtMail.Multiline = true;
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(176, 34);
            txtMail.TabIndex = 7;
            // 
            // FormGrupo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 754);
            Controls.Add(tabControl);
            Controls.Add(panelSuperior);
            Name = "FormGrupo";
            Text = "FormGrupo";
            Load += FormGrupo_Load;
            panelSuperior.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tpDatos.ResumeLayout(false);
            tpDatos.PerformLayout();
            tpAcciones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Button btnAgregar;
        private Button btnCancelar;
        private Button btnEliminar;
        private TabControl tabControl;
        private TabPage tpDatos;
        private TextBox txtCodigo;
        private Label label1;
        private TabPage tpAcciones;
        private ComboBox cmbEstado;
        private Label label4;
        private TextBox txtDNI;
        private Label label3;
        private TextBox txtNombre;
        private Label label2;
        private TreeView tvAcciones;
        private Button btnGuardar;
        private TextBox txtMail;
    }
}
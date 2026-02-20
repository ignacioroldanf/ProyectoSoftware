namespace SAG___Diploma.Vista
{
    partial class FormUsuario
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
            tvAcciones = new TreeView();
            tabControl1 = new TabControl();
            tabPageDatos = new TabPage();
            comboBox1 = new ComboBox();
            label6 = new Label();
            txtUsuario = new TextBox();
            label5 = new Label();
            txtEmail = new TextBox();
            txtDNI = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtApellido = new TextBox();
            label1 = new Label();
            tabPageGrupos = new TabPage();
            clbGrupos = new CheckedListBox();
            tabPageAcciones = new TabPage();
            tvAccion = new TreeView();
            panelSuperior.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageDatos.SuspendLayout();
            tabPageGrupos.SuspendLayout();
            tabPageAcciones.SuspendLayout();
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
            panelSuperior.Size = new Size(645, 82);
            panelSuperior.TabIndex = 36;
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
            btnCancelar.Anchor = AnchorStyles.Right;
            btnCancelar.BackColor = SystemColors.GradientActiveCaption;
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(509, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 68);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // tvAcciones
            // 
            tvAcciones.CheckBoxes = true;
            tvAcciones.Dock = DockStyle.Fill;
            tvAcciones.LineColor = Color.Empty;
            tvAcciones.Location = new Point(10, 10);
            tvAcciones.Name = "tvAcciones";
            tvAcciones.Size = new Size(10, 10);
            tvAcciones.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageDatos);
            tabControl1.Controls.Add(tabPageGrupos);
            tabControl1.Controls.Add(tabPageAcciones);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 82);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(645, 564);
            tabControl1.TabIndex = 37;
            // 
            // tabPageDatos
            // 
            tabPageDatos.Controls.Add(comboBox1);
            tabPageDatos.Controls.Add(label6);
            tabPageDatos.Controls.Add(txtUsuario);
            tabPageDatos.Controls.Add(label5);
            tabPageDatos.Controls.Add(txtEmail);
            tabPageDatos.Controls.Add(txtDNI);
            tabPageDatos.Controls.Add(label4);
            tabPageDatos.Controls.Add(label3);
            tabPageDatos.Controls.Add(txtNombre);
            tabPageDatos.Controls.Add(label2);
            tabPageDatos.Controls.Add(txtApellido);
            tabPageDatos.Controls.Add(label1);
            tabPageDatos.Location = new Point(4, 29);
            tabPageDatos.Name = "tabPageDatos";
            tabPageDatos.Padding = new Padding(3);
            tabPageDatos.Size = new Size(637, 531);
            tabPageDatos.TabIndex = 0;
            tabPageDatos.Text = "Datos";
            tabPageDatos.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(181, 342);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(167, 28);
            comboBox1.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(48, 350);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 19;
            label6.Text = "Estado";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(181, 32);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(167, 27);
            txtUsuario.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 39);
            label5.Name = "label5";
            label5.Size = new Size(59, 20);
            label5.TabIndex = 17;
            label5.Text = "Usuario";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(181, 213);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(167, 27);
            txtEmail.TabIndex = 16;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(181, 273);
            txtDNI.Multiline = true;
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(167, 34);
            txtDNI.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 279);
            label4.Name = "label4";
            label4.Size = new Size(35, 20);
            label4.TabIndex = 14;
            label4.Text = "DNI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 219);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 13;
            label3.Text = "Email";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(181, 93);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(167, 27);
            txtNombre.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 99);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 11;
            label2.Text = "Nombre";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(181, 153);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(167, 27);
            txtApellido.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 159);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 9;
            label1.Text = "Apellido";
            // 
            // tabPageGrupos
            // 
            tabPageGrupos.Controls.Add(clbGrupos);
            tabPageGrupos.Location = new Point(4, 29);
            tabPageGrupos.Name = "tabPageGrupos";
            tabPageGrupos.Padding = new Padding(3);
            tabPageGrupos.Size = new Size(637, 531);
            tabPageGrupos.TabIndex = 1;
            tabPageGrupos.Text = "Grupos";
            tabPageGrupos.UseVisualStyleBackColor = true;
            // 
            // clbGrupos
            // 
            clbGrupos.Dock = DockStyle.Fill;
            clbGrupos.FormattingEnabled = true;
            clbGrupos.Location = new Point(3, 3);
            clbGrupos.Name = "clbGrupos";
            clbGrupos.Size = new Size(631, 525);
            clbGrupos.TabIndex = 0;
            clbGrupos.ItemCheck += clbGrupos_ItemCheck;
            // 
            // tabPageAcciones
            // 
            tabPageAcciones.Controls.Add(tvAccion);
            tabPageAcciones.Location = new Point(4, 29);
            tabPageAcciones.Name = "tabPageAcciones";
            tabPageAcciones.Padding = new Padding(3);
            tabPageAcciones.Size = new Size(637, 531);
            tabPageAcciones.TabIndex = 2;
            tabPageAcciones.Text = "Acciones";
            tabPageAcciones.UseVisualStyleBackColor = true;
            // 
            // tvAccion
            // 
            tvAccion.CheckBoxes = true;
            tvAccion.Dock = DockStyle.Fill;
            tvAccion.Location = new Point(3, 3);
            tvAccion.Name = "tvAccion";
            tvAccion.Size = new Size(631, 525);
            tvAccion.TabIndex = 0;
            tvAccion.AfterCheck += tvAccion_AfterCheck;
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 646);
            Controls.Add(tabControl1);
            Controls.Add(panelSuperior);
            Name = "FormUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GESTIONAR USUARIO";
            Load += FormUsuario_Load;
            panelSuperior.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageDatos.ResumeLayout(false);
            tabPageDatos.PerformLayout();
            tabPageGrupos.ResumeLayout(false);
            tabPageAcciones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSuperior;
        private Button btnGuardar;
        private Button btnCancelar;
        private ComboBox cmbEstado;
        private TextBox txtDescripcion;
        private TreeView tvAcciones;
        private TabPage tpAcciones;
        private TabControl tabControl1;
        private TabPage tabPageDatos;
        private TextBox txtEmail;
        private TextBox txtDNI;
        private Label label4;
        private Label label3;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtApellido;
        private Label label1;
        private TabPage tabPageGrupos;
        private CheckedListBox clbGrupos;
        private TabPage tabPageAcciones;
        private TreeView tvAccion;
        private Label label5;
        private TextBox txtUsuario;
        private ComboBox comboBox1;
        private Label label6;
    }
}
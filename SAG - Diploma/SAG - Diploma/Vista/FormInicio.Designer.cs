namespace SAG___Diploma.Vista
{
    partial class FormInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            panelMenu = new Panel();
            btnReportes = new Button();
            btnUsuarios = new Button();
            btnGrupos = new Button();
            btnGestionarClases = new Button();
            btnCerrarSesion = new Button();
            btnGestionarRutinas = new Button();
            btnGestionarPlanes = new Button();
            btnGestionarClientes = new Button();
            btnInicio = new Button();
            panelLogo = new Panel();
            pcLogo = new PictureBox();
            panelApp = new Panel();
            panelForm = new Panel();
            panelTitulo = new Panel();
            panelTituloCerrar = new Panel();
            pbCerrar = new PictureBox();
            lblTitulo = new Label();
            lblBienvenido = new Label();
            btnBackup = new Button();
            btnAuditoria = new Button();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcLogo).BeginInit();
            panelApp.SuspendLayout();
            panelTitulo.SuspendLayout();
            panelTituloCerrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCerrar).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.DarkGray;
            panelMenu.Controls.Add(btnAuditoria);
            panelMenu.Controls.Add(btnBackup);
            panelMenu.Controls.Add(btnReportes);
            panelMenu.Controls.Add(btnUsuarios);
            panelMenu.Controls.Add(btnGrupos);
            panelMenu.Controls.Add(btnGestionarClases);
            panelMenu.Controls.Add(btnCerrarSesion);
            panelMenu.Controls.Add(btnGestionarRutinas);
            panelMenu.Controls.Add(btnGestionarPlanes);
            panelMenu.Controls.Add(btnGestionarClientes);
            panelMenu.Controls.Add(btnInicio);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(321, 1085);
            panelMenu.TabIndex = 1;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.Black;
            btnReportes.Dock = DockStyle.Bottom;
            btnReportes.FlatAppearance.BorderColor = SystemColors.Info;
            btnReportes.FlatAppearance.BorderSize = 2;
            btnReportes.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(0, 765);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(321, 80);
            btnReportes.TabIndex = 10;
            btnReportes.Text = "REPORTES";
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.Black;
            btnUsuarios.Dock = DockStyle.Bottom;
            btnUsuarios.FlatAppearance.BorderColor = SystemColors.Info;
            btnUsuarios.FlatAppearance.BorderSize = 2;
            btnUsuarios.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(0, 845);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(321, 80);
            btnUsuarios.TabIndex = 9;
            btnUsuarios.Text = "USUARIOS";
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnGrupos
            // 
            btnGrupos.BackColor = Color.Black;
            btnGrupos.Dock = DockStyle.Bottom;
            btnGrupos.FlatAppearance.BorderColor = SystemColors.Info;
            btnGrupos.FlatAppearance.BorderSize = 2;
            btnGrupos.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnGrupos.ForeColor = Color.White;
            btnGrupos.Location = new Point(0, 925);
            btnGrupos.Name = "btnGrupos";
            btnGrupos.Size = new Size(321, 80);
            btnGrupos.TabIndex = 8;
            btnGrupos.Text = "GRUPOS";
            btnGrupos.UseVisualStyleBackColor = false;
            btnGrupos.Click += btnGrupos_Click;
            // 
            // btnGestionarClases
            // 
            btnGestionarClases.BackColor = Color.Black;
            btnGestionarClases.Dock = DockStyle.Top;
            btnGestionarClases.FlatAppearance.BorderColor = SystemColors.Info;
            btnGestionarClases.FlatAppearance.BorderSize = 2;
            btnGestionarClases.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnGestionarClases.ForeColor = Color.White;
            btnGestionarClases.Location = new Point(0, 513);
            btnGestionarClases.Name = "btnGestionarClases";
            btnGestionarClases.Size = new Size(321, 80);
            btnGestionarClases.TabIndex = 7;
            btnGestionarClases.Text = "CLASES";
            btnGestionarClases.UseVisualStyleBackColor = false;
            btnGestionarClases.Click += btnGestionarClases_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.Black;
            btnCerrarSesion.Dock = DockStyle.Bottom;
            btnCerrarSesion.FlatAppearance.BorderColor = SystemColors.Info;
            btnCerrarSesion.FlatAppearance.BorderSize = 2;
            btnCerrarSesion.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(0, 1005);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(321, 80);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "CERRAR SESIÓN";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnGestionarRutinas
            // 
            btnGestionarRutinas.BackColor = Color.Black;
            btnGestionarRutinas.Dock = DockStyle.Top;
            btnGestionarRutinas.FlatAppearance.BorderColor = SystemColors.Info;
            btnGestionarRutinas.FlatAppearance.BorderSize = 2;
            btnGestionarRutinas.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnGestionarRutinas.ForeColor = Color.White;
            btnGestionarRutinas.Location = new Point(0, 433);
            btnGestionarRutinas.Name = "btnGestionarRutinas";
            btnGestionarRutinas.Size = new Size(321, 80);
            btnGestionarRutinas.TabIndex = 5;
            btnGestionarRutinas.Text = "RUTINAS";
            btnGestionarRutinas.UseVisualStyleBackColor = false;
            btnGestionarRutinas.Click += btnGestionarRutinas_Click;
            // 
            // btnGestionarPlanes
            // 
            btnGestionarPlanes.BackColor = Color.Black;
            btnGestionarPlanes.Dock = DockStyle.Top;
            btnGestionarPlanes.FlatAppearance.BorderColor = SystemColors.Info;
            btnGestionarPlanes.FlatAppearance.BorderSize = 2;
            btnGestionarPlanes.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnGestionarPlanes.ForeColor = Color.White;
            btnGestionarPlanes.Location = new Point(0, 353);
            btnGestionarPlanes.Name = "btnGestionarPlanes";
            btnGestionarPlanes.Size = new Size(321, 80);
            btnGestionarPlanes.TabIndex = 4;
            btnGestionarPlanes.Text = "PLANES";
            btnGestionarPlanes.UseVisualStyleBackColor = false;
            btnGestionarPlanes.Click += btnGestionarPlanes_Click;
            // 
            // btnGestionarClientes
            // 
            btnGestionarClientes.BackColor = Color.Black;
            btnGestionarClientes.Dock = DockStyle.Top;
            btnGestionarClientes.FlatAppearance.BorderColor = SystemColors.Info;
            btnGestionarClientes.FlatAppearance.BorderSize = 2;
            btnGestionarClientes.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnGestionarClientes.ForeColor = Color.White;
            btnGestionarClientes.Location = new Point(0, 273);
            btnGestionarClientes.Name = "btnGestionarClientes";
            btnGestionarClientes.Size = new Size(321, 80);
            btnGestionarClientes.TabIndex = 2;
            btnGestionarClientes.Text = "CLIENTES";
            btnGestionarClientes.UseVisualStyleBackColor = false;
            btnGestionarClientes.Click += btnGestionarClientes_Click;
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.Black;
            btnInicio.Dock = DockStyle.Top;
            btnInicio.FlatAppearance.BorderColor = SystemColors.Info;
            btnInicio.FlatAppearance.BorderSize = 2;
            btnInicio.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInicio.ForeColor = Color.White;
            btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
            btnInicio.Location = new Point(0, 193);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(321, 80);
            btnInicio.TabIndex = 1;
            btnInicio.Text = "INICIO";
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = SystemColors.InactiveCaption;
            panelLogo.Controls.Add(pcLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(321, 193);
            panelLogo.TabIndex = 0;
            // 
            // pcLogo
            // 
            pcLogo.BackColor = Color.Transparent;
            pcLogo.Dock = DockStyle.Fill;
            pcLogo.Image = (Image)resources.GetObject("pcLogo.Image");
            pcLogo.Location = new Point(0, 0);
            pcLogo.Name = "pcLogo";
            pcLogo.Size = new Size(321, 193);
            pcLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pcLogo.TabIndex = 0;
            pcLogo.TabStop = false;
            // 
            // panelApp
            // 
            panelApp.AutoSize = true;
            panelApp.BackColor = SystemColors.GradientActiveCaption;
            panelApp.Controls.Add(panelForm);
            panelApp.Controls.Add(panelTitulo);
            panelApp.Controls.Add(lblBienvenido);
            panelApp.Controls.Add(panelMenu);
            panelApp.Cursor = Cursors.Cross;
            panelApp.Dock = DockStyle.Fill;
            panelApp.Location = new Point(0, 0);
            panelApp.Name = "panelApp";
            panelApp.Size = new Size(1249, 1085);
            panelApp.TabIndex = 2;
            // 
            // panelForm
            // 
            panelForm.BackColor = SystemColors.ActiveBorder;
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(321, 60);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(928, 1025);
            panelForm.TabIndex = 4;
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.FromArgb(13, 93, 142);
            panelTitulo.Controls.Add(panelTituloCerrar);
            panelTitulo.Controls.Add(lblTitulo);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(321, 0);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(928, 60);
            panelTitulo.TabIndex = 3;
            // 
            // panelTituloCerrar
            // 
            panelTituloCerrar.BackColor = Color.FromArgb(13, 93, 142);
            panelTituloCerrar.Controls.Add(pbCerrar);
            panelTituloCerrar.Dock = DockStyle.Right;
            panelTituloCerrar.Location = new Point(887, 0);
            panelTituloCerrar.Name = "panelTituloCerrar";
            panelTituloCerrar.Size = new Size(41, 60);
            panelTituloCerrar.TabIndex = 0;
            // 
            // pbCerrar
            // 
            pbCerrar.Image = (Image)resources.GetObject("pbCerrar.Image");
            pbCerrar.Location = new Point(13, 12);
            pbCerrar.Name = "pbCerrar";
            pbCerrar.Size = new Size(16, 16);
            pbCerrar.TabIndex = 1;
            pbCerrar.TabStop = false;
            pbCerrar.Click += pbCerrar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI Semibold", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Blue;
            lblTitulo.ImageAlign = ContentAlignment.MiddleLeft;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(928, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "INICIO";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Segoe UI", 16F);
            lblBienvenido.Location = new Point(409, 313);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(603, 37);
            lblBienvenido.TabIndex = 0;
            lblBienvenido.Text = "Bienvenido, seleccione una opción para continuar";
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.Black;
            btnBackup.Dock = DockStyle.Bottom;
            btnBackup.FlatAppearance.BorderColor = SystemColors.Info;
            btnBackup.FlatAppearance.BorderSize = 2;
            btnBackup.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnBackup.ForeColor = Color.White;
            btnBackup.Location = new Point(0, 685);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(321, 80);
            btnBackup.TabIndex = 11;
            btnBackup.Text = "BACKUP";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnAuditoria
            // 
            btnAuditoria.BackColor = Color.Black;
            btnAuditoria.Dock = DockStyle.Bottom;
            btnAuditoria.FlatAppearance.BorderColor = SystemColors.Info;
            btnAuditoria.FlatAppearance.BorderSize = 2;
            btnAuditoria.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnAuditoria.ForeColor = Color.White;
            btnAuditoria.Location = new Point(0, 605);
            btnAuditoria.Name = "btnAuditoria";
            btnAuditoria.Size = new Size(321, 80);
            btnAuditoria.TabIndex = 12;
            btnAuditoria.Text = "AUDITORÍA";
            btnAuditoria.UseVisualStyleBackColor = false;
            btnAuditoria.Click += btnAuditoria_Click;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1249, 1085);
            Controls.Add(panelApp);
            FormBorderStyle = FormBorderStyle.None;
            MinimizeBox = false;
            Name = "FormInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SISTEMA DE GESTION DE GIMNASIO";
            WindowState = FormWindowState.Maximized;
            FormClosing += FormInicio_FormClosing;
            Load += FormInicio_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcLogo).EndInit();
            panelApp.ResumeLayout(false);
            panelApp.PerformLayout();
            panelTitulo.ResumeLayout(false);
            panelTituloCerrar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbCerrar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelMenu;
        private Panel panelLogo;
        private PictureBox pcLogo;
        private Panel panelApp;
        private Button btnInicio;
        private Button btnCerrarSesion;
        private Button btnGestionarRutinas;
        private Button btnGestionarPlanes;
        private Button btnGestionarClientes;
        private Label lblBienvenido;
        private Button btnGestionarClases;
        private Panel panelTitulo;
        private Panel panelForm;
        private PictureBox pbCerrar;
        private Panel panelTituloCerrar;
        private Label lblTitulo;
        private Button button2;
        private Button btnGrupos;
        private Button btnUsuarios;
        private Button btnReportes;
        private Button btnAuditoria;
        private Button btnBackup;
    }
}
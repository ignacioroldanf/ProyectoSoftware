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
            btnGestionarClases = new Button();
            btnCerrarSesion = new Button();
            btnGestionarRutinas = new Button();
            btnGestionarPlanes = new Button();
            btnGestionarClientes = new Button();
            btnInicio = new Button();
            panelLogo = new Panel();
            pcLogo = new PictureBox();
            panelApp = new Panel();
            lblBienvenido = new Label();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcLogo).BeginInit();
            panelApp.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.DarkGray;
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
            panelMenu.Size = new Size(223, 725);
            panelMenu.TabIndex = 1;
            // 
            // btnGestionarClases
            // 
            btnGestionarClases.BackColor = Color.Black;
            btnGestionarClases.Dock = DockStyle.Top;
            btnGestionarClases.FlatAppearance.BorderColor = SystemColors.Info;
            btnGestionarClases.FlatAppearance.BorderSize = 2;
            btnGestionarClases.Font = new Font("Segoe UI", 10F);
            btnGestionarClases.ForeColor = Color.White;
            btnGestionarClases.Location = new Point(0, 433);
            btnGestionarClases.Name = "btnGestionarClases";
            btnGestionarClases.Size = new Size(223, 60);
            btnGestionarClases.TabIndex = 7;
            btnGestionarClases.Text = "GESTIONAR CLASES";
            btnGestionarClases.UseVisualStyleBackColor = false;
            btnGestionarClases.Click += btnGestionarClases_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.Black;
            btnCerrarSesion.Dock = DockStyle.Bottom;
            btnCerrarSesion.FlatAppearance.BorderColor = SystemColors.Info;
            btnCerrarSesion.FlatAppearance.BorderSize = 2;
            btnCerrarSesion.Font = new Font("Segoe UI", 10F);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(0, 665);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(223, 60);
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
            btnGestionarRutinas.Font = new Font("Segoe UI", 10F);
            btnGestionarRutinas.ForeColor = Color.White;
            btnGestionarRutinas.Location = new Point(0, 373);
            btnGestionarRutinas.Name = "btnGestionarRutinas";
            btnGestionarRutinas.Size = new Size(223, 60);
            btnGestionarRutinas.TabIndex = 5;
            btnGestionarRutinas.Text = "GESTIONAR RUTINAS";
            btnGestionarRutinas.UseVisualStyleBackColor = false;
            btnGestionarRutinas.Click += btnGestionarRutinas_Click;
            // 
            // btnGestionarPlanes
            // 
            btnGestionarPlanes.BackColor = Color.Black;
            btnGestionarPlanes.Dock = DockStyle.Top;
            btnGestionarPlanes.FlatAppearance.BorderColor = SystemColors.Info;
            btnGestionarPlanes.FlatAppearance.BorderSize = 2;
            btnGestionarPlanes.Font = new Font("Segoe UI", 10F);
            btnGestionarPlanes.ForeColor = Color.White;
            btnGestionarPlanes.Location = new Point(0, 313);
            btnGestionarPlanes.Name = "btnGestionarPlanes";
            btnGestionarPlanes.Size = new Size(223, 60);
            btnGestionarPlanes.TabIndex = 4;
            btnGestionarPlanes.Text = "GESTIONAR PLANES";
            btnGestionarPlanes.UseVisualStyleBackColor = false;
            btnGestionarPlanes.Click += btnGestionarPlanes_Click;
            // 
            // btnGestionarClientes
            // 
            btnGestionarClientes.BackColor = Color.Black;
            btnGestionarClientes.Dock = DockStyle.Top;
            btnGestionarClientes.FlatAppearance.BorderColor = SystemColors.Info;
            btnGestionarClientes.FlatAppearance.BorderSize = 2;
            btnGestionarClientes.Font = new Font("Segoe UI", 10F);
            btnGestionarClientes.ForeColor = Color.White;
            btnGestionarClientes.Location = new Point(0, 253);
            btnGestionarClientes.Name = "btnGestionarClientes";
            btnGestionarClientes.Size = new Size(223, 60);
            btnGestionarClientes.TabIndex = 2;
            btnGestionarClientes.Text = "GESTIONAR CLIENTES";
            btnGestionarClientes.UseVisualStyleBackColor = false;
            btnGestionarClientes.Click += btnGestionarClientes_Click;
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.Black;
            btnInicio.Dock = DockStyle.Top;
            btnInicio.FlatAppearance.BorderColor = SystemColors.Info;
            btnInicio.FlatAppearance.BorderSize = 2;
            btnInicio.Font = new Font("Segoe UI", 10F);
            btnInicio.ForeColor = Color.White;
            btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
            btnInicio.Location = new Point(0, 193);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(223, 60);
            btnInicio.TabIndex = 1;
            btnInicio.Text = "INICIO";
            btnInicio.UseVisualStyleBackColor = false;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = SystemColors.InactiveCaption;
            panelLogo.Controls.Add(pcLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(223, 193);
            panelLogo.TabIndex = 0;
            // 
            // pcLogo
            // 
            pcLogo.BackColor = Color.White;
            pcLogo.Dock = DockStyle.Fill;
            pcLogo.Image = (Image)resources.GetObject("pcLogo.Image");
            pcLogo.Location = new Point(0, 0);
            pcLogo.Name = "pcLogo";
            pcLogo.Size = new Size(223, 193);
            pcLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pcLogo.TabIndex = 0;
            pcLogo.TabStop = false;
            // 
            // panelApp
            // 
            panelApp.Anchor = AnchorStyles.None;
            panelApp.AutoSize = true;
            panelApp.BackColor = SystemColors.GradientActiveCaption;
            panelApp.Controls.Add(lblBienvenido);
            panelApp.Cursor = Cursors.Cross;
            panelApp.Location = new Point(223, 0);
            panelApp.Name = "panelApp";
            panelApp.Size = new Size(1026, 725);
            panelApp.TabIndex = 2;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Segoe UI", 16F);
            lblBienvenido.Location = new Point(132, 313);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(603, 37);
            lblBienvenido.TabIndex = 0;
            lblBienvenido.Text = "Bienvenido, seleccione una opción para continuar";
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1249, 725);
            Controls.Add(panelApp);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "FormInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SISTEMA DE GESTION DE GIMNASIO";
            Load += FormInicio_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcLogo).EndInit();
            panelApp.ResumeLayout(false);
            panelApp.PerformLayout();
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
    }
}
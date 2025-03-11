namespace VISTA
{
    partial class formInicioSesion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOjoAbiertoCerrado = new Button();
            materialDivider1 = new ReaLTaiizor.Controls.MaterialDivider();
            lblOlvidarContraseña = new ReaLTaiizor.Controls.DungeonLinkLabel();
            btnIniciarSesion = new Button();
            txtClave = new TextBox();
            txtNombreUsuario = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnCerrar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnOjoAbiertoCerrado
            // 
            btnOjoAbiertoCerrado.BackgroundImage = Properties.Resources.OjoCerrado;
            btnOjoAbiertoCerrado.FlatStyle = FlatStyle.Flat;
            btnOjoAbiertoCerrado.Location = new Point(629, 165);
            btnOjoAbiertoCerrado.Name = "btnOjoAbiertoCerrado";
            btnOjoAbiertoCerrado.Size = new Size(24, 23);
            btnOjoAbiertoCerrado.TabIndex = 31;
            btnOjoAbiertoCerrado.UseVisualStyleBackColor = true;
            btnOjoAbiertoCerrado.Click += btnOjoAbiertoCerrado_Click;
            // 
            // materialDivider1
            // 
            materialDivider1.BackColor = Color.FromArgb(45, 64, 84);
            materialDivider1.Depth = 0;
            materialDivider1.Location = new Point(325, 287);
            materialDivider1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialDivider1.Name = "materialDivider1";
            materialDivider1.Size = new Size(372, 10);
            materialDivider1.TabIndex = 35;
            materialDivider1.Text = "materialDivider1";
            // 
            // lblOlvidarContraseña
            // 
            lblOlvidarContraseña.ActiveLinkColor = Color.FromArgb(221, 72, 20);
            lblOlvidarContraseña.AutoSize = true;
            lblOlvidarContraseña.BackColor = Color.Transparent;
            lblOlvidarContraseña.Font = new Font("Segoe UI", 11F);
            lblOlvidarContraseña.LinkBehavior = LinkBehavior.AlwaysUnderline;
            lblOlvidarContraseña.LinkColor = Color.Black;
            lblOlvidarContraseña.Location = new Point(422, 321);
            lblOlvidarContraseña.Name = "lblOlvidarContraseña";
            lblOlvidarContraseña.Size = new Size(178, 20);
            lblOlvidarContraseña.TabIndex = 34;
            lblOlvidarContraseña.TabStop = true;
            lblOlvidarContraseña.Text = "¿Olvidaste tu contraseña?";
            lblOlvidarContraseña.VisitedLinkColor = Color.FromArgb(240, 119, 70);
            lblOlvidarContraseña.LinkClicked += lblOlvidarContraseña_LinkClicked;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.FromArgb(45, 64, 84);
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.Font = new Font("Arial", 12F);
            btnIniciarSesion.ForeColor = SystemColors.Window;
            btnIniciarSesion.Location = new Point(361, 218);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(297, 39);
            btnIniciarSesion.TabIndex = 32;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(361, 165);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(262, 23);
            txtClave.TabIndex = 30;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(361, 102);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(262, 23);
            txtNombreUsuario.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F);
            label5.Location = new Point(358, 144);
            label5.Name = "label5";
            label5.Size = new Size(93, 18);
            label5.TabIndex = 28;
            label5.Text = "Contraseña:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F);
            label4.Location = new Point(358, 81);
            label4.Name = "label4";
            label4.Size = new Size(148, 18);
            label4.TabIndex = 27;
            label4.Text = "Nombre de Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(356, 28);
            label3.Name = "label3";
            label3.Size = new Size(177, 29);
            label3.TabIndex = 26;
            label3.Text = "Iniciar Sesión:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(277, 427);
            panel1.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label2.Location = new Point(14, 302);
            label2.Name = "label2";
            label2.Size = new Size(260, 40);
            label2.TabIndex = 1;
            label2.Text = "Comercialización de Productos \r\n   Metalúrgicos y Siderúrgicos\r\n";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(5, 69);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(265, 214);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Magneto", 26.25F, FontStyle.Bold);
            label1.Location = new Point(1, 12);
            label1.Name = "label1";
            label1.Size = new Size(275, 44);
            label1.TabIndex = 1;
            label1.Text = "Métallon s.r.l";
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.Black;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCerrar.IconSize = 25;
            btnCerrar.Location = new Point(703, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 27);
            btnCerrar.TabIndex = 53;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // formInicioSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 235, 240);
            ClientSize = new Size(725, 360);
            Controls.Add(btnCerrar);
            Controls.Add(btnOjoAbiertoCerrado);
            Controls.Add(materialDivider1);
            Controls.Add(lblOlvidarContraseña);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtClave);
            Controls.Add(txtNombreUsuario);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formInicioSesion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            MouseDown += formInicioSesion_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOjoAbiertoCerrado;
        private ReaLTaiizor.Controls.MaterialDivider materialDivider1;
        private ReaLTaiizor.Controls.DungeonLinkLabel lblOlvidarContraseña;
        private Button btnIniciarSesion;
        private TextBox txtClave;
        private TextBox txtNombreUsuario;
        private Label label5;
        private Label label4;
        private Label label3;
        private Panel panel1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnCerrar;
    }
}

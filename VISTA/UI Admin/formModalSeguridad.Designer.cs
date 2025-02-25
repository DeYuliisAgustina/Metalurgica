namespace VISTA.Seguridad
{
    partial class formModalSeguridad
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
            btnCerrar = new FontAwesome.Sharp.IconButton();
            lbl = new Label();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            groupBox1 = new GroupBox();
            btnAdministrarBD = new FontAwesome.Sharp.IconButton();
            btnAuditoriaSesion = new FontAwesome.Sharp.IconButton();
            btnGestionarUsuarios = new FontAwesome.Sharp.IconButton();
            btnGestionaGrupos = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(btnCerrar);
            panel1.Controls.Add(lbl);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(-8, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(465, 104);
            panel1.TabIndex = 5;
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.Black;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCerrar.IconSize = 25;
            btnCerrar.Location = new Point(431, 2);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 27);
            btnCerrar.TabIndex = 55;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("Magneto", 21.75F, FontStyle.Bold);
            lbl.Location = new Point(187, 16);
            lbl.Name = "lbl";
            lbl.Size = new Size(229, 35);
            lbl.TabIndex = 48;
            lbl.Text = "Métallon s.r.l";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(45, 64, 84);
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(12, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 101);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(171, 51);
            label7.Name = "label7";
            label7.Size = new Size(273, 29);
            label7.TabIndex = 4;
            label7.Text = "Administrar Seguridad";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAdministrarBD);
            groupBox1.Controls.Add(btnAuditoriaSesion);
            groupBox1.Controls.Add(btnGestionarUsuarios);
            groupBox1.Controls.Add(btnGestionaGrupos);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(31, 118);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(387, 325);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Funciones de Administrador:";
            // 
            // btnAdministrarBD
            // 
            btnAdministrarBD.BackColor = Color.Black;
            btnAdministrarBD.FlatStyle = FlatStyle.Flat;
            btnAdministrarBD.IconChar = FontAwesome.Sharp.IconChar.Database;
            btnAdministrarBD.IconColor = Color.White;
            btnAdministrarBD.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAdministrarBD.IconSize = 34;
            btnAdministrarBD.ImageAlign = ContentAlignment.MiddleRight;
            btnAdministrarBD.Location = new Point(52, 255);
            btnAdministrarBD.Name = "btnAdministrarBD";
            btnAdministrarBD.Size = new Size(285, 49);
            btnAdministrarBD.TabIndex = 13;
            btnAdministrarBD.Text = "Administrar Base de Datos";
            btnAdministrarBD.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdministrarBD.UseVisualStyleBackColor = false;
            btnAdministrarBD.Click += btnAdministrarBD_Click;
            // 
            // btnAuditoriaSesion
            // 
            btnAuditoriaSesion.BackColor = Color.Black;
            btnAuditoriaSesion.FlatStyle = FlatStyle.Flat;
            btnAuditoriaSesion.IconChar = FontAwesome.Sharp.IconChar.A;
            btnAuditoriaSesion.IconColor = Color.White;
            btnAuditoriaSesion.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAuditoriaSesion.IconSize = 34;
            btnAuditoriaSesion.ImageAlign = ContentAlignment.MiddleRight;
            btnAuditoriaSesion.Location = new Point(52, 188);
            btnAuditoriaSesion.Name = "btnAuditoriaSesion";
            btnAuditoriaSesion.Size = new Size(285, 49);
            btnAuditoriaSesion.TabIndex = 12;
            btnAuditoriaSesion.Text = "Auditorías Inicios de Sesión";
            btnAuditoriaSesion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAuditoriaSesion.UseVisualStyleBackColor = false;
            btnAuditoriaSesion.Click += btnAuditoriaSesion_Click;
            // 
            // btnGestionarUsuarios
            // 
            btnGestionarUsuarios.BackColor = Color.Black;
            btnGestionarUsuarios.FlatStyle = FlatStyle.Flat;
            btnGestionarUsuarios.IconChar = FontAwesome.Sharp.IconChar.User;
            btnGestionarUsuarios.IconColor = Color.White;
            btnGestionarUsuarios.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnGestionarUsuarios.IconSize = 34;
            btnGestionarUsuarios.ImageAlign = ContentAlignment.MiddleRight;
            btnGestionarUsuarios.Location = new Point(52, 117);
            btnGestionarUsuarios.Name = "btnGestionarUsuarios";
            btnGestionarUsuarios.Size = new Size(285, 49);
            btnGestionarUsuarios.TabIndex = 11;
            btnGestionarUsuarios.Text = "Gestionar Usuarios";
            btnGestionarUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGestionarUsuarios.UseVisualStyleBackColor = false;
            btnGestionarUsuarios.Click += btnGestionarUsuarios_Click;
            // 
            // btnGestionaGrupos
            // 
            btnGestionaGrupos.BackColor = Color.Black;
            btnGestionaGrupos.FlatStyle = FlatStyle.Flat;
            btnGestionaGrupos.IconChar = FontAwesome.Sharp.IconChar.Users;
            btnGestionaGrupos.IconColor = Color.White;
            btnGestionaGrupos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGestionaGrupos.IconSize = 38;
            btnGestionaGrupos.ImageAlign = ContentAlignment.MiddleRight;
            btnGestionaGrupos.Location = new Point(52, 38);
            btnGestionaGrupos.Name = "btnGestionaGrupos";
            btnGestionaGrupos.Size = new Size(285, 49);
            btnGestionaGrupos.TabIndex = 10;
            btnGestionaGrupos.Text = "Gestionar Grupos";
            btnGestionaGrupos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGestionaGrupos.UseVisualStyleBackColor = false;
            btnGestionaGrupos.Click += btnSeguridad_Click;
            // 
            // formModalSeguridad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(85, 104, 124);
            ClientSize = new Size(448, 475);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formModalSeguridad";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formModalSeguridad";
            MouseDown += formModalSeguridad_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label7;
        private PictureBox pictureBox1;
        private Label lbl;
        private GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnGestionarUsuarios;
        private FontAwesome.Sharp.IconButton btnGestionaGrupos;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private FontAwesome.Sharp.IconButton btnAuditoriaSesion;
        private FontAwesome.Sharp.IconButton btnAdministrarBD;
    }
}
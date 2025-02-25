namespace VISTA
{
    partial class formRecuperarClave
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
            lbl = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtCorreoElectronico = new TextBox();
            txtNombreUsuario = new TextBox();
            btnRecuperar = new Button();
            label4 = new Label();
            label2 = new Label();
            btnCerrar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(lbl);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(296, 313);
            panel1.TabIndex = 1;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("Magneto", 21.75F, FontStyle.Bold);
            lbl.Location = new Point(30, 259);
            lbl.Name = "lbl";
            lbl.Size = new Size(229, 35);
            lbl.TabIndex = 47;
            lbl.Text = "Métallon s.r.l";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(45, 64, 84);
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(30, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(233, 205);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(355, 18);
            label1.Name = "label1";
            label1.Size = new Size(275, 29);
            label1.TabIndex = 27;
            label1.Text = "Recuperar Contraseña:";
            // 
            // txtCorreoElectronico
            // 
            txtCorreoElectronico.Location = new Point(339, 173);
            txtCorreoElectronico.Name = "txtCorreoElectronico";
            txtCorreoElectronico.Size = new Size(248, 23);
            txtCorreoElectronico.TabIndex = 28;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(339, 100);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(248, 23);
            txtNombreUsuario.TabIndex = 29;
            // 
            // btnRecuperar
            // 
            btnRecuperar.BackColor = Color.FromArgb(45, 64, 84);
            btnRecuperar.FlatStyle = FlatStyle.Flat;
            btnRecuperar.Font = new Font("Arial", 12F);
            btnRecuperar.ForeColor = SystemColors.Window;
            btnRecuperar.Location = new Point(332, 240);
            btnRecuperar.Name = "btnRecuperar";
            btnRecuperar.Size = new Size(322, 39);
            btnRecuperar.TabIndex = 43;
            btnRecuperar.Text = "Recuperar";
            btnRecuperar.UseVisualStyleBackColor = false;
            btnRecuperar.Click += btnRecuperar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F);
            label4.Location = new Point(339, 79);
            label4.Name = "label4";
            label4.Size = new Size(217, 18);
            label4.TabIndex = 44;
            label4.Text = "Ingrese su nombre de usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F);
            label2.Location = new Point(339, 152);
            label2.Name = "label2";
            label2.Size = new Size(218, 18);
            label2.TabIndex = 45;
            label2.Text = "Ingrese su Correo Electrónico:";
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.Black;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCerrar.IconSize = 25;
            btnCerrar.Location = new Point(657, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 27);
            btnCerrar.TabIndex = 53;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // formRecuperarClave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 312);
            Controls.Add(btnCerrar);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(btnRecuperar);
            Controls.Add(txtNombreUsuario);
            Controls.Add(txtCorreoElectronico);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formRecuperarClave";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formRecuperarClave";
            MouseDown += formRecuperarClave_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lbl;
        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtCorreoElectronico;
        private TextBox txtNombreUsuario;
        private Button btnRecuperar;
        private Label label4;
        private Label label2;
        private FontAwesome.Sharp.IconButton btnCerrar;
    }
}
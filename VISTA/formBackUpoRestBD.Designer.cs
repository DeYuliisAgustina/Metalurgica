namespace VISTA
{
    partial class formBackUpoRestBD
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
            lblAgregaroModificar = new Label();
            label1 = new Label();
            txtDirectorio = new ReaLTaiizor.Controls.FoxTextBox();
            btnCrearBackup = new FontAwesome.Sharp.IconButton();
            btnRestaurarBD = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(btnCerrar);
            panel1.Controls.Add(lbl);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(-45, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(553, 104);
            panel1.TabIndex = 6;
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.Black;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCerrar.IconSize = 25;
            btnCerrar.Location = new Point(517, 10);
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
            lbl.Location = new Point(222, 13);
            lbl.Name = "lbl";
            lbl.Size = new Size(229, 35);
            lbl.TabIndex = 48;
            lbl.Text = "Métallon s.r.l";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(45, 64, 84);
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(45, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(97, 101);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(242, 48);
            label7.Name = "label7";
            label7.Size = new Size(183, 29);
            label7.TabIndex = 4;
            label7.Text = "Base de Datos";
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Font = new Font("Microsoft Sans Serif", 12F);
            lblAgregaroModificar.ForeColor = Color.White;
            lblAgregaroModificar.Location = new Point(61, 118);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(198, 20);
            lblAgregaroModificar.TabIndex = 55;
            lblAgregaroModificar.Text = "Último Back Up Realizado:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(265, 118);
            label1.Name = "label1";
            label1.Size = new Size(155, 20);
            label1.TabIndex = 56;
            label1.Text = "fecha último back up";
            // 
            // txtDirectorio
            // 
            txtDirectorio.BackColor = Color.Transparent;
            txtDirectorio.EnabledCalc = true;
            txtDirectorio.Font = new Font("Segoe UI", 10F);
            txtDirectorio.ForeColor = Color.FromArgb(66, 78, 90);
            txtDirectorio.Location = new Point(12, 275);
            txtDirectorio.MaxLength = 32767;
            txtDirectorio.MultiLine = false;
            txtDirectorio.Name = "txtDirectorio";
            txtDirectorio.ReadOnly = false;
            txtDirectorio.Size = new Size(484, 29);
            txtDirectorio.TabIndex = 57;
            txtDirectorio.TextAlign = HorizontalAlignment.Left;
            txtDirectorio.UseSystemPasswordChar = false;
            txtDirectorio.Click += txtDirectorio_Click;
            // 
            // btnCrearBackup
            // 
            btnCrearBackup.BackColor = Color.Black;
            btnCrearBackup.FlatStyle = FlatStyle.Flat;
            btnCrearBackup.Font = new Font("Segoe UI", 9.75F);
            btnCrearBackup.ForeColor = Color.White;
            btnCrearBackup.IconChar = FontAwesome.Sharp.IconChar.Database;
            btnCrearBackup.IconColor = Color.White;
            btnCrearBackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCrearBackup.IconSize = 20;
            btnCrearBackup.Location = new Point(90, 165);
            btnCrearBackup.Name = "btnCrearBackup";
            btnCrearBackup.Size = new Size(138, 56);
            btnCrearBackup.TabIndex = 58;
            btnCrearBackup.Text = "Crear Back Up";
            btnCrearBackup.TextAlign = ContentAlignment.MiddleRight;
            btnCrearBackup.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCrearBackup.UseVisualStyleBackColor = false;
            btnCrearBackup.Click += btnCrearBackup_Click;
            // 
            // btnRestaurarBD
            // 
            btnRestaurarBD.BackColor = Color.Black;
            btnRestaurarBD.FlatStyle = FlatStyle.Flat;
            btnRestaurarBD.Font = new Font("Segoe UI", 9.75F);
            btnRestaurarBD.ForeColor = Color.White;
            btnRestaurarBD.IconChar = FontAwesome.Sharp.IconChar.Upload;
            btnRestaurarBD.IconColor = Color.Lime;
            btnRestaurarBD.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRestaurarBD.IconSize = 20;
            btnRestaurarBD.Location = new Point(282, 165);
            btnRestaurarBD.Name = "btnRestaurarBD";
            btnRestaurarBD.Size = new Size(138, 56);
            btnRestaurarBD.TabIndex = 59;
            btnRestaurarBD.Text = "Restaurar BD";
            btnRestaurarBD.TextAlign = ContentAlignment.MiddleRight;
            btnRestaurarBD.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRestaurarBD.UseVisualStyleBackColor = false;
            btnRestaurarBD.Click += btnRestaurarBD_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(23, 252);
            label2.Name = "label2";
            label2.Size = new Size(165, 20);
            label2.TabIndex = 60;
            label2.Text = "Seleccione el Backup:";
            // 
            // formBackUpoRestBD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(85, 104, 124);
            ClientSize = new Size(508, 327);
            Controls.Add(label2);
            Controls.Add(btnRestaurarBD);
            Controls.Add(btnCrearBackup);
            Controls.Add(txtDirectorio);
            Controls.Add(label1);
            Controls.Add(lblAgregaroModificar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formBackUpoRestBD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formBackUpoRestBD";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private Label lbl;
        private PictureBox pictureBox1;
        private Label label7;
        private Label lblAgregaroModificar;
        private Label label1;
        private ReaLTaiizor.Controls.FoxTextBox txtDirectorio;
        private FontAwesome.Sharp.IconButton btnCrearBackup;
        private FontAwesome.Sharp.IconButton btnRestaurarBD;
        private Label label2;
    }
}
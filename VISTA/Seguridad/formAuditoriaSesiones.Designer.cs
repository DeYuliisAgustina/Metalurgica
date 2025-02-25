namespace VISTA
{
    partial class formAuditoriaSesiones
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
            btnImprimir = new FontAwesome.Sharp.IconButton();
            btnCerrar = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            dgvAuditoriaSesion = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoriaSesion).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(btnImprimir);
            panel1.Controls.Add(btnCerrar);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(801, 104);
            panel1.TabIndex = 1;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = SystemColors.ActiveCaptionText;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimir.ForeColor = SystemColors.Control;
            btnImprimir.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            btnImprimir.IconColor = Color.Red;
            btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Regular;
            btnImprimir.IconSize = 30;
            btnImprimir.ImageAlign = ContentAlignment.TopCenter;
            btnImprimir.Location = new Point(648, 59);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(138, 39);
            btnImprimir.TabIndex = 10;
            btnImprimir.Text = "Imprimir PDF";
            btnImprimir.TextAlign = ContentAlignment.MiddleRight;
            btnImprimir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.Red;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCerrar.IconSize = 20;
            btnCerrar.Location = new Point(769, 6);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 27);
            btnCerrar.TabIndex = 9;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Magneto", 36F, FontStyle.Bold);
            label2.Location = new Point(303, 9);
            label2.Name = "label2";
            label2.Size = new Size(376, 58);
            label2.TabIndex = 6;
            label2.Text = "Métallon s.r.l";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(262, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(377, 69);
            label7.Name = "label7";
            label7.Size = new Size(233, 29);
            label7.TabIndex = 4;
            label7.Text = "Auditoria Sesiones";
            // 
            // dgvAuditoriaSesion
            // 
            dgvAuditoriaSesion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditoriaSesion.Location = new Point(80, 118);
            dgvAuditoriaSesion.Name = "dgvAuditoriaSesion";
            dgvAuditoriaSesion.Size = new Size(656, 327);
            dgvAuditoriaSesion.TabIndex = 2;
            // 
            // formAuditoriaSesiones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 52, 69);
            ClientSize = new Size(798, 476);
            Controls.Add(dgvAuditoriaSesion);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formAuditoriaSesiones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formAuditoriaRegistros";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoriaSesion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label7;
        private DataGridView dgvAuditoriaSesion;
        private PictureBox pictureBox1;
        private Label label2;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private FontAwesome.Sharp.IconButton btnImprimir;
    }
}
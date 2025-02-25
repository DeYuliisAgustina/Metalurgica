namespace VISTA.UI_Admin
{
    partial class formGrupo
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
            lblAgregaroModificar = new Label();
            btnCerrar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            cmbCargarEstadoGrupo = new ComboBox();
            label5 = new Label();
            label2 = new Label();
            txtDescripcionGrupo = new TextBox();
            label1 = new Label();
            txtNombreGrupo = new TextBox();
            label4 = new Label();
            txtCodigoGrupo = new TextBox();
            tabPage2 = new TabPage();
            dgvAcciones = new DataGridView();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAcciones).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(lblAgregaroModificar);
            panel1.Controls.Add(btnCerrar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-2, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(720, 79);
            panel1.TabIndex = 2;
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Font = new Font("Microsoft Sans Serif", 12F);
            lblAgregaroModificar.ForeColor = Color.White;
            lblAgregaroModificar.Location = new Point(283, 47);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(204, 20);
            lblAgregaroModificar.TabIndex = 54;
            lblAgregaroModificar.Text = "Agregar o Modificar Grupos";
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.Black;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCerrar.IconSize = 25;
            btnCerrar.Location = new Point(693, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 27);
            btnCerrar.TabIndex = 53;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(273, 7);
            label3.Name = "label3";
            label3.Size = new Size(228, 37);
            label3.TabIndex = 4;
            label3.Text = "Grupos Datos";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(104, 79);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(24, 84);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(661, 286);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cmbCargarEstadoGrupo);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtDescripcionGrupo);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(txtNombreGrupo);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(txtCodigoGrupo);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(653, 258);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbCargarEstadoGrupo
            // 
            cmbCargarEstadoGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCargarEstadoGrupo.FormattingEnabled = true;
            cmbCargarEstadoGrupo.Location = new Point(118, 219);
            cmbCargarEstadoGrupo.Name = "cmbCargarEstadoGrupo";
            cmbCargarEstadoGrupo.Size = new Size(182, 23);
            cmbCargarEstadoGrupo.TabIndex = 60;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F);
            label5.Location = new Point(50, 219);
            label5.Name = "label5";
            label5.Size = new Size(62, 18);
            label5.TabIndex = 59;
            label5.Text = "Estado:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F);
            label2.Location = new Point(16, 123);
            label2.Name = "label2";
            label2.Size = new Size(96, 18);
            label2.TabIndex = 58;
            label2.Text = "Descripción:";
            // 
            // txtDescripcionGrupo
            // 
            txtDescripcionGrupo.Location = new Point(118, 116);
            txtDescripcionGrupo.Multiline = true;
            txtDescripcionGrupo.Name = "txtDescripcionGrupo";
            txtDescripcionGrupo.Size = new Size(490, 83);
            txtDescripcionGrupo.TabIndex = 57;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F);
            label1.Location = new Point(41, 70);
            label1.Name = "label1";
            label1.Size = new Size(68, 18);
            label1.TabIndex = 56;
            label1.Text = "Nombre:";
            // 
            // txtNombreGrupo
            // 
            txtNombreGrupo.Location = new Point(118, 70);
            txtNombreGrupo.Name = "txtNombreGrupo";
            txtNombreGrupo.Size = new Size(490, 23);
            txtNombreGrupo.TabIndex = 55;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F);
            label4.Location = new Point(41, 20);
            label4.Name = "label4";
            label4.Size = new Size(64, 18);
            label4.TabIndex = 54;
            label4.Text = "Código:";
            // 
            // txtCodigoGrupo
            // 
            txtCodigoGrupo.Location = new Point(118, 20);
            txtCodigoGrupo.Name = "txtCodigoGrupo";
            txtCodigoGrupo.Size = new Size(182, 23);
            txtCodigoGrupo.TabIndex = 53;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvAcciones);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(653, 258);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvAcciones
            // 
            dgvAcciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAcciones.Location = new Point(24, 15);
            dgvAcciones.Name = "dgvAcciones";
            dgvAcciones.Size = new Size(611, 223);
            dgvAcciones.TabIndex = 0;
            dgvAcciones.CellClick += DgvAcciones_CellClick;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Black;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Microsoft Sans Serif", 11.25F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCancelar.IconColor = Color.Red;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.IconSize = 25;
            btnCancelar.ImageAlign = ContentAlignment.MiddleRight;
            btnCancelar.Location = new Point(536, 384);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Padding = new Padding(0, 0, 8, 0);
            btnCancelar.Size = new Size(149, 34);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Black;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Microsoft Sans Serif", 11.25F);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Lime;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Regular;
            btnGuardar.IconSize = 25;
            btnGuardar.ImageAlign = ContentAlignment.MiddleRight;
            btnGuardar.Location = new Point(381, 384);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Padding = new Padding(0, 0, 8, 0);
            btnGuardar.Size = new Size(149, 34);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // formGrupo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(85, 104, 124);
            ClientSize = new Size(716, 430);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formGrupo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formGrupo";
            Load += formGrupo_Load;
            MouseDown += formGrupos_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAcciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private Label label3;
        private PictureBox pictureBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ComboBox cmbCargarEstadoGrupo;
        private Label label5;
        private Label label2;
        private TextBox txtDescripcionGrupo;
        private Label label1;
        private TextBox txtNombreGrupo;
        private Label label4;
        private TextBox txtCodigoGrupo;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private DataGridView dgvAcciones;
        private Label lblAgregaroModificar;
    }
}
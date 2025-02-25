namespace VISTA.UI_Admin
{
    partial class formUsuario
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            cmbCargarEstadosUsuario = new ComboBox();
            label5 = new Label();
            label2 = new Label();
            txtCorreoElectronico = new TextBox();
            label1 = new Label();
            txtNombreApellido = new TextBox();
            label4 = new Label();
            txtNombreUsuario = new TextBox();
            tabPage2 = new TabPage();
            dgvGrupos = new DataGridView();
            tabPage3 = new TabPage();
            dgvAcciones = new DataGridView();
            panel1 = new Panel();
            lblAgregaroModificar = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrupos).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAcciones).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(32, 85);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(654, 231);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cmbCargarEstadosUsuario);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtCorreoElectronico);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(txtNombreApellido);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(txtNombreUsuario);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(646, 203);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbCargarEstadosUsuario
            // 
            cmbCargarEstadosUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCargarEstadosUsuario.FormattingEnabled = true;
            cmbCargarEstadosUsuario.Location = new Point(91, 143);
            cmbCargarEstadosUsuario.Name = "cmbCargarEstadosUsuario";
            cmbCargarEstadosUsuario.Size = new Size(182, 23);
            cmbCargarEstadosUsuario.TabIndex = 52;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F);
            label5.Location = new Point(20, 143);
            label5.Name = "label5";
            label5.Size = new Size(62, 18);
            label5.TabIndex = 51;
            label5.Text = "Estado:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F);
            label2.Location = new Point(20, 92);
            label2.Name = "label2";
            label2.Size = new Size(57, 18);
            label2.TabIndex = 49;
            label2.Text = "E-mail:";
            // 
            // txtCorreoElectronico
            // 
            txtCorreoElectronico.Location = new Point(91, 90);
            txtCorreoElectronico.Name = "txtCorreoElectronico";
            txtCorreoElectronico.Size = new Size(182, 23);
            txtCorreoElectronico.TabIndex = 48;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F);
            label1.Location = new Point(296, 92);
            label1.Name = "label1";
            label1.Size = new Size(138, 18);
            label1.TabIndex = 47;
            label1.Text = "Nombre y apellido:";
            // 
            // txtNombreApellido
            // 
            txtNombreApellido.Location = new Point(440, 90);
            txtNombreApellido.Name = "txtNombreApellido";
            txtNombreApellido.Size = new Size(182, 23);
            txtNombreApellido.TabIndex = 46;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F);
            label4.Location = new Point(20, 40);
            label4.Name = "label4";
            label4.Size = new Size(66, 18);
            label4.TabIndex = 45;
            label4.Text = "Usuario:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(91, 38);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(182, 23);
            txtNombreUsuario.TabIndex = 30;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvGrupos);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(646, 203);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvGrupos
            // 
            dgvGrupos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrupos.Location = new Point(6, 6);
            dgvGrupos.Name = "dgvGrupos";
            dgvGrupos.Size = new Size(634, 191);
            dgvGrupos.TabIndex = 0;
            dgvGrupos.CellClick += DgvGrupos_CellClick;
            dgvGrupos.CellContentClick += DgvGrupos_CellClick;
            dgvGrupos.CellContentDoubleClick += DgvGrupos_CellClick;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgvAcciones);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(646, 203);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvAcciones
            // 
            dgvAcciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAcciones.Location = new Point(13, 6);
            dgvAcciones.Name = "dgvAcciones";
            dgvAcciones.Size = new Size(621, 194);
            dgvAcciones.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(lblAgregaroModificar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(720, 79);
            panel1.TabIndex = 1;
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Font = new Font("Microsoft Sans Serif", 12F);
            lblAgregaroModificar.ForeColor = Color.White;
            lblAgregaroModificar.Location = new Point(317, 49);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(214, 20);
            lblAgregaroModificar.TabIndex = 55;
            lblAgregaroModificar.Text = "Agregar o Modificar Usuarios";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(291, 7);
            label3.Name = "label3";
            label3.Size = new Size(251, 37);
            label3.TabIndex = 4;
            label3.Text = "Usuarios Datos";
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
            btnCancelar.Location = new Point(537, 322);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Padding = new Padding(0, 0, 8, 0);
            btnCancelar.Size = new Size(149, 34);
            btnCancelar.TabIndex = 19;
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
            btnGuardar.Location = new Point(382, 322);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Padding = new Padding(0, 0, 8, 0);
            btnGuardar.Size = new Size(149, 34);
            btnGuardar.TabIndex = 18;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // formUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(85, 104, 124);
            ClientSize = new Size(716, 362);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formMisDatos";
            Load += formUsuario_Load;
            MouseDown += formUsuarios_MouseDown;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGrupos).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAcciones).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
        private Label label3;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private TabPage tabPage3;
        private TextBox txtNombreUsuario;
        private Label label2;
        private TextBox txtCorreoElectronico;
        private Label label1;
        private TextBox txtNombreApellido;
        private Label label4;
        private ComboBox cmbCargarEstadosUsuario;
        private Label label5;
        private DataGridView dgvGrupos;
        private DataGridView dgvAcciones;
        private Label lblAgregaroModificar;
    }
}
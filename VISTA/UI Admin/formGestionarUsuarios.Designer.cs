namespace VISTA
{
    partial class formGestionarUsuarios
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
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            btnBuscarFiltrado = new FontAwesome.Sharp.IconButton();
            cmbCargarEstadoUsuario = new ComboBox();
            label4 = new Label();
            cmbCargarGrupos = new ComboBox();
            label1 = new Label();
            label6 = new Label();
            txtNombreUsuario = new TextBox();
            dgvGestionarUsuarios = new DataGridView();
            btnEliminarUsuario = new Button();
            btnModificarUsuario = new Button();
            btnAgregarUsuario = new Button();
            btnResetearUsuario = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGestionarUsuarios).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(btnCerrar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-9, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(829, 104);
            panel1.TabIndex = 1;
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.Black;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCerrar.IconSize = 25;
            btnCerrar.Location = new Point(802, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 27);
            btnCerrar.TabIndex = 54;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(395, 62);
            label3.Name = "label3";
            label3.Size = new Size(236, 29);
            label3.TabIndex = 3;
            label3.Text = "Gestionar Usuarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Magneto", 36F, FontStyle.Bold);
            label2.Location = new Point(324, 4);
            label2.Name = "label2";
            label2.Size = new Size(376, 58);
            label2.TabIndex = 2;
            label2.Text = "Métallon s.r.l";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(262, 104);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscarFiltrado);
            groupBox1.Controls.Add(cmbCargarEstadoUsuario);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbCargarGrupos);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtNombreUsuario);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 109);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(794, 69);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // btnBuscarFiltrado
            // 
            btnBuscarFiltrado.BackColor = Color.Black;
            btnBuscarFiltrado.FlatStyle = FlatStyle.Flat;
            btnBuscarFiltrado.Font = new Font("Segoe UI", 9.75F);
            btnBuscarFiltrado.ForeColor = Color.White;
            btnBuscarFiltrado.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscarFiltrado.IconColor = Color.White;
            btnBuscarFiltrado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscarFiltrado.IconSize = 20;
            btnBuscarFiltrado.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscarFiltrado.Location = new Point(696, 24);
            btnBuscarFiltrado.Name = "btnBuscarFiltrado";
            btnBuscarFiltrado.Size = new Size(80, 33);
            btnBuscarFiltrado.TabIndex = 18;
            btnBuscarFiltrado.Text = "Buscar";
            btnBuscarFiltrado.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscarFiltrado.UseVisualStyleBackColor = false;
            // 
            // cmbCargarEstadoUsuario
            // 
            cmbCargarEstadoUsuario.FormattingEnabled = true;
            cmbCargarEstadoUsuario.Location = new Point(541, 27);
            cmbCargarEstadoUsuario.Name = "cmbCargarEstadoUsuario";
            cmbCargarEstadoUsuario.Size = new Size(135, 28);
            cmbCargarEstadoUsuario.TabIndex = 61;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(480, 31);
            label4.Name = "label4";
            label4.Size = new Size(62, 18);
            label4.TabIndex = 60;
            label4.Text = "Estado:";
            // 
            // cmbCargarGrupos
            // 
            cmbCargarGrupos.FormattingEnabled = true;
            cmbCargarGrupos.Location = new Point(327, 27);
            cmbCargarGrupos.Name = "cmbCargarGrupos";
            cmbCargarGrupos.Size = new Size(135, 28);
            cmbCargarGrupos.TabIndex = 59;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(266, 31);
            label1.Name = "label1";
            label1.Size = new Size(55, 18);
            label1.TabIndex = 58;
            label1.Text = "Grupo:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 12F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(21, 31);
            label6.Name = "label6";
            label6.Size = new Size(68, 18);
            label6.TabIndex = 56;
            label6.Text = "Nombre:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(92, 27);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(149, 27);
            txtNombreUsuario.TabIndex = 55;
            // 
            // dgvGestionarUsuarios
            // 
            dgvGestionarUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGestionarUsuarios.Location = new Point(13, 184);
            dgvGestionarUsuarios.Name = "dgvGestionarUsuarios";
            dgvGestionarUsuarios.Size = new Size(793, 184);
            dgvGestionarUsuarios.TabIndex = 3;
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.BackColor = Color.Black;
            btnEliminarUsuario.FlatStyle = FlatStyle.Flat;
            btnEliminarUsuario.Font = new Font("Segoe UI", 9.75F);
            btnEliminarUsuario.ForeColor = Color.White;
            btnEliminarUsuario.Location = new Point(104, 376);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(83, 30);
            btnEliminarUsuario.TabIndex = 29;
            btnEliminarUsuario.Text = "Eliminar";
            btnEliminarUsuario.UseVisualStyleBackColor = false;
            btnEliminarUsuario.Click += btnEliminarUsuario_Click;
            // 
            // btnModificarUsuario
            // 
            btnModificarUsuario.BackColor = Color.Black;
            btnModificarUsuario.FlatStyle = FlatStyle.Flat;
            btnModificarUsuario.Font = new Font("Segoe UI", 9.75F);
            btnModificarUsuario.ForeColor = Color.White;
            btnModificarUsuario.Location = new Point(194, 376);
            btnModificarUsuario.Name = "btnModificarUsuario";
            btnModificarUsuario.Size = new Size(83, 30);
            btnModificarUsuario.TabIndex = 28;
            btnModificarUsuario.Text = "Modificar ";
            btnModificarUsuario.UseVisualStyleBackColor = false;
            btnModificarUsuario.Click += btnModificarUsuario_Click;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.BackColor = Color.Black;
            btnAgregarUsuario.FlatStyle = FlatStyle.Flat;
            btnAgregarUsuario.Font = new Font("Segoe UI", 9.75F);
            btnAgregarUsuario.ForeColor = Color.White;
            btnAgregarUsuario.Location = new Point(13, 376);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(83, 30);
            btnAgregarUsuario.TabIndex = 27;
            btnAgregarUsuario.Text = "Agregar";
            btnAgregarUsuario.UseVisualStyleBackColor = false;
            btnAgregarUsuario.Click += btnAgregarUsuario_Click;
            // 
            // btnResetearUsuario
            // 
            btnResetearUsuario.BackColor = Color.Black;
            btnResetearUsuario.FlatStyle = FlatStyle.Flat;
            btnResetearUsuario.Font = new Font("Segoe UI", 9.75F);
            btnResetearUsuario.ForeColor = Color.White;
            btnResetearUsuario.Location = new Point(283, 376);
            btnResetearUsuario.Name = "btnResetearUsuario";
            btnResetearUsuario.Size = new Size(83, 30);
            btnResetearUsuario.TabIndex = 30;
            btnResetearUsuario.Text = "Resetear";
            btnResetearUsuario.UseVisualStyleBackColor = false;
            btnResetearUsuario.Click += btnResetearUsuario_Click;
            // 
            // formGestionarUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 89, 109);
            ClientSize = new Size(818, 417);
            Controls.Add(btnResetearUsuario);
            Controls.Add(btnEliminarUsuario);
            Controls.Add(btnModificarUsuario);
            Controls.Add(btnAgregarUsuario);
            Controls.Add(dgvGestionarUsuarios);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formGestionarUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formGestionarUsuarios";
            Load += formGestionarUsuarios_Load;
            MouseDown += formGestionarGrupos_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGestionarUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Label label6;
        private TextBox txtNombreUsuario;
        private ComboBox cmbCargarEstadoUsuario;
        private Label label4;
        private ComboBox cmbCargarGrupos;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnBuscarFiltrado;
        private DataGridView dgvGestionarUsuarios;
        private Button btnEliminarUsuario;
        private Button btnModificarUsuario;
        private Button btnAgregarUsuario;
        private Button btnResetearUsuario;
        private FontAwesome.Sharp.IconButton btnCerrar;
    }
}
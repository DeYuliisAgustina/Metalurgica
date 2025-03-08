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
            btnRefrescarGrilla = new Button();
            btnCerrar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            cmbNombreUsuarios = new ComboBox();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            cmbCargarEstadoUsuario = new ComboBox();
            label4 = new Label();
            cmbCargarGrupos = new ComboBox();
            label1 = new Label();
            label6 = new Label();
            dgvGestionarUsuarios = new DataGridView();
            btnEliminarUsuario = new Button();
            btnModificarUsuario = new Button();
            btnAgregarUsuario = new Button();
            btnResetearUsuario = new Button();
            btnSalir = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGestionarUsuarios).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(btnRefrescarGrilla);
            panel1.Controls.Add(btnCerrar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-9, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(829, 104);
            panel1.TabIndex = 1;
            // 
            // btnRefrescarGrilla
            // 
            btnRefrescarGrilla.BackColor = Color.Black;
            btnRefrescarGrilla.FlatStyle = FlatStyle.Flat;
            btnRefrescarGrilla.Font = new Font("Segoe UI", 9.75F);
            btnRefrescarGrilla.ForeColor = Color.White;
            btnRefrescarGrilla.Location = new Point(706, 64);
            btnRefrescarGrilla.Name = "btnRefrescarGrilla";
            btnRefrescarGrilla.Size = new Size(109, 30);
            btnRefrescarGrilla.TabIndex = 55;
            btnRefrescarGrilla.Text = "Refrescar Grilla";
            btnRefrescarGrilla.UseVisualStyleBackColor = false;
            btnRefrescarGrilla.Click += btnRefrescarGrilla_Click;
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
            groupBox1.Controls.Add(cmbNombreUsuarios);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(cmbCargarEstadoUsuario);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbCargarGrupos);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label6);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 109);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(794, 69);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // cmbNombreUsuarios
            // 
            cmbNombreUsuarios.FormattingEnabled = true;
            cmbNombreUsuarios.Location = new Point(87, 27);
            cmbNombreUsuarios.Name = "cmbNombreUsuarios";
            cmbNombreUsuarios.Size = new Size(165, 28);
            cmbNombreUsuarios.TabIndex = 62;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.Black;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9.75F);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.White;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 20;
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(696, 24);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 33);
            btnBuscar.TabIndex = 18;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
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
            // btnSalir
            // 
            btnSalir.BackColor = Color.Black;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Microsoft Sans Serif", 11.25F);
            btnSalir.ForeColor = Color.White;
            btnSalir.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnSalir.IconColor = Color.Red;
            btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSalir.IconSize = 20;
            btnSalir.ImageAlign = ContentAlignment.MiddleRight;
            btnSalir.Location = new Point(658, 376);
            btnSalir.Name = "btnSalir";
            btnSalir.Padding = new Padding(0, 0, 8, 0);
            btnSalir.Size = new Size(148, 34);
            btnSalir.TabIndex = 38;
            btnSalir.Text = "Salir";
            btnSalir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // formGestionarUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 89, 109);
            ClientSize = new Size(818, 417);
            Controls.Add(btnSalir);
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
        private ComboBox cmbCargarEstadoUsuario;
        private Label label4;
        private ComboBox cmbCargarGrupos;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private DataGridView dgvGestionarUsuarios;
        private Button btnEliminarUsuario;
        private Button btnModificarUsuario;
        private Button btnAgregarUsuario;
        private Button btnResetearUsuario;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private Button btnRefrescarGrilla;
        private ComboBox cmbNombreUsuarios;
        private FontAwesome.Sharp.IconButton btnSalir;
    }
}
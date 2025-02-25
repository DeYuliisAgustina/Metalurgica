namespace VISTA.UI_Admin
{
    partial class formGestionarGrupos
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
            btnEliminarGrupo = new Button();
            btnModificarGrupo = new Button();
            btnAgregarGrupo = new Button();
            dgvGestionarGrupos = new DataGridView();
            groupBox1 = new GroupBox();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            cmbCargarEstadoGrupo = new ComboBox();
            label4 = new Label();
            label6 = new Label();
            txtNombreGrupo = new TextBox();
            panel1 = new Panel();
            btnCerrar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            btnSalir = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvGestionarGrupos).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnEliminarGrupo
            // 
            btnEliminarGrupo.BackColor = Color.Black;
            btnEliminarGrupo.FlatStyle = FlatStyle.Flat;
            btnEliminarGrupo.Font = new Font("Segoe UI", 9.75F);
            btnEliminarGrupo.ForeColor = Color.White;
            btnEliminarGrupo.Location = new Point(105, 377);
            btnEliminarGrupo.Name = "btnEliminarGrupo";
            btnEliminarGrupo.Size = new Size(83, 30);
            btnEliminarGrupo.TabIndex = 36;
            btnEliminarGrupo.Text = "Eliminar";
            btnEliminarGrupo.UseVisualStyleBackColor = false;
            btnEliminarGrupo.Click += btnEliminarGrupo_Click;
            // 
            // btnModificarGrupo
            // 
            btnModificarGrupo.BackColor = Color.Black;
            btnModificarGrupo.FlatStyle = FlatStyle.Flat;
            btnModificarGrupo.Font = new Font("Segoe UI", 9.75F);
            btnModificarGrupo.ForeColor = Color.White;
            btnModificarGrupo.Location = new Point(195, 377);
            btnModificarGrupo.Name = "btnModificarGrupo";
            btnModificarGrupo.Size = new Size(83, 30);
            btnModificarGrupo.TabIndex = 35;
            btnModificarGrupo.Text = "Modificar ";
            btnModificarGrupo.UseVisualStyleBackColor = false;
            btnModificarGrupo.Click += btnModificarGrupo_Click;
            // 
            // btnAgregarGrupo
            // 
            btnAgregarGrupo.BackColor = Color.Black;
            btnAgregarGrupo.FlatStyle = FlatStyle.Flat;
            btnAgregarGrupo.Font = new Font("Segoe UI", 9.75F);
            btnAgregarGrupo.ForeColor = Color.White;
            btnAgregarGrupo.Location = new Point(14, 377);
            btnAgregarGrupo.Name = "btnAgregarGrupo";
            btnAgregarGrupo.Size = new Size(83, 30);
            btnAgregarGrupo.TabIndex = 34;
            btnAgregarGrupo.Text = "Agregar";
            btnAgregarGrupo.UseVisualStyleBackColor = false;
            btnAgregarGrupo.Click += btnAgregarGrupo_Click;
            // 
            // dgvGestionarGrupos
            // 
            dgvGestionarGrupos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGestionarGrupos.Location = new Point(14, 185);
            dgvGestionarGrupos.Name = "dgvGestionarGrupos";
            dgvGestionarGrupos.Size = new Size(793, 184);
            dgvGestionarGrupos.TabIndex = 33;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(cmbCargarEstadoGrupo);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtNombreGrupo);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(13, 110);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(794, 69);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
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
            btnBuscar.Location = new Point(667, 24);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(109, 33);
            btnBuscar.TabIndex = 18;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // cmbCargarEstadoGrupo
            // 
            cmbCargarEstadoGrupo.DropDownStyle = ComboBoxStyle.Simple;
            cmbCargarEstadoGrupo.FormattingEnabled = true;
            cmbCargarEstadoGrupo.Location = new Point(422, 27);
            cmbCargarEstadoGrupo.Name = "cmbCargarEstadoGrupo";
            cmbCargarEstadoGrupo.Size = new Size(179, 28);
            cmbCargarEstadoGrupo.TabIndex = 61;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(361, 31);
            label4.Name = "label4";
            label4.Size = new Size(62, 18);
            label4.TabIndex = 60;
            label4.Text = "Estado:";
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
            // txtNombreGrupo
            // 
            txtNombreGrupo.Location = new Point(92, 27);
            txtNombreGrupo.Name = "txtNombreGrupo";
            txtNombreGrupo.Size = new Size(235, 27);
            txtNombreGrupo.TabIndex = 55;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(btnCerrar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-8, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(829, 104);
            panel1.TabIndex = 31;
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
            label3.Location = new Point(426, 62);
            label3.Name = "label3";
            label3.Size = new Size(218, 29);
            label3.TabIndex = 3;
            label3.Text = "Gestionar Grupos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Magneto", 36F, FontStyle.Bold);
            label2.Location = new Point(335, 4);
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
            btnSalir.Location = new Point(658, 375);
            btnSalir.Name = "btnSalir";
            btnSalir.Padding = new Padding(0, 0, 8, 0);
            btnSalir.Size = new Size(148, 34);
            btnSalir.TabIndex = 37;
            btnSalir.Text = "Salir";
            btnSalir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // formGestionarGrupos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 89, 109);
            ClientSize = new Size(818, 417);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminarGrupo);
            Controls.Add(btnModificarGrupo);
            Controls.Add(btnAgregarGrupo);
            Controls.Add(dgvGestionarGrupos);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formGestionarGrupos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formGestionarGrupos";
            Load += formGestionarGrupos_Load;
            MouseDown += formGestionarGrupos_MouseDown;
            ((System.ComponentModel.ISupportInitialize)dgvGestionarGrupos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnEliminarGrupo;
        private Button btnModificarGrupo;
        private Button btnAgregarGrupo;
        private DataGridView dgvGestionarGrupos;
        private GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private ComboBox cmbCargarEstadoGrupo;
        private Label label4;
        private Label label6;
        private TextBox txtNombreGrupo;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnSalir;
    }
}
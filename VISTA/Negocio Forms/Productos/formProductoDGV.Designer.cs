namespace VISTA.Negocio_Forms
{
    partial class formProductoDGV
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
            txtTextoBuscar = new TextBox();
            cmbBuscarPor = new ComboBox();
            label1 = new Label();
            btnDarAlta = new Button();
            btnModificar = new Button();
            dgvProducto = new DataGridView();
            panel1 = new Panel();
            btnRefrescarGrilla = new Button();
            btnCerrar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            btnAgregar = new Button();
            btnDarBaja = new Button();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvProducto).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtTextoBuscar
            // 
            txtTextoBuscar.Location = new Point(645, 129);
            txtTextoBuscar.Name = "txtTextoBuscar";
            txtTextoBuscar.Size = new Size(162, 23);
            txtTextoBuscar.TabIndex = 15;
            txtTextoBuscar.KeyPress += txtTextoBuscar_KeyPress;
            // 
            // cmbBuscarPor
            // 
            cmbBuscarPor.FormattingEnabled = true;
            cmbBuscarPor.Location = new Point(478, 129);
            cmbBuscarPor.Name = "cmbBuscarPor";
            cmbBuscarPor.Size = new Size(161, 23);
            cmbBuscarPor.TabIndex = 14;
            cmbBuscarPor.SelectedIndexChanged += cmbBuscarPor_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(397, 128);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 13;
            label1.Text = "Buscar Por";
            // 
            // btnDarAlta
            // 
            btnDarAlta.BackColor = Color.Black;
            btnDarAlta.FlatStyle = FlatStyle.Flat;
            btnDarAlta.Font = new Font("Segoe UI", 9.75F);
            btnDarAlta.ForeColor = Color.White;
            btnDarAlta.Location = new Point(193, 122);
            btnDarAlta.Name = "btnDarAlta";
            btnDarAlta.Size = new Size(90, 30);
            btnDarAlta.TabIndex = 12;
            btnDarAlta.Text = "Dar de Alta";
            btnDarAlta.UseVisualStyleBackColor = false;
            btnDarAlta.Click += btnDarAlta_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.Black;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI", 9.75F);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(104, 122);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(83, 30);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Modificar ";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // dgvProducto
            // 
            dgvProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducto.Location = new Point(15, 158);
            dgvProducto.Name = "dgvProducto";
            dgvProducto.Size = new Size(829, 239);
            dgvProducto.TabIndex = 9;
            dgvProducto.CellDoubleClick += dgvProducto_CellDoubleClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(btnRefrescarGrilla);
            panel1.Controls.Add(btnCerrar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(858, 104);
            panel1.TabIndex = 8;
            // 
            // btnRefrescarGrilla
            // 
            btnRefrescarGrilla.BackColor = Color.Black;
            btnRefrescarGrilla.FlatStyle = FlatStyle.Flat;
            btnRefrescarGrilla.Font = new Font("Segoe UI", 9.75F);
            btnRefrescarGrilla.ForeColor = Color.White;
            btnRefrescarGrilla.Location = new Point(735, 64);
            btnRefrescarGrilla.Name = "btnRefrescarGrilla";
            btnRefrescarGrilla.Size = new Size(109, 30);
            btnRefrescarGrilla.TabIndex = 11;
            btnRefrescarGrilla.Text = "Refrescar Grilla";
            btnRefrescarGrilla.UseVisualStyleBackColor = false;
            btnRefrescarGrilla.Click += btnRefrescarGrilla_Click;
            btnRefrescarGrilla.MouseDown += formProductoDGV_MouseDown;
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.Red;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCerrar.IconSize = 20;
            btnCerrar.Location = new Point(831, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 27);
            btnCerrar.TabIndex = 7;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(381, 62);
            label3.Name = "label3";
            label3.Size = new Size(270, 29);
            label3.TabIndex = 3;
            label3.Text = "Administrar Productos";
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
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Black;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9.75F);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(15, 122);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(83, 30);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnDarBaja
            // 
            btnDarBaja.BackColor = Color.Black;
            btnDarBaja.FlatStyle = FlatStyle.Flat;
            btnDarBaja.Font = new Font("Segoe UI", 9.75F);
            btnDarBaja.ForeColor = Color.White;
            btnDarBaja.Location = new Point(289, 122);
            btnDarBaja.Name = "btnDarBaja";
            btnDarBaja.Size = new Size(90, 30);
            btnDarBaja.TabIndex = 16;
            btnDarBaja.Text = "Dar de Baja";
            btnDarBaja.UseVisualStyleBackColor = false;
            btnDarBaja.Click += btnDarBaja_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = SystemColors.ActiveCaptionText;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.White;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 25;
            btnBuscar.Location = new Point(811, 123);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(33, 32);
            btnBuscar.TabIndex = 17;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // formProductoDGV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 89, 109);
            ClientSize = new Size(856, 410);
            Controls.Add(btnBuscar);
            Controls.Add(btnDarBaja);
            Controls.Add(txtTextoBuscar);
            Controls.Add(cmbBuscarPor);
            Controls.Add(label1);
            Controls.Add(btnDarAlta);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvProducto);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formProductoDGV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formProductoDGV";
            Load += formProductoDGV_Load;
            MouseDown += formProductoDGV_MouseDown;
            ((System.ComponentModel.ISupportInitialize)dgvProducto).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTextoBuscar;
        private ComboBox cmbBuscarPor;
        private Label label1;
        private Button btnDarAlta;
        private Button btnModificar;
        private DataGridView dgvProducto;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private Button btnAgregar;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private Button btnDarBaja;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private Button btnRefrescarGrilla;
    }
}
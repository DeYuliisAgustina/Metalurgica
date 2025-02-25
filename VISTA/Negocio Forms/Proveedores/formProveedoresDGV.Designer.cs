namespace VISTA.Negocio_Forms.Proveedores
{
    partial class formProveedoresDGV
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
            txtTextoBuscar = new TextBox();
            cmbBuscarPor = new ComboBox();
            label1 = new Label();
            btnDarAlta = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            dgvProveedor = new DataGridView();
            btnDarBaja = new Button();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProveedor).BeginInit();
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
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(854, 104);
            panel1.TabIndex = 1;
            // 
            // btnRefrescarGrilla
            // 
            btnRefrescarGrilla.BackColor = Color.Black;
            btnRefrescarGrilla.FlatStyle = FlatStyle.Flat;
            btnRefrescarGrilla.Font = new Font("Segoe UI", 9.75F);
            btnRefrescarGrilla.ForeColor = Color.White;
            btnRefrescarGrilla.Location = new Point(732, 61);
            btnRefrescarGrilla.Name = "btnRefrescarGrilla";
            btnRefrescarGrilla.Size = new Size(109, 30);
            btnRefrescarGrilla.TabIndex = 11;
            btnRefrescarGrilla.Text = "Refrescar Grilla";
            btnRefrescarGrilla.UseVisualStyleBackColor = false;
            btnRefrescarGrilla.Click += btnRefrescarGrilla_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.Red;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCerrar.IconSize = 20;
            btnCerrar.Location = new Point(827, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 27);
            btnCerrar.TabIndex = 8;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(362, 62);
            label3.Name = "label3";
            label3.Size = new Size(302, 29);
            label3.TabIndex = 3;
            label3.Text = "Administrar Proveedores";
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
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtTextoBuscar
            // 
            txtTextoBuscar.Location = new Point(642, 129);
            txtTextoBuscar.Name = "txtTextoBuscar";
            txtTextoBuscar.Size = new Size(166, 23);
            txtTextoBuscar.TabIndex = 14;
            txtTextoBuscar.KeyPress += txtTextoBuscar_KeyPress;
            // 
            // cmbBuscarPor
            // 
            cmbBuscarPor.FormattingEnabled = true;
            cmbBuscarPor.Location = new Point(475, 129);
            cmbBuscarPor.Name = "cmbBuscarPor";
            cmbBuscarPor.Size = new Size(161, 23);
            cmbBuscarPor.TabIndex = 13;
            cmbBuscarPor.SelectedIndexChanged += cmbBuscarPor_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(394, 129);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 12;
            label1.Text = "Buscar Por";
            // 
            // btnDarAlta
            // 
            btnDarAlta.BackColor = Color.Black;
            btnDarAlta.FlatStyle = FlatStyle.Flat;
            btnDarAlta.Font = new Font("Segoe UI", 9.75F);
            btnDarAlta.ForeColor = Color.White;
            btnDarAlta.Location = new Point(193, 121);
            btnDarAlta.Name = "btnDarAlta";
            btnDarAlta.Size = new Size(88, 30);
            btnDarAlta.TabIndex = 11;
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
            btnModificar.Location = new Point(104, 121);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(83, 30);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar ";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Black;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9.75F);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(15, 121);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(83, 30);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvProveedor
            // 
            dgvProveedor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedor.Location = new Point(15, 157);
            dgvProveedor.Name = "dgvProveedor";
            dgvProveedor.Size = new Size(826, 239);
            dgvProveedor.TabIndex = 8;
            // 
            // btnDarBaja
            // 
            btnDarBaja.BackColor = Color.Black;
            btnDarBaja.FlatStyle = FlatStyle.Flat;
            btnDarBaja.Font = new Font("Segoe UI", 9.75F);
            btnDarBaja.ForeColor = Color.White;
            btnDarBaja.Location = new Point(287, 121);
            btnDarBaja.Name = "btnDarBaja";
            btnDarBaja.Size = new Size(88, 30);
            btnDarBaja.TabIndex = 15;
            btnDarBaja.Text = "Dar de baja";
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
            btnBuscar.Location = new Point(813, 122);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(33, 32);
            btnBuscar.TabIndex = 16;
            btnBuscar.Text = " ";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // formProveedoresDGV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(70, 89, 109);
            ClientSize = new Size(853, 410);
            Controls.Add(btnBuscar);
            Controls.Add(btnDarBaja);
            Controls.Add(txtTextoBuscar);
            Controls.Add(cmbBuscarPor);
            Controls.Add(label1);
            Controls.Add(btnDarAlta);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvProveedor);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formProveedoresDGV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formProveedoresDGV";
            MouseDown += formProveedoresDGV_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProveedor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private TextBox txtTextoBuscar;
        private ComboBox cmbBuscarPor;
        private Label label1;
        private Button btnDarAlta;
        private Button btnModificar;
        private Button btnAgregar;
        private DataGridView dgvProveedor;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private Button btnDarBaja;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private Button btnRefrescarGrilla;
    }
}
namespace VISTA.Negocio_Forms.Compras
{
    partial class formNotasCompra
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
            btnImprimir = new FontAwesome.Sharp.IconButton();
            btnCerrar = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            txtBuscar = new TextBox();
            cmbBuscarPor = new ComboBox();
            label1 = new Label();
            btnConsultarDetalle = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            dgvHistorialNotasCompra = new DataGridView();
            btnAnularVentaBajaLogica = new Button();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialNotasCompra).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(btnRefrescarGrilla);
            panel1.Controls.Add(btnImprimir);
            panel1.Controls.Add(btnCerrar);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(-1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(880, 104);
            panel1.TabIndex = 2;
            // 
            // btnRefrescarGrilla
            // 
            btnRefrescarGrilla.BackColor = Color.Black;
            btnRefrescarGrilla.FlatStyle = FlatStyle.Flat;
            btnRefrescarGrilla.Font = new Font("Segoe UI", 9.75F);
            btnRefrescarGrilla.ForeColor = Color.White;
            btnRefrescarGrilla.Location = new Point(284, 62);
            btnRefrescarGrilla.Name = "btnRefrescarGrilla";
            btnRefrescarGrilla.Size = new Size(109, 30);
            btnRefrescarGrilla.TabIndex = 12;
            btnRefrescarGrilla.Text = "Refrescar Grilla";
            btnRefrescarGrilla.UseVisualStyleBackColor = false;
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
            btnImprimir.Location = new Point(695, 52);
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
            btnCerrar.Location = new Point(853, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 27);
            btnCerrar.TabIndex = 6;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(262, 104);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(419, 62);
            label3.Name = "label3";
            label3.Size = new Size(219, 29);
            label3.TabIndex = 3;
            label3.Text = "NOTAS COMPRA";
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
            // txtBuscar
            // 
            txtBuscar.Location = new Point(670, 128);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(162, 23);
            txtBuscar.TabIndex = 22;
            txtBuscar.KeyPress += txtBuscar_KeyPress;
            // 
            // cmbBuscarPor
            // 
            cmbBuscarPor.FormattingEnabled = true;
            cmbBuscarPor.Location = new Point(518, 128);
            cmbBuscarPor.Name = "cmbBuscarPor";
            cmbBuscarPor.Size = new Size(146, 23);
            cmbBuscarPor.TabIndex = 21;
            cmbBuscarPor.SelectedIndexChanged += cmbBuscarPor_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(437, 131);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 20;
            label1.Text = "Buscar Por";
            // 
            // btnConsultarDetalle
            // 
            btnConsultarDetalle.BackColor = Color.Black;
            btnConsultarDetalle.FlatStyle = FlatStyle.Flat;
            btnConsultarDetalle.Font = new Font("Segoe UI", 9.75F);
            btnConsultarDetalle.ForeColor = Color.White;
            btnConsultarDetalle.Location = new Point(197, 122);
            btnConsultarDetalle.Name = "btnConsultarDetalle";
            btnConsultarDetalle.Size = new Size(121, 30);
            btnConsultarDetalle.TabIndex = 19;
            btnConsultarDetalle.Text = "Consultar Detalle";
            btnConsultarDetalle.UseVisualStyleBackColor = false;
            btnConsultarDetalle.Click += btnConsultarDetalle_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.Black;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI", 9.75F);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(108, 122);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(83, 30);
            btnModificar.TabIndex = 18;
            btnModificar.Text = "Modificar ";
            btnModificar.TextAlign = ContentAlignment.MiddleRight;
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Black;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9.75F);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(19, 122);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(83, 30);
            btnAgregar.TabIndex = 17;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvHistorialNotasCompra
            // 
            dgvHistorialNotasCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorialNotasCompra.Location = new Point(15, 158);
            dgvHistorialNotasCompra.Name = "dgvHistorialNotasCompra";
            dgvHistorialNotasCompra.Size = new Size(849, 239);
            dgvHistorialNotasCompra.TabIndex = 16;
            // 
            // btnAnularVentaBajaLogica
            // 
            btnAnularVentaBajaLogica.BackColor = Color.Black;
            btnAnularVentaBajaLogica.FlatStyle = FlatStyle.Flat;
            btnAnularVentaBajaLogica.Font = new Font("Segoe UI", 9.75F);
            btnAnularVentaBajaLogica.ForeColor = Color.White;
            btnAnularVentaBajaLogica.Location = new Point(324, 122);
            btnAnularVentaBajaLogica.Name = "btnAnularVentaBajaLogica";
            btnAnularVentaBajaLogica.Size = new Size(107, 30);
            btnAnularVentaBajaLogica.TabIndex = 27;
            btnAnularVentaBajaLogica.Text = "Anular Compra";
            btnAnularVentaBajaLogica.UseVisualStyleBackColor = false;
            btnAnularVentaBajaLogica.Click += btnAnularVentaBajaLogica_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = SystemColors.ActiveCaptionText;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.White;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 25;
            btnBuscar.Location = new Point(835, 120);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(33, 32);
            btnBuscar.TabIndex = 28;
            btnBuscar.Text = " ";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            btnBuscar.KeyPress += txtBuscar_KeyPress;
            // 
            // formNotasCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(85, 104, 124);
            ClientSize = new Size(876, 410);
            Controls.Add(btnBuscar);
            Controls.Add(btnAnularVentaBajaLogica);
            Controls.Add(txtBuscar);
            Controls.Add(cmbBuscarPor);
            Controls.Add(label1);
            Controls.Add(btnConsultarDetalle);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvHistorialNotasCompra);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formNotasCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formBuscarCompra";
            Load += formNotasCompra_Load;
            MouseDown += formNotasCompra_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialNotasCompra).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private TextBox txtBuscar;
        private ComboBox cmbBuscarPor;
        private Label label1;
        private Button btnConsultarDetalle;
        private Button btnModificar;
        private Button btnAgregar;
        private DataGridView dgvHistorialNotasCompra;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private Button btnAnularVentaBajaLogica;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private Button btnRefrescarGrilla;
    }
}
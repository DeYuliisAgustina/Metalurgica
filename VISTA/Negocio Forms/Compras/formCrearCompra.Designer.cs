namespace VISTA.Negocio_Forms.Compras
{
    partial class formCrearCompra
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
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panelDatos = new Panel();
            cmbEstadoNotaCompra = new ComboBox();
            label5 = new Label();
            label1 = new Label();
            txtNumeroAutogenerado = new TextBox();
            cmbNombresProveedores = new ComboBox();
            cmbMedioPago = new ComboBox();
            label4 = new Label();
            dtpFechaRegistro = new DateTimePicker();
            label11 = new Label();
            txtDNIProveedorSeleccionado = new TextBox();
            label9 = new Label();
            label7 = new Label();
            btnAgregarDatos = new FontAwesome.Sharp.IconButton();
            groupBox1 = new GroupBox();
            dgvNotaCompra = new DataGridView();
            btnCrearCompra = new FontAwesome.Sharp.IconButton();
            btnCancelarCompra = new FontAwesome.Sharp.IconButton();
            label10 = new Label();
            txtTotalPagar = new TextBox();
            gbDetalleEstado = new GroupBox();
            btnModificarDetalle = new FontAwesome.Sharp.IconButton();
            btnAgregarDetalle = new FontAwesome.Sharp.IconButton();
            label14 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelDatos.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotaCompra).BeginInit();
            gbDetalleEstado.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(lblAgregaroModificar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(829, 123);
            panel1.TabIndex = 1;
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Font = new Font("Microsoft Sans Serif", 12F);
            lblAgregaroModificar.ForeColor = Color.White;
            lblAgregaroModificar.Location = new Point(372, 89);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(267, 20);
            lblAgregaroModificar.TabIndex = 32;
            lblAgregaroModificar.Text = "Agregar o Modificar Nota de Compra";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(386, 57);
            label3.Name = "label3";
            label3.Size = new Size(244, 29);
            label3.TabIndex = 3;
            label3.Text = "NOTA DE COMPRA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Magneto", 36F, FontStyle.Bold);
            label2.Location = new Point(324, 2);
            label2.Name = "label2";
            label2.Size = new Size(376, 58);
            label2.TabIndex = 2;
            label2.Text = "Métallon s.r.l";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 115);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panelDatos
            // 
            panelDatos.BackColor = Color.LightGray;
            panelDatos.Controls.Add(cmbEstadoNotaCompra);
            panelDatos.Controls.Add(label5);
            panelDatos.Controls.Add(label1);
            panelDatos.Controls.Add(txtNumeroAutogenerado);
            panelDatos.Controls.Add(cmbNombresProveedores);
            panelDatos.Controls.Add(cmbMedioPago);
            panelDatos.Controls.Add(label4);
            panelDatos.Controls.Add(dtpFechaRegistro);
            panelDatos.Controls.Add(label11);
            panelDatos.Controls.Add(txtDNIProveedorSeleccionado);
            panelDatos.Controls.Add(label9);
            panelDatos.Controls.Add(label7);
            panelDatos.Controls.Add(btnAgregarDatos);
            panelDatos.Location = new Point(17, 129);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(793, 164);
            panelDatos.TabIndex = 2;
            // 
            // cmbEstadoNotaCompra
            // 
            cmbEstadoNotaCompra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoNotaCompra.FormattingEnabled = true;
            cmbEstadoNotaCompra.Location = new Point(581, 90);
            cmbEstadoNotaCompra.Name = "cmbEstadoNotaCompra";
            cmbEstadoNotaCompra.Size = new Size(195, 23);
            cmbEstadoNotaCompra.TabIndex = 48;
            cmbEstadoNotaCompra.SelectedIndexChanged += CmbEstadoNotaCompra_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(440, 91);
            label5.Name = "label5";
            label5.Size = new Size(135, 20);
            label5.TabIndex = 47;
            label5.Text = "Estado Nota Venta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(26, 12);
            label1.Name = "label1";
            label1.Size = new Size(118, 17);
            label1.TabIndex = 46;
            label1.Text = "Nro Nota Compra:";
            // 
            // txtNumeroAutogenerado
            // 
            txtNumeroAutogenerado.Location = new Point(149, 11);
            txtNumeroAutogenerado.Name = "txtNumeroAutogenerado";
            txtNumeroAutogenerado.ReadOnly = true;
            txtNumeroAutogenerado.Size = new Size(195, 23);
            txtNumeroAutogenerado.TabIndex = 45;
            // 
            // cmbNombresProveedores
            // 
            cmbNombresProveedores.FormattingEnabled = true;
            cmbNombresProveedores.Location = new Point(150, 88);
            cmbNombresProveedores.Name = "cmbNombresProveedores";
            cmbNombresProveedores.Size = new Size(227, 23);
            cmbNombresProveedores.TabIndex = 44;
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.Location = new Point(581, 46);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new Size(195, 23);
            cmbMedioPago.TabIndex = 43;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(449, 49);
            label4.Name = "label4";
            label4.Size = new Size(102, 17);
            label4.TabIndex = 42;
            label4.Text = "Medio de Pago:";
            // 
            // dtpFechaRegistro
            // 
            dtpFechaRegistro.Location = new Point(149, 47);
            dtpFechaRegistro.Name = "dtpFechaRegistro";
            dtpFechaRegistro.Size = new Size(227, 23);
            dtpFechaRegistro.TabIndex = 41;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F);
            label11.Location = new Point(24, 53);
            label11.Name = "label11";
            label11.Size = new Size(97, 17);
            label11.TabIndex = 40;
            label11.Text = "Fecha Registro:";
            // 
            // txtDNIProveedorSeleccionado
            // 
            txtDNIProveedorSeleccionado.Location = new Point(581, 11);
            txtDNIProveedorSeleccionado.Name = "txtDNIProveedorSeleccionado";
            txtDNIProveedorSeleccionado.Size = new Size(195, 23);
            txtDNIProveedorSeleccionado.TabIndex = 39;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F);
            label9.Location = new Point(24, 91);
            label9.Name = "label9";
            label9.Size = new Size(125, 17);
            label9.TabIndex = 38;
            label9.Text = "Nombre Proveedor:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.Location = new Point(450, 12);
            label7.Name = "label7";
            label7.Size = new Size(120, 17);
            label7.TabIndex = 37;
            label7.Text = "DNI del Proveedor:";
            // 
            // btnAgregarDatos
            // 
            btnAgregarDatos.BackColor = Color.Black;
            btnAgregarDatos.FlatStyle = FlatStyle.Flat;
            btnAgregarDatos.Font = new Font("Segoe UI", 9.75F);
            btnAgregarDatos.ForeColor = Color.White;
            btnAgregarDatos.IconChar = FontAwesome.Sharp.IconChar.Add;
            btnAgregarDatos.IconColor = Color.Lime;
            btnAgregarDatos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregarDatos.IconSize = 20;
            btnAgregarDatos.ImageAlign = ContentAlignment.MiddleRight;
            btnAgregarDatos.Location = new Point(562, 120);
            btnAgregarDatos.Name = "btnAgregarDatos";
            btnAgregarDatos.Size = new Size(227, 34);
            btnAgregarDatos.TabIndex = 29;
            btnAgregarDatos.Text = "Agregar";
            btnAgregarDatos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAgregarDatos.UseVisualStyleBackColor = false;
            btnAgregarDatos.Click += btnAgregarDatos_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvNotaCompra);
            groupBox1.Location = new Point(17, 367);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(793, 236);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // dgvNotaCompra
            // 
            dgvNotaCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotaCompra.Location = new Point(8, 16);
            dgvNotaCompra.Name = "dgvNotaCompra";
            dgvNotaCompra.Size = new Size(777, 211);
            dgvNotaCompra.TabIndex = 0;
            // 
            // btnCrearCompra
            // 
            btnCrearCompra.BackColor = Color.Black;
            btnCrearCompra.FlatStyle = FlatStyle.Flat;
            btnCrearCompra.Font = new Font("Segoe UI", 9.75F);
            btnCrearCompra.ForeColor = Color.White;
            btnCrearCompra.IconChar = FontAwesome.Sharp.IconChar.Tag;
            btnCrearCompra.IconColor = Color.White;
            btnCrearCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCrearCompra.IconSize = 23;
            btnCrearCompra.ImageAlign = ContentAlignment.MiddleRight;
            btnCrearCompra.Location = new Point(14, 614);
            btnCrearCompra.Name = "btnCrearCompra";
            btnCrearCompra.Size = new Size(138, 35);
            btnCrearCompra.TabIndex = 16;
            btnCrearCompra.Text = "Crear Compra";
            btnCrearCompra.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCrearCompra.UseVisualStyleBackColor = false;
            btnCrearCompra.Click += btnCrearCompra_Click;
            // 
            // btnCancelarCompra
            // 
            btnCancelarCompra.BackColor = Color.Black;
            btnCancelarCompra.FlatStyle = FlatStyle.Flat;
            btnCancelarCompra.Font = new Font("Segoe UI", 9.75F);
            btnCancelarCompra.ForeColor = Color.White;
            btnCancelarCompra.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCancelarCompra.IconColor = Color.Red;
            btnCancelarCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelarCompra.IconSize = 23;
            btnCancelarCompra.Location = new Point(172, 614);
            btnCancelarCompra.Name = "btnCancelarCompra";
            btnCancelarCompra.Size = new Size(148, 35);
            btnCancelarCompra.TabIndex = 17;
            btnCancelarCompra.Text = "Cancelar Compra";
            btnCancelarCompra.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelarCompra.UseVisualStyleBackColor = false;
            btnCancelarCompra.Click += btnCancelarCompra_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(593, 622);
            label10.Name = "label10";
            label10.Size = new Size(101, 21);
            label10.TabIndex = 18;
            label10.Text = "Total a pagar:";
            // 
            // txtTotalPagar
            // 
            txtTotalPagar.Location = new Point(700, 622);
            txtTotalPagar.Name = "txtTotalPagar";
            txtTotalPagar.Size = new Size(100, 23);
            txtTotalPagar.TabIndex = 0;
            // 
            // gbDetalleEstado
            // 
            gbDetalleEstado.BackColor = Color.White;
            gbDetalleEstado.Controls.Add(btnModificarDetalle);
            gbDetalleEstado.Controls.Add(btnAgregarDetalle);
            gbDetalleEstado.Controls.Add(label14);
            gbDetalleEstado.Location = new Point(18, 299);
            gbDetalleEstado.Name = "gbDetalleEstado";
            gbDetalleEstado.Size = new Size(791, 64);
            gbDetalleEstado.TabIndex = 23;
            gbDetalleEstado.TabStop = false;
            // 
            // btnModificarDetalle
            // 
            btnModificarDetalle.BackColor = Color.Black;
            btnModificarDetalle.FlatStyle = FlatStyle.Flat;
            btnModificarDetalle.Font = new Font("Segoe UI", 9.75F);
            btnModificarDetalle.ForeColor = Color.White;
            btnModificarDetalle.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnModificarDetalle.IconColor = Color.Red;
            btnModificarDetalle.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnModificarDetalle.IconSize = 25;
            btnModificarDetalle.ImageAlign = ContentAlignment.MiddleRight;
            btnModificarDetalle.Location = new Point(272, 18);
            btnModificarDetalle.Name = "btnModificarDetalle";
            btnModificarDetalle.Size = new Size(103, 35);
            btnModificarDetalle.TabIndex = 34;
            btnModificarDetalle.Text = "Modificar";
            btnModificarDetalle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnModificarDetalle.UseVisualStyleBackColor = false;
            btnModificarDetalle.Click += btnModificarDetalle_Click;
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.BackColor = Color.Black;
            btnAgregarDetalle.FlatStyle = FlatStyle.Flat;
            btnAgregarDetalle.Font = new Font("Segoe UI", 9.75F);
            btnAgregarDetalle.ForeColor = Color.White;
            btnAgregarDetalle.IconChar = FontAwesome.Sharp.IconChar.Add;
            btnAgregarDetalle.IconColor = Color.Lime;
            btnAgregarDetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregarDetalle.IconSize = 20;
            btnAgregarDetalle.ImageAlign = ContentAlignment.MiddleRight;
            btnAgregarDetalle.Location = new Point(169, 18);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(97, 35);
            btnAgregarDetalle.TabIndex = 33;
            btnAgregarDetalle.Text = "Agregar";
            btnAgregarDetalle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAgregarDetalle.UseVisualStyleBackColor = false;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(14, 27);
            label14.Name = "label14";
            label14.Size = new Size(154, 17);
            label14.TabIndex = 32;
            label14.Text = "Detalle Nota de Compra:";
            // 
            // formCrearCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(85, 104, 124);
            ClientSize = new Size(826, 652);
            Controls.Add(gbDetalleEstado);
            Controls.Add(txtTotalPagar);
            Controls.Add(label10);
            Controls.Add(btnCancelarCompra);
            Controls.Add(btnCrearCompra);
            Controls.Add(groupBox1);
            Controls.Add(panelDatos);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formCrearCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formCrearCompra";
            Load += formCrearCompra_Load;
            MouseDown += formCrearCompra_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNotaCompra).EndInit();
            gbDetalleEstado.ResumeLayout(false);
            gbDetalleEstado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private Panel panelDatos;
        private GroupBox groupBox1;
        private DataGridView dgvNotaCompra;
        private FontAwesome.Sharp.IconButton btnCrearCompra;
        private FontAwesome.Sharp.IconButton btnCancelarCompra;
        private Label label10;
        private TextBox txtTotalPagar;
        private FontAwesome.Sharp.IconButton btnAgregarDatos;
        private GroupBox gbDetalleEstado;
        private FontAwesome.Sharp.IconButton btnModificarDetalle;
        private FontAwesome.Sharp.IconButton btnAgregarDetalle;
        private Label label14;
        private Label lblAgregaroModificar;
        private ComboBox cmbEstadoNotaCompra;
        private Label label5;
        private Label label1;
        private TextBox txtNumeroAutogenerado;
        private ComboBox cmbNombresProveedores;
        private ComboBox cmbMedioPago;
        private Label label4;
        private DateTimePicker dtpFechaRegistro;
        private Label label11;
        private TextBox txtDNIProveedorSeleccionado;
        private Label label9;
        private Label label7;
    }
}
namespace VISTA.Negocio_Forms.Ventas
{
    partial class formCrearVenta
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
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            dgvNotaVenta = new DataGridView();
            panel2 = new Panel();
            cmbEstadoNotaVenta = new ComboBox();
            label5 = new Label();
            label1 = new Label();
            txtNumeroAutogenerado = new TextBox();
            cmbNombresClientes = new ComboBox();
            cmbMedioPago = new ComboBox();
            label4 = new Label();
            dtpFechaRegistro = new DateTimePicker();
            label11 = new Label();
            btnAgregarDatos = new FontAwesome.Sharp.IconButton();
            txtDNIClienteSeleccionado = new TextBox();
            label9 = new Label();
            label7 = new Label();
            btnCancelarVenta = new FontAwesome.Sharp.IconButton();
            btnCrearVenta = new FontAwesome.Sharp.IconButton();
            txtTotalPagar = new TextBox();
            label12 = new Label();
            A = new GroupBox();
            btnModificarDetalle = new FontAwesome.Sharp.IconButton();
            btnAgregarDetalle = new FontAwesome.Sharp.IconButton();
            label14 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotaVenta).BeginInit();
            panel2.SuspendLayout();
            A.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(lblAgregaroModificar);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(-1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(829, 123);
            panel1.TabIndex = 3;
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Font = new Font("Microsoft Sans Serif", 12F);
            lblAgregaroModificar.ForeColor = Color.White;
            lblAgregaroModificar.Location = new Point(417, 90);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(254, 20);
            lblAgregaroModificar.TabIndex = 7;
            lblAgregaroModificar.Text = "Agregar o Modificar Nota de Venta";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(238, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(437, 56);
            label3.Name = "label3";
            label3.Size = new Size(219, 29);
            label3.TabIndex = 3;
            label3.Text = "NOTA DE VENTA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Magneto", 36F, FontStyle.Bold);
            label2.Location = new Point(352, 0);
            label2.Name = "label2";
            label2.Size = new Size(376, 58);
            label2.TabIndex = 2;
            label2.Text = "Métallon s.r.l";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvNotaVenta);
            groupBox1.Location = new Point(17, 367);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(793, 236);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            // 
            // dgvNotaVenta
            // 
            dgvNotaVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotaVenta.Location = new Point(8, 16);
            dgvNotaVenta.Name = "dgvNotaVenta";
            dgvNotaVenta.Size = new Size(777, 211);
            dgvNotaVenta.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGray;
            panel2.Controls.Add(cmbEstadoNotaVenta);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtNumeroAutogenerado);
            panel2.Controls.Add(cmbNombresClientes);
            panel2.Controls.Add(cmbMedioPago);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(dtpFechaRegistro);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(btnAgregarDatos);
            panel2.Controls.Add(txtDNIClienteSeleccionado);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label7);
            panel2.Location = new Point(17, 129);
            panel2.Name = "panel2";
            panel2.Size = new Size(793, 164);
            panel2.TabIndex = 6;
            // 
            // cmbEstadoNotaVenta
            // 
            cmbEstadoNotaVenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoNotaVenta.FormattingEnabled = true;
            cmbEstadoNotaVenta.Location = new Point(570, 92);
            cmbEstadoNotaVenta.Name = "cmbEstadoNotaVenta";
            cmbEstadoNotaVenta.Size = new Size(195, 23);
            cmbEstadoNotaVenta.TabIndex = 36;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(429, 93);
            label5.Name = "label5";
            label5.Size = new Size(135, 20);
            label5.TabIndex = 35;
            label5.Text = "Estado Nota Venta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(15, 14);
            label1.Name = "label1";
            label1.Size = new Size(103, 17);
            label1.TabIndex = 33;
            label1.Text = "Nro Nota Venta:";
            // 
            // txtNumeroAutogenerado
            // 
            txtNumeroAutogenerado.Location = new Point(124, 13);
            txtNumeroAutogenerado.Name = "txtNumeroAutogenerado";
            txtNumeroAutogenerado.ReadOnly = true;
            txtNumeroAutogenerado.Size = new Size(195, 23);
            txtNumeroAutogenerado.TabIndex = 32;
            // 
            // cmbNombresClientes
            // 
            cmbNombresClientes.FormattingEnabled = true;
            cmbNombresClientes.Location = new Point(124, 90);
            cmbNombresClientes.Name = "cmbNombresClientes";
            cmbNombresClientes.Size = new Size(227, 23);
            cmbNombresClientes.TabIndex = 31;
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.Location = new Point(570, 51);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new Size(195, 23);
            cmbMedioPago.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(438, 51);
            label4.Name = "label4";
            label4.Size = new Size(102, 17);
            label4.TabIndex = 29;
            label4.Text = "Medio de Pago:";
            // 
            // dtpFechaRegistro
            // 
            dtpFechaRegistro.Location = new Point(124, 51);
            dtpFechaRegistro.Name = "dtpFechaRegistro";
            dtpFechaRegistro.Size = new Size(227, 23);
            dtpFechaRegistro.TabIndex = 26;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F);
            label11.Location = new Point(13, 55);
            label11.Name = "label11";
            label11.Size = new Size(97, 17);
            label11.TabIndex = 25;
            label11.Text = "Fecha Registro:";
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
            btnAgregarDatos.Location = new Point(558, 124);
            btnAgregarDatos.Name = "btnAgregarDatos";
            btnAgregarDatos.Size = new Size(227, 34);
            btnAgregarDatos.TabIndex = 17;
            btnAgregarDatos.Text = "Agregar";
            btnAgregarDatos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAgregarDatos.UseVisualStyleBackColor = false;
            btnAgregarDatos.Click += btnAgregarDatos_Click;
            // 
            // txtDNIClienteSeleccionado
            // 
            txtDNIClienteSeleccionado.Location = new Point(570, 13);
            txtDNIClienteSeleccionado.Name = "txtDNIClienteSeleccionado";
            txtDNIClienteSeleccionado.Size = new Size(195, 23);
            txtDNIClienteSeleccionado.TabIndex = 12;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F);
            label9.Location = new Point(13, 93);
            label9.Name = "label9";
            label9.Size = new Size(103, 17);
            label9.TabIndex = 8;
            label9.Text = "Nombre Cliente:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.Location = new Point(439, 14);
            label7.Name = "label7";
            label7.Size = new Size(98, 17);
            label7.TabIndex = 6;
            label7.Text = "DNI del Cliente:";
            // 
            // btnCancelarVenta
            // 
            btnCancelarVenta.BackColor = Color.Black;
            btnCancelarVenta.FlatStyle = FlatStyle.Flat;
            btnCancelarVenta.Font = new Font("Segoe UI", 9.75F);
            btnCancelarVenta.ForeColor = Color.White;
            btnCancelarVenta.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCancelarVenta.IconColor = Color.Red;
            btnCancelarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelarVenta.IconSize = 23;
            btnCancelarVenta.Location = new Point(170, 610);
            btnCancelarVenta.Name = "btnCancelarVenta";
            btnCancelarVenta.Size = new Size(148, 35);
            btnCancelarVenta.TabIndex = 19;
            btnCancelarVenta.Text = "Cancelar Venta";
            btnCancelarVenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelarVenta.UseVisualStyleBackColor = false;
            btnCancelarVenta.Click += btnCancelarVenta_Click;
            // 
            // btnCrearVenta
            // 
            btnCrearVenta.BackColor = Color.Black;
            btnCrearVenta.FlatStyle = FlatStyle.Flat;
            btnCrearVenta.Font = new Font("Segoe UI", 9.75F);
            btnCrearVenta.ForeColor = Color.White;
            btnCrearVenta.IconChar = FontAwesome.Sharp.IconChar.Tag;
            btnCrearVenta.IconColor = Color.White;
            btnCrearVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCrearVenta.IconSize = 23;
            btnCrearVenta.ImageAlign = ContentAlignment.MiddleRight;
            btnCrearVenta.Location = new Point(17, 609);
            btnCrearVenta.Name = "btnCrearVenta";
            btnCrearVenta.Size = new Size(138, 35);
            btnCrearVenta.TabIndex = 18;
            btnCrearVenta.Text = "Crear Venta";
            btnCrearVenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCrearVenta.UseVisualStyleBackColor = false;
            btnCrearVenta.Click += btnCrearVenta_Click;
            // 
            // txtTotalPagar
            // 
            txtTotalPagar.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTotalPagar.ForeColor = Color.Lime;
            txtTotalPagar.Location = new Point(709, 617);
            txtTotalPagar.Name = "txtTotalPagar";
            txtTotalPagar.ReadOnly = true;
            txtTotalPagar.Size = new Size(100, 24);
            txtTotalPagar.TabIndex = 20;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(602, 617);
            label12.Name = "label12";
            label12.Size = new Size(101, 21);
            label12.TabIndex = 21;
            label12.Text = "Total a pagar:";
            // 
            // A
            // 
            A.BackColor = Color.White;
            A.Controls.Add(btnModificarDetalle);
            A.Controls.Add(btnAgregarDetalle);
            A.Controls.Add(label14);
            A.Location = new Point(18, 299);
            A.Name = "A";
            A.Size = new Size(791, 64);
            A.TabIndex = 22;
            A.TabStop = false;
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
            btnModificarDetalle.Location = new Point(262, 18);
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
            btnAgregarDetalle.Location = new Point(159, 18);
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
            label14.Size = new Size(139, 17);
            label14.TabIndex = 32;
            label14.Text = "Detalle Nota de Venta:";
            // 
            // formCrearVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(85, 104, 124);
            ClientSize = new Size(826, 652);
            Controls.Add(A);
            Controls.Add(txtTotalPagar);
            Controls.Add(label12);
            Controls.Add(btnCancelarVenta);
            Controls.Add(btnCrearVenta);
            Controls.Add(panel2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formCrearVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formCrearVenta";
            Load += formCrearVenta_Load;
            MouseDown += formCrearVenta_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNotaVenta).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            A.ResumeLayout(false);
            A.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private DataGridView dgvNotaVenta;
        private Panel panel2;
        private DateTimePicker dtpFechaRegistro;
        private Label label11;
        private FontAwesome.Sharp.IconButton btnAgregarDatos;
        private TextBox txtDNIClienteSeleccionado;
        private Label label9;
        private Label label7;
        private FontAwesome.Sharp.IconButton btnCancelarVenta;
        private FontAwesome.Sharp.IconButton btnCrearVenta;
        private TextBox txtTotalPagar;
        private Label label12;
        private GroupBox A;
        private ComboBox cmbMedioPago;
        private Label label4;
        private FontAwesome.Sharp.IconButton btnModificarDetalle;
        private FontAwesome.Sharp.IconButton btnAgregarDetalle;
        private Label label14;
        private ComboBox cmbNombresClientes;
        private Label lblAgregaroModificar;
        private Label label1;
        private TextBox txtNumeroAutogenerado;
        private ComboBox cmbEstadoNotaVenta;
        private Label label5;
    }
}
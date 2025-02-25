namespace VISTA.Negocio_Forms.Ventas
{
    partial class formDetalleVenta
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
            pictureBox1 = new PictureBox();
            lblAgregaroModificar = new Label();
            label7 = new Label();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnAceptar = new FontAwesome.Sharp.IconButton();
            groupBox1 = new GroupBox();
            btnBuscarProducto = new FontAwesome.Sharp.IconButton();
            numCantidadProducto = new NumericUpDown();
            txtProductoSeleccionado = new TextBox();
            txtPrecioUnitario = new TextBox();
            label9 = new Label();
            label4 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidadProducto).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lblAgregaroModificar);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(516, 104);
            panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(45, 64, 84);
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 101);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Font = new Font("Microsoft Sans Serif", 12F);
            lblAgregaroModificar.ForeColor = Color.White;
            lblAgregaroModificar.Location = new Point(219, 58);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(201, 20);
            lblAgregaroModificar.TabIndex = 5;
            lblAgregaroModificar.Text = "Agregar o Modificar Detalle";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(205, 18);
            label7.Name = "label7";
            label7.Size = new Size(231, 29);
            label7.TabIndex = 4;
            label7.Text = "Detalle Nota Venta";
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
            btnCancelar.IconSize = 20;
            btnCancelar.ImageAlign = ContentAlignment.MiddleRight;
            btnCancelar.Location = new Point(270, 300);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Padding = new Padding(0, 0, 8, 0);
            btnCancelar.Size = new Size(172, 27);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.Black;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Microsoft Sans Serif", 11.25F);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.IconChar = FontAwesome.Sharp.IconChar.Check;
            btnAceptar.IconColor = Color.Lime;
            btnAceptar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAceptar.IconSize = 20;
            btnAceptar.ImageAlign = ContentAlignment.MiddleRight;
            btnAceptar.Location = new Point(68, 300);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Padding = new Padding(0, 0, 8, 0);
            btnAceptar.Size = new Size(172, 27);
            btnAceptar.TabIndex = 17;
            btnAceptar.Text = "Aceptar";
            btnAceptar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscarProducto);
            groupBox1.Controls.Add(numCantidadProducto);
            groupBox1.Controls.Add(txtProductoSeleccionado);
            groupBox1.Controls.Add(txtPrecioUnitario);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(13, 111);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(490, 180);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crear Deatalle Nota de Venta";
            // 
            // btnBuscarProducto
            // 
            btnBuscarProducto.BackColor = Color.Black;
            btnBuscarProducto.FlatStyle = FlatStyle.Flat;
            btnBuscarProducto.Font = new Font("Segoe UI", 9.75F);
            btnBuscarProducto.ForeColor = Color.White;
            btnBuscarProducto.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscarProducto.IconColor = Color.White;
            btnBuscarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscarProducto.IconSize = 20;
            btnBuscarProducto.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscarProducto.Location = new Point(397, 35);
            btnBuscarProducto.Name = "btnBuscarProducto";
            btnBuscarProducto.Size = new Size(80, 33);
            btnBuscarProducto.TabIndex = 17;
            btnBuscarProducto.Text = "Buscar";
            btnBuscarProducto.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscarProducto.UseVisualStyleBackColor = false;
            btnBuscarProducto.Click += btnBuscarProducto_Click;
            // 
            // numCantidadProducto
            // 
            numCantidadProducto.Location = new Point(175, 80);
            numCantidadProducto.Name = "numCantidadProducto";
            numCantidadProducto.Size = new Size(216, 29);
            numCantidadProducto.TabIndex = 15;
            // 
            // txtProductoSeleccionado
            // 
            txtProductoSeleccionado.Location = new Point(175, 37);
            txtProductoSeleccionado.Name = "txtProductoSeleccionado";
            txtProductoSeleccionado.Size = new Size(216, 29);
            txtProductoSeleccionado.TabIndex = 14;
            // 
            // txtPrecioUnitario
            // 
            txtPrecioUnitario.Location = new Point(175, 123);
            txtPrecioUnitario.Name = "txtPrecioUnitario";
            txtPrecioUnitario.Size = new Size(216, 29);
            txtPrecioUnitario.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F);
            label9.Location = new Point(19, 127);
            label9.Name = "label9";
            label9.Size = new Size(110, 20);
            label9.TabIndex = 12;
            label9.Text = "Precio Unitario:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(19, 83);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 3;
            label4.Text = "Cantidad:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(19, 41);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Producto:";
            // 
            // formDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(85, 104, 124);
            ClientSize = new Size(516, 344);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formDetalleVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formBuscarVenta";
            Load += formDetalleVenta_Load;
            MouseDown += formDetalleVenta_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidadProducto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label lblAgregaroModificar;
        private Label label7;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnAceptar;
        private GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnBuscarProducto;
        private NumericUpDown numCantidadProducto;
        private TextBox txtProductoSeleccionado;
        private TextBox txtPrecioUnitario;
        private Label label9;
        private Label label4;
        private Label label1;
    }
}
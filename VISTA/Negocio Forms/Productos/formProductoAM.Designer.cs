namespace VISTA.Negocio_Forms.Proveedores
{
    partial class formProductoAM
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
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            lblAgregaroModificar = new Label();
            label7 = new Label();
            groupBox1 = new GroupBox();
            txtPrecio = new TextBox();
            label3 = new Label();
            txtCodigoProducto = new TextBox();
            txtDescripcionProducto = new TextBox();
            label9 = new Label();
            txtCategoriaProducto = new TextBox();
            txtNombreProducto = new TextBox();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnAceptar = new FontAwesome.Sharp.IconButton();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(45, 64, 84);
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 101);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(lblAgregaroModificar);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(0, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(465, 104);
            panel1.TabIndex = 4;
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Font = new Font("Microsoft Sans Serif", 12F);
            lblAgregaroModificar.ForeColor = Color.White;
            lblAgregaroModificar.Location = new Point(183, 55);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(223, 20);
            lblAgregaroModificar.TabIndex = 5;
            lblAgregaroModificar.Text = "Agregar o Modificar Productos";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(168, 12);
            label7.Name = "label7";
            label7.Size = new Size(270, 29);
            label7.TabIndex = 4;
            label7.Text = "Administrar Productos";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPrecio);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCodigoProducto);
            groupBox1.Controls.Add(txtDescripcionProducto);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtCategoriaProducto);
            groupBox1.Controls.Add(txtNombreProducto);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(39, 116);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(387, 255);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crear Producto";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(141, 121);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(214, 29);
            txtPrecio.TabIndex = 16;
            txtPrecio.Enter += txtPrecio_Enter;
            txtPrecio.KeyPress += txtPrecio_KeyPress;
            txtPrecio.Leave += txtPrecio_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(11, 122);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 15;
            label3.Text = "Precio:";
            // 
            // txtCodigoProducto
            // 
            txtCodigoProducto.Location = new Point(141, 36);
            txtCodigoProducto.Name = "txtCodigoProducto";
            txtCodigoProducto.Size = new Size(214, 29);
            txtCodigoProducto.TabIndex = 14;
            txtCodigoProducto.Enter += txtCodigoProducto_Enter;
            txtCodigoProducto.KeyPress += txtCodigoProducto_KeyPress;
            txtCodigoProducto.Leave += txtCodigoProducto_Leave;
            // 
            // txtDescripcionProducto
            // 
            txtDescripcionProducto.Location = new Point(141, 208);
            txtDescripcionProducto.Name = "txtDescripcionProducto";
            txtDescripcionProducto.Size = new Size(214, 29);
            txtDescripcionProducto.TabIndex = 13;
            txtDescripcionProducto.Enter += txtDescripcionProducto_Enter;
            txtDescripcionProducto.KeyPress += txtDescripcionProducto_KeyPress;
            txtDescripcionProducto.Leave += txtDescripcionProducto_Leave;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F);
            label9.Location = new Point(11, 209);
            label9.Name = "label9";
            label9.Size = new Size(90, 20);
            label9.TabIndex = 12;
            label9.Text = "Descripción:";
            // 
            // txtCategoriaProducto
            // 
            txtCategoriaProducto.Location = new Point(141, 165);
            txtCategoriaProducto.Name = "txtCategoriaProducto";
            txtCategoriaProducto.Size = new Size(214, 29);
            txtCategoriaProducto.TabIndex = 9;
            txtCategoriaProducto.Enter += txtCategoriaProducto_Enter;
            txtCategoriaProducto.KeyPress += txtCategoriaProducto_KeyPress;
            txtCategoriaProducto.Leave += txtCategoriaProducto_Leave;
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(141, 75);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(214, 29);
            txtNombreProducto.TabIndex = 7;
            txtNombreProducto.Enter += txtNombreProducto_Enter;
            txtNombreProducto.KeyPress += txtNombreProducto_KeyPress;
            txtNombreProducto.Leave += txtNombreProducto_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(11, 166);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 3;
            label4.Text = "Categoría:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(11, 76);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(11, 37);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 0;
            label1.Text = "Código Producto:";
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
            btnAceptar.Location = new Point(46, 377);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Padding = new Padding(0, 0, 8, 0);
            btnAceptar.Size = new Size(172, 27);
            btnAceptar.TabIndex = 16;
            btnAceptar.Text = "Aceptar";
            btnAceptar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
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
            btnCancelar.Location = new Point(248, 377);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Padding = new Padding(0, 0, 8, 0);
            btnCancelar.Size = new Size(172, 27);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // formProductoAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(85, 104, 124);
            ClientSize = new Size(464, 430);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formProductoAM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formProductoAM";
            Load += formProductoAM_Load;
            MouseDown += formProductoAM_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Label lblAgregaroModificar;
        private Label label7;
        private GroupBox groupBox1;
        private TextBox txtDescripcionProducto;
        private Label label9;
        private TextBox txtCategoriaProducto;
        private TextBox txtNombreProducto;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox txtCodigoProducto;
        private FontAwesome.Sharp.IconButton btnAceptar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private TextBox txtPrecio;
        private Label label3;
    }
}
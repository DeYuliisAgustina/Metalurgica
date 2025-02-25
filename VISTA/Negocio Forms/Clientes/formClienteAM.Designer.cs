namespace VISTA.Negocio_Forms
{
    partial class formClienteAM
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
            label7 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            txtRazonSocial = new TextBox();
            label9 = new Label();
            txtTelefono = new TextBox();
            txtDNI = new TextBox();
            txtEmail = new TextBox();
            label3 = new Label();
            txtDireccion = new TextBox();
            txtNombreApellido = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnAceptar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(lblAgregaroModificar);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(727, 104);
            panel1.TabIndex = 0;
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Font = new Font("Microsoft Sans Serif", 12F);
            lblAgregaroModificar.ForeColor = Color.White;
            lblAgregaroModificar.Location = new Point(326, 53);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(208, 20);
            lblAgregaroModificar.TabIndex = 5;
            lblAgregaroModificar.Text = "Agregar o Modificar Clientes";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(306, 15);
            label7.Name = "label7";
            label7.Size = new Size(248, 29);
            label7.TabIndex = 4;
            label7.Text = "Administrar Clientes";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(45, 64, 84);
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
            groupBox1.Controls.Add(txtRazonSocial);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(txtDNI);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(txtNombreApellido);
            groupBox1.Controls.Add(dtpFechaNacimiento);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(47, 118);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(522, 285);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crear Cliente:";
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(18, 51);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(308, 27);
            txtRazonSocial.TabIndex = 13;
            txtRazonSocial.Enter += txtRazonSocial_Enter;
            txtRazonSocial.KeyPress += txtRazonSocial_KeyPress;
            txtRazonSocial.Leave += txtRazonSocial_Leave;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F);
            label9.Location = new Point(18, 31);
            label9.Name = "label9";
            label9.Size = new Size(85, 17);
            label9.TabIndex = 12;
            label9.Text = "Razón Social:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(289, 177);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(214, 27);
            txtTelefono.TabIndex = 11;
            txtTelefono.Enter += txtTelefono_Enter;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            txtTelefono.Leave += txtTelefono_Leave;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(289, 115);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(214, 27);
            txtDNI.TabIndex = 10;
            txtDNI.Enter += txtDNI_Enter;
            txtDNI.KeyPress += txtDNI_KeyPress;
            txtDNI.Leave += txtDNI_Leave;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(18, 241);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(214, 27);
            txtEmail.TabIndex = 9;
            txtEmail.Enter += txtEmail_Enter;
            txtEmail.KeyPress += txtEmail_KeyPress;
            txtEmail.Leave += txtEmail_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(289, 95);
            label3.Name = "label3";
            label3.Size = new Size(104, 17);
            label3.TabIndex = 2;
            label3.Text = "Número de DNI:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(289, 241);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(214, 27);
            txtDireccion.TabIndex = 8;
            txtDireccion.Enter += txtDireccion_Enter;
            txtDireccion.KeyPress += txtDireccion_KeyPress;
            txtDireccion.Leave += txtDireccion_Leave;
            // 
            // txtNombreApellido
            // 
            txtNombreApellido.BorderStyle = BorderStyle.FixedSingle;
            txtNombreApellido.Location = new Point(18, 178);
            txtNombreApellido.Name = "txtNombreApellido";
            txtNombreApellido.Size = new Size(214, 27);
            txtNombreApellido.TabIndex = 7;
            txtNombreApellido.Enter += txtNombreApellido_Enter;
            txtNombreApellido.KeyPress += txtNombreApellido_KeyPress;
            txtNombreApellido.Leave += txtNombreApellido_Leave;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(18, 112);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(214, 27);
            dtpFechaNacimiento.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F);
            label6.Location = new Point(289, 221);
            label6.Name = "label6";
            label6.Size = new Size(65, 17);
            label6.TabIndex = 5;
            label6.Text = "Dirección:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(289, 157);
            label5.Name = "label5";
            label5.Size = new Size(61, 17);
            label5.TabIndex = 4;
            label5.Text = "Teléfono:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(18, 221);
            label4.Name = "label4";
            label4.Size = new Size(120, 17);
            label4.TabIndex = 3;
            label4.Text = "Correo Electrónico:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(18, 158);
            label2.Name = "label2";
            label2.Size = new Size(122, 17);
            label2.TabIndex = 1;
            label2.Text = "Nombre y Apellido:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(18, 92);
            label1.Name = "label1";
            label1.Size = new Size(133, 17);
            label1.TabIndex = 0;
            label1.Text = "Fecha de Nacimiento:";
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
            btnCancelar.Location = new Point(326, 421);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Padding = new Padding(0, 0, 8, 0);
            btnCancelar.Size = new Size(172, 34);
            btnCancelar.TabIndex = 17;
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
            btnAceptar.Location = new Point(107, 421);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Padding = new Padding(0, 0, 8, 0);
            btnAceptar.Size = new Size(172, 34);
            btnAceptar.TabIndex = 16;
            btnAceptar.Text = "Aceptar";
            btnAceptar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // formClienteAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(85, 104, 124);
            ClientSize = new Size(609, 475);
            Controls.Add(btnCancelar);
            Controls.Add(groupBox1);
            Controls.Add(btnAceptar);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formClienteAM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formClienteAM";
            Load += formClienteAM_Load;
            MouseDown += formClienteAM_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private DateTimePicker dtpFechaNacimiento;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtTelefono;
        private TextBox txtDNI;
        private TextBox txtEmail;
        private TextBox txtDireccion;
        private TextBox txtNombreApellido;
        private Label lblAgregaroModificar;
        private Label label7;
        private TextBox txtRazonSocial;
        private Label label9;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnAceptar;
    }
}
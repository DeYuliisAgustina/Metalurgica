namespace VISTA
{
    partial class formCambiarClave
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
            label3 = new Label();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            txtClaveActual = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtClaveNueva = new TextBox();
            label5 = new Label();
            txtConfirmarClave = new TextBox();
            btnAceptar = new Button();
            btnCerrar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 64, 84);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(296, 366);
            panel1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Magneto", 21.75F, FontStyle.Bold);
            label3.Location = new Point(30, 280);
            label3.Name = "label3";
            label3.Size = new Size(229, 35);
            label3.TabIndex = 47;
            label3.Text = "Métallon s.r.l";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(45, 64, 84);
            pictureBox1.Image = Properties.Resources.MetallonIcon;
            pictureBox1.Location = new Point(30, 58);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(233, 205);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F);
            label4.Location = new Point(357, 76);
            label4.Name = "label4";
            label4.Size = new Size(172, 18);
            label4.TabIndex = 46;
            label4.Text = "Ingrese su Clave actual:";
            // 
            // txtClaveActual
            // 
            txtClaveActual.Location = new Point(357, 97);
            txtClaveActual.Name = "txtClaveActual";
            txtClaveActual.Size = new Size(248, 23);
            txtClaveActual.TabIndex = 45;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(348, 18);
            label1.Name = "label1";
            label1.Size = new Size(246, 29);
            label1.TabIndex = 47;
            label1.Text = "Cambiar Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F);
            label2.Location = new Point(357, 149);
            label2.Name = "label2";
            label2.Size = new Size(175, 18);
            label2.TabIndex = 49;
            label2.Text = "Ingrese su Clave Nueva:";
            // 
            // txtClaveNueva
            // 
            txtClaveNueva.Location = new Point(357, 170);
            txtClaveNueva.Name = "txtClaveNueva";
            txtClaveNueva.Size = new Size(248, 23);
            txtClaveNueva.TabIndex = 46;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F);
            label5.Location = new Point(354, 227);
            label5.Name = "label5";
            label5.Size = new Size(125, 18);
            label5.TabIndex = 51;
            label5.Text = "Confirmar Clave:";
            // 
            // txtConfirmarClave
            // 
            txtConfirmarClave.Location = new Point(354, 248);
            txtConfirmarClave.Name = "txtConfirmarClave";
            txtConfirmarClave.Size = new Size(248, 23);
            txtConfirmarClave.TabIndex = 47;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(45, 64, 84);
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Arial", 12F);
            btnAceptar.ForeColor = SystemColors.Window;
            btnAceptar.Location = new Point(329, 309);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(322, 39);
            btnAceptar.TabIndex = 48;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCerrar.IconColor = Color.Black;
            btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCerrar.IconSize = 25;
            btnCerrar.Location = new Point(656, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 27);
            btnCerrar.TabIndex = 52;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // formCambiarClave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 362);
            Controls.Add(btnCerrar);
            Controls.Add(btnAceptar);
            Controls.Add(label5);
            Controls.Add(txtConfirmarClave);
            Controls.Add(label2);
            Controls.Add(txtClaveNueva);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(txtClaveActual);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formCambiarClave";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "s";
            MouseDown += formCambiarClave_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label4;
        private TextBox txtClaveActual;
        private Label label1;
        private Label label2;
        private TextBox txtClaveNueva;
        private Label label5;
        private TextBox txtConfirmarClave;
        private Button btnAceptar;
        private FontAwesome.Sharp.IconButton btnCerrar;
    }
}
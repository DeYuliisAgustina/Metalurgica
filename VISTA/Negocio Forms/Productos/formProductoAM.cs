using Controladora;
using Entidades;
using System.Runtime.InteropServices;

namespace VISTA.Negocio_Forms.Proveedores
{
    public partial class formProductoAM : Form
    {
        #region Atributos privados
        private Producto producto;
        private bool modificar = false;
        #endregion

        #region Constructor
        public formProductoAM()
        {
            InitializeComponent();
            producto = new Producto();
        }
        #endregion

        #region mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formProductoAM_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Constructor Modificar
        public formProductoAM(Producto productoModificar)
        {
            InitializeComponent();
            producto = productoModificar;
            modificar = true;
        }
        #endregion

        #region FormLoad
        private void formProductoAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Producto";

                txtCodigoProducto.Text = producto.Codigo.ToString();
                txtNombreProducto.Text = producto.Nombre.ToString();
                txtPrecio.Text = producto.Precio.ToString();
                txtCategoriaProducto.Text = producto.Categoria.ToString();
                txtDescripcionProducto.Text = producto.Descripcion.ToString();

            }
            else
            {
                lblAgregaroModificar.Text = "Agregar Producto";
            }
        }
        #endregion

        #region btnAceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar el producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        #region Validar si ya existe un producto con el mismo nombre y código
                        if (ControladoraProducto.Instancia.RecuperarProductos().Any(c => c.Nombre.ToLower() == txtNombreProducto.Text.ToLower() && producto.Nombre.ToLower() != txtNombreProducto.Text.ToLower() || c.Codigo.ToLower() == txtCodigoProducto.Text.ToLower() && producto.Codigo.ToLower() != txtCodigoProducto.Text.ToLower()))
                        {
                            MessageBox.Show("Ya existe un producto con ese nombre y código.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        #endregion
                        producto.Codigo = txtCodigoProducto.Text;
                        producto.Nombre = txtNombreProducto.Text;
                        producto.Precio = Convert.ToDecimal(txtPrecio.Text);
                        producto.Categoria = txtCategoriaProducto.Text;
                        producto.Descripcion = txtDescripcionProducto.Text;
                        producto.Stock = 0;


                        var mensaje = ControladoraProducto.Instancia.ModificarProducto(producto);

                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    producto.Codigo = txtCodigoProducto.Text;
                    producto.Nombre = txtNombreProducto.Text;
                    #region Validar si ya existe un producto con el mismo nombre y código
                    if (ControladoraProducto.Instancia.RecuperarProductos().Any(c => c.Nombre.ToLower() == txtNombreProducto.Text.ToLower() && producto.Nombre.ToLower() != txtNombreProducto.Text.ToLower() || c.Codigo.ToLower() == txtCodigoProducto.Text.ToLower() && producto.Codigo.ToLower() != txtCodigoProducto.Text.ToLower()))
                    {
                        MessageBox.Show("Ya existe un producto con ese nombre y código.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    #endregion
                    producto.Precio = Convert.ToDecimal(txtPrecio.Text);
                    producto.Categoria = txtCategoriaProducto.Text;
                    producto.Descripcion = txtDescripcionProducto.Text;
                    producto.Stock = 0;
                    producto.Activo = true;



                    var mensaje = ControladoraProducto.Instancia.AgregarProducto(producto);

                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }
        #endregion

        #region btnCerrar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cancelar la carga de datos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region Validaciones
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtCodigoProducto.Text) || txtCodigoProducto.Text == "Ingrese un codigo de producto...")
            {
                MessageBox.Show("El código del producto no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcionProducto.Text) || txtDescripcionProducto.Text == "Ingrese una descripción")
            {
                MessageBox.Show("La descripción del producto no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtCategoriaProducto.Text) || txtCategoriaProducto.Text == "Ingrese una categoria")
            {
                MessageBox.Show("La categoría del producto no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        static public KeyPressEventArgs KeyPressSoloLetras(KeyPressEventArgs e, string TEXTO)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e;
        }

        static public KeyPressEventArgs KeyPressSoloNumeros(KeyPressEventArgs e, string TEXTO)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) // Permite teclas como Backspace
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e;
        }

        private void txtCodigoProducto_Enter(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text == "")
            {
                txtCodigoProducto.Text = "Ingrese un codigo de producto...";
                txtCodigoProducto.ForeColor = Color.Black;
            }
        }

        private void txtCodigoProducto_Leave(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text == "")
            {
                txtCodigoProducto.Text = "Ingrese un codigo de producto...";
                txtCodigoProducto.ForeColor = Color.Silver;
            }
        }

        private void txtNombreProducto_Enter(object sender, EventArgs e)
        {
            if (txtNombreProducto.Text == "")
            {
                txtNombreProducto.Text = "Ingrese un nombre de producto...";
                txtNombreProducto.ForeColor = Color.Black;
            }

        }

        private void txtNombreProducto_Leave(object sender, EventArgs e)
        {
            if (txtNombreProducto.Text == "")
            {
                txtNombreProducto.Text = "Ingrese un nombre de producto...";
                txtNombreProducto.ForeColor = Color.Silver;
            }
        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "")
            {
                txtPrecio.Text = "Ingrese un precio...";
                txtPrecio.ForeColor = Color.Black;
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "")
            {
                txtPrecio.Text = "Ingrese un precio...";
                txtPrecio.ForeColor = Color.Silver;
            }
        }

        private void txtCategoriaProducto_Enter(object sender, EventArgs e)
        {
            if (txtCategoriaProducto.Text == "")
            {
                txtCategoriaProducto.Text = "Ingrese una categoria";
                txtCategoriaProducto.ForeColor = Color.Black;
            }
        }

        private void txtCategoriaProducto_Leave(object sender, EventArgs e)
        {
            if (txtCategoriaProducto.Text == "")
            {
                txtCategoriaProducto.Text = "Ingrese una categoria";
                txtCategoriaProducto.ForeColor = Color.Silver;
            }
        }

        private void txtDescripcionProducto_Enter(object sender, EventArgs e)
        {
            if (txtDescripcionProducto.Text == "")
            {
                txtDescripcionProducto.Text = "Ingrese una descripción";
                txtDescripcionProducto.ForeColor = Color.Black;
            }
        }

        private void txtDescripcionProducto_Leave(object sender, EventArgs e)
        {
            if (txtDescripcionProducto.Text == "")
            {
                txtDescripcionProducto.Text = "Ingrese una descripción";
                txtDescripcionProducto.ForeColor = Color.Silver;
            }
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtCodigoProducto.Text).Handled)
            {
                MessageBox.Show("Solo se permiten letras y números, no caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtNombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtNombreProducto.Text).Handled)
            {
                MessageBox.Show("Solo se permiten letras y números, no caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloNumeros(e, txtPrecio.Text).Handled)
            {
                MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtCategoriaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtCategoriaProducto.Text).Handled)
            {
                MessageBox.Show("Solo se permiten letras y números, no caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescripcionProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtDescripcionProducto.Text).Handled)
            {
                MessageBox.Show("Solo se permiten letras y números, no caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}

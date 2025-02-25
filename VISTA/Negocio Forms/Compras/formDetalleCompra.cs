using Controladora;
using Entidades;
using System.Runtime.InteropServices;

namespace VISTA.Negocio_Forms.Compras
{
    public partial class formDetalleCompra : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formDetalleNotaCompra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private DetalleNotaCompra detalleCompra;
        private NotaCompra notaCompraActual; //se agrega para poder recuperar la nota de compra actual en el caso de que se quiera modificar un detalle de compra
        private bool modificar = false;

        private Producto productoSeleccionado;

        public formDetalleCompra(NotaCompra notaCompra)
        {
            InitializeComponent();
            detalleCompra = new DetalleNotaCompra();
            productoSeleccionado = new Producto();
            notaCompraActual = notaCompra; //se agrega para poder recuperar la nota de compra actual en el caso de que se quiera modificar un detalle de compra
        }

        public formDetalleCompra(DetalleNotaCompra DetalleNotaCompraModificar)
        {
            InitializeComponent();
            detalleCompra = DetalleNotaCompraModificar;
            modificar = true;
            productoSeleccionado = new Producto();
            notaCompraActual = detalleCompra.NotaCompra; //se agrega para poder recuperar la nota de compra actual en el caso de que se quiera modificar un detalle de compra
        }

        private void formDetalleNotaCompra_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Detalle Compra";

                productoSeleccionado = detalleCompra.Producto;
                txtProductoSeleccionado.Text = detalleCompra.Producto.Nombre.ToString();
                txtPrecioUnitario.Text = detalleCompra.PrecioUnitario.ToString();
                numCantidadProducto.Value = detalleCompra.Cantidad;

                txtPrecioUnitario.Enabled = false;
                txtPrecioUnitario.ReadOnly = true;
            }
            else
            {
                lblAgregaroModificar.Text = "Agregar Producto";
                txtPrecioUnitario.Enabled = false;
                txtPrecioUnitario.ReadOnly = true;
            }


        }

        #region Metodo seleccionar producto
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var formProducto = new formProductoDGV(true))
            {
                if (formProducto.ShowDialog() == DialogResult.OK)
                {
                    productoSeleccionado = formProducto.ObtenerProductoSeleccionado();
                    if (productoSeleccionado != null)
                    {
                        txtProductoSeleccionado.Text = productoSeleccionado.Nombre;
                        txtPrecioUnitario.Text = productoSeleccionado.Precio.ToString();
                    }
                }
            }
        }
        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar el detalle de compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        detalleCompra.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                        detalleCompra.Subtotal = detalleCompra.Cantidad * detalleCompra.PrecioUnitario;
                        detalleCompra.Cantidad = (int)numCantidadProducto.Value;
                        detalleCompra.Producto = ControladoraDetalleNotaVenta.Instancia.RecuperarProductos().FirstOrDefault(p => p.ProductoId == productoSeleccionado.ProductoId);
                        detalleCompra.NotaCompra = ControladoraDetalleNotaCompra.Instancia.RecuperarNotasCompra().FirstOrDefault(n => n.NroNotaCompra == detalleCompra.NotaCompra.NroNotaCompra);

                        var mensaje = ControladoraDetalleNotaCompra.Instancia.ModificarDetalleNotaCompra(detalleCompra);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    detalleCompra.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                    detalleCompra.Subtotal = detalleCompra.Cantidad * detalleCompra.PrecioUnitario;
                    detalleCompra.Cantidad = (int)numCantidadProducto.Value;
                    detalleCompra.Producto = ControladoraDetalleNotaVenta.Instancia.RecuperarProductos().FirstOrDefault(p => p.ProductoId == productoSeleccionado.ProductoId);
                    detalleCompra.NotaCompra = ControladoraDetalleNotaCompra.Instancia.RecuperarNotasCompra().FirstOrDefault(n => n.NroNotaCompra == notaCompraActual.NroNotaCompra);


                    var mensaje = ControladoraDetalleNotaCompra.Instancia.AgregarDetalleNotaCompra(detalleCompra);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cancelar la carga de datos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #region Validaciones
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtProductoSeleccionado.Text) || txtProductoSeleccionado.Text == "Debe seleccionar un producto en el ProductoDGV...")
            {
                MessageBox.Show("El campo productos no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (numCantidadProducto.Value == 0 || numCantidadProducto.Value < 0) //valido que la capacidad máxima de computadoras sea mayor a 0
            {
                MessageBox.Show("Debe ingresar un número de cantidad máxima mayor a 0 de productos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtPrecioUnitario.Text))
            {
                MessageBox.Show("El campo precio unitario no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (numCantidadProducto.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!decimal.TryParse(txtPrecioUnitario.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio unitario debe ser un número válido mayor a 0.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion
    }
}

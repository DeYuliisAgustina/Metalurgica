using Controladora;
using Entidades;
using System.Runtime.InteropServices;

namespace VISTA.Negocio_Forms.Ventas
{
    public partial class formDetalleVenta : Form
    {

        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formDetalleVenta_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Atributos privados
        private DetalleNotaVenta detalleVenta;
        private NotaVenta notaVentaActual;

        private bool modificar = false;
        private Producto productoSeleccionado;
        #endregion

        #region Selección de Producto
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

        #region Constructor 
        public formDetalleVenta(NotaVenta notaVenta)
        {
            InitializeComponent();
            detalleVenta = new DetalleNotaVenta();
            productoSeleccionado = new Producto();
            notaVentaActual = notaVenta;

        }
        #endregion

        #region Constructor Modificar
        public formDetalleVenta(DetalleNotaVenta detalleModificar)
        {
            InitializeComponent();
            detalleVenta = detalleModificar;
            modificar = true;
            productoSeleccionado = new Producto();
            notaVentaActual = detalleModificar.NotaVenta;
        }
        #endregion

        #region FormLoad
        private void formDetalleVenta_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Producto";
                productoSeleccionado = detalleVenta.Producto;
                txtProductoSeleccionado.Text = detalleVenta.Producto.Nombre.ToString();
                txtPrecioUnitario.Text = detalleVenta.PrecioUnitario.ToString();
                numCantidadProducto.Value = detalleVenta.Cantidad;

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
        #endregion

        #region Botones aceptar y cancelar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar el detalle de compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        #region Validar Stock
                        int nuevaCantidad = (int)numCantidadProducto.Value;
                        var producto = ControladoraDetalleNotaVenta.Instancia.RecuperarProductos().FirstOrDefault(p => p.ProductoId == productoSeleccionado.ProductoId);

                        // Calcular stock disponible total (stock actual + cantidad original del detalle)
                        int stockDisponibleTotal = producto.Stock + detalleVenta.Cantidad;

                        if (nuevaCantidad > stockDisponibleTotal)
                        {
                            MessageBox.Show($"No hay suficiente stock. Stock disponible total: {stockDisponibleTotal}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        #endregion

                        detalleVenta.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                        detalleVenta.Subtotal = detalleVenta.Cantidad * detalleVenta.PrecioUnitario;
                        detalleVenta.Producto = ControladoraDetalleNotaVenta.Instancia.RecuperarProductos().FirstOrDefault(p => p.ProductoId == productoSeleccionado.ProductoId);
                        detalleVenta.NotaVenta = ControladoraDetalleNotaVenta.Instancia.RecuperarNotasVenta().FirstOrDefault(n => n.NroNotaVenta == detalleVenta.NotaVenta.NroNotaVenta);

                        var mensaje = ControladoraDetalleNotaVenta.Instancia.ModificarDetalleNotaVenta(detalleVenta);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    detalleVenta.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                    detalleVenta.Subtotal = detalleVenta.Cantidad * detalleVenta.PrecioUnitario;
                    detalleVenta.Cantidad = (int)numCantidadProducto.Value;
                    detalleVenta.Producto = ControladoraDetalleNotaVenta.Instancia.RecuperarProductos().FirstOrDefault(p => p.ProductoId == productoSeleccionado.ProductoId);
                    detalleVenta.NotaVenta = ControladoraDetalleNotaVenta.Instancia.RecuperarNotasVenta().FirstOrDefault(n => n.NroNotaVenta == notaVentaActual.NroNotaVenta);

                    var mensaje = ControladoraDetalleNotaVenta.Instancia.AgregarDetalleNotaVenta(detalleVenta);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region recupero el usuario logueado y verifico el stock bajo
                    //recuperar el usuario logueado
                    var usuarioLogueado = ControladoraDetalleNotaVenta.Instancia.RecuperarUsuarioLogueado().FirstOrDefault();

                    if (usuarioLogueado != null) //si el usuario logueado no es nulo, entonces verifico el stock bajo
                    {
                        ControladoraDetalleNotaVenta.Instancia.VerificarStockBajo(usuarioLogueado);
                    }
                    #endregion

                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cancelar la operación?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region Validaciones
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtProductoSeleccionado.Text) || txtProductoSeleccionado.Text == "Debe seleccionar un producto en el ProductoDGV...")
            {
                MessageBox.Show("El campo productos no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un producto.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

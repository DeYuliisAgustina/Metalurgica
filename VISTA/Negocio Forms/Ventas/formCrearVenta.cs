using Controladora;
using Entidades;
using System.Runtime.InteropServices;
using static Entidades.NotaVenta;

namespace VISTA.Negocio_Forms.Ventas
{
    public partial class formCrearVenta : Form
    {
        #region Atributos privados
        private NotaVenta notaVenta;
        private bool modificar = false;
        private bool soloLectura = false;  // Nuevo campo para modo consulta
        #endregion

        #region Constructor
        public formCrearVenta()
        {
            InitializeComponent();
            CargarCmbyTxt();
            notaVenta = new NotaVenta();
            txtNumeroAutogenerado.Clear(); // Aseguramos que empiece vacío
        }
        #endregion

        #region Constructor para modo modificar
        public formCrearVenta(NotaVenta notaVentaModificar)
        {
            InitializeComponent();
            CargarCmbyTxt();
            notaVenta = notaVentaModificar;
            modificar = true;
            ActualizarGrilla();
        }
        #endregion

        #region Constructor para modo solo lectura
        public formCrearVenta(NotaVenta notaVentaConsultar, bool soloLectura) //creo este constructor para el btnConsultar y que los datos sean solo lectura
        {
            InitializeComponent();
            CargarCmbyTxt();
            notaVenta = notaVentaConsultar;
            this.soloLectura = soloLectura;
            ActualizarGrilla();
        }
        #endregion

        #region formCrearVenta_Load
        private void formCrearVenta_Load(object sender, EventArgs e)
        {

            if (soloLectura)
            {
                // Configurar formulario para modo solo lectura
                lblAgregaroModificar.Text = "Consultar Nota de Venta";
                ConfigurarModoSoloLectura();
            }
            else if (modificar)
            {
                // Código existente para modo modificar
                lblAgregaroModificar.Text = "Modificar Nota de Venta";

                #region versión modificada
                btnAgregarDatos.Text = "Modificar";
                btnAgregarDatos.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
                btnAgregarDatos.IconColor = Color.Yellow;
                #endregion

                #region Cargar datos de la nota de venta 
                txtNumeroAutogenerado.Text = notaVenta.NroNotaVenta.ToString();
                dtpFechaRegistro.Value = notaVenta.Fecha;
                cmbNombresClientes.SelectedItem = notaVenta.Cliente.NombreyApellido.ToString();
                txtDNIClienteSeleccionado.Text = notaVenta.Cliente.DNI.ToString();
                cmbMedioPago.SelectedItem = notaVenta.tipoMedioPago.ToString();
                cmbEstadoNotaVenta.SelectedItem = notaVenta.estadosNotaVenta.ToString();
                #endregion

                #region Configurar grilla de detalles
                btnAgregarDetalle.Enabled = true;
                btnModificarDetalle.Enabled = true;

                if (notaVenta.DetallesNotaVenta.Count > 0)
                {
                    btnCrearVenta.Enabled = true;
                }
                #endregion
            }
            else
            {
                lblAgregaroModificar.Text = "Agregar Nota de Venta";

                btnAgregarDetalle.Enabled = false;
                btnModificarDetalle.Enabled = false;
                btnCrearVenta.Enabled = false;

                #region Cargar datos 
                cmbNombresClientes.Items.Add("Seleccione un Cliente...");
                cmbNombresClientes.SelectedItem = "Seleccione un Cliente...";
                cmbMedioPago.Items.Add("Seleccione un medio de pago...");
                cmbMedioPago.SelectedItem = "Seleccione un medio de pago...";
                cmbEstadoNotaVenta.Items.Add("Seleccione un estado...");
                cmbEstadoNotaVenta.SelectedItem = "Seleccione un estado...";
                #endregion
            }
        }
        #endregion

        #region Configuración Modo Solo Lectura
        private void ConfigurarModoSoloLectura()
        {
            lblAgregaroModificar.Text = "Consultar Nota de Venta";

            DeshabilitarControles();
            CargarDatosLecturaNotaVenta();
            ConfigurarGrillaDetalles();
            ConfigurarBotonCerrar();
        }

        private void CargarDatosLecturaNotaVenta()
        {
            dtpFechaRegistro.Value = notaVenta.Fecha;
            cmbNombresClientes.Text = notaVenta.Cliente.NombreyApellido;
            txtDNIClienteSeleccionado.Text = notaVenta.Cliente.DNI.ToString();
            cmbMedioPago.Text = notaVenta.tipoMedioPago.ToString();
            cmbEstadoNotaVenta.Text = notaVenta.estadosNotaVenta.ToString();
        }

        private void DeshabilitarControles()
        {
            txtNumeroAutogenerado.ReadOnly = true;
            dtpFechaRegistro.Enabled = false;
            cmbNombresClientes.Enabled = false;
            txtDNIClienteSeleccionado.ReadOnly = true;
            cmbMedioPago.Enabled = false;
            cmbEstadoNotaVenta.Enabled = false;

            btnAgregarDatos.Enabled = false;
            btnAgregarDetalle.Enabled = false;
            btnModificarDetalle.Enabled = false;
            btnCrearVenta.Visible = false;
        }

        private void ConfigurarGrillaDetalles()
        {
            dgvNotaVenta.DataSource = null;
            dgvNotaVenta.DataSource = notaVenta.DetallesNotaVenta;
            CalcularTotal();
        }

        private void ConfigurarBotonCerrar()
        {
            btnCancelarVenta.Text = "Cancelar";
            btnCancelarVenta.Size = new Size(99, 27);
        }
        #endregion

        #region Cargar ComboBox y TextBox
        private void CargarCmbyTxt()
        {
            foreach (Cliente cliente in ControladoraCliente.Instancia.RecuperarClientes(soloActivos: true))
            {
                cmbNombresClientes.Items.Add(cliente.NombreyApellido.ToString());
            }

            cmbNombresClientes.SelectedIndexChanged += (s, e) =>
            {
                if (cmbNombresClientes.SelectedItem != null)
                {
                    var cliente = ControladoraCliente.Instancia.RecuperarClientes()
                        .FirstOrDefault(c => c.NombreyApellido == cmbNombresClientes.Text);
                    if (cliente != null)
                    {
                        txtDNIClienteSeleccionado.Text = cliente.DNI.ToString();
                    }
                }
            };
            foreach (TipoMedioPago tipoMedioPago in Enum.GetValues(typeof(TipoMedioPago)))
            {
                cmbMedioPago.Items.Add(tipoMedioPago.ToString());
            }
            foreach (EstadoNotaVenta estado in Enum.GetValues(typeof(EstadoNotaVenta)))
            {
                cmbEstadoNotaVenta.Items.Add(estado.ToString());
            }
        }
        #endregion

        #region ActualizarGrilla y CalcularTotal
        private void ActualizarGrilla()
        {
            dgvNotaVenta.DataSource = null;

            if (modificar)
            {
                // Cuando modifico, mostrar solo los detalles de la nota de venta seleccionada
                dgvNotaVenta.DataSource = notaVenta.DetallesNotaVenta.ToList();
            }
            else
            {
                // Cuando agrego, mostrar solo el último detalle creado
                var detalles = ControladoraNotaVenta.Instancia.RecuperarDetallesNotaVenta().Where(d => d.NotaVentaId == notaVenta.NotaVentaId)
                    .OrderByDescending(d => d.DetalleNotaVentaId)
                    .Take(1)
                    .ToList();
                dgvNotaVenta.DataSource = detalles;
            }
            CalcularTotal();
            btnCrearVenta.Enabled = dgvNotaVenta.Rows.Count > 0; //Si hay un detalle de venta en la nota de venta, se habilita el botón de crear venta

        }

        private void CalcularTotal()
        {
            if (notaVenta != null && notaVenta.DetallesNotaVenta != null)
            {
                decimal total = notaVenta.DetallesNotaVenta.Sum(d => d.Subtotal);
                txtTotalPagar.Text = total.ToString("C");
                txtTotalPagar.ForeColor = Color.Green;
            }
            else
            {
                txtTotalPagar.Text = "$ 0.00";
                txtTotalPagar.ForeColor = Color.Green;
            }
        }
        #endregion

        #region Botones Agregar, Modificar, Crear y Cancelar
        private void btnAgregarDatos_Click(object sender, EventArgs e) //se usa para agregar datos principales de la nota de venta sin guardarla en la base de datos
        {
            if (ValidarCamposAgregarDatos())
            {
                if (modificar)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar la nota de venta?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        notaVenta.Fecha = dtpFechaRegistro.Value;
                        notaVenta.Cliente = ControladoraCliente.Instancia.RecuperarClientes().FirstOrDefault(c => c.NombreyApellido == cmbNombresClientes.Text);
                        notaVenta.tipoMedioPago = (TipoMedioPago)Enum.Parse(typeof(TipoMedioPago), cmbMedioPago.SelectedItem.ToString());
                        notaVenta.estadosNotaVenta = (EstadoNotaVenta)Enum.Parse(typeof(EstadoNotaVenta), cmbEstadoNotaVenta.SelectedItem.ToString());
                        notaVenta.NroNotaVenta = int.Parse(txtNumeroAutogenerado.Text);

                        var mensaje = ControladoraNotaVenta.Instancia.ModificarNotaVenta(notaVenta);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
                else
                {
                    notaVenta.Fecha = dtpFechaRegistro.Value;
                    notaVenta.Cliente = ControladoraCliente.Instancia.RecuperarClientes().FirstOrDefault(c => c.NombreyApellido == cmbNombresClientes.Text);
                    notaVenta.tipoMedioPago = (TipoMedioPago)Enum.Parse(typeof(TipoMedioPago), cmbMedioPago.SelectedItem.ToString());
                    notaVenta.estadosNotaVenta = (EstadoNotaVenta)Enum.Parse(typeof(EstadoNotaVenta), cmbEstadoNotaVenta.SelectedItem.ToString());

                    // Solo genera un nuevo número si aún no hay uno asignado
                    if (string.IsNullOrEmpty(txtNumeroAutogenerado.Text))
                    {
                        txtNumeroAutogenerado.Text = ControladoraNotaVenta.Instancia.ObtenerSiguienteNumeroNv().ToString();
                        notaVenta.NroNotaVenta = int.Parse(txtNumeroAutogenerado.Text);
                    }

                    // Deshabilitar el botón después de agregar los datos
                    btnAgregarDatos.Enabled = false;

                    var mensaje = ControladoraNotaVenta.Instancia.AgregarNotaVenta(notaVenta);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnAgregarDetalle.Enabled = true;
                    btnModificarDetalle.Enabled = true;

                    MessageBox.Show("Datos principales cargados. Ahora puede agregar el detalle de venta.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            formDetalleVenta formDetalleVenta = new formDetalleVenta(notaVenta); //le paso la nota de venta para que se pueda asignar el detalle de venta a la misma nota de venta que se esta creando 
            formDetalleVenta.ShowDialog();
            ActualizarGrilla();
        }

        private void btnModificarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvNotaVenta.Rows.Count > 0)
            {
                var detalleSeleccionado = (DetalleNotaVenta)dgvNotaVenta.CurrentRow.DataBoundItem;
                formDetalleVenta formDetalleVenta = new formDetalleVenta(detalleSeleccionado);
                formDetalleVenta.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un detalle de venta para modificarlo.");
            }
            ActualizarGrilla();
        }

        private void btnCrearVenta_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La nota de venta se ha creado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            if (soloLectura)
            {
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea cancelar la operación?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Eliminamos la nota independientemente de si tiene detalles o no
                    if (!modificar) // Solo si no es una modificación
                    {
                        var mensaje = ControladoraNotaVenta.Instancia.CancelarNotaVenta(notaVenta);
                        if (mensaje.Contains("correctamente"))
                        {
                            MessageBox.Show("Se ha cancelado la nota de venta.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(mensaje,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.Close();
                }
            }
        }
        #endregion

        #region Validaciones    
        private bool ValidarCamposAgregarDatos()
        {
            if (dtpFechaRegistro.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de registro no puede ser menor a la fecha actual.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbNombresClientes.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbMedioPago.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un medio de pago.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        #region Eventos Mover ventana
        // Event handler for window movement
        private void formCrearVenta_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        #endregion
    }
}
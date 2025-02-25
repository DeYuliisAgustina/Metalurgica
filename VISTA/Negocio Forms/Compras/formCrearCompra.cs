using Controladora;
using Entidades;
using Entidades.EstadoNotaCompra_State;
using System.Runtime.InteropServices;
using static Entidades.NotaCompra;

namespace VISTA.Negocio_Forms.Compras
{
    public partial class formCrearCompra : Form
    {
        #region Atributos privados
        private NotaCompra notaCompra;
        private bool modificar = false;
        private bool soloLectura = false;  // Nuevo campo para modo consulta
        #endregion

        #region Constructor
        public formCrearCompra()
        {
            InitializeComponent();
            CargarCmbyTxt();
            notaCompra = new NotaCompra();
        }
        #endregion

        #region Constructor para modo modificar
        public formCrearCompra(NotaCompra notaCompraModificar)
        {
            InitializeComponent();
            CargarCmbyTxt();
            notaCompra = notaCompraModificar;
            modificar = true;
            ActualizarGrilla();
        }
        #endregion

        #region Constructor para modo solo lectura
        public formCrearCompra(NotaCompra notaCompraConsultar, bool soloLectura) //creo este constructor para el btnConsultar y que los datos sean solo lectura
        {
            InitializeComponent();
            CargarCmbyTxt();
            notaCompra = notaCompraConsultar;
            this.soloLectura = soloLectura;
            ActualizarGrilla();
        }
        #endregion

        #region formLoad
        private void formCrearCompra_Load(object sender, EventArgs e)
        {
            if (soloLectura)
            {
                // Configurar formulario para modo solo lectura
                lblAgregaroModificar.Text = "Consultar Nota de Compra";
                ConfigurarModoSoloLectura();
            }
            else if (modificar)
            {
                // Código existente para modo modificar
                lblAgregaroModificar.Text = "Modificar Nota de Compra";

                #region form parte de modificar
                btnAgregarDatos.Text = "Modificar";
                btnAgregarDatos.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
                btnAgregarDatos.IconColor = Color.Yellow;
                #endregion

                #region Cargar ComboBox, TextBox y botones
                txtNumeroAutogenerado.Text = notaCompra.NroNotaCompra.ToString();
                dtpFechaRegistro.Value = notaCompra.Fecha;
                cmbNombresProveedores.SelectedItem = notaCompra.Proveedor.NombreyApellido.ToString();
                txtDNIProveedorSeleccionado.Text = notaCompra.Proveedor.DNI.ToString();
                cmbMedioPago.SelectedItem = notaCompra.tipoMedioPago.ToString();
                cmbEstadoNotaCompra.Text = notaCompra.ObtenerEstado();

                btnAgregarDetalle.Enabled = true;
                btnModificarDetalle.Enabled = true;

                if (notaCompra.DetallesNotaCompra.Count > 0)
                {
                    btnCrearCompra.Enabled = true;
                }
                #endregion
            }
            else
            {
                lblAgregaroModificar.Text = "Agregar Nota de Venta";

                btnAgregarDetalle.Enabled = false;
                btnModificarDetalle.Enabled = false;
                btnCrearCompra.Enabled = false;

                #region Cargar ComboBox y TextBox
                cmbNombresProveedores.Items.Add("Seleccione un Cliente...");
                cmbNombresProveedores.SelectedItem = "Seleccione un Cliente...";
                cmbMedioPago.Items.Add("Seleccione un medio de pago...");
                cmbMedioPago.SelectedItem = "Seleccione un medio de pago...";
                cmbEstadoNotaCompra.Items.Add("Seleccione un estado...");
                cmbEstadoNotaCompra.SelectedItem = "Seleccione un estado...";
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
            dtpFechaRegistro.Value = notaCompra.Fecha;
            cmbNombresProveedores.Text = notaCompra.Proveedor.NombreyApellido;
            txtDNIProveedorSeleccionado.Text = notaCompra.Proveedor.DNI.ToString();
            cmbMedioPago.Text = notaCompra.tipoMedioPago.ToString();
            cmbEstadoNotaCompra.Text = notaCompra.ObtenerEstado();
        }

        private void DeshabilitarControles()
        {
            txtNumeroAutogenerado.ReadOnly = true;
            dtpFechaRegistro.Enabled = false;
            cmbNombresProveedores.Enabled = false;
            txtDNIProveedorSeleccionado.ReadOnly = true;
            cmbMedioPago.Enabled = false;
            cmbEstadoNotaCompra.Enabled = false;

            btnAgregarDatos.Enabled = false;
            btnAgregarDetalle.Enabled = false;
            btnModificarDetalle.Enabled = false;
            btnCrearCompra.Visible = false;
        }

        private void ConfigurarGrillaDetalles()
        {
            dgvNotaCompra.DataSource = null;
            dgvNotaCompra.DataSource = notaCompra.DetallesNotaCompra;
            CalcularTotal();
        }

        private void ConfigurarBotonCerrar()
        {
            btnCancelarCompra.Text = "Cancelar";
            btnCancelarCompra.Size = new Size(99, 27);
        }
        #endregion

        #region Cargar ComboBox y TextBox
        private void CargarCmbyTxt()
        {
            foreach (Proveedor proveedor in ControladoraProveedor.Instancia.RecuperarProveedores(soloActivos: true))
            {
                cmbNombresProveedores.Items.Add(proveedor.NombreyApellido.ToString());
            }

            cmbNombresProveedores.SelectedIndexChanged += (s, e) =>
            {
                if (cmbNombresProveedores.SelectedItem != null)
                {
                    var proveedor = ControladoraProveedor.Instancia.RecuperarProveedores()
                        .FirstOrDefault(p => p.NombreyApellido == cmbNombresProveedores.Text);
                    if (proveedor != null)
                    {
                        txtDNIProveedorSeleccionado.Text = proveedor.DNI.ToString();
                    }
                }
            };

            foreach (TipoMedioPagoCompra tipoMedioPago in Enum.GetValues(typeof(TipoMedioPagoCompra)))
            {
                cmbMedioPago.Items.Add(tipoMedioPago.ToString());
            }

            // Cargar estados de nota de compra
            var estados = new List<IEstadoNotaCompra>
            {
                new EstadoPendiente(),
                new EstadoEnProceso(),
                new EstadoPagada(),
                new EstadoAnulada(),
                new EstadoFinalizada()
            };

            foreach (var estado in estados)
            {
                cmbEstadoNotaCompra.Items.Add(estado.ObtenerNombreEstado());
            }

        }
        #endregion

        #region Cambiar Estado de la Nota de Compra State
        private void CmbEstadoNotaCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstadoNotaCompra.SelectedItem == null || notaCompra == null) return;

            string nuevoEstado = cmbEstadoNotaCompra.SelectedItem.ToString();
            string estadoActual = notaCompra.ObtenerEstado();

            // Si el nuevo estado es igual al actual, no hacemos nada
            if (nuevoEstado == estadoActual) return;

            try
            {
                switch (nuevoEstado)
                {
                    case "Pendiente":
                        notaCompra.Pendiente();
                        break;

                    case "En Proceso":
                        notaCompra.Procesar();
                        break;

                    case "Pagada":
                        var resultPagar = MessageBox.Show(
                            "¿Está seguro que desea marcar la nota como pagada? Esto actualizará el stock de los productos.",
                            "Confirmación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (resultPagar == DialogResult.Yes)
                        {
                            var mensajePagar = ControladoraNotaCompra.Instancia.PagarNotaCompra(notaCompra);
                            notaCompra.Pagar(); // Actualizamos el state
                            if (!mensajePagar.Contains("correctamente"))
                            {
                                cmbEstadoNotaCompra.SelectedItem = estadoActual;
                                return;
                            }
                        }
                        else
                        {
                            cmbEstadoNotaCompra.SelectedItem = estadoActual;
                            return;
                        }
                        break;

                    case "Anulada":
                        var resultAnular = MessageBox.Show(
                            "¿Está seguro que desea anular la nota de compra?",
                            "Confirmación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (resultAnular == DialogResult.Yes)
                        {
                            var mensajeAnular = ControladoraNotaCompra.Instancia.AnularNotaCompra(notaCompra);
                            notaCompra.Anular(); // Actualizamos el state
                            if (!mensajeAnular.Contains("correctamente"))
                            {
                                cmbEstadoNotaCompra.SelectedItem = estadoActual;
                                return;
                            }
                        }
                        else
                        {
                            cmbEstadoNotaCompra.SelectedItem = estadoActual;
                            return;
                        }
                        break;

                    case "Finalizada":
                        notaCompra.Finalizar();
                        break;
                }
                ;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEstadoNotaCompra.SelectedItem = estadoActual;
            }
        }
        #endregion

        #region Actualizar Grilla
        private void ActualizarGrilla()
        {
            dgvNotaCompra.DataSource = null;

            if (modificar)
            {
                // Cuando modifico, mostrar solo los detalles de la nota de venta seleccionada
                dgvNotaCompra.DataSource = notaCompra.DetallesNotaCompra.ToList();
            }
            else
            {
                // Cuando agrego, mostrar solo el último detalle creado
                var detalles = ControladoraNotaCompra.Instancia.RecuperarDetallesNotaCompra().Where(d => d.NotaCompraId == notaCompra.NotaCompraId)
                    .OrderByDescending(d => d.DetalleNotaCompraId)
                    .Take(1)
                    .ToList();
                dgvNotaCompra.DataSource = detalles;
            }
            CalcularTotal();
            btnCrearCompra.Enabled = dgvNotaCompra.Rows.Count > 0; //Si hay un detalle de venta en la nota de venta, se habilita el botón de crear venta
        }
        #endregion

        #region Calcular Total para txtTotalPagar
        private void CalcularTotal()
        {
            decimal total = 0;
            if (notaCompra.DetallesNotaCompra != null)
            {
                total = notaCompra.DetallesNotaCompra.Sum(d => d.Subtotal);
            }
            txtTotalPagar.Text = total.ToString("C");
            txtTotalPagar.ForeColor = Color.Green;
        }
        #endregion

        #region btnAgregarDatos
        private void btnAgregarDatos_Click(object sender, EventArgs e)
        {
            if (ValidarCamposAgregarDatos())
            {
                if (modificar)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar la nota de venta?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        txtNumeroAutogenerado.Text = notaCompra.NroNotaCompra.ToString();
                        notaCompra.Fecha = dtpFechaRegistro.Value;
                        notaCompra.Proveedor = ControladoraNotaCompra.Instancia.RecuperarProveedores().FirstOrDefault(p => p.NombreyApellido == cmbNombresProveedores.Text);
                        notaCompra.tipoMedioPago = (TipoMedioPagoCompra)Enum.Parse(typeof(TipoMedioPagoCompra), cmbMedioPago.Text);
                        notaCompra.Estado = cmbEstadoNotaCompra.SelectedText;

                        var mensaje = ControladoraNotaCompra.Instancia.ModificarNotaCompra(notaCompra);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    notaCompra.Fecha = dtpFechaRegistro.Value;
                    notaCompra.Proveedor = ControladoraNotaCompra.Instancia.RecuperarProveedores().FirstOrDefault(p => p.NombreyApellido == cmbNombresProveedores.Text);
                    notaCompra.tipoMedioPago = (TipoMedioPagoCompra)Enum.Parse(typeof(TipoMedioPagoCompra), cmbMedioPago.Text);
                    notaCompra.Estado = cmbEstadoNotaCompra.Text;

                    // Solo genera un nuevo número si aún no hay uno asignado
                    if (string.IsNullOrEmpty(txtNumeroAutogenerado.Text))
                    {
                        txtNumeroAutogenerado.Text = ControladoraNotaCompra.Instancia.ObtenerSiguienteNumeroNc().ToString();
                        notaCompra.NroNotaCompra = int.Parse(txtNumeroAutogenerado.Text);
                    }

                    btnAgregarDatos.Enabled = false;


                    var mensaje = ControladoraNotaCompra.Instancia.AgregarNotaCompra(notaCompra);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnAgregarDetalle.Enabled = true;
                    btnModificarDetalle.Enabled = true;

                    MessageBox.Show("Datos principales cargados. Ahora puede agregar el detalle de venta.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region btnAgregarDetalle, btnModificarDetalle, btnCrearCompra, btnCancelarCompra
        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            formDetalleCompra formDetalleCompra = new formDetalleCompra(notaCompra);
            formDetalleCompra.ShowDialog();
            ActualizarGrilla();
        }

        private void btnModificarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvNotaCompra.Rows.Count > 0)
            {
                var detalleSeleccionado = (DetalleNotaCompra)dgvNotaCompra.CurrentRow.DataBoundItem;
                formDetalleCompra formDetalleCompra = new formDetalleCompra(detalleSeleccionado);
                formDetalleCompra.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un detalle de compra para modificarlo.");
            }
            ActualizarGrilla();
        }

        private void btnCrearCompra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La nota de compra se ha creado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelarCompra_Click(object sender, EventArgs e)
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
                        var mensaje = ControladoraNotaCompra.Instancia.CancelarNotaCompra(notaCompra);
                        if (mensaje.Contains("correctamente"))
                        {
                            MessageBox.Show("Se ha cancelado la nota de compra.",
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
            if (cmbNombresProveedores.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbMedioPago.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un medio de pago.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbEstadoNotaCompra.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estado válido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        #region Mover la ventana
        private void formCrearCompra_MouseDown(object sender, MouseEventArgs e)
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
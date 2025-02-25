using Controladora;
using Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Runtime.InteropServices;

namespace VISTA.Negocio_Forms.Ventas
{
    public partial class formNotasVenta : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formNotasVenta_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Constructor
        public formNotasVenta()
        {
            InitializeComponent();
            ActualizarGrilla();
            CargarFiltros();
        }
        #endregion

        #region Actualizar Grilla
        private void ActualizarGrilla()
        {

            dgvHistorialNotasVenta.DataSource = null;
            dgvHistorialNotasVenta.DataSource =
            dgvHistorialNotasVenta.DataSource = ControladoraNotaVenta.Instancia.RecuperarNotasVenta();
            AplicarFormatoGrilla();
        }
        #endregion

        #region Logica de Busqueda
        private void CargarFiltros()
        {
            cmbBuscarPor.Items.Clear();
            cmbBuscarPor.Items.AddRange(new string[] {
        "Nro. Nota Venta",
        "Nombre y Apellido Cliente",
        "Fecha",
        "Tipo Medio Pago",
        "Estado"
    });
            cmbBuscarPor.SelectedIndex = 0;
        }

        private void RealizarBusqueda()
        {
            if (string.IsNullOrEmpty(cmbBuscarPor.Text))
            {
                MessageBox.Show("Debe seleccionar un filtro de búsqueda", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var notasVenta = ControladoraNotaVenta.Instancia.RecuperarNotasVenta();
            List<NotaVenta> notasVentaFiltradas = new List<NotaVenta>();

            switch (cmbBuscarPor.Text)
            {
                case "Nro. Nota Venta":
                    if (!string.IsNullOrEmpty(txtBuscar.Text) && int.TryParse(txtBuscar.Text, out int nroNotaVenta))
                    {
                        notasVentaFiltradas = notasVenta
                            .Where(nv => nv.NroNotaVenta == nroNotaVenta)
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un número de nota de venta válido", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;

                case "Nombre y Apellido Cliente":
                    if (!string.IsNullOrEmpty(txtBuscar.Text))
                    {
                        notasVentaFiltradas = notasVenta
                            .Where(nv => nv.Cliente.NombreyApellido.ToLower()
                            .Contains(txtBuscar.Text.ToLower()))
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un nombre para buscar", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;

                case "Fecha":
                    if (!string.IsNullOrEmpty(txtBuscar.Text) && DateTime.TryParse(txtBuscar.Text, out DateTime fecha))
                    {
                        notasVentaFiltradas = notasVenta
                            .Where(nv => nv.Fecha.Date == fecha.Date)
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese una fecha válida (dd/mm/yyyy)", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;

                case "Tipo Medio Pago":
                    if (!string.IsNullOrEmpty(txtBuscar.Text))
                    {
                        notasVentaFiltradas = notasVenta
                            .Where(nv => nv.tipoMedioPago.ToString().ToLower()
                            .Contains(txtBuscar.Text.ToLower()))
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un tipo de medio de pago para buscar", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;

                case "Estado":
                    if (!string.IsNullOrEmpty(txtBuscar.Text))
                    {
                        notasVentaFiltradas = notasVenta
                            .Where(nv => nv.estadosNotaVenta.ToString().ToLower()
                            .Contains(txtBuscar.Text.ToLower()))
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un estado para buscar", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
            }

            // Verificar si se encontraron resultados
            if (notasVentaFiltradas.Count == 0)
            {
                string mensaje = cmbBuscarPor.Text switch
                {
                    "Nro. Nota Venta" => $"No se encontraron notas de venta con el número '{txtBuscar.Text}'",
                    "Nombre y Apellido Cliente" => $"No se encontraron notas de venta para el cliente '{txtBuscar.Text}'",
                    "Fecha" => $"No se encontraron notas de venta para la fecha '{txtBuscar.Text}'",
                    "Tipo Medio Pago" => $"No se encontraron notas de venta con el medio de pago '{txtBuscar.Text}'",
                    "Estado" => $"No se encontraron notas de venta en estado '{txtBuscar.Text}'",
                    _ => "No se encontraron resultados"
                };

                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvHistorialNotasVenta.DataSource = null;
            dgvHistorialNotasVenta.DataSource = notasVentaFiltradas;
            AplicarFormatoGrilla();
        }

        private void cmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            switch (cmbBuscarPor.Text)
            {
                case "Fecha":
                    txtBuscar.PlaceholderText = "dd/mm/yyyy";
                    break;
                case "Tipo Medio Pago":
                    txtBuscar.PlaceholderText = "Efectivo/Tarjeta/Transferencia";
                    break;
                case "Estado":
                    txtBuscar.PlaceholderText = "Pendiente/Finalizada/Anulada";
                    break;
                default:
                    txtBuscar.PlaceholderText = "";
                    break;
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cmbBuscarPor.Text)
            {
                case "Nro. Nota Venta":
                    // Solo permitir números y teclas de control
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;

                case "Fecha":
                    // Permitir números, teclas de control y el caracter '/'
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }
        private void btnRefrescarGrilla_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RealizarBusqueda();

        }
        #endregion

        #region Botones load
        private void formNotasVenta_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region Botones ABM
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formCrearVenta formVentasAM = new formCrearVenta();
            formVentasAM.ShowDialog();
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvHistorialNotasVenta.SelectedRows.Count > 0)
            {
                var notaVentaSeleccionada = (NotaVenta)dgvHistorialNotasVenta.CurrentRow.DataBoundItem;

                // Validación para estados no modificables: Anulada o Finalizada
                if (notaVentaSeleccionada.estadosNotaVenta == NotaVenta.EstadoNotaVenta.Anulada ||
                    notaVentaSeleccionada.estadosNotaVenta == NotaVenta.EstadoNotaVenta.Finalizada)
                {
                    MessageBox.Show($"No se puede modificar una nota de venta en estado {notaVentaSeleccionada.estadosNotaVenta}.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                formCrearVenta formVentasAM = new formCrearVenta(notaVentaSeleccionada);
                formVentasAM.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione una Nota de Venta para modificar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAnularVentaBajaLogica_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionNotaVenta())
                return;

            if (MessageBox.Show("¿Está seguro que desea anular esta nota de venta?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var notaVenta = (NotaVenta)dgvHistorialNotasVenta.CurrentRow.DataBoundItem;
            AnularNotaVenta(notaVenta);
        }
        #endregion

        #region Boton Consultar
        private void btnConsultarDatos_Click(object sender, EventArgs e)
        {
            if (dgvHistorialNotasVenta.SelectedRows.Count > 0)
            {
                var notaVentaSeleccionada = (NotaVenta)dgvHistorialNotasVenta.CurrentRow.DataBoundItem;
                formCrearVenta formVentasConsulta = new formCrearVenta(notaVentaSeleccionada, true);
                formVentasConsulta.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una nota de venta para consultar sus detalles.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Logica para Nv Anuladas y Finalizadas
        private void AplicarFormatoGrilla() //metodo para cambiar el color de las filas de las notas de venta anuladas
        {
            // ajusta el tamaño de las columnas al tamaño del datagridview
            dgvHistorialNotasVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorialNotasVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // selecciona toda la fila
            dgvHistorialNotasVenta.ReadOnly = true; // solo lectura 

            foreach (DataGridViewRow row in dgvHistorialNotasVenta.Rows)
            {
                var notaVenta = row.DataBoundItem as NotaVenta; //obtiene la nota de venta de la fila actual

                if (notaVenta != null && notaVenta.estadosNotaVenta == NotaVenta.EstadoNotaVenta.Anulada)
                {
                    // Estilo para notas anuladas - solo cambio de color
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.DarkGray;
                    row.DefaultCellStyle.SelectionBackColor = Color.Gray;
                    row.DefaultCellStyle.SelectionForeColor = Color.LightGray;
                }
                //verifica si la nota de venta esta finalizada para cambiar el color de la fila
                else if (notaVenta.estadosNotaVenta == NotaVenta.EstadoNotaVenta.Finalizada)
                {
                    // Estilo para notas finalizadas
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    row.DefaultCellStyle.SelectionBackColor = Color.MediumSeaGreen;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        private bool ValidarSeleccionNotaVenta()
        {
            if (dgvHistorialNotasVenta.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una nota de venta para anular.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var notaVenta = (NotaVenta)dgvHistorialNotasVenta.CurrentRow.DataBoundItem;
            if (notaVenta.estadosNotaVenta == NotaVenta.EstadoNotaVenta.Anulada)
            {
                MessageBox.Show("Esta nota de venta ya se encuentra anulada.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (notaVenta.estadosNotaVenta == NotaVenta.EstadoNotaVenta.Finalizada)
            {
                MessageBox.Show("No se puede anular una nota de venta finalizada.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void AnularNotaVenta(NotaVenta notaVenta)
        {
            try
            {
                notaVenta.estadosNotaVenta = NotaVenta.EstadoNotaVenta.Anulada;
                var mensaje = ControladoraNotaVenta.Instancia.ModificarNotaVenta(notaVenta);

                // Actualiza la grilla para reflejar el cambio visual
                ActualizarGrilla();

                MessageBox.Show("La nota de venta ha sido anulada exitosamente.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al anular la nota de venta: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Boton Imprimir
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Verificar si hay notas de venta creadas
            if (ControladoraNotaVenta.Instancia.RecuperarNotasVenta().Count == 0)
            {
                MessageBox.Show("No hay notas de venta creadas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "Historial de Notas de Venta" + ".pdf";

            string paginahtml_texto = Properties.Resources.plantillaNotaVenta.ToString(); //Cargo la plantilla HTML en una variable string para reemplazar los valores de los tickets en el PDF que se va a crear

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        {
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                            pdfDoc.Open();

                            var listaNotasVenta = ControladoraNotaVenta.Instancia.RecuperarNotasVenta();

                            foreach (var notaVenta in listaNotasVenta)
                            {
                                var listaDetallesNotaVenta = ControladoraDetalleNotaVenta.Instancia.RecuperarDetallesVenta();
                                // Primero reemplazar los datos de la nota de venta y cliente
                                paginahtml_texto = paginahtml_texto.Replace("@NotaVentaId", notaVenta.NotaVentaId.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@NroNotaVenta", notaVenta.NroNotaVenta.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@Fecha", notaVenta.Fecha.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@tipoMedioPago", notaVenta.tipoMedioPago.ToString());

                                // Datos del cliente
                                paginahtml_texto = paginahtml_texto.Replace("@ClienteId", notaVenta.ClienteId.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@NombreyApellido", notaVenta.Cliente.NombreyApellido.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@DNI", notaVenta.Cliente.DNI.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@RazonSocial", notaVenta.Cliente.RazonSocial.ToString());

                                foreach (var detalle in listaDetallesNotaVenta)
                                {
                                    if (detalle.NotaVentaId == notaVenta.NotaVentaId)
                                    {
                                        paginahtml_texto = paginahtml_texto.Replace("@DetalleNotaVentaId", detalle.DetalleNotaVentaId.ToString());
                                        paginahtml_texto = paginahtml_texto.Replace("@ProductoId", detalle.ProductoId.ToString());
                                        paginahtml_texto = paginahtml_texto.Replace("@Nombre", detalle.Producto.Nombre.ToString());
                                        paginahtml_texto = paginahtml_texto.Replace("@Cantidad", detalle.Cantidad.ToString());
                                        paginahtml_texto = paginahtml_texto.Replace("@PrecioUnitario", detalle.PrecioUnitario.ToString());
                                        paginahtml_texto = paginahtml_texto.Replace("@Subtotal", detalle.Subtotal.ToString());
                                    }
                                }

                                using (StringReader sr = new StringReader(paginahtml_texto))
                                {
                                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                                }

                            }

                            pdfDoc.Close();
                        }
                        stream.Close();
                    }

                    MessageBox.Show("Archivo PDF creado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abrir el archivo PDF creado
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = guardar.FileName,
                        UseShellExecute = true,
                        Verb = "open"
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear el archivo PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Boton Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}

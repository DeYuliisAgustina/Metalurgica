using Controladora;
using Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Runtime.InteropServices;


namespace VISTA.Negocio_Forms.Compras
{
    public partial class formNotasCompra : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formNotasCompra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Constructor
        public formNotasCompra()
        {
            InitializeComponent();
            ActualizarGrilla();
            CargarFiltros();
        }
        #endregion

        #region Actualizar Grilla
        private void ActualizarGrilla()
        {
            dgvHistorialNotasCompra.DataSource = null;
            dgvHistorialNotasCompra.DataSource = ControladoraNotaCompra.Instancia.RecuperarNotasCompra();
            AplicarFormatoGrilla();
        }
        #endregion

        #region Botones agregar, modificar, consultar y anular
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formCrearCompra formCrearCompra = new formCrearCompra();
            formCrearCompra.ShowDialog();
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvHistorialNotasCompra.Rows.Count > 0)
            {
                var notaCompraSeleccionada = (NotaCompra)dgvHistorialNotasCompra.CurrentRow.DataBoundItem;
                formCrearCompra formCrearCompra = new formCrearCompra(notaCompraSeleccionada);
                formCrearCompra.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione una nota de compra para modificarla");
            }
        }

        private void btnConsultarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvHistorialNotasCompra.SelectedRows.Count > 0)
            {
                var notaCompraSeleccionada = (NotaCompra)dgvHistorialNotasCompra.CurrentRow.DataBoundItem;
                formCrearCompra formComprasConsulta = new formCrearCompra(notaCompraSeleccionada, true);
                formComprasConsulta.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una nota de compra para consultar sus detalles.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAnularVentaBajaLogica_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionNotaCompra())
                return;

            if (MessageBox.Show("¿Está seguro que desea anular esta nota de compra?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var notaCompra = (NotaCompra)dgvHistorialNotasCompra.CurrentRow.DataBoundItem;// Obtiene la nota de compra seleccionada
            AnularNotaCompra(notaCompra); // Llama a la lógica para anular la nota de compra
        }
        #endregion

        #region Logica para Nc Anuladas y Finalizadas
        private void AplicarFormatoGrilla()
        {
            // Configuración básica del DataGridView
            dgvHistorialNotasCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorialNotasCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialNotasCompra.ReadOnly = true;

            foreach (DataGridViewRow row in dgvHistorialNotasCompra.Rows)
            {
                var notaCompra = row.DataBoundItem as NotaCompra;
                if (notaCompra != null)
                {
                    if (notaCompra.ObtenerEstado() == "Anulada")
                    {
                        // Estilo para notas anuladas
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        row.DefaultCellStyle.ForeColor = Color.DarkGray;
                        row.DefaultCellStyle.SelectionBackColor = Color.Gray;
                        row.DefaultCellStyle.SelectionForeColor = Color.LightGray;
                    }
                    else if (notaCompra.ObtenerEstado() == "Finalizada")
                    {
                        // Estilo para notas finalizadas
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                        row.DefaultCellStyle.SelectionBackColor = Color.MediumSeaGreen;
                        row.DefaultCellStyle.SelectionForeColor = Color.White;
                    }
                }
            }
        }

        private bool ValidarSeleccionNotaCompra()
        {
            if (dgvHistorialNotasCompra.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una nota de compra para anular.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var notaCompra = (NotaCompra)dgvHistorialNotasCompra.CurrentRow.DataBoundItem;

            if (notaCompra.ObtenerEstado() == "Anulada")
            {
                MessageBox.Show("Esta nota de compra ya se encuentra anulada.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (notaCompra.ObtenerEstado() == "Finalizada")
            {
                MessageBox.Show("No se puede anular una nota de compra finalizada.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void AnularNotaCompra(NotaCompra notaCompra)
        {
            try
            {
                notaCompra.Anular();
                var mensaje = ControladoraNotaCompra.Instancia.ModificarNotaCompra(notaCompra);

                // Actualiza la grilla para reflejar el cambio visual
                ActualizarGrilla();

                MessageBox.Show("La nota de compra ha sido anulada exitosamente.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al anular la nota de compra: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region formLoad 
        private void formNotasCompra_Load(object sender, EventArgs e)
        {
            AplicarFormatoGrilla();
        }
        #endregion

        #region Buscar Nota de Compra
        // Actualizar el método CargarFiltros() para incluir los nuevos filtros
        private void CargarFiltros()
        {
            cmbBuscarPor.Items.Clear();
            cmbBuscarPor.Items.AddRange(new string[] {
        "Nro. Nota Compra",
        "Nombre y Apellido Proveedor",
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

            var notasCompra = ControladoraNotaCompra.Instancia.RecuperarNotasCompra();
            List<NotaCompra> notasCompraFiltradas = new List<NotaCompra>();

            switch (cmbBuscarPor.Text)
            {
                case "Nro. Nota Compra":
                    if (!string.IsNullOrEmpty(txtBuscar.Text) && int.TryParse(txtBuscar.Text, out int nroNotaCompra))
                    {
                        notasCompraFiltradas = notasCompra
                            .Where(nc => nc.NroNotaCompra == nroNotaCompra)
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un número de nota de compra válido", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;

                case "Nombre y Apellido Proveedor":
                    if (!string.IsNullOrEmpty(txtBuscar.Text))
                    {
                        notasCompraFiltradas = notasCompra
                            .Where(nc => nc.Proveedor.NombreyApellido.ToLower()
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
                        notasCompraFiltradas = notasCompra
                            .Where(nc => nc.Fecha.Date == fecha.Date)
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
                        notasCompraFiltradas = notasCompra
                            .Where(nc => nc.tipoMedioPago.ToString().ToLower()
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
                        notasCompraFiltradas = notasCompra
                            .Where(nc => nc.ObtenerEstado().ToLower()
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
            if (notasCompraFiltradas.Count == 0)
            {
                string mensaje = cmbBuscarPor.Text switch
                {
                    "Nro. Nota Compra" => $"No se encontraron notas de compra con el número '{txtBuscar.Text}'",
                    "Nombre y Apellido Proveedor" => $"No se encontraron notas de compra para el proveedor '{txtBuscar.Text}'",
                    "Fecha" => $"No se encontraron notas de compra para la fecha '{txtBuscar.Text}'",
                    "Tipo Medio Pago" => $"No se encontraron notas de compra con el medio de pago '{txtBuscar.Text}'",
                    "Estado" => $"No se encontraron notas de compra en estado '{txtBuscar.Text}'",
                    _ => "No se encontraron resultados"
                };

                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvHistorialNotasCompra.DataSource = null;
            dgvHistorialNotasCompra.DataSource = notasCompraFiltradas;
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
                case "Nro. Nota Compra":
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

        #region Reporte de Notas de Compra
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Verificar si hay notas de venta creadas
            if (ControladoraNotaCompra.Instancia.RecuperarNotasCompra().Count == 0)
            {
                MessageBox.Show("No hay notas de compra creadas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "Nota de Compra" + ".pdf";

            string paginahtml_texto = Properties.Resources.plantillaNotaCompra.ToString(); //Cargo la plantilla HTML en una variable string para reemplazar los valores de los tickets en el PDF que se va a crear

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

                            var listaNotasCompra = ControladoraNotaCompra.Instancia.RecuperarNotasCompra();

                            foreach (var notaCompra in listaNotasCompra)
                            {
                                var listaDetallesNotaCompra = ControladoraDetalleNotaCompra.Instancia.RecuperarDetallesCompra();

                                // Reemplazar los datos de la nota de venta
                                paginahtml_texto = paginahtml_texto.Replace("@NotaCompraId", notaCompra.NotaCompraId.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@NroNotaCompra", notaCompra.NroNotaCompra.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@Fecha", notaCompra.Fecha.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@tipoMedioPago", notaCompra.tipoMedioPago.ToString());

                                paginahtml_texto = paginahtml_texto.Replace("@ProveedorId", notaCompra.ProveedorId.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@NombreyApellido", notaCompra.Proveedor.NombreyApellido.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@DNI", notaCompra.Proveedor.DNI.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@RazonSocial", notaCompra.Proveedor.RazonSocial.ToString());
                                paginahtml_texto = paginahtml_texto.Replace("@CUIT", notaCompra.Proveedor.CUIT.ToString());

                                foreach (var detalle in listaDetallesNotaCompra)
                                {
                                    if (detalle.NotaCompraId == notaCompra.NotaCompraId)
                                    {

                                        paginahtml_texto = paginahtml_texto.Replace("@DetalleNotaCompraId", detalle.DetalleNotaCompraId.ToString());
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

        #region Cerrar Formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }

}

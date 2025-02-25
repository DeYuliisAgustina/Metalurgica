using Controladora;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Text;


namespace VISTA
{
    public partial class formAuditoriaClientes : Form
    {
        #region constructor
        public formAuditoriaClientes()
        {
            InitializeComponent();
            ActualizarGrilla();
        }
        #endregion

        #region ActualizarGrilla
        private void ActualizarGrilla()
        {
            dgvAuditoriaClientes.DataSource = null;
            dgvAuditoriaClientes.DataSource = ControladoraCliente.Instancia.RecuperarAuditorias();
        }
        #endregion

        #region Imprimir
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Verificar si hay auditorías de cliente
            var listaAuditorias = ControladoraCliente.Instancia.RecuperarAuditorias();
            if (listaAuditorias.Count == 0)
            {
                MessageBox.Show("No hay auditorías de cliente para imprimir.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "Reporte_Auditorias_Cliente" + ".pdf";

            string paginahtml_texto = Properties.Resources.plantillaAuditoriaClientes.ToString();

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Construir todas las filas de auditoría
                    StringBuilder filasAuditoria = new StringBuilder();
                    foreach (var auditoria in listaAuditorias)
                    {
                        filasAuditoria.AppendLine("<tr>");
                        filasAuditoria.AppendLine($"<td>{auditoria.AuditoriaClienteId}</td>");
                        filasAuditoria.AppendLine($"<td>{auditoria.Usuario?.NombreUsuario ?? "N/A"}</td>");
                        filasAuditoria.AppendLine($"<td>{auditoria.NombreyApellido}</td>");
                        filasAuditoria.AppendLine($"<td>{auditoria.DNI}</td>");
                        filasAuditoria.AppendLine($"<td>{auditoria.RazonSocial}</td>");
                        filasAuditoria.AppendLine($"<td>{auditoria.FechaAuditoria:dd/MM/yyyy HH:mm:ss}</td>");
                        filasAuditoria.AppendLine($"<td>{auditoria.TipoMovimiento}</td>");
                        filasAuditoria.AppendLine("</tr>");
                    }

                    // Reemplazar los datos en la plantilla
                    paginahtml_texto = paginahtml_texto.Replace("@FechaGeneracion",
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    paginahtml_texto = paginahtml_texto.Replace("@TotalRegistros",
                        listaAuditorias.Count.ToString());

                    // Reemplazar la fila de ejemplo con todas las filas generadas
                    paginahtml_texto = paginahtml_texto.Replace("<tr>\r\n                <td>@AuditoriaClienteId</td>\r\n                <td>@NombreUsuario</td>\r\n                <td>@NombreyApellido</td>\r\n                <td>@DNI</td>\r\n                <td>@RazonSocial</td>\r\n                <td>@FechaAuditoria</td>\r\n                <td>@TipoMovimiento</td>\r\n            </tr>",
                        filasAuditoria.ToString());

                    using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                        pdfDoc.Open();
                        using (StringReader sr = new StringReader(paginahtml_texto))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }
                        pdfDoc.Close();
                    }

                    MessageBox.Show("Archivo PDF creado con éxito.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    MessageBox.Show($"Error al crear el archivo PDF: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

using Controladora;
using iTextSharp.tool.xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Text;

namespace VISTA
{
    public partial class formAuditoriaSesiones : Form
    {
        public formAuditoriaSesiones()
        {
            InitializeComponent();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvAuditoriaSesion.DataSource = null;
            dgvAuditoriaSesion.DataSource = ControladoraSeguridad.Instancia.RecuperarAuditoriasSesion();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Imprimir PDF
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Verificar si hay auditorías de sesión
            var listaAuditorias = ControladoraSeguridad.Instancia.RecuperarAuditoriasSesion();
            if (listaAuditorias.Count == 0)
            {
                MessageBox.Show("No hay auditorías de sesión para imprimir.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "Reporte_Auditorias_Sesion" + ".pdf";

            string paginahtml_texto = Properties.Resources.plantillaAuditoriaSesion.ToString();

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Construir todas las filas de auditoría
                    StringBuilder filasAuditoria = new StringBuilder();
                    foreach (var auditoria in listaAuditorias)
                    {
                        filasAuditoria.AppendLine("<tr>");
                        filasAuditoria.AppendLine($"<td>{auditoria.AuditoriaSesionId}</td>");
                        filasAuditoria.AppendLine($"<td>{auditoria.Usuario?.NombreUsuario ?? "N/A"}</td>");
                        filasAuditoria.AppendLine($"<td>{auditoria.FechaInicio:dd/MM/yyyy HH:mm:ss}</td>");
                        filasAuditoria.AppendLine($"<td>{(auditoria.FechaFin?.ToString("dd/MM/yyyy HH:mm:ss") ?? "Sesión activa")}</td>");
                        filasAuditoria.AppendLine("</tr>");
                    }

                    // Reemplazar los datos en la plantilla
                    paginahtml_texto = paginahtml_texto.Replace("@FechaGeneracion",
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    paginahtml_texto = paginahtml_texto.Replace("@TotalRegistros",
                        listaAuditorias.Count.ToString());

                    // Reemplazar la fila de ejemplo con todas las filas generadas
                    paginahtml_texto = paginahtml_texto.Replace("<tr>\r\n                <td>@AuditoriaId</td>\r\n                <td>@NombreUsuario</td>\r\n                <td>@FechaInicio</td>\r\n                <td>@FechaFin</td>\r\n            </tr>",
                        filasAuditoria.ToString());

                    using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
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
    }
}

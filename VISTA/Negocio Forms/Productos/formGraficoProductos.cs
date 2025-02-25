using Controladora;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.VisualElements;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VISTA
{
    public partial class formGraficoProductos : Form
    {
        #region Constructor
        public formGraficoProductos()
        {
            InitializeComponent();
            CargarGrafico();
        }
        #endregion

        #region Gráfico de torta
        private void CargarGrafico()
        {
            try
            {
                var top5Productos = ControladoraProducto.Instancia.ObtenerTop5ProductosMasVendidos();
                if (!top5Productos.Any()) //si no hay datos para mostrar en el gráfico (lista vacía) 
                {
                    MessageBox.Show("No hay datos de ventas para mostrar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Calcula el total de ventas sumando todas las cantidades vendidas
                double totalVentas = top5Productos.Sum(p => p.TotalVendido);

                // Crear y agregar el Label con el total de productos vendidos
                Label lblTotalProductos = new Label();
                lblTotalProductos.AutoSize = false;
                lblTotalProductos.Width = this.Width; // Ancho igual al formulario
                lblTotalProductos.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
                lblTotalProductos.ForeColor = Color.White;
                lblTotalProductos.TextAlign = ContentAlignment.MiddleCenter;
                lblTotalProductos.Location = new Point(0, 470);
                lblTotalProductos.Text = $"Total de productos vendidos: {totalVentas:N0} unidades"; // texto con el total de productos vendidos
                this.Controls.Add(lblTotalProductos); // Agregar el Label al formulario

                var values = new List<ISeries>(); // Lista de series de datos para el gráfico de torta
                var colores = new[] // Colores para las partes del gráfico 
                        {
                    new SKColor(255, 182, 193), // Rosa claro
                    new SKColor(173, 216, 230), // Azul claro
                    new SKColor(144, 238, 144), // Verde claro
                    new SKColor(221, 160, 221), // Violeta claro
                    new SKColor(255, 218, 185)  // Melocotón
                };

                for (int i = 0; i < top5Productos.Count; i++) // Recorrer los 5 productos más vendidos, i es el índice del producto en la lista top5Productos 
                {
                    double porcentaje = (top5Productos[i].TotalVendido / totalVentas) * 100; // Calcular el porcentaje de ventas del producto actual
                    values.Add(new PieSeries<double> // Agregar una serie de datos al gráfico de torta
                    {
                        Values = new double[] { top5Productos[i].TotalVendido }, // Valores de la serie, un solo valor que es la cantidad vendida del producto actual
                        Name = $"{top5Productos[i].Nombre} ({porcentaje:F1}%)", // Nombre de la serie, el nombre del producto y el porcentaje de ventas
                        Fill = new SolidColorPaint(colores[i]), // Color de la parte del gráfico
                        DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle, // Posición de las etiquetas de datos
                        DataLabelsSize = 14, // Tamaño de las etiquetas de datos
                        DataLabelsPaint = new SolidColorPaint(SKColors.White), // Color de las etiquetas de datos
                        DataLabelsFormatter = point => $"{point.PrimaryValue:N0} ({(point.PrimaryValue / totalVentas * 100):F1}%)" // Formato de las etiquetas de datos
                    });
                }

                pieChartMasVendidos.Series = values; // Asignar las series de datos al gráfico de torta
                pieChartMasVendidos.Title = new LabelVisual // Título del gráfico
                {
                    Text = "Top 5 Productos Más Vendidos",
                    TextSize = 25,
                    Paint = new SolidColorPaint(SKColors.White),
                    Padding = new LiveChartsCore.Drawing.Padding(0, 10)
                };

                pieChartMasVendidos.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right; // Posición de la leyenda,es decir, la lista de colores y nombres de las partes del gráfico
                pieChartMasVendidos.LegendTextPaint = new SolidColorPaint(SKColors.White); // Color del texto de la leyenda
                pieChartMasVendidos.LegendTextSize = 14;
                pieChartMasVendidos.IsClockwise = true;
                pieChartMasVendidos.InitialRotation = -90;

                pieChartMasVendidos.Invalidate(); // Actualizar el gráfico
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el gráfico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region btnCerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}

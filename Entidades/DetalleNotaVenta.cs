namespace Entidades
{
    public class DetalleNotaVenta
    {
        public int DetalleNotaVentaId { get; set; }

        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public int Cantidad { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; } //relacion de uno a muchos con Producto, es decir, un detalle de nota de venta tiene un producto

        public int NotaVentaId { get; set; }
        public NotaVenta NotaVenta { get; set; }

        public override string ToString()
        {
            return Producto.Nombre;
        }
    }
}

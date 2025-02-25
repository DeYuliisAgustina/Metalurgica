namespace Entidades
{
    public class DetalleNotaCompra
    {
        public int DetalleNotaCompraId { get; set; }

        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public int Cantidad { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int NotaCompraId { get; set; }
        public NotaCompra NotaCompra { get; set; }

        public override string ToString()
        {
            return Producto.Nombre;
        }
    }
}

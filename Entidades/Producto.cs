namespace Entidades
{
    public class Producto
    {
        public int ProductoId { get; set; }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }


        public List<DetalleNotaVenta> DetallesNotaVenta { get; set; } = new List<DetalleNotaVenta>();
        public List<DetalleNotaCompra> DetallesNotaCompra { get; set; } = new List<DetalleNotaCompra>();

        public override string ToString()
        {
            return Nombre;
        }
    }
}

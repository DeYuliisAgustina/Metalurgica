namespace Entidades
{
    public class NotaVenta
    {

        public int NotaVentaId { get; set; }

        public int NroNotaVenta { get; set; }

        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public List<DetalleNotaVenta> DetallesNotaVenta { get; set; } = new List<DetalleNotaVenta>(); //relacion de uno a muchos con DetalleNotaVenta, es decir, una nota de venta tiene muchos detalles de nota de venta

        public enum TipoMedioPago { Efectivo, Transferencia }
        public enum EstadoNotaVenta { Pendiente, Procesada, Anulada, Finalizada, Pagada }

        public TipoMedioPago tipoMedioPago { get; set; }
        public EstadoNotaVenta estadosNotaVenta { get; set; }


        public override string ToString()
        {
            return NroNotaVenta.ToString();
        }
    }
}

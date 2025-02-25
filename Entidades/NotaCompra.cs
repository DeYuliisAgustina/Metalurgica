using Entidades.EstadoNotaCompra_State;

namespace Entidades
{
    public class NotaCompra
    {
        public int NotaCompraId { get; set; }

        public int NroNotaCompra { get; set; }

        public DateTime Fecha { get; set; }

        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public List<DetalleNotaCompra> DetallesNotaCompra { get; set; } = new List<DetalleNotaCompra>();

        public enum TipoMedioPagoCompra { Efectivo, Transferencia }
        public TipoMedioPagoCompra tipoMedioPago { get; set; }

        private IEstadoNotaCompra EstadoActual { get; set; }

        public string Estado
        {
            get { return EstadoActual.ObtenerNombreEstado(); }
            set
            {
                switch (value)
                {
                    case "Pendiente":
                        EstadoActual = new EstadoPendiente();
                        break;
                    case "En Proceso":
                        EstadoActual = new EstadoEnProceso();
                        break;
                    case "Pagada":
                        EstadoActual = new EstadoPagada();
                        break;
                    case "Anulada":
                        EstadoActual = new EstadoAnulada();
                        break;
                    case "Finalizada":
                        EstadoActual = new EstadoFinalizada();
                        break;
                }
            }
        }


        public NotaCompra()
        {
            EstadoActual = new EstadoPendiente(); // Inicializar con estado pendiente por defecto
        }

        public string ObtenerEstado()
        {
            return EstadoActual.ObtenerNombreEstado();
        }

        public void CambiarEstado(IEstadoNotaCompra nuevoEstado)
        {
            EstadoActual = nuevoEstado;
        }

        public void Pendiente()
        {
            EstadoActual.Pendiente(this);
        }

        public void Procesar()
        {
            EstadoActual.Procesar(this);
        }

        public void Anular()
        {
            EstadoActual.Anular(this);
        }

        public void Finalizar()
        {
            EstadoActual.Finalizar(this);
        }

        public void Pagar()
        {
            EstadoActual.Pagar(this);
        }

        public override string ToString()
        {
            return NroNotaCompra.ToString();
        }
    }
}
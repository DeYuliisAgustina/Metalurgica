using Entidades.EstadoNotaCompra_State;

namespace Entidades
{
    public class EstadoEnProceso : IEstadoNotaCompra
    {
        public void Pendiente(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("No se puede cambiar a pendiente una nota en proceso");
        }

        public void Procesar(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("La nota ya está en proceso");
        }

        public void Pagar(NotaCompra notaCompra)
        {
            notaCompra.CambiarEstado(new EstadoPagada());
            Console.WriteLine($"Nota de compra #{notaCompra.NroNotaCompra} pagada");

        }

        public void Anular(NotaCompra notaCompra)
        {
            notaCompra.CambiarEstado(new EstadoAnulada());
            Console.WriteLine($"Nota de compra #{notaCompra.NroNotaCompra} anulada");
        }

        public void Finalizar(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("La nota debe estar pagada para finalizar");
        }

        public string ObtenerNombreEstado()
        {
            return "En Proceso";
        }
    }
}

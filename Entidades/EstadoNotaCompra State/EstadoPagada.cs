namespace Entidades.EstadoNotaCompra_State
{
    public class EstadoPagada : IEstadoNotaCompra
    {
        public void Pendiente(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: La nota ya está pagada");
        }

        public void Procesar(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: La nota ya está pagada");
        }

        public void Pagar(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: La nota ya está pagada");
        }

        public void Anular(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: No se puede anular una nota pagada");
        }

        public void Finalizar(NotaCompra notaCompra)
        {
            notaCompra.CambiarEstado(new EstadoFinalizada());
            Console.WriteLine($"Nota de compra #{notaCompra.NroNotaCompra} finalizada");
        }

        public string ObtenerNombreEstado()
        {
            return "Pagada";
        }
    }
}

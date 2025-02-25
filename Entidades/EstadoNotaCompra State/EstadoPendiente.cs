namespace Entidades.EstadoNotaCompra_State
{
    public class EstadoPendiente : IEstadoNotaCompra
    {
        public void Pendiente(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: La nota ya está en estado pendiente");
        }

        public void Procesar(NotaCompra notaCompra)
        {
            notaCompra.CambiarEstado(new EstadoEnProceso());
        }

        public void Pagar(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("La nota debe estar en proceso para ser pagada");
        }

        public void Anular(NotaCompra notaCompra)
        {
            notaCompra.CambiarEstado(new EstadoAnulada());

        }

        public void Finalizar(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("La nota debe estar pagada para finalizar");
        }

        public string ObtenerNombreEstado()
        {
            return "Pendiente";
        }

    }

}

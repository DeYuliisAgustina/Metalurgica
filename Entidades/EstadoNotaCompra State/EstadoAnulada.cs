namespace Entidades.EstadoNotaCompra_State
{
    public class EstadoAnulada : IEstadoNotaCompra
    {
        public void Pendiente(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: No se puede poner una nota anulada en estado pendiente");
        }

        public void Procesar(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: No se puede procesar una nota anulada");
        }

        public void Pagar(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: No se puede pagar una nota anulada");
        }

        public void Anular(NotaCompra notaCompra)
        {
            throw new InvalidOperationException(" La nota ya está anulada");
        }

        public void Finalizar(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: No se puede finalizar una nota anulada");
        }

        public string ObtenerNombreEstado()
        {
            return "Anulada";
        }
    }
}

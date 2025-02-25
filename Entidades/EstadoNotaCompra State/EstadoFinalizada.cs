namespace Entidades.EstadoNotaCompra_State
{
    public class EstadoFinalizada : IEstadoNotaCompra
    {
        public void Pendiente(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: La nota ya está finalizada");
        }

        public void Procesar(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: La nota ya está finalizada");
        }
        public void Pagar(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: La nota ya está finalizada");
        }
        public void Anular(NotaCompra notaCompra)
        {
            throw new InvalidOperationException("Error: No se puede anular una nota finalizada");
        }
        public void Finalizar(NotaCompra notaCompra)
        {
            throw new InvalidOperationException(" La nota ya está finalizada");
        }
        public string ObtenerNombreEstado()
        {
            return "Finalizada";
        }
    }
}

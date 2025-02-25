namespace Entidades
{
    public interface IEstadoNotaCompra
    {
        void Pendiente(NotaCompra notaCompra);
        void Procesar(NotaCompra notaCompra);
        void Pagar(NotaCompra notaCompra);
        void Anular(NotaCompra notaCompra);
        void Finalizar(NotaCompra notaCompra);
        string ObtenerNombreEstado();
    }
}

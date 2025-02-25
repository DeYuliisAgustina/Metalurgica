namespace Entidades
{
    public class Proveedor : Persona
    {
        public int ProveedorId { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public bool Activo { get; set; }

        public int CantidadNotasCompra { get; set; }
        public ICollection<NotaCompra> NotasCompra { get; set; } = new List<NotaCompra>();
    }
}

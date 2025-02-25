namespace Entidades
{
    public class Cliente : Persona
    {
        public int ClienteId { get; set; }
        public string RazonSocial { get; set; }
        public bool Activo { get; set; }

        public int CantidadNotasVenta { get; set; }
        public List<NotaVenta> NotasVenta { get; set; } = new List<NotaVenta>();

        public override string ToString()
        {
            return NombreyApellido;
        }
    }
}

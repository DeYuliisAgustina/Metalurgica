namespace Entidades.Seguridad
{
    public class EstadoUsuario
    {
        public int EstadoUsuarioId { get; set; }
        public string Nombre { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}

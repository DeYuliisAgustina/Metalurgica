namespace Entidades.Seguridad
{
    public abstract class Componente
    {
        public int ComponenteId { get; set; }
        public string Nombre { get; set; }

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public abstract void AgregarHijo(Componente componente);
        public abstract void EliminarHijo(Componente componente);
        public abstract void Display(int depth);
    }
}

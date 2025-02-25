namespace Entidades.Seguridad
{
    public class Grupo : Componente
    {
        public int GrupoId { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }

        public bool Asignado { get; set; } //grupo asignado a un usuario

        public EstadoGrupo EstadoGrupo { get; set; }
        public List<Componente> Hijos { get; set; } = new List<Componente>();

        public override void AgregarHijo(Componente componente)
        {
            Hijos.Add(componente);
        }

        public override void EliminarHijo(Componente componente)
        {
            Hijos.Remove(componente);
        }

        public override void Display(int depth)
        {
            throw new NotImplementedException();
        }
    }
}

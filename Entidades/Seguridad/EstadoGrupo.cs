namespace Entidades.Seguridad
{
    public class EstadoGrupo
    {
        public int EstadoGrupoId { get; set; }
        public string Nombre { get; set; }

        public List<Grupo> Grupos { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}

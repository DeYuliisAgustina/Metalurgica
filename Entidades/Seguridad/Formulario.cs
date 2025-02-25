namespace Entidades.Seguridad
{
    public class Formulario
    {
        public int FormularioId { get; set; }
        public string Nombre { get; set; }

        public Modulo Modulo { get; set; }
        public List<Accion> Acciones { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}

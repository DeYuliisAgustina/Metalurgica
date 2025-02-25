using System.ComponentModel;

namespace Entidades.Seguridad
{
    public class Accion : Componente
    {
        public int AccionId { get; set; }

        public Formulario Formulario { get; set; }

        public bool Asignada { get; set; } //acción asignada a un grupo

        public override void AgregarHijo(Componente componente)
        {
            throw new Exception("No se puede agregar un hijo.");
        }

        public override void EliminarHijo(Componente componente)
        {
            throw new Exception("No se puede eliminar un hijo.");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + Nombre);
        }
    }
}

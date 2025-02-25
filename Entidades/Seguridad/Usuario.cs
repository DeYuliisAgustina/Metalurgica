namespace Entidades.Seguridad
{
    public class Usuario
    {
        //no se tiene que mappear en la base de datos
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public string NombreyApellido { get; set; }

        public EstadoUsuario EstadoUsuario { get; set; }

        public List<Componente> Perfil { get; set; } = new List<Componente>();

        public void AgregarPermiso(Componente componente)
        {
            Perfil.Add(componente);
        }

        public void EliminarPermiso(Componente componente)
        {
            Perfil.Remove(componente);
        }

        public override string ToString()
        {
            return NombreUsuario;
        }

    }
}

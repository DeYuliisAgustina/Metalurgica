using Entidades;
using Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace Modelo
{

    public class Context : DbContext
    {
        private static Context instancia;
        public static Context Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new Context();
                return instancia;
            }
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<Componente> Componentes { get; set; }
        public DbSet<EstadoGrupo> EstadoGrupos { get; set; }
        public DbSet<EstadoUsuario> EstadoUsuarios { get; set; }
        public DbSet<Formulario> Formularios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<NotaCompra> NotasCompra { get; set; }
        public DbSet<NotaVenta> NotasVenta { get; set; }
        public DbSet<DetalleNotaCompra> DetallesNotaCompra { get; set; }
        public DbSet<DetalleNotaVenta> DetallesNotaVenta { get; set; }

        public DbSet<AuditoriaSesion> AuditoriasSesion { get; set; }
        public DbSet<AuditoriaCliente> AuditoriaClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.EnableSensitiveDataLogging(true);
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Metalurgica;Trusted_Connection=True;");
        }
    }
}
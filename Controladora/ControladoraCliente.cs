using Entidades;
using Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraCliente
    {
        Context context;

        private ControladoraCliente()
        {
            context = new Context();
        }

        private static ControladoraCliente instancia;

        public static ControladoraCliente Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraCliente();
                return instancia;
            }
        }

        public ReadOnlyCollection<Cliente> RecuperarClientes(bool? soloActivos = null)
        {
            var clientes = Context.Instancia.Clientes.ToList();
            if (soloActivos.HasValue)
            {
                clientes = clientes.Where(c => c.Activo == soloActivos.Value).ToList();
            }
            return clientes.AsReadOnly();
        }

        public ReadOnlyCollection<Cliente> RecuperarCliente()
        {
            return Context.Instancia.Clientes.ToList().AsReadOnly();
        }

        public ReadOnlyCollection<AuditoriaCliente> RecuperarAuditorias()
        {
            return Context.Instancia.AuditoriaClientes
                .Include(a => a.Usuario)
                .OrderByDescending(a => a.FechaAuditoria)
                .ToList()
                .AsReadOnly();
        }

        public int ContarNotasVentaPorCliente(Cliente cliente)
        {
            try
            {
                var listaNotasVentas = Context.Instancia.NotasVenta.ToList().AsReadOnly();
                var notasVentaPorCliente = listaNotasVentas.Where(s => s.ClienteId == cliente.ClienteId);
                return notasVentaPorCliente.Count();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarCliente(Cliente cliente, Usuario usuario)
        {
            try
            {
                var listaClientes = Context.Instancia.Clientes.ToList().AsReadOnly();
                var clienteEncontrado = listaClientes.FirstOrDefault(s => s.NombreyApellido.ToLower() == cliente.NombreyApellido.ToLower() && s.DNI == cliente.DNI);
                if (clienteEncontrado == null)
                {
                    Context.Instancia.Clientes.Add(cliente);

                    // Crear registro de auditoría
                    var auditoria = new AuditoriaCliente
                    {
                        UsuarioId = usuario.UsuarioId,
                        ClienteId = cliente.ClienteId,
                        NombreyApellido = cliente.NombreyApellido,
                        DNI = cliente.DNI,
                        RazonSocial = cliente.RazonSocial,
                        FechaAuditoria = DateTime.Now,
                        TipoMovimiento = "Alta de Cliente"
                    };
                    Context.Instancia.AuditoriaClientes.Add(auditoria);

                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El cliente se agregó correctamente";
                    }
                    else return $"El cliente no se ha podido agregar";
                }
                else
                {
                    return $"El cliente ya existe";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string ModificarCliente(Cliente cliente, Usuario usuario)
        {
            try
            {
                var listaClientes = Context.Instancia.Clientes.ToList().AsReadOnly();
                var clienteEncontrado = listaClientes.FirstOrDefault(s => s.NombreyApellido.ToLower() == cliente.NombreyApellido.ToLower() && s.DNI == cliente.DNI);
                if (clienteEncontrado != null)
                {
                    Context.Instancia.Clientes.Update(cliente);

                    // Crear registro de auditoría
                    var auditoria = new AuditoriaCliente
                    {
                        UsuarioId = usuario.UsuarioId,
                        ClienteId = cliente.ClienteId,
                        NombreyApellido = cliente.NombreyApellido,
                        DNI = cliente.DNI,
                        RazonSocial = cliente.RazonSocial,
                        FechaAuditoria = DateTime.Now,
                        TipoMovimiento = "Modificación de Cliente"
                    };
                    Context.Instancia.AuditoriaClientes.Add(auditoria);

                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El cliente se modificó correctamente";
                    }
                    else return $"El cliente no se ha podido modificar";
                }
                else
                {
                    return $"El cliente no existe";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string DarBajaCliente(Cliente cliente, Usuario usuario)
        {
            try
            {
                var listaClientes = Context.Instancia.Clientes.ToList().AsReadOnly();
                var clienteEncontrado = listaClientes.FirstOrDefault(s => s.NombreyApellido.ToLower() == cliente.NombreyApellido.ToLower() && s.DNI == cliente.DNI);
                if (clienteEncontrado != null)
                {
                    cliente.Activo = false;
                    Context.Instancia.Clientes.Update(cliente);

                    // Crear registro de auditoría
                    var auditoria = new AuditoriaCliente
                    {
                        UsuarioId = usuario.UsuarioId,
                        ClienteId = cliente.ClienteId,
                        NombreyApellido = cliente.NombreyApellido,
                        DNI = cliente.DNI,
                        RazonSocial = cliente.RazonSocial,
                        FechaAuditoria = DateTime.Now,
                        TipoMovimiento = "Baja de Cliente"
                    };
                    Context.Instancia.AuditoriaClientes.Add(auditoria);

                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El cliente se dio de baja correctamente";
                    }
                    else return $"El cliente no se ha podido dar de baja";
                }
                else
                {
                    return $"El cliente no existe";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string DarAltaCliente(Cliente cliente, Usuario usuario)
        {
            try
            {
                var listaClientes = Context.Instancia.Clientes.ToList().AsReadOnly();
                var clienteEncontrado = listaClientes.FirstOrDefault(s => s.NombreyApellido.ToLower() == cliente.NombreyApellido.ToLower() && s.DNI == cliente.DNI);
                if (clienteEncontrado != null)
                {
                    cliente.Activo = true;
                    Context.Instancia.Clientes.Update(cliente);

                    // Crear registro de auditoría
                    var auditoria = new AuditoriaCliente
                    {
                        UsuarioId = usuario.UsuarioId,
                        ClienteId = cliente.ClienteId,
                        NombreyApellido = cliente.NombreyApellido,
                        DNI = cliente.DNI,
                        RazonSocial = cliente.RazonSocial,
                        FechaAuditoria = DateTime.Now,
                        TipoMovimiento = "Reactivación de Cliente"
                    };
                    Context.Instancia.AuditoriaClientes.Add(auditoria);

                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El cliente se dio de alta correctamente";
                    }
                    else return $"El cliente no se ha podido dar de alta";
                }
                else
                {
                    return $"El cliente no existe";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
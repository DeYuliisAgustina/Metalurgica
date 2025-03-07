using Entidades;
using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraProveedor
    {
        Context context;

        private ControladoraProveedor()
        {
            context = new Context();
        }

        private static ControladoraProveedor instancia;

        public static ControladoraProveedor Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new ControladoraProveedor();
                return instancia;
            }
        }

        public ReadOnlyCollection<Proveedor> RecuperarProveedores(bool? soloActivos = null)
        {
            var proveedores = Context.Instancia.Proveedores.ToList();
            if (soloActivos.HasValue)
            {
                proveedores = proveedores.Where(c => c.Activo == soloActivos.Value).ToList();
            }
            return proveedores.AsReadOnly();
        }

        public int ContarNotasCompraPorProveedor(Proveedor proveedor)
        {
            try
            {
                var listaNotasCompras = Context.Instancia.NotasCompra.ToList().AsReadOnly(); // Recupero todos los tickets 
                var notasCompraPorProveedor = listaNotasCompras.Where(s => s.Proveedor.NombreyApellido == proveedor.NombreyApellido); // Recupero los tickets que tiene asignados el tecnico
                return notasCompraPorProveedor.Count();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                var listaProveedores = Context.Instancia.Proveedores.ToList().AsReadOnly();
                var proveedorEncontrado = listaProveedores.FirstOrDefault(s => s.NombreyApellido.ToLower() == proveedor.NombreyApellido.ToLower() && s.DNI == proveedor.DNI);
                if (proveedorEncontrado == null)
                {
                    Context.Instancia.Proveedores.Add(proveedor);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El proveedor se agregó correctamente";
                    }
                    else return $"El proveedor  no se ha podido agregar";
                }
                else
                {
                    return $"El proveedor  ya existe";
                }

            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarProveedor(Proveedor proveedor)
        {
            try
            {
                var listaProveedores = Context.Instancia.Proveedores.ToList().AsReadOnly();
                var proveedorEncontrado = listaProveedores.FirstOrDefault(s => s.NombreyApellido.ToLower() == proveedor.NombreyApellido.ToLower() && s.DNI == proveedor.DNI);
                if (proveedorEncontrado != null)
                {
                    Context.Instancia.Proveedores.Update(proveedor);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El proveedor se modificó correctamente";
                    }
                    else return $"El proveedor no se ha podido modificar";
                }
                else
                {
                    return $"El proveedor no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string DarBajaProveedor(Proveedor proveedor)
        {
            try
            {
                var listaProveedores = Context.Instancia.Proveedores.ToList().AsReadOnly();
                var proveedorEncontrado = listaProveedores.FirstOrDefault(s => s.NombreyApellido.ToLower() == proveedor.NombreyApellido.ToLower() && s.DNI == proveedor.DNI);
                if (proveedorEncontrado != null)
                {
                    proveedor.Activo = false;
                    Context.Instancia.Proveedores.Update(proveedor);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El proveedor se dio de baja correctamente";
                    }
                    else return $"El proveedor no se ha podido dar de baja";
                }
                else
                {
                    return $"El proveedor no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string DarAltaProveedor(Proveedor proveedor)
        {
            try
            {
                var listaProveedores = Context.Instancia.Proveedores.ToList().AsReadOnly();
                var proveedorEncontrado = listaProveedores.FirstOrDefault(s => s.NombreyApellido.ToLower() == proveedor.NombreyApellido.ToLower() && s.DNI == proveedor.DNI);
                if (proveedorEncontrado != null)
                {
                    proveedor.Activo = true;
                    Context.Instancia.Proveedores.Update(proveedor);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El proveedor se dio de alta correctamente";
                    }
                    else return $"El proveedor no se ha podido dar de alta";
                }
                else
                {
                    return $"El proveedor no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarProveedor(Proveedor proveedor)
        {
            try
            {
                var listaProveedores = Context.Instancia.Proveedores.ToList().AsReadOnly();
                var proveedorEncontrado = listaProveedores.FirstOrDefault(s => s.NombreyApellido.ToLower() == proveedor.NombreyApellido.ToLower() && s.DNI == proveedor.DNI);
                if (proveedorEncontrado != null)
                {
                    Context.Instancia.Proveedores.Remove(proveedor);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El proveedor se eliminó correctamente";
                    }
                    else return $"El proveedor no se ha podido eliminar";
                }
                else
                {
                    return $"El proveedor no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }


    }
}

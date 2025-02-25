using Entidades;
using Entidades.Seguridad;
using Modelo;
using System.Collections.ObjectModel;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.EntityFrameworkCore;

namespace Controladora
{
    public class ControladoraProducto
    {

        Context context;

        private ControladoraProducto()
        {
            context = new Context();
        }

        private static ControladoraProducto instancia;

        public static ControladoraProducto Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraProducto();
                return instancia;
            }
        }

        public ReadOnlyCollection<Producto> RecuperarProductos()
        {
            Context.Instancia.Productos.ToList().AsReadOnly();
            return Context.Instancia.Productos.ToList().AsReadOnly();
        }

        public ReadOnlyCollection<Producto> RecuperarProductos(bool? soloActivos = null)
        {
            var productos = Context.Instancia.Productos.ToList();
            if (soloActivos.HasValue)
            {
                productos = productos.Where(c => c.Activo == soloActivos.Value).ToList();
            }
            return productos.AsReadOnly();
        }

        public List<(string Nombre, int TotalVendido, decimal MontoTotal)> ObtenerTop5ProductosMasVendidos() //retorna una lista de tablas con 3 columnas: Nombre, TotalVendido, MontoTotal para los 5 productos más vendidos 
        {
            try
            {
                //obtengo los productos con sus detalles de nota de venta (es como un join)
                var productos = Context.Instancia.Productos
                    .Include(p => p.DetallesNotaVenta)
                    .ToList();

                return productos //filtro los productos que tienen detalles de nota de venta /no null y que tengan al menos un detalle)
                    .Where(p => p.DetallesNotaVenta != null && p.DetallesNotaVenta.Any())
                    .Select(p => ( //creo una tupla con los datos que necesito
                        Nombre: p.Nombre,
                        TotalVendido: p.DetallesNotaVenta.Sum(d => d.Cantidad), //sumo las cantidades vendidas
                        MontoTotal: p.DetallesNotaVenta.Sum(d => d.Subtotal) //sumo los subtotales para obtener el monto total
                    ))
                    .OrderByDescending(p => p.TotalVendido) //ordeno de mayor a menor por la cantidad vendida
                    .Take(5) //me quedo con los 5 primeros
                    .ToList(); //convierto a lista
            }
            catch (Exception) //si hay un error
            {
                return new List<(string, int, decimal)>(); //retorno una lista vacía (no hay datos)
            }
        }

        public string AgregarProducto(Producto producto)
        {
            try
            {
                var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                var productoEncontrado = listaProductos.FirstOrDefault(p => p.Nombre == producto.Nombre && p.Codigo == producto.Codigo);
                if (productoEncontrado == null)
                {
                    Context.Instancia.Productos.Add(producto);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return "El producto se agregó correctamente";
                    }
                    else return "El producto no se ha podido agregar";
                }
                else
                {
                    return "El producto ya existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarProducto(Producto producto)
        {
            try
            {
                var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                var productoEncontrado = listaProductos.FirstOrDefault(p => p.Nombre == producto.Nombre && p.Codigo == producto.Codigo);
                if (productoEncontrado != null)
                {
                    Context.Instancia.Productos.Update(producto);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return "El producto se modificó correctamente";
                    }
                    else return "El producto no se ha podido modificar";
                }
                else
                {
                    return "El producto no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string DarBajaProducto(Producto producto)
        {
            try
            {
                var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                var productoEncontrado = listaProductos.FirstOrDefault(p => p.Codigo == producto.Codigo);
                if (productoEncontrado != null)
                {
                    producto.Activo = false;
                    Context.Instancia.Productos.Update(producto);

                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El producto se dio de baja correctamente";
                    }
                    else return $"El producto no se ha podido dar de baja";
                }
                else
                {
                    return $"El producto no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string DarAltaProducto(Producto producto)
        {
            try
            {
                var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                var productoEncontrado = listaProductos.FirstOrDefault(p => p.Codigo == producto.Codigo);
                if (productoEncontrado != null)
                {
                    producto.Activo = true;
                    Context.Instancia.Productos.Update(producto);

                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El producto se dio de alta correctamente";
                    }
                    else return $"El producto no se ha podido dar de alta";
                }
                else
                {
                    return $"El producto no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarProducto(Producto producto)
        {
            try
            {
                var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                var productoEncontrado = listaProductos.FirstOrDefault(p => p.Nombre == producto.Nombre && p.Codigo == producto.Codigo);
                if (productoEncontrado != null)
                {
                    Context.Instancia.Productos.Remove(producto);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return "El producto se eliminó correctamente";
                    }
                    else return "El producto no se ha podido eliminar";
                }
                else
                {
                    return "El producto no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
    }
}
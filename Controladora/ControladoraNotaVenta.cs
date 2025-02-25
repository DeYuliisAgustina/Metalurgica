using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraNotaVenta
    {
        Context context;
        private static ControladoraNotaVenta instancia;

        private ControladoraNotaVenta()
        {
            context = new Context();
        }

        public static ControladoraNotaVenta Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraNotaVenta();
                return instancia;
            }
        }

        public ReadOnlyCollection<NotaVenta> RecuperarNotasVenta()
        {
            try
            {
                return Context.Instancia.NotasVenta
                    .Include(n => n.DetallesNotaVenta)
                    .Include(n => n.Cliente)
                    .Where(n => n.DetallesNotaVenta.Any()) // Solo trae notas con detalles
                    .ToList()
                    .AsReadOnly();
            }
            catch (Exception)
            {
                throw;
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

        public ReadOnlyCollection<Producto> RecuperarProductos()
        {
            Context.Instancia.Productos.ToList().AsReadOnly();
            return Context.Instancia.Productos.ToList().AsReadOnly();
        }

        public ReadOnlyCollection<DetalleNotaVenta> RecuperarDetallesNotaVenta()
        {
            Context.Instancia.DetallesNotaVenta.ToList().AsReadOnly();
            return Context.Instancia.DetallesNotaVenta.ToList().AsReadOnly();
        }

        //RecuperarDetallesNotaVentaPorId
        public ReadOnlyCollection<DetalleNotaVenta> RecuperarDetallesNotaVentaPorId()
        {
            Context.Instancia.DetallesNotaVenta.Where(d => d.DetalleNotaVentaId == d.DetalleNotaVentaId).ToList().AsReadOnly();
            return Context.Instancia.DetallesNotaVenta.Where(d => d.DetalleNotaVentaId == d.DetalleNotaVentaId).ToList().AsReadOnly();
        }

        private int ultimoNumeroVenta = 0;  // Ya no es static

        public int ObtenerSiguienteNumeroNv()  // Ya no es static
        {
            if (ultimoNumeroVenta == 0)
            {
                var notasVenta = Context.Instancia.NotasVenta.ToList();
                if (notasVenta.Any())
                {
                    ultimoNumeroVenta = notasVenta.Max(n => n.NroNotaVenta);//
                }
                else
                {
                    ultimoNumeroVenta = 0;
                }
            }

            ultimoNumeroVenta++;
            return ultimoNumeroVenta;
        }

        public string AgregarNotaVenta(NotaVenta notaVenta)
        {
            try
            {
                var cliente = Context.Instancia.Clientes.ToList().AsReadOnly();
                var clienteEncontrado = cliente.FirstOrDefault(c => c.ClienteId == notaVenta.Cliente.ClienteId);

                // Verificar si el cliente esta activo
                if (clienteEncontrado == null || !clienteEncontrado.Activo)
                {
                    return "No se puede crear una nota de venta con un cliente inactivo";
                }

                var listaNotas = Context.Instancia.NotasVenta.ToList().AsReadOnly();
                var notaEncontrada = listaNotas.FirstOrDefault(n => n.NotaVentaId == notaVenta.NotaVentaId);
                if (notaEncontrada == null)
                {
                    Context.Instancia.NotasVenta.Add(notaVenta);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return "La nota de venta se agregó correctamente";
                    }
                    else return "La nota de venta no se ha podido agregar";
                }
                else return "La nota de venta ya existe";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarNotaVenta(NotaVenta notaVenta)
        {
            try
            {
                var listaNotas = Context.Instancia.NotasVenta.ToList().AsReadOnly();
                var notaEncontrada = listaNotas.FirstOrDefault(n => n.NotaVentaId == notaVenta.NotaVentaId);
                if (notaEncontrada != null)
                {
                    Context.Instancia.NotasVenta.Update(notaVenta);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return "La nota de venta se modificó correctamente";
                    }
                    else return "La nota de venta no se ha podido modificar";
                }
                else return "La nota de venta no existe";

            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string CancelarNotaVenta(NotaVenta notaVenta) 
        {
            try
            {
                var listaNotas = Context.Instancia.NotasVenta.ToList().AsReadOnly();
                var notaEncontrada = listaNotas.FirstOrDefault(n => n.NotaVentaId == notaVenta.NotaVentaId);
                if (notaEncontrada != null)
                {
                    // Obtenemos la lista de detalles
                    var listaDetalles = Context.Instancia.DetallesNotaVenta.ToList().AsReadOnly();
                    var detalles = listaDetalles.Where(d => d.NotaVentaId == notaVenta.NotaVentaId);

                    // Restaurar el stock de cada producto en los detalles
                    foreach (var detalle in detalles)
                    {
                        var producto = Context.Instancia.Productos.Find(detalle.Producto.ProductoId);
                        if (producto != null)
                        {
                            producto.Stock += detalle.Cantidad;
                            Context.Instancia.Productos.Update(producto);
                        }
                    }

                    // Eliminar los detalles primero
                    Context.Instancia.DetallesNotaVenta.RemoveRange(detalles);

                    // Luego eliminar la nota
                    Context.Instancia.NotasVenta.Remove(notaEncontrada);

                    int eliminados = Context.Instancia.SaveChanges();
                    if (eliminados > 0)
                    {
                        return "La nota de venta se eliminó correctamente y el stock ha sido restaurado";
                    }
                    return "La nota de venta no se ha podido eliminar";
                }
                return "Se canceló la operación";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

    }
}


using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraNotaCompra
    {
        Context context;

        private ControladoraNotaCompra()
        {
            context = new Context();
        }

        private static ControladoraNotaCompra instancia;

        public static ControladoraNotaCompra Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraNotaCompra();
                return instancia;
            }
        }

        public ReadOnlyCollection<NotaCompra> RecuperarNotasCompra()
        {
            try
            {
                return Context.Instancia.NotasCompra
                    .Include(n => n.DetallesNotaCompra)
                    .Include(n => n.Proveedor)
                    .Where(n => n.DetallesNotaCompra.Any()) // Solo trae notas con detalles
                    .ToList()
                    .AsReadOnly();
            }
            catch (Exception)
            {
                throw;
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

        public ReadOnlyCollection<Proveedor> RecuperarProveedores()
        {
            Context.Instancia.Proveedores.ToList().AsReadOnly();
            return Context.Instancia.Proveedores.ToList().AsReadOnly();
        }

        public ReadOnlyCollection<Producto> RecuperarProductos()
        {
            Context.Instancia.Productos.ToList().AsReadOnly();
            return Context.Instancia.Productos.ToList().AsReadOnly();
        }

        public ReadOnlyCollection<DetalleNotaCompra> RecuperarDetallesNotaCompra()
        {
            Context.Instancia.DetallesNotaCompra.ToList().AsReadOnly();
            return Context.Instancia.DetallesNotaCompra.ToList().AsReadOnly();

        }

        private int ultimoNumero = 0;  // Ya no es static

        public int ObtenerSiguienteNumeroNc()  // Ya no es static
        {
            if (ultimoNumero == 0)
            {
                var notasCompra = Context.Instancia.NotasCompra.ToList();
                if (notasCompra.Any())
                {
                    ultimoNumero = notasCompra.Max(n => n.NroNotaCompra);
                }
                else
                {
                    ultimoNumero = 0;
                }
            }

            ultimoNumero++;
            return ultimoNumero;
        }

        // In ControladoraNotaCompra
        public string AgregarNotaCompra(NotaCompra notaCompra)
        {
            try
            {
                var proveedor = Context.Instancia.Proveedores.FirstOrDefault(p => p.ProveedorId == notaCompra.ProveedorId);
                if (proveedor == null || !proveedor.Activo)
                {
                    return "No se puede realizar una compra con un proveedor inactivo";
                }

                var listaNotasCompra = Context.Instancia.NotasCompra.ToList().AsReadOnly();
                var notaCompraEncontrada = listaNotasCompra.FirstOrDefault(n => n.NotaCompraId == notaCompra.NotaCompraId);

                if (notaCompraEncontrada == null)
                {
                    Context.Instancia.NotasCompra.Add(notaCompra);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return "La nota de compra se agregó correctamente";
                    }
                    else return "La nota de compra no se ha podido agregar";
                }
                else
                {
                    return "La nota de compra ya existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarNotaCompra(NotaCompra notaCompra)
        {
            try
            {
                var listaNotasCompra = Context.Instancia.NotasCompra.ToList().AsReadOnly();
                var notaCompraEncontrada = listaNotasCompra.FirstOrDefault(n => n.NotaCompraId == notaCompra.NotaCompraId);
                if (notaCompraEncontrada != null)
                {
                    notaCompraEncontrada.Estado = notaCompra.Estado;

                    Context.Instancia.NotasCompra.Update(notaCompra);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return "La nota de compra se modificó correctamente";
                    }
                    else return "La nota de compra no se ha podido modificar";
                }
                else
                {
                    return "La nota de compra no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string CancelarNotaCompra(NotaCompra notaCompra) //esto es por si el usuario se arrepiente de agregar una nota de compra
        {
            try
            {
                var listaNotas = Context.Instancia.NotasCompra.ToList().AsReadOnly();
                var notaEncontrada = listaNotas.FirstOrDefault(n => n.NotaCompraId == notaCompra.NotaCompraId);
                if (notaEncontrada != null)
                {
                    // Obtenemos la lista de detalles
                    var listaDetalles = Context.Instancia.DetallesNotaCompra.ToList().AsReadOnly();
                    var detalles = listaDetalles.Where(d => d.NotaCompraId == notaCompra.NotaCompraId);

                    // Restaurar el stock de cada producto en los detalles
                    foreach (var detalle in detalles)
                    {
                        var producto = Context.Instancia.Productos.Find(detalle.Producto.ProductoId);
                        if (producto != null)
                        {
                            producto.Stock -= detalle.Cantidad; // Aquí restamos en lugar de sumar
                            Context.Instancia.Productos.Update(producto);
                        }
                    }

                    // Eliminar los detalles primero
                    Context.Instancia.DetallesNotaCompra.RemoveRange(detalles);

                    // Luego eliminar la nota
                    Context.Instancia.NotasCompra.Remove(notaEncontrada);

                    int eliminados = Context.Instancia.SaveChanges();
                    if (eliminados > 0)
                    {
                        return "La nota de compra se eliminó correctamente y el stock ha sido restaurado";
                    }
                    return "La nota de compra no se ha podido eliminar";
                }
                return "Se canceló la operación";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string AnularNotaCompra(NotaCompra notaCompra)
        {
            try
            {
                var listaNotasCompra = Context.Instancia.NotasCompra.ToList().AsReadOnly();
                var notaCompraEncontrada = listaNotasCompra.FirstOrDefault(n => n.NotaCompraId == notaCompra.NotaCompraId);
                if (notaCompraEncontrada != null)
                {
                    if (notaCompraEncontrada.ObtenerEstado() == "Anulada")
                    {
                        return $"La nota de compra ya se encuentra anulada";
                    }

                    if (notaCompraEncontrada.ObtenerEstado() == "Pagada" || notaCompraEncontrada.ObtenerEstado() == "Finalizada")
                    {
                        return $"No se puede anular una nota de compra que ya está pagada";
                    }

                    var listaDetalles = Context.Instancia.DetallesNotaCompra.ToList().AsReadOnly();
                    var detallesNotaCompra = listaDetalles.Where(d => d.NotaCompraId == notaCompra.NotaCompraId);
                    foreach (var detalle in detallesNotaCompra)
                    {
                        var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                        var producto = listaProductos.FirstOrDefault(p => p.ProductoId == detalle.Producto.ProductoId);
                        if (producto != null)
                        {
                            producto.Stock -= detalle.Cantidad;
                            Context.Instancia.Productos.Update(producto);
                        }
                    }

                    notaCompra.Anular();
                    Context.Instancia.NotasCompra.Update(notaCompra);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"La nota de compra se anuló correctamente";
                    }
                    else return $"La nota de compra no se ha podido anular";
                }
                else
                {
                    return $"La nota de compra no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }


        public string PagarNotaCompra(NotaCompra notaCompra)
        {
            try
            {
                var listaNotasCompra = Context.Instancia.NotasCompra.ToList().AsReadOnly();
                var notaCompraEncontrada = listaNotasCompra.FirstOrDefault(n => n.NotaCompraId == notaCompra.NotaCompraId);

                if (notaCompraEncontrada != null && notaCompraEncontrada.ObtenerEstado() != "Pagada" && notaCompraEncontrada.ObtenerEstado() != "Anulada")
                {
                    var listaDetalles = Context.Instancia.DetallesNotaCompra.ToList().AsReadOnly();
                    var detallesNotaCompra = listaDetalles.Where(d => d.NotaCompraId == notaCompra.NotaCompraId);

                    foreach (var detalle in detallesNotaCompra)
                    {
                        var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                        var producto = listaProductos.FirstOrDefault(p => p.ProductoId == detalle.Producto.ProductoId);
                        if (producto != null)
                        {
                            producto.Stock += detalle.Cantidad;
                            Context.Instancia.Productos.Update(producto);
                        }
                    }

                    notaCompra.Pagar();
                    Context.Instancia.NotasCompra.Update(notaCompra);

                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"La nota de compra se pagó correctamente";
                    }
                    else return $"La nota de compra no se ha podido pagar";
                }
                else
                {
                    return $"La nota de compra no existe o ya está pagada/anulada";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

    }
}
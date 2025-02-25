using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraDetalleNotaCompra
    {
        Context context;

        private ControladoraDetalleNotaCompra()
        {
            context = new Context();
        }

        private static ControladoraDetalleNotaCompra instancia;

        public static ControladoraDetalleNotaCompra Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraDetalleNotaCompra();
                return instancia;
            }
        }

        public ReadOnlyCollection<DetalleNotaCompra> RecuperarDetallesCompra()
        {
            try
            {
                Context.Instancia.DetallesNotaCompra.Include(d => d.Producto).Include(d => d.NotaCompra.Proveedor).ToList().AsReadOnly();
                return Context.Instancia.DetallesNotaCompra.Include(d => d.Producto).Include(d => d.NotaCompra.Proveedor).ToList().AsReadOnly();

            }
            catch (Exception)
            {
                throw;
            }
        }

        //recuperar notas de compra
        public ReadOnlyCollection<NotaCompra> RecuperarNotasCompra()
        {
            try
            {
                Context.Instancia.NotasCompra.Include(n => n.Proveedor).ToList().AsReadOnly();
                return Context.Instancia.NotasCompra.Include(n => n.Proveedor).ToList().AsReadOnly();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public ReadOnlyCollection<Producto> RecuperarProductos()
        {
            Context.Instancia.Productos.ToList().AsReadOnly();
            return Context.Instancia.Productos.ToList().AsReadOnly();
        }

        public ReadOnlyCollection<Proveedor> RecuperarProveedores()
        {
            Context.Instancia.Proveedores.ToList().AsReadOnly();
            return Context.Instancia.Proveedores.ToList().AsReadOnly();
        }

        public string AgregarDetalleNotaCompra(DetalleNotaCompra detalleCompra)
        {
            try
            {
                var listaDetalles = Context.Instancia.DetallesNotaCompra.ToList().AsReadOnly();
                var detalleEncontrado = listaDetalles.FirstOrDefault(d => d.DetalleNotaCompraId == detalleCompra.DetalleNotaCompraId);
                if (detalleEncontrado == null) // Validar si el detalle no existe
                {
                    var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                    var productoEncontrado = listaProductos.FirstOrDefault(p => p.ProductoId == detalleCompra.Producto.ProductoId);
                    if (productoEncontrado != null)  // Validar existencia del producto
                    {
                        // Validar si el producto está activo
                        if (!productoEncontrado.Activo)
                        {
                            return $"No se puede comprar el producto {productoEncontrado.Nombre} porque está inactivo";
                        }

                        // Cálculo de negocio
                        detalleCompra.Subtotal = detalleCompra.Cantidad * detalleCompra.PrecioUnitario;

                        try
                        {
                            Context.Instancia.DetallesNotaCompra.Add(detalleCompra);
                            int insertados = Context.Instancia.SaveChanges();
                            if (insertados > 0)
                            {
                                return $"El detalle de nota de compra se agregó correctamente";
                            }
                            return $"El detalle de nota de compra no se ha podido agregar";
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    else
                    {
                        return "El producto no existe";
                    }
                }
                return "El detalle de nota de compra ya existe";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarDetalleNotaCompra(DetalleNotaCompra detalleCompra)
        {
            try
            {
                var listaDetalles = Context.Instancia.DetallesNotaCompra.ToList().AsReadOnly();
                var detalleEncontrado = listaDetalles.FirstOrDefault(d => d.DetalleNotaCompraId == detalleCompra.DetalleNotaCompraId);

                if (detalleEncontrado != null)
                {
                    Context.Instancia.DetallesNotaCompra.Update(detalleCompra);
                    int insertados = Context.Instancia.SaveChanges();

                    if (insertados > 0)
                    {
                        return "El detalle de nota de compra se modificó correctamente";
                    }
                    else return "El detalle de nota de compra no se ha podido modificar";
                }
                else
                {
                    return "El detalle de nota de compra no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
    }
}
using Entidades;
using Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Controladora
{
    public class ControladoraDetalleNotaVenta
    {
        Context context;

        private ControladoraDetalleNotaVenta()
        {
            context = new Context();
        }

        private static ControladoraDetalleNotaVenta instancia;

        public static ControladoraDetalleNotaVenta Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraDetalleNotaVenta();
                return instancia;
            }
        }

        public ReadOnlyCollection<DetalleNotaVenta> RecuperarDetallesVenta()
        {
            try
            {
                Context.Instancia.DetallesNotaVenta.Include(d => d.Producto).Include(d => d.NotaVenta.Cliente).ToList().AsReadOnly();
                return Context.Instancia.DetallesNotaVenta.Include(d => d.Producto).Include(d => d.NotaVenta.Cliente).ToList().AsReadOnly();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<NotaVenta> RecuperarNotasVenta()
        {
            try
            {
                return Context.Instancia.NotasVenta.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar las notas de venta", ex);
            }
        }

        // En ControladoraDetalleNotaVenta

        public ReadOnlyCollection<Producto> RecuperarProductos()
        {
            try
            {
                Context.Instancia.Productos.ToList().AsReadOnly();
                return Context.Instancia.Productos.ToList().AsReadOnly();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReadOnlyCollection<Usuario> RecuperarUsuarioLogueado()
        {
            try
            {
                var listaUsuarios = Context.Instancia.Usuarios
                    .Include(u => u.Perfil)
                    .Include(u => u.EstadoUsuario)
                    .Where(u => u.EstadoUsuario.Nombre.ToLower() == "activo")
                    .ToList()
                    .AsReadOnly();

                return listaUsuarios;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //AGREGAR DETALLE DE NOTA DE VENTA
        public string AgregarDetalleNotaVenta(DetalleNotaVenta detalleVenta)
        {
            try
            {
                var listaDetalles = Context.Instancia.DetallesNotaVenta.ToList().AsReadOnly();
                var detalleEncontrado = listaDetalles.FirstOrDefault(d => d.DetalleNotaVentaId == detalleVenta.DetalleNotaVentaId);

                if (detalleEncontrado == null)
                {
                    var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                    var productoEncontrado = listaProductos.FirstOrDefault(p => p.ProductoId == detalleVenta.Producto.ProductoId);
                    if (productoEncontrado != null) //si e
                    {
                        if (!productoEncontrado.Activo)
                        {
                            return $"No se puede vender el producto {productoEncontrado.Nombre} porque está inactivo";
                        }

                        // Validar stock
                        if (productoEncontrado.Stock < detalleVenta.Cantidad)
                        {
                            return $"Stock insuficiente del producto: {productoEncontrado.Nombre}. Stock disponible: {productoEncontrado.Stock}";
                        }

                        // Cálculo de negocio
                        detalleVenta.Subtotal = detalleVenta.Cantidad * detalleVenta.PrecioUnitario;

                        // Reducir stock
                        productoEncontrado.Stock -= detalleVenta.Cantidad;

                        try
                        {
                            // Agregar el detalle de venta y actualizar stock
                            Context.Instancia.DetallesNotaVenta.Add(detalleVenta);
                            int insertados = Context.Instancia.SaveChanges();

                            if (insertados > 0)
                            {
                                return "El detalle de nota de venta se agregó correctamente";
                            }
                            else
                            {
                                // Si falla la inserción, revertir la reducción del stock
                                productoEncontrado.Stock += detalleVenta.Cantidad;
                                Context.Instancia.SaveChanges();
                                return "El detalle de nota de venta no se ha podido agregar";
                            }
                        }
                        catch (Exception)
                        {
                            // Si ocurre un error, revertir la reducción del stock
                            productoEncontrado.Stock += detalleVenta.Cantidad;
                            Context.Instancia.SaveChanges();
                            throw;
                        }
                    }
                    else
                    {
                        return "El producto no existe";
                    }
                }
                return "El detalle de nota de venta ya existe";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarDetalleNotaVenta(DetalleNotaVenta detalleVenta)
        {
            try
            {
                var listaDetalles = Context.Instancia.DetallesNotaVenta.ToList().AsReadOnly();
                var detalleEncontrado = listaDetalles.FirstOrDefault(d => d.DetalleNotaVentaId == detalleVenta.DetalleNotaVentaId);

                if (detalleEncontrado != null)
                {
                    Context.Instancia.DetallesNotaVenta.Update(detalleVenta);
                    int insertados = Context.Instancia.SaveChanges();

                    if (insertados > 0)
                    {
                        return "El detalle de nota de venta se modificó correctamente";
                    }
                    else return "El detalle de nota de venta no se ha podido modificar";
                }
                else
                {
                    return "El detalle de nota de venta no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        // Al inicio de la clase ControladoraProducto
        private static HashSet<int> productosNotificados = new HashSet<int>();

        public void VerificarStockBajo(Usuario usuario)
        {
            try
            {
                var listaProductos = Context.Instancia.Productos.ToList().AsReadOnly();
                var productos = listaProductos
                    .Where(p => p.Activo && p.Stock < 5)
                    .Where(p => !productosNotificados.Contains(p.ProductoId))
                    .ToList();

                if (productos.Any())
                {
                    StringBuilder htmlProductos = new StringBuilder();
                    foreach (var producto in productos)
                    {
                        // Color rojo para stock 0, amarillo para stock bajo
                        string colorFondo = producto.Stock == 0 ? "#ffcccc" : "#fff3cd";

                        htmlProductos.Append($@"
                <tr style='background-color: {colorFondo}'>
                    <td style='padding: 8px; border: 1px solid #ddd;'>{producto.Codigo}</td>
                    <td style='padding: 8px; border: 1px solid #ddd;'>{producto.Nombre}</td>
                    <td style='padding: 8px; border: 1px solid #ddd;'>{producto.Stock}</td>
                    <td style='padding: 8px; border: 1px solid #ddd;'>{producto.Categoria}</td>
                </tr>");

                        // Marcar como notificado
                        productosNotificados.Add(producto.ProductoId);
                    }

                    string htmlBody = $@"
            <html>
            <head>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        line-height: 1.6;
                        margin: 0;
                        padding: 0;
                        color: #333333;
                    }}
                    .container {{
                        max-width: 800px;
                        margin: 20px auto;
                        border: 1px solid #ccc;
                        border-radius: 8px;
                        overflow: hidden;
                    }}
                    .header {{
                        background-color: #2b3e4f;
                        color: white;
                        padding: 20px;
                        text-align: center;
                        font-family: Magneto, sans-serif;
                    }}
                    .content {{
                        padding: 30px 40px;
                        background-color: #ffffff;
                    }}
                    table {{
                        width: 100%;
                        border-collapse: collapse;
                        margin: 20px 0;
                    }}
                    th {{
                        background-color: #2b3e4f;
                        color: white;
                        padding: 12px 8px;
                        text-align: left;
                        border: 1px solid #ddd;
                    }}
                    .warning {{
                        margin-top: 20px;
                        padding: 10px;
                        background-color: #fff3cd;
                        border: 1px solid #ffeeba;
                        border-radius: 4px;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>
                        <h1>Metallon S.R.L</h1>
                    </div>
                    <div class='content'>
                        <h2>Alerta de Stock Bajo</h2>
                        <p>Estimado/a {usuario.NombreyApellido},</p>
                        <p>Se han detectado los siguientes productos con stock bajo:</p>
                        <table>
                            <thead>
                                <tr>
                                    <th>Código</th>
                                    <th>Nombre</th>
                                    <th>Stock</th>
                                    <th>Categoría</th>
                                </tr>
                            </thead>
                            <tbody>
                                {htmlProductos}
                            </tbody>
                        </table>
                        <div class='warning'>
                            <strong>Nota:</strong>
                            <br>- Productos en rojo: Sin stock (0 unidades)
                            <br>- Productos en amarillo: Stock bajo (menos de 5 unidades)
                        </div>
                    </div>
                </div>
            </body>
            </html>";

                    SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
                    string emailEmisor = "tesisdyl@gmail.com";
                    string passwordApp = "kvjj xyle iscg gbic";

                    server.Credentials = new NetworkCredential(emailEmisor, passwordApp);
                    server.EnableSsl = true;

                    MailMessage correoElectronico = new MailMessage();
                    correoElectronico.From = new MailAddress(emailEmisor, "Metallon S.R.L");
                    correoElectronico.Subject = "Alerta de Stock Bajo - Metallon S.R.L";
                    correoElectronico.Body = htmlBody;
                    correoElectronico.IsBodyHtml = true;
                    correoElectronico.To.Add(new MailAddress(usuario.Email));

                    server.Send(correoElectronico);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al enviar notificación de stock bajo: {ex.Message}");
                throw;
            }
        }

    }
}
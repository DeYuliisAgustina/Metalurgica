using Entidades;
using Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Controladora
{
    public class ControladoraSeguridad
    {
        Context context;

        private ControladoraSeguridad()
        {
            context = new Context();
        }

        private static ControladoraSeguridad instancia;

        public static ControladoraSeguridad Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraSeguridad();
                return instancia;
            }
        }

        public ReadOnlyCollection<Usuario> RecuperarUsuarios()
        {
            Context.Instancia.Usuarios.ToList().AsReadOnly();
            return Context.Instancia.Usuarios.ToList().AsReadOnly();
        }

        //RECUPERAR ESTADOS DE USUARIO
        public ReadOnlyCollection<EstadoUsuario> RecuperarEstadosUsuario()
        {
            Context.Instancia.EstadoUsuarios.ToList().AsReadOnly();
            return Context.Instancia.EstadoUsuarios.ToList().AsReadOnly();
        }

        //RECUPERAR ESTADOS DE GRUPO
        public ReadOnlyCollection<EstadoGrupo> RecuperarEstadosGrupo()
        {
            Context.Instancia.EstadoGrupos.ToList().AsReadOnly();
            return Context.Instancia.EstadoGrupos.ToList().AsReadOnly();
        }

        // MÉTODOS DE GRUPO
        public ReadOnlyCollection<Grupo> RecuperarGrupos()
        {
            Context.Instancia.Grupos.ToList().AsReadOnly();
            return Context.Instancia.Grupos.ToList().AsReadOnly();
        }

        public ReadOnlyCollection<Accion> RecuperarAcciones()
        {
            Context.Instancia.Acciones.ToList().AsReadOnly();
            return Context.Instancia.Acciones.ToList().AsReadOnly();
        }


        public ReadOnlyCollection<Administrador> RecuperarAdministradores()
        {
            Context.Instancia.Administradores.ToList().AsReadOnly();
            return Context.Instancia.Administradores.ToList().AsReadOnly();
        }

        public string IniciarSesion(Usuario usuario)
        {
            try
            {
                var listaUsuarios = Context.Instancia.Usuarios
                    .Include(u => u.Perfil)
                    .Include(u => u.EstadoUsuario)
                    .ToList()
                    .AsReadOnly();

                var usuarioEncontrado = listaUsuarios.FirstOrDefault(u => u.NombreUsuario.ToLower() == usuario.NombreUsuario.ToLower());

                if (usuarioEncontrado == null)
                {
                    return "Usuario o contraseña incorrectos";
                }

                if (HashPassword(usuario.Clave) != usuarioEncontrado.Clave)
                {
                    return "Usuario o contraseña incorrectos";
                }

                if (usuarioEncontrado.EstadoUsuario.Nombre.ToLower() != "activo")
                {
                    return "El usuario no está activo";
                }

                usuario.UsuarioId = usuarioEncontrado.UsuarioId;
                usuario.NombreUsuario = usuarioEncontrado.NombreUsuario;
                usuario.Email = usuarioEncontrado.Email;
                usuario.NombreyApellido = usuarioEncontrado.NombreyApellido;
                usuario.EstadoUsuario = usuarioEncontrado.EstadoUsuario;
                usuario.Perfil = usuarioEncontrado.Perfil;

                return "Inicio de sesión exitoso";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string CambiarClave(Usuario usuario, string claveNueva, string confirmacionClave)
        {
            try
            {
                if (claveNueva != confirmacionClave)
                    return "Las claves no coinciden";

                if (!ValidarFormatoClave(claveNueva))
                    return "La clave no cumple con los requisitos de seguridad";

                var listaUsuarios = RecuperarUsuarios();
                var usuarioExistente = listaUsuarios.FirstOrDefault(u =>
                    u.UsuarioId == usuario.UsuarioId);

                if (usuarioExistente == null)
                    return "Usuario no encontrado";

                usuarioExistente.Clave = HashPassword(claveNueva);
                int modificados = Context.Instancia.SaveChanges();
                return modificados > 0 ? "Clave modificada exitosamente" : "No se pudo modificar la clave";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string RecuperarClave(Usuario usuario)
        {
            try
            {
                var listaUsuarios = Context.Instancia.Usuarios.ToList().AsReadOnly();
                var usuarioExistente = listaUsuarios.FirstOrDefault(u =>
                    u.NombreUsuario.ToLower() == usuario.NombreUsuario.ToLower() &&
                    u.Email.ToLower() == usuario.Email.ToLower());

                if (usuarioExistente == null)
                    return "Usuario no encontrado";

                string nuevaClave = GenerarClaveAleatoria();
                usuarioExistente.Clave = HashPassword(nuevaClave);

                int modificados = Context.Instancia.SaveChanges();
                if (modificados > 0)
                {
                    EnviarClaveEmail(usuarioExistente.Email, usuarioExistente.NombreUsuario, nuevaClave);
                    return "La nueva clave ha sido enviada a su email";
                }
                return "No se pudo recuperar la clave";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ResetearClave(Usuario usuario)
        {
            try
            {
                var usuarioEncontrado = Context.Instancia.Usuarios
                    .Include(u => u.EstadoUsuario)
                    .FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);

                if (usuarioEncontrado == null)
                    return "Usuario no encontrado";

                if (usuarioEncontrado.EstadoUsuario.Nombre != "Activo")
                    return "Usuario inactivo";

                if (string.IsNullOrEmpty(usuarioEncontrado.Email))
                    return "El usuario no tiene email registrado";

                // Generate and set new random password
                string nuevaClave = GenerarClaveAleatoria();
                usuarioEncontrado.Clave = HashPassword(nuevaClave);

                int insertados = Context.Instancia.SaveChanges();
                if (insertados > 0)
                {
                    EnviarClaveEmail(usuarioEncontrado.Email, usuarioEncontrado.NombreUsuario, nuevaClave);
                    return "La nueva clave ha sido enviada al email del usuario";
                }

                return "No se ha podido resetear la clave";
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string AgregarUsuario(Usuario usuario)
        {
            try
            {
                string clave = GenerarClaveAleatoria();
                usuario.Clave = HashPassword(clave);
                var listaUsuarios = Context.Instancia.Usuarios.ToList().AsReadOnly();
                var usuarioEncontrado = listaUsuarios.FirstOrDefault(x => x.NombreUsuario.ToLower() == usuario.NombreUsuario.ToLower());
                if (usuarioEncontrado == null)
                {
                    var emailEncontrado = listaUsuarios.FirstOrDefault(x => x.Email.ToLower() == usuario.Email.ToLower());
                    if (emailEncontrado == null)
                    {
                        Context.Instancia.Usuarios.Add(usuario);
                        int insertados = Context.Instancia.SaveChanges();
                        if (insertados > 0)
                        {
                            EnviarClaveEmail(usuario.Email, usuario.NombreUsuario, clave);
                            return $"El usuario se registró correctamente. Se envió un email con la clave de acceso.";
                        }
                        else
                        {
                            return $"El usuario no se ha podido registrar";
                        }
                    }
                    else
                    {
                        return $"Ya existe un usuario registrado con ese Email.";
                    }
                }
                else
                {
                    return $"Ya existe un usuario registrado con ese nombre. Piense en otro nombre de usuario.";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en AgregarUsuario: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                return $"Error desconocido: {ex.Message}"; // Temporalmente mostramos el mensaje de error
            }
        }


        public string ModificarUsuario(Usuario usuario)
        {
            try
            {
                var listaUsuarios = Context.Instancia.Usuarios.ToList().AsReadOnly();
                var usuarioEncontrado = listaUsuarios.FirstOrDefault(u => u.NombreUsuario.ToLower() == u.NombreUsuario.ToLower());
                if (usuarioEncontrado != null)
                {
                    Context.Instancia.Usuarios.Update(usuario);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El usuario se modificó correctamente";
                    }
                    else return $"El usuario no se ha podido modificar";
                }
                else
                {
                    return $"El usuario ya existe";
                }

            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarUsuario(Usuario usuario)
        {
            try
            {
                var listaUsuarios = Context.Instancia.Usuarios.ToList().AsReadOnly();
                var usuarioEncontrado = listaUsuarios.FirstOrDefault(u => u.NombreUsuario.ToLower() == u.NombreUsuario.ToLower());
                if (usuarioEncontrado != null)
                {
                    Context.Instancia.Usuarios.Remove(usuario);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El usuario se eliminó correctamente";
                    }
                    else return $"El usuario no se ha podido eliminar";
                }
                else
                {
                    return $"El usuario ya existe";
                }

            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string AgregarGrupo(Grupo grupo)
        {
            try
            {
                var listaGrupos = Context.Instancia.Grupos.ToList().AsReadOnly();
                var grupoExistente = listaGrupos.FirstOrDefault(g => g.Nombre.ToLower() == grupo.Nombre.ToLower() || g.Codigo.ToLower() == grupo.Codigo.ToLower() || g.ComponenteId == grupo.ComponenteId);
                if (grupoExistente == null)
                {
                    Context.Instancia.Grupos.Add(grupo);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El grupo se agregó correctamente";
                    }
                    else return $"El grupo no se ha podido agregar";
                }
                else
                {
                    return $"El grupo ya existe";
                }

            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarGrupo(Grupo grupo)
        {
            try
            {
                var listaGrupos = Context.Instancia.Grupos.ToList().AsReadOnly();
                var grupoExistente = listaGrupos.FirstOrDefault(g => g.GrupoId == grupo.GrupoId || g.Nombre.ToLower() == grupo.Nombre.ToLower());
                if (grupoExistente != null)
                {
                    Context.Instancia.Grupos.Update(grupo);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El grupo se modifico correctamente";
                    }
                    else return $"El grupo no se ha podido modificar";
                }
                else
                {
                    return $"El grupo ya existe";
                }

            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarGrupo(Grupo grupo)
        {
            try
            {
                var listaGrupos = Context.Instancia.Grupos.ToList().AsReadOnly();
                var grupoExistente = listaGrupos.FirstOrDefault(g => g.GrupoId == grupo.GrupoId || g.Nombre.ToLower() == grupo.Nombre.ToLower());
                if (grupoExistente != null)
                {
                    Context.Instancia.Grupos.Remove(grupo);
                    int insertados = Context.Instancia.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El grupo se elimino correctamente";
                    }
                    else return $"El grupo no se ha podido eliminar";
                }
                else
                {
                    return $"El grupo ya existe";
                }

            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool ValidarFormatoClave(string clave)
        {
            if (clave.Length < 8) return false;
            if (!clave.Any(char.IsUpper)) return false;
            if (!clave.Any(char.IsLower)) return false;
            if (!clave.Any(char.IsDigit)) return false;
            if (!clave.Any(ch => !char.IsLetterOrDigit(ch))) return false;
            return true;
        }

        private string GenerarClaveAleatoria()
        {
            const string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string minusculas = "abcdefghijklmnopqrstuvwxyz";
            const string numeros = "0123456789";
            const string especiales = "*#$@!";

            var random = new Random();
            var password = new StringBuilder();

            // Asegurar requisitos mínimos
            password.Append(mayusculas[random.Next(mayusculas.Length)]);
            password.Append(minusculas[random.Next(minusculas.Length)]);
            password.Append(numeros[random.Next(numeros.Length)]);
            password.Append(especiales[random.Next(especiales.Length)]);

            // Completar hasta 12 caracteres
            const string todosCaracteres = mayusculas + minusculas + numeros + especiales;
            while (password.Length < 12)
            {
                password.Append(todosCaracteres[random.Next(todosCaracteres.Length)]);
            }

            // Mezclar caracteres
            return new string(password.ToString().ToCharArray().OrderBy(x => random.Next()).ToArray());
        }

        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification,
            System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            // Omite validaciones del certificado SSL
            return true;
        }

        public static void EnviarClaveEmail(string email, string nombreUsuario, string clave)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Iniciando envío de email a {email}");

                SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
                string emailEmisor = "tesisdyl@gmail.com";
                string passwordApp = "kvjj xyle iscg gbic";

                server.Credentials = new NetworkCredential(emailEmisor, passwordApp);
                server.EnableSsl = true;

                MailMessage correoElectronico = new MailMessage();
                correoElectronico.From = new MailAddress(emailEmisor, "Metallon S.R.L");
                correoElectronico.Subject = "Nueva clave de acceso - Metallon S.R.L";

                #region html
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
                            max-width: 500px;
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
                        .header h1 {{
                            margin: 0;
                            font-size: 28px;
                        }}
                        .content {{
                            padding: 30px 40px;
                            background-color: #ffffff;
                        }}
                        .content h2 {{
                            color: #333;
                            margin-top: 0;
                        }}
                        .password-box {{
                            background-color: #e8f4ff;
                            border: 3px solid #2b3e4f;
                            border-radius: 8px;
                            padding: 15px;
                            margin: 25px 0;
                            text-align: center;
                            font-size: 18px;
                            box-shadow: 0 4px 8px rgba(0,0,0,0.2);
                        }}
                        .password-box strong {{
                            color: #2b3e4f;
                            display: block;
                            margin-bottom: 5px;
                        }}
                        .warning {{
                            color: #721c24;
                            background-color: #f8d7da;
                            border: 1px solid #f5c6cb;
                            padding: 10px;
                            border-radius: 4px;
                            margin: 20px 0;
                            font-size: 14px;
                        }}
                        .bottom-info {{
                            background-color: #f8f9fa;
                            padding: 15px;
                            text-align: center;
                            font-size: 12px;
                            color: #666666;
                            border-top: 1px solid #dee2e6;
                        }}
                        @media screen and (max-width: 600px) {{
                            .container {{
                                margin: 0;
                                border-radius: 0;
                                width: 100%;
                            }}
                            .content {{
                                padding: 15px;
                            }}
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>Metallon S.R.L</h1>
                        </div>
                        <div class='content'>
                            <h2>¡Hola {nombreUsuario}!</h2>
                            <p>Se ha generado una nueva clave de acceso para su cuenta.</p>
                            <div class='password-box'>
                                <strong>Su nueva clave es:</strong><br>
                                {clave}
                            </div>
                            <div class='warning'>
                                <strong>¡Importante!</strong><br>
                                Por motivos de seguridad, le recomendamos cambiar esta clave la próxima vez que inicie sesión.
                            </div>
                            <p>Si usted no solicitó este cambio, por favor contacte al administrador del sistema inmediatamente.</p>
                        </div>
                        <div class='bottom-info'>
                            Este es un correo automático, por favor no responda a este mensaje.<br>
                            © {DateTime.Now.Year} Metallon S.R.L - Todos los derechos reservados
                        </div>
                    </div>
                </body>
                </html>";

                correoElectronico.Body = htmlBody;
                correoElectronico.IsBodyHtml = true;
                correoElectronico.To.Add(new MailAddress(email));
                #endregion

                System.Diagnostics.Debug.WriteLine("Configuración de email completada, intentando enviar...");
                server.Send(correoElectronico);
                System.Diagnostics.Debug.WriteLine("Email enviado exitosamente");
            }
            catch (SmtpException smtpEx)
            {
                System.Diagnostics.Debug.WriteLine($"Error SMTP al enviar el email: {smtpEx.Message}");
                System.Diagnostics.Debug.WriteLine($"Status Code: {smtpEx.StatusCode}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {smtpEx.StackTrace}");
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error general al enviar el email: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                throw;
            }
        }

        public ReadOnlyCollection<AuditoriaSesion> RecuperarAuditoriasSesion()
        {
            return Context.Instancia.AuditoriasSesion
                .Include(a => a.Usuario)
                .OrderByDescending(a => a.FechaInicio)
                .ToList()
                .AsReadOnly();
        }

        public void RegistrarInicioSesion(Usuario usuario)
        {
            var auditoria = new AuditoriaSesion
            {
                UsuarioId = usuario.UsuarioId,
                FechaInicio = DateTime.Now
            };

            Context.Instancia.AuditoriasSesion.Add(auditoria);
            Context.Instancia.SaveChanges();
        }

        public void RegistrarCierreSesion(Usuario usuario)
        {
            var ultimaSesion = Context.Instancia.AuditoriasSesion
                .Where(a => a.UsuarioId == usuario.UsuarioId && !a.FechaFin.HasValue)
                .OrderByDescending(a => a.FechaInicio)
                .FirstOrDefault();

            if (ultimaSesion != null)
            {
                ultimaSesion.FechaFin = DateTime.Now;
                Context.Instancia.SaveChanges();
            }

        }
    }
}
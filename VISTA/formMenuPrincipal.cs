using Controladora;
using Entidades.Seguridad;
using System.Runtime.InteropServices;
using VISTA.Negocio_Forms;
using VISTA.Negocio_Forms.Compras;
using VISTA.Negocio_Forms.Proveedores;
using VISTA.Negocio_Forms.Ventas;
using VISTA.Seguridad;
using VISTA.UI_Admin;

namespace VISTA
{
    public partial class formMenuPrincipal : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formMenuPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion


        public formMenuPrincipal()
        {
            InitializeComponent();
            ConfigurarVisibilidadBtnSeguridad();
            ConfigurarPermisosMenus();
        }

        #region Configurar permisos
        private void ConfigurarPermisosMenus()
        {
            // Ocultar todos los botones inicialmente
            OcultarTodosLosBotones();

            var usuario = formInicioSesion.UsuarioActual;
            if (usuario == null) return;

            // Si es Admin, mostrar todo
            if (usuario.NombreUsuario == "Admin")
            {
                MostrarTodosLosBotones();
                return;
            }

            // Para usuario normal, mostrar según sus permisos
            foreach (var componente in usuario.Perfil)
            {
                if (componente is Accion accion)
                {
                    MostrarBotonSegunAccion(accion.Nombre);
                }
                else if (componente is Grupo grupo)
                {
                    foreach (var accionGrupo in grupo.Hijos)
                    {
                        if (accionGrupo is Accion accionDelGrupo)
                        {
                            MostrarBotonSegunAccion(accionDelGrupo.Nombre);
                        }
                    }
                }
            }
        }

        private void OcultarTodosLosBotones()
        {
            btnCrearNotaCompra.Visible = false;
            btnHistorialCompras.Visible = false;
            btnCrearNotaVenta.Visible = false;
            btnHistorialVentas.Visible = false;
            btnCrearProductos.Visible = false;
            btnStock.Visible = false;
            btnProveedores.Visible = false;
            btnClientes.Visible = false;
            btnAnaliticas.Visible = false;
        }

        private void MostrarTodosLosBotones()
        {
            btnCrearNotaCompra.Visible = true;
            btnHistorialCompras.Visible = true;
            btnCrearNotaVenta.Visible = true;
            btnHistorialVentas.Visible = true;
            btnCrearProductos.Visible = true;
            btnStock.Visible = true;
            btnProveedores.Visible = true;
            btnClientes.Visible = true;
            btnAnaliticas.Visible = true;
        }

        private void MostrarBotonSegunAccion(string nombreAccion)
        {
            switch (nombreAccion)
            {
                case "Crear Compra": btnCrearNotaCompra.Visible = true; break;
                case "Ver Listado Compras": btnHistorialCompras.Visible = true; break;
                case "Crear Venta": btnCrearNotaVenta.Visible = true; break;
                case "Ver Listado Ventas": btnHistorialVentas.Visible = true; break;
                case "Agregar Producto": btnCrearProductos.Visible = true; break;
                case "Ver Listado Productos": btnStock.Visible = true; break;
                case "Ver Listado Proveedores": btnProveedores.Visible = true; break;
                case "Ver Listado Clientes": btnClientes.Visible = true; break;
                case "Ver Analíticas": btnAnaliticas.Visible = true; break;
            }
        }
        #endregion

        #region Visibilidad Botón Seguridad Admin
        private void ConfigurarVisibilidadBtnSeguridad()
        {
            // Verificar si hay un usuario actual
            if (formInicioSesion.UsuarioActual != null)
            {
                // El botón solo será visible si el usuario es "Admin"
                if (formInicioSesion.UsuarioActual.NombreUsuario == "Admin")
                {
                    btnSeguridad.Visible = true;
                    lblAdminoUsuario.Text = "Administrador";
                }
                else
                {
                    btnSeguridad.Visible = false;
                    lblAdminoUsuario.Text = "Usuario";
                    lblNombreyApellidoUsuario.Text = formInicioSesion.UsuarioActual.NombreyApellido.ToString();
                }
            }
            else
            {
                btnSeguridad.Visible = false; // Si no hay usuario, ocultar el botón
                lblAdminoUsuario.Text = ""; // Dejar el label vacío si no hay usuario
            }
        }
        #endregion

        #region Control SubMenus
        bool menuAbiertoCompras = false;
        bool menuAbiertoVentas = false;
        bool menuAbiertoProductos = false;
        bool menuAbiertoMiPerfil = false;

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            // Cerrar todos los menús excepto el actual
            if (menuActual == "Productos")
            {
                // Cerrar Compras si está abierto
                if (menuAbiertoCompras)
                {
                    menuContainerCompras.Height -= 10;
                    if (menuContainerCompras.Height <= 61)
                    {
                        menuAbiertoCompras = false;
                    }
                }
                // Cerrar Ventas si está abierto
                if (menuAbiertoVentas)
                {
                    menuContainerVentas.Height -= 10;
                    if (menuContainerVentas.Height <= 61)
                    {
                        menuAbiertoVentas = false;
                    }
                }
                // Manejar el menú de Productos
                if (!menuAbiertoProductos)
                {
                    menuContainerProductos.Height += 10;
                    if (menuContainerProductos.Height >= 185)
                    {
                        menuTransition.Stop();
                        menuAbiertoProductos = true;
                    }
                }
                else
                {
                    menuContainerProductos.Height -= 10;
                    if (menuContainerProductos.Height <= 61)
                    {
                        menuTransition.Stop();
                        menuAbiertoProductos = false;
                    }
                }
            }
            else if (menuActual == "Compras")
            {
                // Cerrar Productos si está abierto
                if (menuAbiertoProductos)
                {
                    menuContainerProductos.Height -= 10;
                    if (menuContainerProductos.Height <= 61)
                    {
                        menuAbiertoProductos = false;
                    }
                }
                // Cerrar Ventas si está abierto
                if (menuAbiertoVentas)
                {
                    menuContainerVentas.Height -= 10;
                    if (menuContainerVentas.Height <= 61)
                    {
                        menuAbiertoVentas = false;
                    }
                }
                // Manejar el menú de Compras
                if (!menuAbiertoCompras)
                {
                    menuContainerCompras.Height += 10;
                    if (menuContainerCompras.Height >= 183)
                    {
                        menuTransition.Stop();
                        menuAbiertoCompras = true;
                    }
                }
                else
                {
                    menuContainerCompras.Height -= 10;
                    if (menuContainerCompras.Height <= 61)
                    {
                        menuTransition.Stop();
                        menuAbiertoCompras = false;
                    }
                }
            }
            else if (menuActual == "Ventas")
            {
                // Cerrar Productos si está abierto
                if (menuAbiertoProductos)
                {
                    menuContainerProductos.Height -= 10;
                    if (menuContainerProductos.Height <= 61)
                    {
                        menuAbiertoProductos = false;
                    }
                }
                // Cerrar Compras si está abierto
                if (menuAbiertoCompras)
                {
                    menuContainerCompras.Height -= 10;
                    if (menuContainerCompras.Height <= 61)
                    {
                        menuAbiertoCompras = false;
                    }
                }
                // Manejar el menú de Ventas
                if (!menuAbiertoVentas)
                {
                    menuContainerVentas.Height += 10;
                    if (menuContainerVentas.Height >= 183)
                    {
                        menuTransition.Stop();
                        menuAbiertoVentas = true;
                    }
                }
                else
                {
                    menuContainerVentas.Height -= 10;
                    if (menuContainerVentas.Height <= 61)
                    {
                        menuTransition.Stop();
                        menuAbiertoVentas = false;
                    }
                }
            }
            else if (menuActual == "MiPerfil")
            {
                // Cerrar Productos si está abierto
                if (menuAbiertoProductos)
                {
                    menuContainerProductos.Height -= 10;
                    if (menuContainerProductos.Height <= 61)
                    {
                        menuAbiertoProductos = false;
                    }
                }
                // Cerrar Compras si está abierto
                if (menuAbiertoCompras)
                {
                    menuContainerCompras.Height -= 10;
                    if (menuContainerCompras.Height <= 61)
                    {
                        menuAbiertoCompras = false;
                    }
                }
                // Cerrar Ventas si está abierto
                if (menuAbiertoVentas)
                {
                    menuContainerVentas.Height -= 10;
                    if (menuContainerVentas.Height <= 36)
                    {
                        menuAbiertoVentas = false;
                    }
                }
                // Manejar el menú de MiPerfil
                if (!menuAbiertoMiPerfil)
                {
                    menuMiPerfilContainer.Height += 10;
                    if (menuMiPerfilContainer.Height >= 110)
                    {
                        menuTransition.Stop();
                        menuAbiertoMiPerfil = true;
                    }
                }
                else
                {
                    menuMiPerfilContainer.Height -= 10;
                    if (menuMiPerfilContainer.Height <= 36)
                    {
                        menuTransition.Stop();
                        menuAbiertoMiPerfil = false;
                    }

                }
            }
        }

        string menuActual = "";
        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (formInicioSesion.UsuarioActual != null)
            {
                ControladoraSeguridad.Instancia.RegistrarCierreSesion(formInicioSesion.UsuarioActual);
            }
            formInicioSesion loginForm = new formInicioSesion();
            loginForm.Show();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Registrar cierre de sesión antes de cerrar
            if (formInicioSesion.UsuarioActual != null)
            {
                ControladoraSeguridad.Instancia.RegistrarCierreSesion(formInicioSesion.UsuarioActual);
            }
        }


        private void btnProductos_Click(object sender, EventArgs e)
        {
            menuActual = "Productos";
            menuTransition.Start();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            menuActual = "Compras";
            menuTransition.Start();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            menuActual = "Ventas";
            menuTransition.Start();
        }

        private void btnMiPerfil_Click(object sender, EventArgs e)
        {
            menuActual = "MiPerfil";
            menuTransition.Start();

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            //abrir formulario de clientesDGV
            formClienteDGV formClientesDGV = new formClienteDGV();
            formClientesDGV.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            formProveedoresDGV formProveedoresDGV = new formProveedoresDGV();
            formProveedoresDGV.ShowDialog();

        }

        private void btnCrearProductos_Click(object sender, EventArgs e)
        {
            //abrir formulario de formProductosAM
            formProductoAM formProductosAM = new formProductoAM();
            formProductosAM.ShowDialog();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            formProductoDGV formProductosDGV = new formProductoDGV();
            formProductosDGV.ShowDialog();

        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            formCambiarClave formCambiarClave = new formCambiarClave();
            formCambiarClave.ShowDialog();

        }

        private void btnHistorialCompras_Click(object sender, EventArgs e)
        {
            formNotasCompra formNotasCompra = new formNotasCompra();
            formNotasCompra.ShowDialog();
        }

        private void btnCrearNotaCompra_Click(object sender, EventArgs e)
        {
            formCrearCompra formCrearCompra = new formCrearCompra();
            formCrearCompra.ShowDialog();
        }

        private void btnHistorialVentas_Click(object sender, EventArgs e)
        {
            formNotasVenta formNotasVenta = new formNotasVenta();
            formNotasVenta.ShowDialog();

        }

        private void btnCrearNotaVenta_Click(object sender, EventArgs e)
        {
            formCrearVenta formCrearVenta = new formCrearVenta();
            formCrearVenta.ShowDialog();
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            formModalSeguridad formModalSeguridad = new formModalSeguridad();
            formModalSeguridad.ShowDialog();
        }

        private void btnMisDatos_Click(object sender, EventArgs e)
        {
            // Obtener el usuario actual que inició sesión
            Usuario usuarioActual = formInicioSesion.UsuarioActual;

            if (usuarioActual != null)
            {
                // Crear una nueva instancia del formUsuario con el usuario actual
                formUsuario frmUsuario = new formUsuario(usuarioActual, true); // Agregar parámetro para modo solo lectura
                frmUsuario.ShowDialog();
            }

        }

        private void btnAuditoriaClientes_Click(object sender, EventArgs e)
        {
            formAuditoriaClientes formAuditoriaClientes = new formAuditoriaClientes();
            formAuditoriaClientes.ShowDialog();
        }

        private void btnAnaliticas_Click(object sender, EventArgs e)
        {
            formGraficoProductos formGraficoProductos = new formGraficoProductos();
            formGraficoProductos.ShowDialog();
        }
    }
}

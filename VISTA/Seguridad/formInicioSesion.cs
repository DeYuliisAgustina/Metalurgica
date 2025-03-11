using Controladora;
using Entidades.Seguridad;
using System.Runtime.InteropServices;

namespace VISTA
{
    public partial class formInicioSesion : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formInicioSesion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        public static Usuario UsuarioActual { get; private set; }

        public formInicioSesion()
        {
            InitializeComponent();
            txtClave.UseSystemPasswordChar = true;
        }

        int bandera = 1;

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreUsuario.Text) || string.IsNullOrEmpty(txtClave.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Usuario usuario = new Usuario
                {
                    NombreUsuario = txtNombreUsuario.Text,
                    Clave = txtClave.Text
                };

                string resultado = ControladoraSeguridad.Instancia.IniciarSesion(usuario);

                if (resultado == "Usuario o contraseña incorrectos")
                {
                    var administradores = ControladoraSeguridad.Instancia.RecuperarAdministradores();
                    var esAdmin = administradores.Any(a => a.NombreUsuario == txtNombreUsuario.Text && a.Clave == txtClave.Text);

                    if (esAdmin)
                    {
                        UsuarioActual = new Usuario
                        {
                            NombreUsuario = txtNombreUsuario.Text,
                            UsuarioId = administradores.First(a => a.NombreUsuario == txtNombreUsuario.Text).UsuarioId
                        };
                        ControladoraSeguridad.Instancia.RegistrarInicioSesion(UsuarioActual);
                        MessageBox.Show($"¡Bienvenido Administrador!", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        formMenuPrincipal formMenuPrincipal = new formMenuPrincipal();
                        formMenuPrincipal.Show();
                        this.Hide();
                        return;
                    }
                }
                if (resultado == "Inicio de sesión exitoso")
                {
                    UsuarioActual = usuario;
                    ControladoraSeguridad.Instancia.RegistrarInicioSesion(UsuarioActual);
                    MessageBox.Show($"¡Bienvenido usuario: {usuario.NombreUsuario}!", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formMenuPrincipal formMenuPrincipal = new formMenuPrincipal();
                    formMenuPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lblOlvidarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formRecuperarClave formRecuperarClave = new formRecuperarClave();
            formRecuperarClave.ShowDialog();
        }

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

        private void btnOjoAbiertoCerrado_Click(object sender, EventArgs e)
        {
            if (bandera == 0)
            {
                btnOjoAbiertoCerrado.BackgroundImage = Properties.Resources.OjoCerrado;
                txtClave.UseSystemPasswordChar = true;
                bandera = 1;

            }
            else
            {
                btnOjoAbiertoCerrado.BackgroundImage = Properties.Resources.OjoAbierto;
                txtClave.UseSystemPasswordChar = false;
                bandera = 0;

            }
        }
    }
}

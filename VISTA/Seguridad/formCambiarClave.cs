using Controladora;
using Entidades.Seguridad;
using System.Runtime.InteropServices;

namespace VISTA
{
    public partial class formCambiarClave : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formCambiarClave_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private Usuario usuarioActual;

        public formCambiarClave()
        {
            InitializeComponent();
            usuarioActual = formInicioSesion.UsuarioActual;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    var usuarioActual = formInicioSesion.UsuarioActual; //uso formInicioSesion.UsuarioActual en vez de usuarioActual para que sea el usuario que se logueó en el inicio de sesión

                    DialogResult result = MessageBox.Show("¿Está seguro de que desea cambiar su contraseña?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var mensaje = ControladoraSeguridad.Instancia.CambiarClave(usuarioActual, txtClaveNueva.Text, txtConfirmarClave.Text);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (mensaje == "Clave modificada exitosamente")
                        {
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar la clave: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtClaveActual.Text))
            {
                MessageBox.Show("El campo Clave Actual no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var listaUsuarios = ControladoraSeguridad.Instancia.RecuperarUsuarios();
            var usuarioEncontrado = listaUsuarios.FirstOrDefault(u => u.UsuarioId == usuarioActual.UsuarioId);

            if (usuarioEncontrado == null || ControladoraSeguridad.Instancia.HashPassword(txtClaveActual.Text) != usuarioEncontrado.Clave)
            {
                MessageBox.Show("La clave actual ingresada es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtClaveNueva.Text))
            {
                MessageBox.Show("El campo Nueva Clave no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtConfirmarClave.Text))
            {
                MessageBox.Show("El campo Confirmar Clave no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtClaveNueva.Text != txtConfirmarClave.Text)
            {
                MessageBox.Show("Las claves no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtClaveNueva.Text.Length < 8 ||
                !txtClaveNueva.Text.Any(char.IsUpper) ||
                !txtClaveNueva.Text.Any(char.IsLower) ||
                !txtClaveNueva.Text.Any(char.IsDigit) ||
                !txtClaveNueva.Text.Any(c => "*#$@!".Contains(c)))
            {
                MessageBox.Show("La clave debe tener al menos 8 caracteres, una mayúscula, una minúscula, un número y un carácter especial (*,#,$,@,!).",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}

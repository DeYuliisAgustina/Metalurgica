using Controladora;
using Entidades.Seguridad;
using System.Runtime.InteropServices;

namespace VISTA
{
    public partial class formRecuperarClave : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formRecuperarClave_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        public formRecuperarClave()
        {
            InitializeComponent();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    Usuario usuario = new Usuario
                    {
                        NombreUsuario = txtNombreUsuario.Text,
                        Email = txtCorreoElectronico.Text
                    };

                    DialogResult result = MessageBox.Show("¿Está seguro que desea recuperar su contraseña?", "Confirmación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var mensaje = ControladoraSeguridad.Instancia.RecuperarClave(usuario);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (mensaje == "La nueva clave ha sido enviada a su email")
                        {
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar la clave: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Validaciones
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                MessageBox.Show("El campo Nombre de Usuario no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtCorreoElectronico.Text))
            {
                MessageBox.Show("El campo Correo Electrónico no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!txtCorreoElectronico.Text.Contains("@") || !txtCorreoElectronico.Text.Contains("."))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion
    }
}

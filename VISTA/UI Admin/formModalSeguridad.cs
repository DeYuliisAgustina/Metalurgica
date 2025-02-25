using System.Runtime.InteropServices;
using VISTA.UI_Admin;

namespace VISTA.Seguridad
{
    public partial class formModalSeguridad : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formModalSeguridad_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        public formModalSeguridad()
        {
            InitializeComponent();
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            formGestionarGrupos formGestionarGrupos = new formGestionarGrupos();
            formGestionarGrupos.ShowDialog();
        }

        private void btnGestionarUsuarios_Click(object sender, EventArgs e)
        {
            formGestionarUsuarios formGestionarUsuarios = new formGestionarUsuarios();
            formGestionarUsuarios.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAuditoriaSesion_Click(object sender, EventArgs e)
        {
            formAuditoriaSesiones frmAuditoriaSesion = new formAuditoriaSesiones();
            frmAuditoriaSesion.ShowDialog();
        }

        private void btnAdministrarBD_Click(object sender, EventArgs e)
        {
            formBackUpoRestBD frmBackUpoRestBD = new formBackUpoRestBD();
            frmBackUpoRestBD.ShowDialog();
        }
    }
}

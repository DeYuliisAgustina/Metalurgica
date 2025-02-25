using Controladora;
using Entidades.Seguridad;
using System.Runtime.InteropServices;
using VISTA.UI_Admin;

namespace VISTA
{
    public partial class formGestionarUsuarios : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formGestionarGrupos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        public formGestionarUsuarios()
        {
            InitializeComponent();
            dgvGestionarUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ActualizarGrilla();
            //columna de clave no visible en la grilla de usuarios para que no se muestre la clave

        }

        private void ActualizarGrilla()
        {
            dgvGestionarUsuarios.DataSource = null;
            dgvGestionarUsuarios.DataSource = ControladoraSeguridad.Instancia.RecuperarUsuarios();
            dgvGestionarUsuarios.Columns["Clave"].Visible = false;

        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            formUsuario formUsuario = new formUsuario();
            formUsuario.ShowDialog();
            ActualizarGrilla();
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvGestionarUsuarios.CurrentRow != null)
            {
                Usuario usuario = (Usuario)dgvGestionarUsuarios.CurrentRow.DataBoundItem;
                formUsuario frmUsuario = new formUsuario(usuario);
                frmUsuario.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario para modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvGestionarUsuarios.SelectedRows.Count > 0)
            {
                var usuarioSeleccionado = (Usuario)dgvGestionarUsuarios.CurrentRow.DataBoundItem;
                var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar el usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    var mensaje = ControladoraSeguridad.Instancia.EliminarUsuario(usuarioSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnResetearUsuario_Click(object sender, EventArgs e)
        {
            if (dgvGestionarUsuarios.SelectedRows.Count > 0)
            {
                var usuarioSeleccionado = (Usuario)dgvGestionarUsuarios.CurrentRow.DataBoundItem;
                var confirmacion = MessageBox.Show("¿Está seguro que desea resetear la clave del usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    var mensaje = ControladoraSeguridad.Instancia.ResetearClave(usuarioSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para resetear su clave.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void formGestionarUsuarios_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

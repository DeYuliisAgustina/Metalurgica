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
            CargarComboBoxes();
        }

        private void ActualizarGrilla()
        {
            dgvGestionarUsuarios.DataSource = null;
            dgvGestionarUsuarios.DataSource = ControladoraSeguridad.Instancia.RecuperarUsuarios();
            dgvGestionarUsuarios.Columns["Clave"].Visible = false;
        }

        private void CargarComboBoxes()
        {
            // Cargar estados de usuario
            cmbCargarEstadoUsuario.Items.Clear();
            var estadosUsuario = ControladoraSeguridad.Instancia.RecuperarEstadosUsuario();
            cmbCargarEstadoUsuario.Items.AddRange(estadosUsuario.Select(e => e.Nombre).ToArray());

            // Cargar grupos
            cmbCargarGrupos.Items.Clear();
            var grupos = ControladoraSeguridad.Instancia.RecuperarGrupos();
            cmbCargarGrupos.Items.AddRange(grupos.Select(g => g.Nombre).ToArray());

            cmbNombreUsuarios.Items.Clear();
            var usuarios = ControladoraSeguridad.Instancia.RecuperarUsuarios();
            cmbNombreUsuarios.Items.AddRange(usuarios.Select(u => u.NombreUsuario).ToArray());
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

        private void formGestionarUsuarios_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnRefrescarGrilla_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            ActualizarGrilla();
        }

        private void LimpiarFiltros()
        {
            cmbNombreUsuarios.Text = string.Empty;
            cmbCargarGrupos.SelectedIndex = -1;
            cmbCargarEstadoUsuario.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RealizarBusqueda();

        }

        private void RealizarBusqueda()
        {
            var usuarios = ControladoraSeguridad.Instancia.RecuperarUsuarios().ToList();

            // Filtro por nombre de usuario
            if (!string.IsNullOrEmpty(cmbNombreUsuarios.Text))
            {
                usuarios = usuarios.Where(u => u.NombreUsuario.ToLower().Contains(cmbNombreUsuarios.Text.ToLower())).ToList();
            }

            // Filtro por grupo
            if (!string.IsNullOrEmpty(cmbCargarGrupos.Text))
            {
                usuarios = usuarios.Where(u =>
                    u.Perfil != null &&
                    u.Perfil.Any(p => p.Nombre.ToLower() == cmbCargarGrupos.Text.ToLower())
                ).ToList();
            }

            // Filtro por estado de usuario
            if (!string.IsNullOrEmpty(cmbCargarEstadoUsuario.Text))
            {
                usuarios = usuarios.Where(u =>
                    u.EstadoUsuario != null &&
                    u.EstadoUsuario.Nombre.ToLower() == cmbCargarEstadoUsuario.Text.ToLower()
                ).ToList();
            }

            // Verificar si se encontraron resultados
            if (usuarios.Count == 0)
            {
                string mensaje = "No se encontraron usuarios con los filtros seleccionados.";
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvGestionarUsuarios.DataSource = null;
                return;
            }

            dgvGestionarUsuarios.DataSource = null;
            dgvGestionarUsuarios.DataSource = usuarios;

            //oculto la columna clave
            if (dgvGestionarUsuarios.Columns.Contains("Clave"))
            {
                dgvGestionarUsuarios.Columns["Clave"].Visible = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //pregunto si esta seguro de salir de la ventana
            var confirmacion = MessageBox.Show("¿Está seguro que desea salir de la ventana?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Está seguro que desea salir de la ventana?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

using Controladora;
using Entidades.Seguridad;
using System.Runtime.InteropServices;

namespace VISTA.UI_Admin
{
    public partial class formGestionarGrupos : Form
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

        public formGestionarGrupos()
        {
            InitializeComponent();
            dgvGestionarGrupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvGestionarGrupos.DataSource = null;
            dgvGestionarGrupos.DataSource = ControladoraSeguridad.Instancia.RecuperarEstadosGrupo();
            dgvGestionarGrupos.DataSource = ControladoraSeguridad.Instancia.RecuperarGrupos();

            //borro para prolijidad
            dgvGestionarGrupos.Columns["Asignado"].Visible = false;
            dgvGestionarGrupos.Columns["GrupoId"].Visible = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarGrupo_Click(object sender, EventArgs e)
        {
            formGrupo formGrupo = new formGrupo();
            formGrupo.ShowDialog();
            ActualizarGrilla();
        }

        private void btnModificarGrupo_Click(object sender, EventArgs e)
        {
            if (dgvGestionarGrupos.CurrentRow != null)
            {
                Grupo grupo = (Grupo)dgvGestionarGrupos.CurrentRow.DataBoundItem;
                formGrupo frmGrupo = new formGrupo(grupo);
                frmGrupo.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un grupo para modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarGrupo_Click(object sender, EventArgs e)
        {
            if (dgvGestionarGrupos.SelectedRows.Count > 0)
            {
                var grupoSeleccionado = (Grupo)dgvGestionarGrupos.CurrentRow.DataBoundItem;
                var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar el grupo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    var mensaje = ControladoraSeguridad.Instancia.EliminarGrupo(grupoSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un grupo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void formGestionarGrupos_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}

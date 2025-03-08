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
            CargarComboBoxes();
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

        private void CargarComboBoxes()
        {
            // Cargar estados de grupo
            cmbEstadosGrupo.Items.Clear();
            var estadosGrupo = ControladoraSeguridad.Instancia.RecuperarEstadosGrupo();
            cmbEstadosGrupo.Items.AddRange(estadosGrupo.Select(e => e.Nombre).ToArray());

            // Cargar nombres de grupos
            cmbNombreGrupos.Items.Clear();
            var grupos = ControladoraSeguridad.Instancia.RecuperarGrupos();
            cmbNombreGrupos.Items.AddRange(grupos.Select(g => g.Nombre).ToArray());
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //pregunto si desea salir
            var confirmacion = MessageBox.Show("¿Está seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void RealizarBusqueda()
        {
            var grupos = ControladoraSeguridad.Instancia.RecuperarGrupos().ToList();

            // Filtro por nombre de grupo
            if (!string.IsNullOrEmpty(cmbNombreGrupos.Text))
            {
                grupos = grupos.Where(g => g.Nombre.ToLower().Contains(cmbNombreGrupos.Text.ToLower())).ToList();
            }

            // Filtro por estado de grupo
            if (!string.IsNullOrEmpty(cmbEstadosGrupo.Text))
            {
                grupos = grupos.Where(g => g.EstadoGrupo != null && g.EstadoGrupo.Nombre == cmbEstadosGrupo.Text).ToList();
            }

            // Verificar si se encontraron resultados
            if (grupos.Count == 0)
            {
                string mensaje = "No se encontraron grupos con los filtros seleccionados.";
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvGestionarGrupos.DataSource = null;
                return;
            }

            dgvGestionarGrupos.DataSource = null;
            dgvGestionarGrupos.DataSource = grupos;

            // Ocultar columnas para prolijidad
            dgvGestionarGrupos.Columns["Asignado"].Visible = false;
            dgvGestionarGrupos.Columns["GrupoId"].Visible = false;
        }

        private void LimpiarFiltros()
        {
            cmbNombreGrupos.SelectedIndex = -1;
            cmbEstadosGrupo.SelectedIndex = -1;
        }

        private void btnRefrescarGrilla_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            ActualizarGrilla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RealizarBusqueda();
        }
    }
}

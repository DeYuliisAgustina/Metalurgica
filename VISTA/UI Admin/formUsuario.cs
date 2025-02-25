using Controladora;
using Entidades.Seguridad;
using System.Runtime.InteropServices;

namespace VISTA.UI_Admin
{
    public partial class formUsuario : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formUsuarios_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Atributos privados
        private Usuario usuario;
        private bool modificar = false;
        private List<Grupo> gruposOriginales = new List<Grupo>();
        private List<Accion> accionesOriginales = new List<Accion>();
        private bool soloLectura = false;
        #endregion

        public formUsuario()
        {
            InitializeComponent();
            usuario = new Usuario();
            ConfigurarFormulario();
            CargarDatosIniciales();
        }

        public formUsuario(Usuario usuarioModificar, bool soloLectura = false)
        {
            InitializeComponent();
            usuario = usuarioModificar;
            this.soloLectura = soloLectura;
            modificar = true;
            ConfigurarFormulario();
            CargarDatosIniciales();
        }

        private void formUsuario_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Usuario";
                txtNombreUsuario.Text = usuario.NombreUsuario;
                txtCorreoElectronico.Text = usuario.Email;
                txtNombreApellido.Text = usuario.NombreyApellido;
                cmbCargarEstadosUsuario.SelectedItem = usuario.EstadoUsuario?.Nombre;
            }
            else
            {
                lblAgregaroModificar.Text = "Agregar Usuario";

            }
        }

        #region Configuración DGV para Prolijidad
        private void ConfigurarFormulario()
        {
            tabPage1.Text = "Datos";
            tabPage2.Text = "Grupos";
            tabPage3.Text = "Acciones";

            // Configurar DataGridViews
            ConfigurarDataGridViewGrupos();
            ConfigurarDataGridViewAcciones();

            // Si es modo solo lectura, desactivar controles de edición
            if (soloLectura)
            {
                txtNombreUsuario.ReadOnly = true;
                txtCorreoElectronico.ReadOnly = true;
                txtNombreApellido.ReadOnly = true;
                cmbCargarEstadosUsuario.Enabled = false;
                dgvGrupos.Enabled = false;
                dgvAcciones.Enabled = false;
                btnGuardar.Visible = false;
                btnCancelar.Text = "Cerrar";
                lblAgregaroModificar.Text = "Mis Datos";

                // Deshabilitar checkboxes en los DataGridViews
                if (dgvGrupos.Columns.Contains("Asignado"))
                    dgvGrupos.Columns["Asignado"].ReadOnly = true;
                if (dgvAcciones.Columns.Contains("Asignada"))
                    dgvAcciones.Columns["Asignada"].ReadOnly = true;
            }

            // Suscribir eventos solo si no es modo solo lectura
            if (!soloLectura)
            {
                dgvGrupos.SelectionChanged += DgvGrupos_SelectionChanged;
                dgvGrupos.CellClick += DgvGrupos_CellClick;
                dgvAcciones.CellClick += DgvAcciones_CellClick;
            }
        }

        private void ConfigurarDataGridViewGrupos()
        {
            dgvGrupos.DataSource = null;
            dgvGrupos.DataSource = ControladoraSeguridad.Instancia.RecuperarEstadosGrupo();
            dgvGrupos.DataSource = ControladoraSeguridad.Instancia.RecuperarGrupos();
            dgvGrupos.AutoGenerateColumns = false;
            dgvGrupos.MultiSelect = false;
            dgvGrupos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvGrupos.Columns["GrupoId"].Visible = false;
            dgvGrupos.Columns["ComponenteId"].Visible = false;
        }

        private void ConfigurarDataGridViewAcciones()
        {
            dgvAcciones.DataSource = null;
            dgvAcciones.DataSource = ControladoraSeguridad.Instancia.RecuperarAcciones();
            dgvAcciones.AutoGenerateColumns = false;
            dgvAcciones.MultiSelect = false;
            dgvAcciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        #endregion

        private void CargarDatosIniciales()
        {
            CargarCmb();
            CargarDatosUsuario();
            ActualizarGruposDGV();
            ActualizarAccionesDGV();
        }

        private void CargarCmb()
        {
            foreach (EstadoUsuario estadoUsuario in ControladoraSeguridad.Instancia.RecuperarEstadosUsuario())
            {
                cmbCargarEstadosUsuario.Items.Add(estadoUsuario.Nombre);
            }
        }

        private void CargarDatosUsuario()
        {
            if (modificar)
            {
                txtNombreUsuario.Text = usuario.NombreUsuario;
                txtCorreoElectronico.Text = usuario.Email;
                txtNombreApellido.Text = usuario.NombreyApellido;
                cmbCargarEstadosUsuario.SelectedItem = usuario.EstadoUsuario?.Nombre;
                lblAgregaroModificar.Text = "Modificar Usuario";

                // Guardar estados originales
                gruposOriginales = usuario.Perfil.OfType<Grupo>().ToList();
                accionesOriginales = usuario.Perfil.OfType<Accion>().ToList();
            }
            else
            {
                cmbCargarEstadosUsuario.Items.Add("Seleccione un estado...");
                cmbCargarEstadosUsuario.SelectedItem = "Seleccione un estado...";

                lblAgregaroModificar.Text = "Agregar Usuario";
            }
        }

        #region Carga de datos
        private void ActualizarGruposDGV()
        {
            var grupos = ControladoraSeguridad.Instancia.RecuperarGrupos();
            dgvGrupos.DataSource = null;
            dgvGrupos.DataSource = grupos;

            // Marcar grupos asignados
            foreach (DataGridViewRow row in dgvGrupos.Rows)
            {
                var grupo = row.DataBoundItem as Grupo;
                if (grupo != null)
                {
                    row.Cells["Asignado"].Value = usuario.Perfil.Any(p => p.ComponenteId == grupo.ComponenteId);
                }
            }
        }

        private void ActualizarAccionesDGV(Grupo grupoSeleccionado = null)
        {
            List<Accion> acciones;
            if (grupoSeleccionado != null)
            {
                acciones = grupoSeleccionado.Hijos.OfType<Accion>().ToList();
            }
            else
            {
                acciones = ControladoraSeguridad.Instancia.RecuperarAcciones().ToList();
            }

            dgvAcciones.DataSource = null;
            dgvAcciones.DataSource = acciones;

            // Marcar acciones asignadas
            foreach (DataGridViewRow row in dgvAcciones.Rows)
            {
                var accion = row.DataBoundItem as Accion;
                if (accion != null)
                {
                    row.Cells["Asignada"].Value = usuario.Perfil.Any(p => p.ComponenteId == accion.ComponenteId);
                }
            }
        }
        #endregion

        #region Manejo de checkboxes
        private void DgvGrupos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGrupos.CurrentRow != null && dgvGrupos.CurrentRow.DataBoundItem is Grupo grupoSeleccionado)
            {
                ActualizarAccionesDGV(grupoSeleccionado);
            }
        }

        private void DgvGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvGrupos.Columns["Asignado"].Index)
            {
                var grupo = dgvGrupos.Rows[e.RowIndex].DataBoundItem as Grupo;
                if (grupo != null)
                {
                    bool nuevoValor = !Convert.ToBoolean(dgvGrupos.Rows[e.RowIndex].Cells["Asignado"].Value);
                    dgvGrupos.Rows[e.RowIndex].Cells["Asignado"].Value = nuevoValor;

                    if (nuevoValor)
                    {
                        if (!usuario.Perfil.Contains(grupo))
                        {
                            usuario.AgregarPermiso(grupo);
                            // Agregar también las acciones del grupo
                            foreach (var accion in grupo.Hijos.OfType<Accion>())
                            {
                                if (!usuario.Perfil.Contains(accion))
                                {
                                    usuario.AgregarPermiso(accion);
                                }
                            }
                        }
                    }
                    else
                    {
                        usuario.EliminarPermiso(grupo);
                        // Remover también las acciones del grupo
                        foreach (var accion in grupo.Hijos.OfType<Accion>())
                        {
                            usuario.EliminarPermiso(accion);
                        }
                    }
                    ActualizarAccionesDGV(grupo);
                }
            }
        }

        private void DgvAcciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvAcciones.Columns["Asignada"].Index)
            {
                var accion = dgvAcciones.Rows[e.RowIndex].DataBoundItem as Accion;
                if (accion != null)
                {
                    bool nuevoValor = !Convert.ToBoolean(dgvAcciones.Rows[e.RowIndex].Cells["Asignada"].Value);
                    dgvAcciones.Rows[e.RowIndex].Cells["Asignada"].Value = nuevoValor;

                    if (nuevoValor)
                    {
                        if (!usuario.Perfil.Contains(accion))
                        {
                            usuario.AgregarPermiso(accion);
                        }
                    }
                    else
                    {
                        usuario.EliminarPermiso(accion);
                    }
                }
            }
        }
        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    if (modificar)
                    {
                        DialogResult result = MessageBox.Show("¿Está seguro de que desea modificar el usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            usuario.NombreUsuario = txtNombreUsuario.Text;
                            usuario.Email = txtCorreoElectronico.Text;
                            usuario.NombreyApellido = txtNombreApellido.Text;
                            usuario.EstadoUsuario = ControladoraSeguridad.Instancia.RecuperarEstadosUsuario().FirstOrDefault(e => e.Nombre == cmbCargarEstadosUsuario.SelectedItem.ToString());

                            // Limpiar y actualizar permisos
                            usuario.Perfil.Clear();

                            // Agregar grupos seleccionados
                            foreach (DataGridViewRow row in dgvGrupos.Rows)
                            {
                                if (Convert.ToBoolean(row.Cells["Asignado"].Value))
                                {
                                    var grupo = row.DataBoundItem as Grupo;
                                    if (grupo != null)
                                    {
                                        usuario.AgregarPermiso(grupo);
                                    }
                                }
                            }

                            // Agregar acciones seleccionadas
                            foreach (DataGridViewRow row in dgvAcciones.Rows)
                            {
                                if (Convert.ToBoolean(row.Cells["Asignada"].Value))
                                {
                                    var accion = row.DataBoundItem as Accion;
                                    if (accion != null)
                                    {
                                        usuario.AgregarPermiso(accion);
                                    }
                                }
                            }

                            var mensaje = ControladoraSeguridad.Instancia.ModificarUsuario(usuario);
                            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        usuario.NombreUsuario = txtNombreUsuario.Text;
                        usuario.Email = txtCorreoElectronico.Text;
                        usuario.NombreyApellido = txtNombreApellido.Text;
                        usuario.EstadoUsuario = ControladoraSeguridad.Instancia.RecuperarEstadosUsuario().FirstOrDefault(e => e.Nombre == cmbCargarEstadosUsuario.SelectedItem.ToString());

                        // Limpiar y actualizar permisos
                        usuario.Perfil.Clear();

                        // Agregar grupos seleccionados
                        foreach (DataGridViewRow row in dgvGrupos.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["Asignado"].Value))
                            {
                                var grupo = row.DataBoundItem as Grupo;
                                if (grupo != null)
                                {
                                    usuario.AgregarPermiso(grupo);
                                }
                            }
                        }

                        // Agregar acciones seleccionadas
                        foreach (DataGridViewRow row in dgvAcciones.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["Asignada"].Value))
                            {
                                var accion = row.DataBoundItem as Accion;
                                if (accion != null)
                                {
                                    usuario.AgregarPermiso(accion);
                                }
                            }
                        }

                        var mensaje = ControladoraSeguridad.Instancia.AgregarUsuario(usuario);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (soloLectura)
            {
                this.Close();
            }
            else
            {
                if (MessageBox.Show("¿Está seguro que desea cancelar la operación?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
        }

        #region Validaciones
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                txtNombreUsuario.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNombreApellido.Text))
            {
                MessageBox.Show("Debe ingresar nombre y apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                txtNombreApellido.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCorreoElectronico.Text))
            {
                MessageBox.Show("Debe ingresar un correo electrónico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                txtCorreoElectronico.Focus();
                return false;
            }

            if (cmbCargarEstadosUsuario.SelectedItem == null ||
                cmbCargarEstadosUsuario.SelectedItem.ToString() == "Seleccione un estado...")
            {
                MessageBox.Show("Debe seleccionar un estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                cmbCargarEstadosUsuario.Focus();
                return false;
            }

            bool tieneGrupoSeleccionado = false;
            foreach (DataGridViewRow row in dgvGrupos.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Asignado"].Value))
                {
                    tieneGrupoSeleccionado = true;
                    break;
                }
            }

            if (!tieneGrupoSeleccionado)
            {
                MessageBox.Show("Debe seleccionar al menos un grupo para el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage2;
                return false;
            }

            return true;
        }
        #endregion
    }
}
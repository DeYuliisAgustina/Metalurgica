using Controladora;
using Entidades.Seguridad;
using System.Runtime.InteropServices;

namespace VISTA.UI_Admin
{
    public partial class formGrupo : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formGrupos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private Grupo grupo;
        private bool modificar = false;

        public formGrupo()
        {
            InitializeComponent();
            grupo = new Grupo();
            CargarCmb();
            ActualizarAccionesDGV();
            ConfigurarTabPages();
        }

        public formGrupo(Grupo grupoModificar)
        {
            InitializeComponent();
            grupo = grupoModificar;
            modificar = true;
            CargarCmb();
            ActualizarAccionesDGV();
            ConfigurarTabPages();
        }

        private void formGrupo_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar grupo";

                txtCodigoGrupo.Text = grupo.Codigo.ToString();
                txtNombreGrupo.Text += grupo.Nombre.ToString();
                txtDescripcionGrupo.Text = grupo.Descripcion.ToString();
                cmbCargarEstadoGrupo.SelectedItem = grupo.EstadoGrupo.Nombre.ToString();
            }
            else
            {
                cmbCargarEstadoGrupo.Items.Add("Seleccione un estado...");
                cmbCargarEstadoGrupo.SelectedItem = "Seleccione un estado...";

                lblAgregaroModificar.Text = "Agregar Grupo";
            }
        }

        private void ConfigurarTabPages()
        {
            tabPage1.Text = "Datos";
            tabPage2.Text = "Acciones";
        }

        public void CargarCmb()
        {
            foreach (EstadoGrupo estadoGrupo in ControladoraSeguridad.Instancia.RecuperarEstadosGrupo()) //se recorren los laboratorios y se agregan al cmb
            {
                cmbCargarEstadoGrupo.Items.Add(estadoGrupo.Nombre.ToString());
            }
        }

        #region ActualizarAccionesDGV
        private void ActualizarAccionesDGV()
        {
            dgvAcciones.DataSource = null;
            dgvAcciones.DataSource = ControladoraSeguridad.Instancia.RecuperarAcciones();

            // Configurar el DataGridView
            dgvAcciones.ReadOnly = false;
            dgvAcciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Solo marcar las acciones si estamos modificando un grupo existente
            if (modificar)
            {
                foreach (DataGridViewRow row in dgvAcciones.Rows)
                {
                    var accion = (Accion)row.DataBoundItem;
                    if (grupo.Hijos.Any(h => h.ComponenteId == accion.ComponenteId))
                    {
                        row.Cells["Asignada"].Value = true;
                    }
                    else
                    {
                        row.Cells["Asignada"].Value = false;
                    }
                }
            }
            else
            {
                // Si es un nuevo grupo, asegurarse de que ninguna acción esté marcada
                foreach (DataGridViewRow row in dgvAcciones.Rows)
                {
                    row.Cells["Asignada"].Value = false;
                }
            }

            // Asegurarse de que el evento esté suscrito solo una vez
            dgvAcciones.CellClick -= DgvAcciones_CellClick;
            dgvAcciones.CellClick += DgvAcciones_CellClick;
        }

        private void DgvAcciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se haya hecho clic en la columna "Asignada"
            if (e.RowIndex >= 0 && dgvAcciones.Columns["Asignada"].Index == e.ColumnIndex)
            {
                DataGridViewRow row = dgvAcciones.Rows[e.RowIndex];
                bool currentValue = row.Cells["Asignada"].Value != null && (bool)row.Cells["Asignada"].Value;
                row.Cells["Asignada"].Value = !currentValue;
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
                        DialogResult result = MessageBox.Show("¿Está seguro de que desea modificar el grupo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            grupo.Codigo = txtCodigoGrupo.Text;
                            grupo.Nombre = txtNombreGrupo.Text;
                            grupo.Descripcion = txtDescripcionGrupo.Text;
                            grupo.EstadoGrupo = ControladoraSeguridad.Instancia.RecuperarEstadosGrupo().FirstOrDefault(e => e.Nombre == cmbCargarEstadoGrupo.SelectedItem.ToString());

                            grupo.Hijos.Clear();//limpio las acciones que tenia asignadas antes 

                            foreach (DataGridViewRow row in dgvAcciones.Rows) //recorro las acciones y agrego las que estan seleccionadas
                            {
                                if (row.Cells["Asignada"].Value != null && (bool)row.Cells["Asignada"].Value) //si la accion esta seleccionada la agrego al grupo
                                {
                                    if (row.DataBoundItem is Accion accion) //si la fila es una accion la agrego al grupo
                                    {
                                        grupo.AgregarHijo(accion); //agrego la accion al grupo
                                    }
                                }
                            }

                            var mensaje = ControladoraSeguridad.Instancia.ModificarGrupo(grupo);
                            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        grupo.Codigo = txtCodigoGrupo.Text;
                        grupo.Nombre = txtNombreGrupo.Text;
                        grupo.Descripcion = txtDescripcionGrupo.Text;
                        grupo.EstadoGrupo = ControladoraSeguridad.Instancia.RecuperarEstadosGrupo().FirstOrDefault(e => e.Nombre == cmbCargarEstadoGrupo.SelectedItem.ToString());

                        foreach (DataGridViewRow row in dgvAcciones.Rows)
                        {
                            if (row.Cells["Asignada"].Value != null && (bool)row.Cells["Asignada"].Value)
                            {
                                if (row.DataBoundItem is Accion accion)
                                {
                                    grupo.AgregarHijo(accion);
                                }
                            }
                        }

                        var mensaje = ControladoraSeguridad.Instancia.AgregarGrupo(grupo);
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

        #region Validaciones
        private bool ValidarCampos()
        {
            // Validaciones existentes
            if (string.IsNullOrEmpty(txtCodigoGrupo.Text) || txtCodigoGrupo.Text == "Código del grupo...")
            {
                MessageBox.Show("Debe ingresar un código", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                txtCodigoGrupo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNombreGrupo.Text) || txtNombreGrupo.Text == "Nombre del grupo...")
            {
                MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                txtNombreGrupo.Focus();
                return false;
            }
            if (cmbCargarEstadoGrupo.SelectedItem == null || cmbCargarEstadoGrupo.SelectedItem.ToString() == "Seleccione un estado...")
            {
                MessageBox.Show("El estado del grupo no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                cmbCargarEstadoGrupo.Focus();
                return false;
            }

            // Validar que al menos una acción esté seleccionada
            bool tieneAccionSeleccionada = false;
            foreach (DataGridViewRow row in dgvAcciones.Rows)
            {
                if (row.Cells["Asignada"].Value != null && (bool)row.Cells["Asignada"].Value)
                {
                    tieneAccionSeleccionada = true;
                    break;
                }
            }

            if (!tieneAccionSeleccionada)
            {
                MessageBox.Show("Debe seleccionar al menos una acción para el grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage2;
                return false;
            }

            return true;
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar la carga de datos?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar la carga de datos?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

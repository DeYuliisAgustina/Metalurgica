using Controladora;
using Entidades;
using System.Data;
using System.Runtime.InteropServices;

namespace VISTA.Negocio_Forms.Proveedores
{
    public partial class formProveedoresDGV : Form
    {

        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formProveedoresDGV_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        public formProveedoresDGV()
        {
            InitializeComponent();
            dgvProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ActualizarGrilla();
            FormatoGrillaClientesInactivos();
            CargarFiltros();
        }

        private void ActualizarGrilla()
        {
            dgvProveedor.DataSource = null;
            dgvProveedor.DataSource = ControladoraProveedor.Instancia.RecuperarProveedores();

            foreach (DataGridViewRow row in dgvProveedor.Rows) //recorro todas las filas de la grilla para contar la cantidad de tickets que tiene cada tecnico y mostrarlo en la grilla
            {
                var proveedor = (Proveedor)row.DataBoundItem; //con esto obtengo el objeto proveedor de la fila actual de la grilla y lo guardo en la variable proveedor
                row.Cells["CantidadNotasCompra"].Value = ControladoraProveedor.Instancia.ContarNotasCompraPorProveedor(proveedor);//cuento la cantidad de notas que tiene el proveedor y lo muestro en la grilla en la columna cantidad de notas 
            }
        }

        private void FormatoGrillaClientesInactivos()
        {
            foreach (DataGridViewRow row in dgvProveedor.Rows)
            {
                var proveedor = (Proveedor)row.DataBoundItem;
                if (!proveedor.Activo)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.DarkGray;
                    row.DefaultCellStyle.SelectionBackColor = Color.Gray;
                    row.DefaultCellStyle.SelectionForeColor = Color.LightGray;
                }
            }
        }

        private void CargarFiltros()
        {
            cmbBuscarPor.Items.Clear();
            cmbBuscarPor.Items.AddRange(new string[] {
                "Proveedor Activo",
                "Proveedor Inactivo",
                "Nombre y Apellido",
                "DNI",
                "CUIT",
                "Razón Social"
            });
            cmbBuscarPor.SelectedIndex = 0;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formProveedoresAM formProveedoresAM = new formProveedoresAM();
            formProveedoresAM.ShowDialog();
            ActualizarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.Rows.Count > 0)
            {
                var proveedorSeleccionado = (Proveedor)dgvProveedor.CurrentRow.DataBoundItem;
                formProveedoresAM formProveedoresAM = new formProveedoresAM(proveedorSeleccionado);
                formProveedoresAM.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para modificarlo.");
            }
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.SelectedRows.Count > 0)
            {
                var proveedorSeleccionado = (Proveedor)dgvProveedor.CurrentRow.DataBoundItem;
                if (proveedorSeleccionado.Activo)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea dar de baja al proveedor?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var mensaje = ControladoraProveedor.Instancia.DarBajaProveedor(proveedorSeleccionado);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrilla();
                    }
                }
                else
                {
                    MessageBox.Show("El proveedor ya está dado de baja.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para dar de baja.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.SelectedRows.Count > 0)
            {
                var proveedorSeleccionado = (Proveedor)dgvProveedor.CurrentRow.DataBoundItem;
                if (!proveedorSeleccionado.Activo)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea dar de alta al proveedor?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var mensaje = ControladoraProveedor.Instancia.DarAltaProveedor(proveedorSeleccionado);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrilla();
                    }
                }
                else
                {
                    MessageBox.Show("El proveedor ya está activo.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para dar de alta.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RealizarBusqueda();

        }

        private void btnRefrescarGrilla_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void cmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si selecciona Proveedor Activo o Inactivo, realizar la búsqueda automáticamente
            if (cmbBuscarPor.Text == "Proveedor Activo" || cmbBuscarPor.Text == "Proveedor Inactivo")
            {
                txtTextoBuscar.Clear();
                txtTextoBuscar.Enabled = false;
                RealizarBusqueda();
            }
            else
            {
                txtTextoBuscar.Enabled = true;
            }
        }

        private void RealizarBusqueda()
        {
            if (string.IsNullOrEmpty(cmbBuscarPor.Text))
            {
                MessageBox.Show("Debe seleccionar un filtro de búsqueda", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proveedores = ControladoraProveedor.Instancia.RecuperarProveedores();
            List<Proveedor> filteredProveedores = new List<Proveedor>();

            switch (cmbBuscarPor.Text)
            {
                case "Proveedor Activo":
                    filteredProveedores = ControladoraProveedor.Instancia.RecuperarProveedores(true).ToList();
                    break;

                case "Proveedor Inactivo":
                    filteredProveedores = ControladoraProveedor.Instancia.RecuperarProveedores(false).ToList();
                    break;

                case "Nombre y Apellido":
                    if (!string.IsNullOrEmpty(txtTextoBuscar.Text))
                    {
                        filteredProveedores = proveedores
                            .Where(p => p.NombreyApellido.ToLower()
                            .Contains(txtTextoBuscar.Text.ToLower()))
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un nombre para buscar", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;

                case "DNI":
                    if (!string.IsNullOrEmpty(txtTextoBuscar.Text) && long.TryParse(txtTextoBuscar.Text, out long dni))
                    {
                        filteredProveedores = proveedores
                            .Where(p => p.DNI == dni)
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un DNI válido", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;

                case "CUIT":
                    if (!string.IsNullOrEmpty(txtTextoBuscar.Text))
                    {
                        filteredProveedores = proveedores
                            .Where(p => p.CUIT != null && p.CUIT.Contains(txtTextoBuscar.Text))
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un CUIT para buscar", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;

                case "Razón Social":
                    if (!string.IsNullOrEmpty(txtTextoBuscar.Text))
                    {
                        filteredProveedores = proveedores
                            .Where(p => p.RazonSocial != null && p.RazonSocial.ToLower()
                            .Contains(txtTextoBuscar.Text.ToLower()))
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar una razón social para buscar", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
            }

            // Verificar si se encontraron resultados
            if (filteredProveedores.Count == 0)
            {
                string mensaje = cmbBuscarPor.Text switch
                {
                    "Proveedor Activo" => "No se encontraron proveedores activos",
                    "Proveedor Inactivo" => "No se encontraron proveedores inactivos",
                    "Nombre y Apellido" => $"No se encontraron proveedores con el nombre '{txtTextoBuscar.Text}'",
                    "DNI" => $"No se encontró ningún proveedor con el DNI {txtTextoBuscar.Text}",
                    "CUIT" => $"No se encontró ningún proveedor con el CUIT {txtTextoBuscar.Text}",
                    "Razón Social" => $"No se encontraron proveedores con la razón social '{txtTextoBuscar.Text}'",
                    _ => "No se encontraron resultados"
                };

                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvProveedor.DataSource = null;
            dgvProveedor.DataSource = filteredProveedores;
            FormatoGrillaClientesInactivos();

            // Actualizar el conteo de notas de compra
            foreach (DataGridViewRow row in dgvProveedor.Rows)
            {
                if (row.DataBoundItem is Proveedor proveedor)
                {
                    row.Cells["CantidadNotasCompra"].Value =
                        ControladoraProveedor.Instancia.ContarNotasCompraPorProveedor(proveedor);
                }
            }
        }

        private void txtTextoBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbBuscarPor.Text == "DNI")
            {
                // Solo permitir números y teclas de control
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}

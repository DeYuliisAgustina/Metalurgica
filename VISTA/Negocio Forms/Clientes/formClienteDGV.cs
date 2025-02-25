using Controladora;
using Entidades;
using Entidades.Seguridad;
using System.Data;
using System.Runtime.InteropServices;

namespace VISTA.Negocio_Forms
{
    public partial class formClienteDGV : Form
    {
        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formClienteDGV_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion


        public formClienteDGV()
        {
            InitializeComponent();
            dgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ActualizarGrilla();
            FormatoGrillaClientesInactivos();
            CargarFiltros();
        }


        private void ActualizarGrilla()
        {
            dgvCliente.DataSource = null;
            dgvCliente.DataSource = ControladoraCliente.Instancia.RecuperarClientes();

            foreach (DataGridViewRow row in dgvCliente.Rows) //recorro todas las filas de la grilla para contar la cantidad de tickets que tiene cada tecnico y mostrarlo en la grilla
            {
                var cliente = (Cliente)row.DataBoundItem; //con esto obtengo el objeto tecnico de la fila actual de la grilla y lo guardo en la variable tecnico
                row.Cells["CantidadNotasVenta"].Value = ControladoraCliente.Instancia.ContarNotasVentaPorCliente(cliente);//cuento la cantidad de tickets que tiene el tecnico y lo muestro en la grilla en la columna cantidad de tickets 
            }
        }
        private void CargarFiltros()
        {
            cmbBuscarPor.Items.Clear();
            cmbBuscarPor.Items.AddRange(new string[] {
                "Cliente Activo",
                "Cliente Inactivo",
                "Nombre y Apellido",
                "DNI",
                "Razón Social"
            });
            cmbBuscarPor.SelectedIndex = 0;
        }

        private void cmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si selecciona Cliente Activo o Inactivo, realizar la búsqueda automáticamente
            if (cmbBuscarPor.Text == "Cliente Activo" || cmbBuscarPor.Text == "Cliente Inactivo")
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

            var clientes = ControladoraCliente.Instancia.RecuperarClientes();
            List<Cliente> filtrarClientes = new List<Cliente>();

            switch (cmbBuscarPor.Text)
            {
                case "Cliente Activo":
                    filtrarClientes = ControladoraCliente.Instancia.RecuperarClientes(true).ToList();
                    break;

                case "Cliente Inactivo":
                    filtrarClientes = ControladoraCliente.Instancia.RecuperarClientes(false).ToList();
                    break;

                case "Nombre y Apellido":
                    if (!string.IsNullOrEmpty(txtTextoBuscar.Text))
                    {
                        filtrarClientes = clientes
                            .Where(c => c.NombreyApellido.ToLower()
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
                        filtrarClientes = clientes
                            .Where(c => c.DNI == dni)
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un DNI válido", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;

                case "Razón Social":
                    if (!string.IsNullOrEmpty(txtTextoBuscar.Text))
                    {
                        filtrarClientes = clientes
                            .Where(c => c.RazonSocial != null && c.RazonSocial.ToLower()
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
            if (filtrarClientes.Count == 0)
            {
                string mensaje = cmbBuscarPor.Text switch
                {
                    "Cliente Activo" => "No se encontraron clientes activos",
                    "Cliente Inactivo" => "No se encontraron clientes inactivos",
                    "Nombre y Apellido" => $"No se encontraron clientes con el nombre '{txtTextoBuscar.Text}'",
                    "DNI" => $"No se encontró ningún cliente con el DNI {txtTextoBuscar.Text}",
                    "Razón Social" => $"No se encontraron clientes con la razón social '{txtTextoBuscar.Text}'",
                    _ => "No se encontraron resultados"
                };

                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvCliente.DataSource = null;
            dgvCliente.DataSource = filtrarClientes;
            FormatoGrillaClientesInactivos();

            // Actualizar el conteo de notas de venta
            foreach (DataGridViewRow row in dgvCliente.Rows)
            {
                if (row.DataBoundItem is Cliente cliente)
                {
                    row.Cells["CantidadNotasVenta"].Value =
                        ControladoraCliente.Instancia.ContarNotasVentaPorCliente(cliente);
                }
            }
        }

        private void FormatoGrillaClientesInactivos()
        {
            foreach (DataGridViewRow row in dgvCliente.Rows)
            {
                var cliente = (Cliente)row.DataBoundItem;
                if (!cliente.Activo)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.DarkGray;
                    row.DefaultCellStyle.SelectionBackColor = Color.Gray;
                    row.DefaultCellStyle.SelectionForeColor = Color.LightGray;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RealizarBusqueda();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formClienteAM formClienteAM = new formClienteAM();
            formClienteAM.ShowDialog();
            ActualizarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dgvCliente.CurrentRow.DataBoundItem;
                formClienteAM formClienteAM = new formClienteAM(clienteSeleccionado);
                formClienteAM.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dgvCliente.CurrentRow.DataBoundItem;
                if (!clienteSeleccionado.Activo)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea dar de alta al cliente?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var mensaje = ControladoraCliente.Instancia.DarAltaCliente(clienteSeleccionado, formInicioSesion.UsuarioActual);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrilla();
                    }
                }
                else
                {
                    MessageBox.Show("El cliente ya está activo.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para dar de alta.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dgvCliente.CurrentRow.DataBoundItem;
                if (clienteSeleccionado.Activo)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea dar de baja al cliente?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var mensaje = ControladoraCliente.Instancia.DarBajaCliente(clienteSeleccionado, formInicioSesion.UsuarioActual);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrilla();
                    }
                }
                else
                {
                    MessageBox.Show("El cliente ya está dado de baja.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para dar de baja.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnRefrescarGrilla_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        // Método para manejar el placeholder del TextBox
        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
        }

        // Agregar estos eventos para manejar el placeholder
        private void txtTextoBuscar_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.ForeColor == Color.Gray)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

    }
}

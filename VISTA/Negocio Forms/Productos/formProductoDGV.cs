using Controladora;
using Entidades;
using System.Runtime.InteropServices;
using VISTA.Negocio_Forms.Proveedores;

namespace VISTA.Negocio_Forms
{
    public partial class formProductoDGV : Form
    {

        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formProductoDGV_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Atributos privados
        private bool esParaSeleccion;
        private Producto productoSeleccionado;
        #endregion

        #region Constructor
        public formProductoDGV(bool paraSeleccion = false)
        {
            InitializeComponent();
            ActualizarGrilla();
            CargarFiltros();

            #region es para seleccion
            esParaSeleccion = paraSeleccion;
            if (esParaSeleccion)
            {
                btnModificar.Enabled = false;
                btnAgregar.Enabled = false;
                btnDarAlta.Enabled = false;
                btnDarBaja.Enabled = false;
            }
            #endregion
        }
        #endregion

        #region Actualizar grilla
        private void ActualizarGrilla()
        {
            dgvProducto.DataSource = null;
            dgvProducto.DataSource = ControladoraProducto.Instancia.RecuperarProductos(soloActivos: true);
        }

        private void dgvProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && esParaSeleccion)
            {
                productoSeleccionado = (Producto)dgvProducto.Rows[e.RowIndex].DataBoundItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public Producto ObtenerProductoSeleccionado()
        {
            return productoSeleccionado;
        }
        #endregion

        #region cargar filtros
        private void CargarFiltros()
        {
            cmbBuscarPor.Items.Clear();
            cmbBuscarPor.Items.AddRange(new string[] {
                "Producto Activo",
                "Producto Inactivo",
                "Código",
                "Nombre",
                "Precio",
                "Categoría",
                "Descripción",
                "Stock"
            });
            cmbBuscarPor.SelectedIndex = 0;
        }
        #endregion 

        #region btnAgregar, btnModificar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formProductoAM formProductoAM = new formProductoAM();
            formProductoAM.ShowDialog();
            ActualizarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProducto.Rows.Count > 0)
            {
                var productoSeleccionado = (Producto)dgvProducto.CurrentRow.DataBoundItem;
                formProductoAM formProductoAM = new formProductoAM(productoSeleccionado);
                formProductoAM.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione un producto para modificarlo.");
            }
        }
        #endregion

        #region Formato de grilla semaforizada
        private void FormatoGrillaProductos()
        {
            foreach (DataGridViewRow row in dgvProducto.Rows)
            {
                if (row.Cells["Stock"].Value != null)
                {
                    int stock = Convert.ToInt32(row.Cells["Stock"].Value);
                    if (stock == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 102, 102); // Rojo más intenso
                        row.DefaultCellStyle.ForeColor = Color.White; // Texto blanco para mejor contraste
                    }
                    else if (stock < 5) // Stock bajo
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 153); // Amarillo suave
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else // Stock suficiente
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(144, 238, 144); // Verde claro
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }
        #endregion

        #region btnDarAlta, btnDarBaja
        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            if (dgvProducto.SelectedRows.Count > 0)
            {
                var productoSeleccionado = (Producto)dgvProducto.CurrentRow.DataBoundItem;
                if (!productoSeleccionado.Activo)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea dar de alta al producto?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var mensaje = ControladoraProducto.Instancia.DarAltaProducto(productoSeleccionado);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrilla();
                    }
                }
                else
                {
                    MessageBox.Show("El producto ya está activo.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para dar de alta.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            if (dgvProducto.SelectedRows.Count > 0)
            {
                var productoSeleccionado = (Producto)dgvProducto.CurrentRow.DataBoundItem;
                if (productoSeleccionado.Activo)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea dar de baja al producto?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var mensaje = ControladoraProducto.Instancia.DarBajaProducto(productoSeleccionado);

                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrilla();
                    }
                }
                else
                {
                    MessageBox.Show("El producto ya está dado de baja.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para dar de baja.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region filtro de busqueda
        private void cmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscarPor.Text == "Producto Activo" || cmbBuscarPor.Text == "Producto Inactivo")
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

            var productos = ControladoraProducto.Instancia.RecuperarProductos();
            List<Producto> productosFiltrados = new List<Producto>();

            switch (cmbBuscarPor.Text)
            {
                case "Producto Activo":
                    productosFiltrados = ControladoraProducto.Instancia.RecuperarProductos(true).ToList();
                    break;

                case "Producto Inactivo":
                    productosFiltrados = ControladoraProducto.Instancia.RecuperarProductos(false).ToList();
                    break;

                case "Código":
                    if (!string.IsNullOrEmpty(txtTextoBuscar.Text))
                    {
                        productosFiltrados = productos
                            .Where(p => p.Codigo.ToLower()
                            .Contains(txtTextoBuscar.Text.ToLower()))
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un código para buscar", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;

                case "Nombre":
                    if (!string.IsNullOrEmpty(txtTextoBuscar.Text))
                    {
                        productosFiltrados = productos
                            .Where(p => p.Nombre.ToLower()
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

                case "Precio":
                    if (!string.IsNullOrEmpty(txtTextoBuscar.Text) && decimal.TryParse(txtTextoBuscar.Text, out decimal precio))
                    {
                        productosFiltrados = productos
                            .Where(p => p.Precio == precio)
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un precio válido", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;

                case "Categoría":
                    if (!string.IsNullOrEmpty(txtTextoBuscar.Text))
                    {
                        productosFiltrados = productos
                            .Where(p => p.Categoria.ToLower()
                            .Contains(txtTextoBuscar.Text.ToLower()))
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar una categoría para buscar", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;

                case "Descripción":
                    if (!string.IsNullOrEmpty(txtTextoBuscar.Text))
                    {
                        productosFiltrados = productos
                            .Where(p => p.Descripcion.ToLower()
                            .Contains(txtTextoBuscar.Text.ToLower()))
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar una descripción para buscar", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;

                case "Stock":
                    if (!string.IsNullOrEmpty(txtTextoBuscar.Text) && int.TryParse(txtTextoBuscar.Text, out int stock))
                    {
                        productosFiltrados = productos
                            .Where(p => p.Stock == stock)
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un stock válido", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
            }

            // Verificar si se encontraron resultados
            if (productosFiltrados.Count == 0)
            {
                string mensaje = cmbBuscarPor.Text switch
                {
                    "Producto Activo" => "No se encontraron productos activos",
                    "Producto Inactivo" => "No se encontraron productos inactivos",
                    "Código" => $"No se encontraron productos con el código '{txtTextoBuscar.Text}'",
                    "Nombre" => $"No se encontraron productos con el nombre '{txtTextoBuscar.Text}'",
                    "Precio" => $"No se encontraron productos con el precio {txtTextoBuscar.Text}",
                    "Categoría" => $"No se encontraron productos en la categoría '{txtTextoBuscar.Text}'",
                    "Descripción" => $"No se encontraron productos con la descripción '{txtTextoBuscar.Text}'",
                    "Stock" => $"No se encontraron productos con el stock {txtTextoBuscar.Text}",
                    _ => "No se encontraron resultados"
                };

                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvProducto.DataSource = null;
            dgvProducto.DataSource = productosFiltrados;
            FormatoGrillaProductos();
        }

        private void txtTextoBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números para Precio y Stock
            if (cmbBuscarPor.Text == "Precio" || cmbBuscarPor.Text == "Stock")
            {
                // Permitir números, punto decimal (para precio) y teclas de control
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (cmbBuscarPor.Text == "Stock" || e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // Evitar múltiples puntos decimales para Precio
                if (cmbBuscarPor.Text == "Precio" && e.KeyChar == '.' &&
                    txtTextoBuscar.Text.Contains('.'))
                {
                    e.Handled = true;
                }
            }
        }
        #endregion

        #region btnRefrescarGrilla_Click
        private void btnRefrescarGrilla_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
        #endregion

        #region btnbuscar, btncerrar, formProductoDGV_Load
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RealizarBusqueda();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formProductoDGV_Load(object sender, EventArgs e)
        {
            FormatoGrillaProductos();
        }
        #endregion
    }
}

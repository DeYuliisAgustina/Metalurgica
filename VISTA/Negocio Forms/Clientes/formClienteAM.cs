using Controladora;
using Entidades;
using Entidades.Seguridad;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace VISTA.Negocio_Forms
{
    public partial class formClienteAM : Form
    {
        #region Atributos
        private Cliente cliente;
        private bool modificar = false;
        #endregion

        #region Constructor
        public formClienteAM()
        {
            InitializeComponent();
            cliente = new Cliente();
        }
        #endregion

        #region Mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void formClienteAM_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Constructor para modificar
        public formClienteAM(Cliente clienteModificar)
        {
            InitializeComponent();
            cliente = clienteModificar;
            modificar = true;
        }
        #endregion

        #region formClienteAM_Load
        private void formClienteAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Cliente";

                txtRazonSocial.Text = cliente.RazonSocial;
                txtNombreApellido.Text = cliente.NombreyApellido;
                txtDNI.Text = cliente.DNI.ToString();
                txtEmail.Text = cliente.Email;
                txtTelefono.Text = cliente.Telefono;
                txtDireccion.Text = cliente.Domicilio;
                dtpFechaNacimiento.Value = cliente.FechaNacimiento;
            }
            else
            {
                lblAgregaroModificar.Text = "Agregar Cliente";
            }
        }
        #endregion

        #region Botones Aceptar y Cancelar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea modificar el cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        #region Validaciones para evitar duplicados
                        if (ControladoraCliente.Instancia.RecuperarCliente().Any(c => c.NombreyApellido.ToLower() == txtNombreApellido.Text.ToLower() && cliente.NombreyApellido.ToLower() != txtNombreApellido.Text.ToLower())) 
                        {
                            MessageBox.Show("Ya existe un cliente con ese nombre y apellido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (ValidaDNI(txtDNI.Text) == false || txtDNI.Text.Length > 9)  //verifico que el DNI sea válido y que no tenga más de 9 caracteres 
                        {
                            MessageBox.Show("El DNI ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (ControladoraCliente.Instancia.RecuperarClientes().Any(t => t.DNI == long.Parse(txtDNI.Text) && cliente.DNI != long.Parse(txtDNI.Text)))
                        {
                            MessageBox.Show("Ya existe otro cliente con el mismo DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (ControladoraCliente.Instancia.RecuperarClientes().Any(t => t.Telefono == txtTelefono.Text.ToLower() && cliente.Telefono != txtTelefono.Text.ToLower()))
                        {
                            MessageBox.Show("Ya existe otro tecnico con el mismo telefono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (ControladoraCliente.Instancia.RecuperarClientes().Any(t => t.Email == txtEmail.Text.ToLower() && cliente.Email != txtEmail.Text.ToLower()))
                        {
                            MessageBox.Show("Ya existe otro tecnico con el mismo telefono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        #endregion

                        cliente.RazonSocial = txtRazonSocial.Text;
                        cliente.NombreyApellido = txtNombreApellido.Text;
                        cliente.DNI = long.Parse(txtDNI.Text);
                        cliente.Email = txtEmail.Text;
                        cliente.Telefono = txtTelefono.Text;
                        cliente.Domicilio = txtDireccion.Text;
                        cliente.FechaNacimiento = dtpFechaNacimiento.Value;

                        var mensaje = ControladoraCliente.Instancia.ModificarCliente(cliente, formInicioSesion.UsuarioActual);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    #region Validaciones para evitar duplicados
                    if (ControladoraCliente.Instancia.RecuperarCliente().Any(c => c.NombreyApellido.ToLower() == txtNombreApellido.Text.ToLower() && cliente.NombreyApellido.ToLower() != txtNombreApellido.Text.ToLower()))
                    {
                        MessageBox.Show("Ya existe un cliente con ese nombre y apellido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (ControladoraCliente.Instancia.RecuperarClientes().Any(t => t.DNI == long.Parse(txtDNI.Text) && cliente.DNI != long.Parse(txtDNI.Text)))
                    {
                        MessageBox.Show("Ya existe otro cliente con el mismo DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (ControladoraCliente.Instancia.RecuperarClientes().Any(t => t.Telefono == txtTelefono.Text.ToLower() && cliente.Telefono != txtTelefono.Text.ToLower()))
                    {
                        MessageBox.Show("Ya existe otro tecnico con el mismo telefono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (ControladoraCliente.Instancia.RecuperarClientes().Any(t => t.Email == txtEmail.Text.ToLower() && cliente.Email != txtEmail.Text.ToLower()))
                    {
                        MessageBox.Show("Ya existe otro tecnico con el mismo telefono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion

                    cliente.RazonSocial = txtRazonSocial.Text;
                    cliente.NombreyApellido = txtNombreApellido.Text;
                    cliente.DNI = Convert.ToInt32(txtDNI.Text);
                    #region
                    if (ValidaDNI(txtDNI.Text) == false || txtDNI.Text.Length > 9)  //verifico que el DNI sea válido y que no tenga más de 9 caracteres 
                    {
                        MessageBox.Show("El DNI ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion
                    cliente.Email = txtEmail.Text;
                    cliente.Telefono = txtTelefono.Text;
                    cliente.Domicilio = txtDireccion.Text;
                    cliente.FechaNacimiento = dtpFechaNacimiento.Value;
                    cliente.Activo = true;

                    var mensaje = ControladoraCliente.Instancia.AgregarCliente(cliente, formInicioSesion.UsuarioActual);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cancelar la carga de datos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region Validaciones
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtRazonSocial.Text) || txtRazonSocial.Text == "Ingrese una razón social...")
            {
                MessageBox.Show("El campo Razón Social no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtNombreApellido.Text) || txtNombreApellido.Text == "Ingrese un nombre y apellido...")
            {
                MessageBox.Show("El campo Nombre y Apellido no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDNI.Text) || txtDNI.Text == "Ingrese un DNI...")
            {
                MessageBox.Show("El campo DNI no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == "Ingrese un email...")
            {
                MessageBox.Show("El campo Email no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text) || txtTelefono.Text == "Ingrese un teléfono...")
            {
                MessageBox.Show("El campo Teléfono no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text) || txtDireccion.Text == "Ingrese una dirección...")
            {
                MessageBox.Show("El campo Dirección no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        static public bool ValidaDNI(string dni)
        {

            if (Regex.Match(dni, @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$").Success == true)
            {
                //dni correcto
                return true;
            }
            else
            {
                //dni incorrecto
                return false;
            }
        }


        private void txtRazonSocial_Enter(object sender, EventArgs e)
        {
            if (txtRazonSocial.Text == "")
            {
                txtRazonSocial.Text = "Ingrese una razón social...";
                txtRazonSocial.ForeColor = Color.Black;
            }
        }

        private void txtRazonSocial_Leave(object sender, EventArgs e)
        {
            if (txtRazonSocial.Text == "")
            {
                txtRazonSocial.Text = "Ingrese una razón social...";
                txtRazonSocial.ForeColor = Color.Silver;
            }
        }

        private void txtNombreApellido_Enter(object sender, EventArgs e)
        {
            if (txtNombreApellido.Text == "")
            {
                txtNombreApellido.Text = "Ingrese un nombre y apellido...";
                txtNombreApellido.ForeColor = Color.Black;
            }
        }

        private void txtNombreApellido_Leave(object sender, EventArgs e)
        {
            if (txtNombreApellido.Text == "")
            {
                txtNombreApellido.Text = "Ingrese un nombre y apellido...";
                txtNombreApellido.ForeColor = Color.Silver;
            }
        }

        private void txtDNI_Enter(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                txtDNI.Text = "Ingrese un DNI...";
                txtDNI.ForeColor = Color.Black;
            }
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                txtDNI.Text = "Ingrese un DNI...";
            }
            txtDNI.ForeColor = Color.Silver;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Ingrese un email...";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Ingrese un email...";
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "Ingrese un teléfono...";
                txtTelefono.ForeColor = Color.Black;
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "Ingrese un teléfono...";
                txtTelefono.ForeColor = Color.Silver;
            }
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
            {
                txtDireccion.Text = "Ingrese una dirección...";
                txtDireccion.ForeColor = Color.Black;
            }
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
            {
                txtDireccion.Text = "Ingrese una dirección...";
                txtDireccion.ForeColor = Color.Silver;
            }
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtRazonSocial.Text).Handled)
            {
                MessageBox.Show("Solo se permiten letras y números, no caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloNumeros(e, txtDNI.Text).Handled)
            {
                MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloNumeros(e, txtTelefono.Text).Handled)
            {
                MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombreApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtNombreApellido.Text).Handled)
            {
                MessageBox.Show("Solo se permiten letras y números, no caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtEmail.Text).Handled)
            {
                MessageBox.Show("Solo se permiten letras y números, no caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtDireccion.Text).Handled)
            {
                MessageBox.Show("Solo se permiten letras y números, no caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public KeyPressEventArgs KeyPressSoloLetras(KeyPressEventArgs e, string TEXTO)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e;
        }

        static public KeyPressEventArgs KeyPressSoloNumeros(KeyPressEventArgs e, string TEXTO)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) // Permite teclas como Backspace
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e;
        }
        #endregion
    }
}

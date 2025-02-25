

using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace VISTA
{
    public partial class formBackUpoRestBD : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Metalurgica;Trusted_Connection=True;";
        private string backupDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MetalurgicaBackups");
        private string ultimoBackup = string.Empty;

        public formBackUpoRestBD()
        {
            InitializeComponent();
            // Crear el directorio de backups si no existe
            if (!Directory.Exists(backupDirectory))
            {
                Directory.CreateDirectory(backupDirectory);
            }
            CargarUltimoBackUp();
        }

        private void CargarUltimoBackUp()
        {
            try
            {
                if (Directory.Exists(backupDirectory))
                {
                    var archivos = Directory.GetFiles(backupDirectory, "*.bak")
                                           .OrderByDescending(f => new FileInfo(f).CreationTime)
                                           .ToList();

                    if (archivos.Any())
                    {
                        ultimoBackup = archivos.First();
                        DateTime fechaUltimoBackup = File.GetCreationTime(ultimoBackup);
                        label1.Text = fechaUltimoBackup.ToString("dd/MM/yyyy HH:mm:ss");
                    }
                    else
                    {
                        label1.Text = "No se encontraron backups";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el último backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label1.Text = "Error al cargar";
            }

        }

        private void btnCrearBackup_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string resultado = GenerarBKP();
                Cursor = Cursors.Default;

                if (resultado.EndsWith(".bak"))
                {
                    MessageBox.Show("Backup creado correctamente en: " + resultado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUltimoBackUp();
                }
                else
                {
                    MessageBox.Show("Error al crear el backup: " + resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error al crear el backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRestaurarBD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDirectorio.Text))
            {
                MessageBox.Show("Por favor, seleccione un archivo de backup", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(txtDirectorio.Text))
            {
                MessageBox.Show("El archivo de backup seleccionado no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (MessageBox.Show("¿Está seguro de restaurar la base de datos? Esta acción no se puede deshacer.\n\n" +
                                   "IMPORTANTE: Se cerrarán todas las conexiones a la base de datos.",
                                   "Confirmar restauración",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Deshabilitamos los controles durante la restauración
                    btnCrearBackup.Enabled = false;
                    btnRestaurarBD.Enabled = false;
                    txtDirectorio.Enabled = false;

                    MessageBox.Show("La restauración comenzará ahora. Este proceso puede tardar varios minutos.\n" +
                                   "La aplicación podría parecer que no responde durante este tiempo.\n" +
                                   "Por favor, espere hasta que se complete.",
                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Cursor = Cursors.WaitCursor;
                    btnRestaurarBD.Text = "Restaurando...";
                    Application.DoEvents(); // Permite que la UI se actualice

                    string resultado = RestaurarBKP(txtDirectorio.Text);

                    Cursor = Cursors.Default;
                    btnRestaurarBD.Text = "Restaurar BD";

                    // Rehabilitamos los controles
                    btnCrearBackup.Enabled = true;
                    btnRestaurarBD.Enabled = true;
                    txtDirectorio.Enabled = true;

                    if (resultado == "Restauración realizada con éxito")
                    {
                        MessageBox.Show(resultado + "\n\nEs recomendable reiniciar la aplicación para asegurar que los cambios se apliquen correctamente.",
                                       "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                btnRestaurarBD.Text = "Restaurar BD";
                btnCrearBackup.Enabled = true;
                btnRestaurarBD.Enabled = true;
                txtDirectorio.Enabled = true;
                MessageBox.Show("Error al restaurar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtDirectorio_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de backup (*.bak)|*.bak",
                Title = "Seleccione un archivo de backup",
                InitialDirectory = backupDirectory
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDirectorio.Text = openFileDialog.FileName;
            }
        }

        public string GenerarBKP()
        {
            string nombreBackup = string.Format("{0}-{1}-{2}-{3}-{4}-{5}-Metalurgica.bak",
                DateTime.Today.Day.ToString(),
                DateTime.Today.Month.ToString(),
                DateTime.Today.Year.ToString(),
                DateTime.Now.Hour.ToString(),
                DateTime.Now.Minute.ToString(),
                DateTime.Now.Second.ToString());

            string rutaCompleta = Path.Combine(backupDirectory, nombreBackup);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = "BACKUP DATABASE [Metalurgica] TO DISK = N'" +
                            rutaCompleta +
                            "' WITH NOFORMAT, NOINIT, NAME = N'" + nombreBackup + "', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
                        command.CommandType = System.Data.CommandType.Text;
                        command.ExecuteNonQuery();
                        connection.Close();
                        return rutaCompleta;
                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        return ex.Message;
                    }
                }
            }
        }

        // Método para restaurar el backup
        public string RestaurarBKP(string path)
        {
            // Conexión a la base de datos master para restaurar
            string masterConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(masterConnectionString))
            {
                try
                {
                    connection.Open();

                    // Cerrar todas las conexiones a la base de datos Metalurgica
                    string killQuery = @"
                        DECLARE @kill varchar(8000) = '';
                        SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'
                        FROM sys.dm_exec_sessions
                        WHERE database_id = DB_ID('Metalurgica')
                        AND session_id <> @@SPID;
                        EXEC(@kill);";

                    using (SqlCommand killCommand = new SqlCommand(killQuery, connection))
                    {
                        killCommand.ExecuteNonQuery();
                    }

                    // Cambiar la base de datos a modo SINGLE_USER
                    string singleUserQuery = "ALTER DATABASE [Metalurgica] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    using (SqlCommand singleUserCommand = new SqlCommand(singleUserQuery, connection))
                    {
                        singleUserCommand.ExecuteNonQuery();
                    }

                    // Restaurar la base de datos
                    string restoreQuery = $"RESTORE DATABASE [Metalurgica] FROM DISK = N'{path}' WITH REPLACE, STATS = 10";
                    using (SqlCommand restoreCommand = new SqlCommand(restoreQuery, connection))
                    {
                        restoreCommand.CommandTimeout = 300; // 5 minutos de timeout para operaciones grandes
                        restoreCommand.ExecuteNonQuery();
                    }

                    // Cambiar la base de datos a modo MULTI_USER
                    string multiUserQuery = "ALTER DATABASE [Metalurgica] SET MULTI_USER";
                    using (SqlCommand multiUserCommand = new SqlCommand(multiUserQuery, connection))
                    {
                        multiUserCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                    return "Restauración realizada con éxito";
                }
                catch (Exception ex)
                {
                    // Si algo falla, intentamos volver a modo MULTI_USER para no dejar la BD bloqueada
                    try
                    {
                        string emergencyResetQuery = "ALTER DATABASE [Metalurgica] SET MULTI_USER";
                        using (SqlCommand emergencyCommand = new SqlCommand(emergencyResetQuery, connection))
                        {
                            emergencyCommand.ExecuteNonQuery();
                        }
                    }
                    catch { /* Ignoramos errores aquí, estamos en modo de recuperación */ }

                    connection.Close();
                    return "Error al restaurar: " + ex.Message;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
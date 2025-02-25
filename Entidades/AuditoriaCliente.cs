using Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AuditoriaCliente
    {
        public int AuditoriaClienteId { get; set; }
        public int ClienteId { get; set; }
        public string NombreyApellido { get; set; }
        public long DNI { get; set; }
        public string RazonSocial { get; set; }
        public DateTime FechaAuditoria { get; set; }
        public string TipoMovimiento { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}

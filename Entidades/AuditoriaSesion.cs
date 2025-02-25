using Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AuditoriaSesion
    {
        public int AuditoriaSesionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        // Referencia al usuario que inició sesión
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

       
    }
}


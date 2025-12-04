using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsAuditoria
{
    public class DTOAuditoria
    {
        public string? Accion { get; set; }
        public string? Autor { get; set; }
        public DateTime Fecha { get; set; }
    }
}

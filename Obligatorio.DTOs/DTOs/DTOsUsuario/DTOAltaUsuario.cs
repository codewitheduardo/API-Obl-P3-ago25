using Obligatorio.DTOs.DTOs.DTOsEquipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsUsuario
{
    public class DTOAltaUsuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public int IdEquipo { get; set; }
        public List<DTOEquipo> Equipos { get; set; }
    }
}

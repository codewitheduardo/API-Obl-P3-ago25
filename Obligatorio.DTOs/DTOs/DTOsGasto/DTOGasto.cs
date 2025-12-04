using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsGasto
{
    public class DTOGasto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [JsonIgnore]
        public bool Activo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Auditoria
    {
        public int Id { get; set; }
        public string? Accion { get; set; }
        public string? Entidad { get; set; }
        public string? IdentificadorEntidad { get; set; }
        public string? Autor { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public Auditoria()
        {
            Fecha = DateTime.Now;
        }
    }
}

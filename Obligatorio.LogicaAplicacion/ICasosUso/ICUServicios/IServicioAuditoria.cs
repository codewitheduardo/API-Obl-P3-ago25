using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUServicios
{
    public interface IServicioAuditoria
    {
        void Auditar(string accion, string entidad, string? identificadorEntidad, string autor, string observaciones);
    }
}

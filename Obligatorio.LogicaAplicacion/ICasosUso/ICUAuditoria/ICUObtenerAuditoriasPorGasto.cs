using Obligatorio.DTOs.DTOs.DTOsAuditoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUAuditoria
{
    public interface ICUObtenerAuditoriasPorGasto
    {
        List<DTOAuditoria> ObtenerAuditorias(int gastoId);
    }
}

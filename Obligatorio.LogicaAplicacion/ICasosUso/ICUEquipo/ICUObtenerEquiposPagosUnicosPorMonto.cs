using Obligatorio.DTOs.DTOs.DTOsEquipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo
{
    public interface ICUObtenerEquiposPagosUnicosPorMonto
    {
        List<DTOEquipo> ObtenerEquiposConPagosUnicosMayores(decimal monto);
    }
}

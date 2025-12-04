using Obligatorio.DTOs.DTOs.DTOsGasto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUGasto
{
    public interface ICUObtenerGastosActivos
    {
        List<DTOGasto> ObtenerGastosActivos();
    }
}

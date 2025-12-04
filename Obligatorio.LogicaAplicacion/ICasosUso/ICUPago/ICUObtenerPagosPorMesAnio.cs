using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUPago
{
    public interface ICUObtenerPagosPorMesAnio
    {
        List<DTOPago> ObtenerPagosPorMesAnio(int mes, int anio);

    }
}

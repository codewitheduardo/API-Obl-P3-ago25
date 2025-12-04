using Obligatorio.DTOs.DTOs.DTOsPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUPago
{
    public interface ICUObtenerPagosPorUsuario
    {
        List<DTOPago> ObtenerPagosPorUsuario(string email);
    }
}

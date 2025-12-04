using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio.DTOs.DTOs.DTOsGasto;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUGasto
{
    public interface ICUEditarGasto
    {
        void EditarGasto(DTOGasto dto, string email);
    }
}

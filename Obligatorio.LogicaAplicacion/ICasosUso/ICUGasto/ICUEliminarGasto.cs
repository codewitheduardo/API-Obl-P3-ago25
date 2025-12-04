using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUGasto
{
    public interface ICUEliminarGasto
    {
        void EliminarGasto(int id, string email);
    }
}

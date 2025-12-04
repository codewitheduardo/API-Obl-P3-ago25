using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEGasto
{
    public class GastoConPagosAsociadosException : Exception
    {
        public GastoConPagosAsociadosException()
        {
        }
        public GastoConPagosAsociadosException(string message) : base(message)
        {
        }
    }
}

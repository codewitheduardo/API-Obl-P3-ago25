using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEPeriodoVO
{
    public class PeriodoNoValidoException : Exception
    {
        public PeriodoNoValidoException() { }

        public PeriodoNoValidoException(string message) : base(message) { }
    }
}

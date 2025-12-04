using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEPago
{
    public class TipoPagoNoValidoException : Exception
    {
        public TipoPagoNoValidoException() { }
        public TipoPagoNoValidoException(string message) : base(message) { }
    }
}

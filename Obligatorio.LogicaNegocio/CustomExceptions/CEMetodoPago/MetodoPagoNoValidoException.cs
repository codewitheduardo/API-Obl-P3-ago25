using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEMetodoPago
{
    public class MetodoPagoNoValidoException : Exception
    {
        public MetodoPagoNoValidoException() { }
        public MetodoPagoNoValidoException(string message) : base(message) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEPago
{
    public class FechaNoValidaException : Exception
    {
        public FechaNoValidaException() { }

        public FechaNoValidaException(string message) : base(message) { }
    }
}

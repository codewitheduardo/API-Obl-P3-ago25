using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEPago
{
    public class MontoNoValidoException : DatosInvalidosException
    {
        public MontoNoValidoException() { }

        public MontoNoValidoException(string message) : base(message) { }
    }
}

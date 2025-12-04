using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos
{
    public class DescripcionInvalidaException : DatosInvalidosException
    {
        public DescripcionInvalidaException() { }
        public DescripcionInvalidaException(string message) : base(message) { }
    }
}

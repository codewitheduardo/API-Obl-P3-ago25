using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos
{
    public class NombreInvalidoException : Exception
    {
        public NombreInvalidoException() { }
        public NombreInvalidoException(string message) : base(message) { }
    }
}

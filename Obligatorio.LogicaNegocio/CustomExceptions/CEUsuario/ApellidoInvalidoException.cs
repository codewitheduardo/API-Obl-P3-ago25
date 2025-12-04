using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario
{
    public class ApellidoInvalidoException : Exception
    {
        public ApellidoInvalidoException() { }
        public ApellidoInvalidoException(string message) : base(message) { }

    }
}

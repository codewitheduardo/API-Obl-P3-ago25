using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario
{
    public class PasswordInvalidaException : Exception
    {
        public PasswordInvalidaException() { }
        public PasswordInvalidaException(string message) : base(message) { }
    }
}

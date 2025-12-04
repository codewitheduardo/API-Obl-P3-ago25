using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CERol
{
    public class RolNoValidoException : Exception
    {
        public RolNoValidoException() { }
        public RolNoValidoException(string message) : base(message) { }
        
    }
}

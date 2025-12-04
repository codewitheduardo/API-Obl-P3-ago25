using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEGenero
{
    public class GastoYaExisteException : Exception
    {
        public GastoYaExisteException() { }
        public GastoYaExisteException(string message) : base(message) { }
    }
}

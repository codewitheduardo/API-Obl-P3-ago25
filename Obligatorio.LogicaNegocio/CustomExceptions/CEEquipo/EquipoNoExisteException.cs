using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEEquipo
{
    public class EquipoNoExisteException : Exception
    {
        public EquipoNoExisteException() { }
        public EquipoNoExisteException(string message) : base(message) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEPago
{
    public class DiaNoCoincidenteException : Exception
    {
        public DiaNoCoincidenteException() { }
        public DiaNoCoincidenteException(string message) : base(message) { }
    }
}

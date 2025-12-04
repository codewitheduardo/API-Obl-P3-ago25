using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEPago
{
    public class PagosNoEncontradosException : Exception
    {
        public PagosNoEncontradosException() { }

        public PagosNoEncontradosException(string message) : base(message) { }
    }
}

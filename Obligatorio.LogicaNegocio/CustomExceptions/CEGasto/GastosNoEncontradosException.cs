using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEGasto
{
    public class GastosNoEncontradosException : Exception
    {
        public GastosNoEncontradosException() { }
        public GastosNoEncontradosException(string message) : base(message) { }
    }
}

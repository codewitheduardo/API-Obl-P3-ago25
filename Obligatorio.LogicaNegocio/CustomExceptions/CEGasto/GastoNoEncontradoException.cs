using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEGasto
{
    public class GastoNoEncontradoException : Exception
    {
        public GastoNoEncontradoException()
        {
            
        }

        public GastoNoEncontradoException(string message) : base(message)
        {

        }
    }
}

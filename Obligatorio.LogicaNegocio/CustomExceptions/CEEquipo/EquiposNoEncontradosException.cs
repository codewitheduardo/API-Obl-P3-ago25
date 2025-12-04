using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEEquipo
{
    public class EquiposNoEncontradosException : Exception
    {
        public EquiposNoEncontradosException() { }
        public EquiposNoEncontradosException(string message) : base(message) { }
    }
}

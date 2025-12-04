using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEGasto
{
    public class GastoInactivoException :Exception
    {
        public GastoInactivoException()
        {
            
        }

        public GastoInactivoException(string mensaje) : base(mensaje)
        {
            
        }
    }
}

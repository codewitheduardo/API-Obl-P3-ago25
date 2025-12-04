using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEAuditoria
{
    public class AuditoriasNoEncontradasException : Exception
    {
        public AuditoriasNoEncontradasException() : base()
        {
        }

        public AuditoriasNoEncontradasException(string message) : base(message)
        {
        }
    }
}

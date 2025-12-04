using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario
{
    public class UsuarioSinPermisosException : Exception
    {
        public UsuarioSinPermisosException() { }

        public UsuarioSinPermisosException(string message) : base(message) { }
    }
}

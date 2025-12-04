using Obligatorio.DTOs.DTOs.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.iCULogin
{
    public interface ICULogin
    {
        DTOUsuario VerificarExistencia(DTOLogin deUsuario);
        
    }
}

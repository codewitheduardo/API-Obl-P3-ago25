using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.iCULogin;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CULogin
{
    public class CULogin : ICULogin
    {
        private IRepositorioUsuario _repositorioUsuario;

        public CULogin(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public DTOUsuario VerificarExistencia(DTOLogin dto)
        {
            Usuario u = _repositorioUsuario.FindByEmail(dto.Correo);
            if (u is not null)
            {
                if (Utilidades.Crypto.VerificarHashBcrypt(dto.Password, u.Password))
                {
                    return MapperUsuario.FromUsuarioToDTOUsuario(u);
                }
            }
            throw new DatosInvalidosException("Correo o contraseña incorrectos");
        }
    }
}

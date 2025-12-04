using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUObtenerUsuarioPorMonto : ICUObtenerUsuarioPorMonto
    {
        private IRepositorioUsuario _repositorioUsuario;
        public CUObtenerUsuarioPorMonto(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public List<DTOUsuario> ObtenerUsuarioPorMonto(decimal monto)
        {
            List <Usuario> usuarios = _repositorioUsuario.FindUsersByMontoPago(monto);

            if (usuarios is null || usuarios.Count() == 0)
            {
                throw new UsuarioNoEncontradoException("No hay usuario con un monto superior al ingresado");
            }

            List<DTOUsuario> retorno = MapperUsuario.FromListUsuarioToListDTOUsuario(usuarios);

            return retorno;
        }
    }
}

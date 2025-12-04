using Obligatorio.DTOs.DTOs.DTOsGasto;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUGasto;
using Obligatorio.LogicaNegocio.CustomExceptions.CEGasto;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUGasto
{
    public class CUObtenerGasto : ICUObtenerGasto
    {
        public IRepositorioGasto _repositorioGasto;

        public CUObtenerGasto(IRepositorioGasto repositorioGasto)
        {
            _repositorioGasto = repositorioGasto;
        }

        public DTOGasto ObtenerGasto(int id)
        {
            Gasto buscado = _repositorioGasto.FindById(id);

            if (buscado is null)
            {
                throw new GastoNoEncontradoException("Gasto inexistente");
            }

            DTOGasto retorno = MapperGasto.FromGastoToDTOGasto(buscado);

            return retorno;
        }
    }
}

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
    public class CUObtenerGastos : ICUObtenerGastos
    {
        public IRepositorioGasto _repositorioGasto;

        public CUObtenerGastos(IRepositorioGasto repositorioGasto)
        {
            _repositorioGasto = repositorioGasto;
        }

        public List<DTOGasto> ObtenerGastos()
        {
            List<Gasto> gastos = _repositorioGasto.FindAll();

            if (gastos is null || gastos.Count == 0)
            {
                throw new GastosNoEncontradosException("No se encontraron gastos registrados en el sistema");
            }

            List<DTOGasto> retorno = MapperGasto.FromListGastoToListDTOGasto(gastos);

            return retorno;
        }
    }
}

using Obligatorio.DTOs.DTOs.DTOsEquipo;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaNegocio.CustomExceptions.CEEquipo;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUEquipo
{
    public class CUObtenerEquiposPagosUnicosPorMonto : ICUObtenerEquiposPagosUnicosPorMonto
    {
        private IRepositorioEquipo _repositorioEquipo;

        public CUObtenerEquiposPagosUnicosPorMonto(IRepositorioEquipo repositorioEquipo) 
        {
            _repositorioEquipo = repositorioEquipo;
        }

        public List<DTOEquipo> ObtenerEquiposConPagosUnicosMayores(decimal monto)
        {
            List<DTOEquipo> retorno = MapperEquipo.FromListEquipoToListDTOEquipo(_repositorioEquipo.FindByMonto(monto));

            return retorno;
        }
    }
}

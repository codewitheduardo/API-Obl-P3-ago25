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
    public class CUObtenerEquipos : ICUObtenerEquipos
    {
        private IRepositorioEquipo _repositorioEquipo;
        
        public CUObtenerEquipos(IRepositorioEquipo repositorioEquipo)
        {
            _repositorioEquipo = repositorioEquipo;
        }

        public List<DTOEquipo> ObtenerEquipos()
        {
            List<Equipo> listaDeEquipos = _repositorioEquipo.FindAll();

            if (listaDeEquipos is null || listaDeEquipos.Count == 0)
            {
                throw new EquiposNoEncontradosException("No se encontraron equipos registrados en el sistema");
            }

            List<DTOEquipo> retorno = MapperEquipo.FromListEquipoToListDTOEquipo(listaDeEquipos);

            return retorno;
        }
    }
}

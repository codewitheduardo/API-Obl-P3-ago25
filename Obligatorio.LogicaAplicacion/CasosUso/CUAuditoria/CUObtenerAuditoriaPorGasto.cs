using Obligatorio.DTOs.DTOs.DTOsAuditoria;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAuditoria;
using Obligatorio.LogicaNegocio.CustomExceptions.CEAuditoria;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUAuditoria
{
    public class CUObtenerAuditoriaPorGasto : ICUObtenerAuditoriasPorGasto
    {
        private IRepositorioAuditoria _repositorioAuditoria;

        public CUObtenerAuditoriaPorGasto(IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioAuditoria = repositorioAuditoria;
        }

        public List<DTOAuditoria> ObtenerAuditorias(int gastoId)
        {
            List<DTOAuditoria> retorno = MapperAuditoria.FromListAuditoriaToListDTOAuditoria(_repositorioAuditoria.FindByGastoId(gastoId));

            return retorno;
        }
    }
}

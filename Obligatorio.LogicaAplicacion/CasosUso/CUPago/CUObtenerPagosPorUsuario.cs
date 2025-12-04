using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUPago
{
    public class CUObtenerPagosPorUsuario : ICUObtenerPagosPorUsuario
    {
        private IRepositorioPago _repositorioPago;

        public CUObtenerPagosPorUsuario(IRepositorioPago repositorioPago)
        {
            _repositorioPago = repositorioPago;
        }

        public List<DTOPago> ObtenerPagosPorUsuario(string email)
        {
            List<DTOPago> retorno = MapperPago.FromListPagoToListDTOPago(_repositorioPago.FindByUsuario(email));

            return retorno;
        }
    }
}

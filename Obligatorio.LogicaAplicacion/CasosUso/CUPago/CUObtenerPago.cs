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
    public class CUObtenerPago : ICUObtenerPago
    {
        private IRepositorioPago _repositorioPago;

        public CUObtenerPago(IRepositorioPago repositorioPago)
        {
            _repositorioPago = repositorioPago;
        }

        public DTOPago ObtenerPago(int id)
        {
            Pago buscado = _repositorioPago.FindById(id);

            if (buscado is null)
            {
                throw new PagoNoEncontradoException("Pago inexistente");
            }

            DTOPago retorno = MapperPago.FromPagoToDTOPago(buscado);

            return retorno;
        }
    }
}

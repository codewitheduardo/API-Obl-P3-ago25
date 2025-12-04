using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUPago
{
    public class CUObtenerPagosPorMesAnio : ICUObtenerPagosPorMesAnio
    {
        private IRepositorioPago _repositorioPago;

        public CUObtenerPagosPorMesAnio(IRepositorioPago repositorioPago)
        {
            _repositorioPago = repositorioPago;
        }

        public List<DTOPago> ObtenerPagosPorMesAnio(int mes, int anio)
        {
            if (anio < 1 || mes < 1 || mes > 12)
            {
                throw new FechaNoValidaException("Año o mes inválido");
            }

            List<Pago> pagos = _repositorioPago.FindByMesAnio(mes, anio);

            if (pagos is null || pagos.Count == 0)
            {
                throw new PagosNoEncontradosException($"No se encontraron pagos para el año {anio} y mes {mes}");
            }

            List<DTOPago> retorno = MapperPago.FromListPagoToListDTOPago(pagos);

            return retorno;
        }
    }
}

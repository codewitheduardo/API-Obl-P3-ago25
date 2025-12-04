using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CEMetodoPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.ValueObjects;
using Obligatorio.Utilidades;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperPago
    {
        public static Pago FromDTOAltaPagoToPago(DTOAltaPago dto)
        {
            if (dto.TipoPago.ToUpper() == "UNICO")
            {
                PagoUnico p = new PagoUnico();

                if (dto.MetodoPago.ToUpper() == "CREDITO")
                {
                    p.MetodoPago = MetodoPago.CREDITO;
                }
                else if (dto.MetodoPago.ToUpper() == "EFECTIVO")
                {
                    p.MetodoPago = MetodoPago.EFECTIVO;
                }
                else
                {
                    throw new MetodoPagoNoValidoException("El metodo de pago indicado no es valido");
                }

                if (dto.FechaInicio is null)
                {
                    throw new FechaNoValidaException("La fecha de inicio no puede ser nula para un pago unico");
                }

                p.Descripcion = dto.Descripcion;
                p.Monto = dto.Monto;
                p.Fecha = dto.FechaInicio.Value;
                p.NroRecibo = ReciboService.GenerarNroRecibo();

                return p;
            }
            else if (dto.TipoPago.ToUpper() == "RECURRENTE")
            {
                PagoRecurrente p = new PagoRecurrente();

                if (dto.MetodoPago.ToUpper() == "CREDITO")
                {
                    p.MetodoPago = MetodoPago.CREDITO;
                }
                else if (dto.MetodoPago.ToUpper() == "EFECTIVO")
                {
                    p.MetodoPago = MetodoPago.EFECTIVO;
                }
                else
                {
                    throw new MetodoPagoNoValidoException("El metodo de pago indicado no es valido");
                }

                if (dto.FechaInicio is null || dto.FechaFin is null)
                {
                    throw new FechaNoValidaException("La fecha de inicio y fin no pueden ser nulas para un pago recurrente");
                }

                p.Descripcion = dto.Descripcion;
                p.Monto = dto.Monto;
                PeriodoVO pVO = new PeriodoVO() { Desde = dto.FechaInicio.Value, Hasta = dto.FechaFin.Value };
                pVO.Validar();
                p.Periodo = pVO;

                return p;
            }
            else
            {
                throw new TipoPagoNoValidoException("El tipo de pago indicado no es valido");
            }
        }

        public static DTOPago FromPagoToDTOPago(Pago pago)
        {
            DTOPago dto = new DTOPago();

            dto.Id = pago.Id;
            dto.MetodoPago = pago.MetodoPago.ToString();
            dto.Gasto = pago.TipoGasto.Nombre;
            dto.UsuarioNombre = pago.Usuario.Nombre + " " + pago.Usuario.Apellido;
            dto.UsuarioEmail = pago.Usuario.Email.EmailCompleto;
            dto.MontoFinal = pago.MontoFinal;
            dto.TipoPago = (pago is PagoUnico) ? "Unico" : "Recurrente";
            dto.SaldoPendiente = pago.CalcularSaldoPendiente();
            dto.FechaInicio = pago.GetFechaDesde().ToString("dd MMM yyyy");
            dto.FechaFin = (pago is PagoRecurrente pr) ? pr.Periodo.Hasta.ToString("dd MMM yyyy") : "NO APLICA";
    
            return dto;
        }

        public static List<DTOPago> FromListPagoToListDTOPago(List<Pago> listaDePagos)
        {
            List<DTOPago> retorno = new List<DTOPago>();

            foreach (Pago p in listaDePagos)
            {
                DTOPago dto = MapperPago.FromPagoToDTOPago(p);
                retorno.Add(dto);
            }

            return retorno;
        }
    }
}

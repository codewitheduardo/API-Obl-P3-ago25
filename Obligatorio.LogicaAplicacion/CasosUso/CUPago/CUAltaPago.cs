using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CEGasto;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUPago
{
    public class CUAltaPago : ICUAltaPago
    {
        private IRepositorioPago _repositorioPago;
        private IRepositorioGasto _repositorioGasto;
        private IRepositorioUsuario _repositorioUsuario;

        public CUAltaPago(IRepositorioPago repositorioPago, IRepositorioGasto repositorioGasto, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioPago = repositorioPago;
            _repositorioGasto = repositorioGasto;
            _repositorioUsuario = repositorioUsuario;
        }

        public void AltaPago(DTOAltaPago dto)
        {
            Pago nuevo = MapperPago.FromDTOAltaPagoToPago(dto);
            Gasto g = _repositorioGasto.FindById(dto.IdGasto);
            Usuario u = _repositorioUsuario.FindByEmail(dto.Email);

            if (g is null)
            {
                throw new GastoNoEncontradoException("No existe el gasto indicado");
            }
            if (u is null)
            {
                throw new UsuarioNoEncontradoException("No existe el usuario indicado");
            }

            nuevo.TipoGasto = g;
            nuevo.Usuario = u;
            nuevo.Validar();
            nuevo.CalcularMontoTotal();
            _repositorioPago.Add(nuevo);
        }
    }
}

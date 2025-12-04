using Obligatorio.DTOs.DTOs.DTOsGasto;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUServicios;
using Obligatorio.LogicaNegocio.CustomExceptions.CEGenero;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System.Text.Json;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUGasto
{
    public class CUAltaGasto : ICUAltaGasto
    {
        private IRepositorioGasto _repositorioGasto;
        private IRepositorioUsuario _repositorioUsuario;
        private IServicioAuditoria _servicioAuditoria;

        public CUAltaGasto(IRepositorioGasto repositorioGasto, IRepositorioUsuario repositorioUsuario, IServicioAuditoria servicioAuditoria)
        {
            _repositorioGasto = repositorioGasto;
            _repositorioUsuario = repositorioUsuario;
            _servicioAuditoria = servicioAuditoria;
        }

        public void AltaGasto(DTOAltaGasto dto, string email)
        {
            Usuario user = _repositorioUsuario.FindByEmail(email);
            int idUser = user.Id;

            try
            {
                if (!user.esAdministrador())
                {
                    throw new UsuarioSinPermisosException("El usuario " + user.Nombre + " " + user.Apellido + " no tiene permisos para dar de alta un gasto");
                }

                Gasto buscado = _repositorioGasto.FindByNombre(dto.Nombre);

                if (buscado is not null)
                {
                    throw new GastoYaExisteException("El gasto " + dto.Nombre + " ya existe");
                }

                Gasto nuevo = MapperGasto.FromDTOAltaGastoToGasto(dto);
                nuevo.Validar();

                int idInsertado = _repositorioGasto.Add(nuevo);

                _servicioAuditoria.Auditar("Alta", "Gasto", idInsertado.ToString(), idUser.ToString(), JsonSerializer.Serialize(nuevo));
            }
            catch (Exception e)
            {
                _servicioAuditoria.Auditar("Alta", "Gasto", null, idUser.ToString(), "Error de alta: " + e.Message);

                throw new Exception(e.Message);
            }
        }
    }
}

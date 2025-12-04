using Obligatorio.DTOs.DTOs.DTOsGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUServicios;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEGasto;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System.Text.Json;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUGasto
{
    public class CUEditarGasto : ICUEditarGasto
    {
        private IRepositorioGasto _repositorioGasto;
        private IRepositorioUsuario _repositorioUsuario;
        private IServicioAuditoria _servicioAuditoria;

        public CUEditarGasto(IRepositorioGasto repositorioGasto, IRepositorioUsuario repositorioUsuario, IServicioAuditoria servicioAuditoria)
        {
            _repositorioGasto = repositorioGasto;
            _repositorioUsuario = repositorioUsuario;
            _servicioAuditoria = servicioAuditoria;
        }

        public void EditarGasto(DTOGasto dto, string email)
        {
            Gasto aCambiar = _repositorioGasto.FindById(dto.Id);
            Usuario user = _repositorioUsuario.FindByEmail(email);
            int idUser = user.Id;

            try
            {
                if (!user.esAdministrador())
                {
                    throw new UsuarioSinPermisosException("El usuario " + user.Nombre + " " + user.Apellido + " no tiene permisos para editar un gasto");
                }

                if (aCambiar is null)
                {
                    throw new GastoNoEncontradoException("Gasto inexistente");
                }

                aCambiar.Nombre = dto.Nombre;
                aCambiar.Descripcion = dto.Descripcion;
                aCambiar.Activo = dto.Activo;
                aCambiar.Validar();
                _repositorioGasto.Update(aCambiar);

                _servicioAuditoria.Auditar("Editar", "Gasto", aCambiar.Id.ToString(), idUser.ToString(), JsonSerializer.Serialize(aCambiar));

            }
            catch (NombreInvalidoException e)
            {
                throw new NombreInvalidoException(e.Message);
            }
            catch (DescripcionInvalidaException e)
            {
                throw new DescripcionInvalidaException(e.Message);
            }
            catch (Exception e)
            {
                _servicioAuditoria.Auditar("Editar", "Gasto", aCambiar.Id.ToString(), idUser.ToString(), "Error de edición: " + e.Message);

                throw new Exception(e.Message);
            }
        }
    }
}

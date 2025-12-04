using Obligatorio.LogicaAplicacion.ICasosUso.ICUServicios;
using Obligatorio.LogicaNegocio.CustomExceptions.CEGasto;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System.Text.Json;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUGasto
{
    public class CUEliminarGasto : ICUEliminarGasto
    {
        private IRepositorioGasto _repositorioGasto;
        private IRepositorioUsuario _repositorioUsuario;
        private IServicioAuditoria _servicioAuditoria;

        public CUEliminarGasto(IRepositorioGasto repositorioGasto, IRepositorioUsuario repositorioUsuario, IServicioAuditoria servicioAuditoria)
        {
            _repositorioGasto = repositorioGasto;
            _repositorioUsuario = repositorioUsuario;
            _servicioAuditoria = servicioAuditoria;
        }

        public void EliminarGasto(int id, string email)
        {
            Gasto aEliminar = _repositorioGasto.FindById(id);
            Usuario user = _repositorioUsuario.FindByEmail(email);
            int idUser = user.Id;

            try
            {
                if (!user.esAdministrador())
                {
                    throw new UsuarioSinPermisosException("El usuario " + user.Nombre + " " + user.Apellido + " no tiene permisos para eliminar un gasto");
                }

                if (aEliminar is null)
                {
                    throw new GastoNoEncontradoException("El gasto con id " + id + " no existe");
                }

                if (aEliminar.Pagos != null || aEliminar.Pagos.Count > 0)
                {
                    throw new GastoConPagosAsociadosException("El gasto " + aEliminar.Nombre + " tiene pagos asociados y no se puede eliminar");
                }

                _repositorioGasto.Remove(aEliminar.Id);

                _servicioAuditoria.Auditar("Eliminar", "Gasto", aEliminar.Id.ToString(), idUser.ToString(), JsonSerializer.Serialize(aEliminar));
            }
            catch (Exception e)
            {
                _servicioAuditoria.Auditar("Eliminar", "Gasto", aEliminar.Id.ToString(), idUser.ToString(), "Error de eliminación: " + e.Message);

                throw new Exception(e.Message);
            }
        }
    }
}

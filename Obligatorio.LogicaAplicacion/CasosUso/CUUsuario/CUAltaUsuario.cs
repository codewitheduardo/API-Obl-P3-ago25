using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CEEquipo;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.ValueObjects;
using Obligatorio.Utilidades;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        private IRepositorioEquipo _repositorioEquipo;

        public CUAltaUsuario(IRepositorioUsuario repositorioUsuario, IRepositorioEquipo repositorioEquipo)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioEquipo = repositorioEquipo;
        }

        public void AltaUsuario(DTOAltaUsuario dto)
        {
            try
            {
                Equipo e = _repositorioEquipo.FindById(dto.IdEquipo);

                if (e is null)
                {
                    throw new EquipoNoExisteException("El equipo indicado no existe");
                }

                if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 8)
                {
                    throw new PasswordInvalidaException("La contraseña debe tener al menos 8 caracteres");
                }

                Usuario nuevo = MapperUsuario.FromDTOAltaUsuarioToUsuario(dto);
                nuevo.Password = Utilidades.Crypto.HashConBcrypt(dto.Password, 10);
                nuevo.Equipo = e;
                nuevo.Validar();

                string direccionBase = EmailVO.GenerarDireccion(dto.Nombre, dto.Apellido);
                string direccion = direccionBase;
                string dominio = EmailVO.GenerarDominio(e.Nombre);
                string email = direccion + dominio;

                while (_repositorioUsuario.FindByEmail(email) is not null)
                {
                    int randomNum = new Random().Next(1000, 9999);
                    direccion = direccionBase + randomNum.ToString();
                    email = direccion + dominio;
                }

                EmailVO emailVO = new EmailVO(direccion, dominio);
                nuevo.Email = emailVO;

                _repositorioUsuario.Add(nuevo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

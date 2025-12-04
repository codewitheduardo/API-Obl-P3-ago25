using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CERol;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.ValueObjects;
using Obligatorio.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperUsuario
    {
        public static DTOUsuario FromUsuarioToDTOUsuario(Usuario u) 
        {
            DTOUsuario dto = new DTOUsuario();

            dto.Nombre = u.Nombre;
            dto.Apellido = u.Apellido;
            dto.Email = u.Email.EmailCompleto;
            dto.Rol = u.Rol.ToString();
            dto.Equipo = u.Equipo.Nombre;

            return dto;
        }

        public static Usuario FromDTOAltaUsuarioToUsuario(DTOAltaUsuario dto) 
        {
            Usuario u = new Usuario();

            u.Nombre = dto.Nombre;
            u.Apellido = dto.Apellido;
            
            if (dto.Rol.ToUpper() == "EMPLEADO")
            {
                u.Rol = Rol.EMPLEADO;
            }
            else if (dto.Rol.ToUpper() == "GERENTE")
            {
                u.Rol = Rol.GERENTE;
            }
            else
            {
                throw new RolNoValidoException("El rol indicado no es valido");
            }

            return u;
        }

        public static List<DTOUsuario> FromListUsuarioToListDTOUsuario(List<Usuario> usuarios)
        {

            List<DTOUsuario> dtos = new List<DTOUsuario>();
            foreach (var u in usuarios)
            {
                dtos.Add(FromUsuarioToDTOUsuario(u));
            }
            return dtos;
        }
    }
}

using Obligatorio.DTOs.DTOs.DTOsEquipo;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperEquipo
    {
        public static DTOEquipo FromEquipoToDTOEquipo(Equipo e)
        {
            DTOEquipo dto = new DTOEquipo();
            dto.Id = e.Id;
            dto.Nombre = e.Nombre;

            return dto;
        }

        public static List<DTOEquipo> FromListEquipoToListDTOEquipo(List<Equipo> listaDeEquipos)
        {
            List<DTOEquipo> retorno = new List<DTOEquipo>();

            foreach (Equipo e in listaDeEquipos)
            {
                DTOEquipo dto = MapperEquipo.FromEquipoToDTOEquipo(e);
                retorno.Add(dto);
            }
            return retorno;
        }   
    }
}

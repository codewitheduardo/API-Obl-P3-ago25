using Obligatorio.DTOs.DTOs.DTOsGasto;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperGasto
    {
        public static Gasto FromDTOAltaGastoToGasto(DTOAltaGasto dto)
        {
            Gasto g = new Gasto(dto.Nombre, dto.Descripcion);

            return g;
        }

        public static DTOGasto FromGastoToDTOGasto(Gasto g)
        {
            DTOGasto dto = new DTOGasto();
            dto.Id = g.Id;
            dto.Nombre = g.Nombre;
            dto.Descripcion = g.Descripcion;
            dto.Activo = g.Activo;

            return dto;
        }

        public static List<DTOGasto> FromListGastoToListDTOGasto(List<Gasto> listaDeGastos)
        {
            List<DTOGasto> retorno = new List<DTOGasto>();

            foreach (Gasto g in listaDeGastos)
            {
                DTOGasto dto = MapperGasto.FromGastoToDTOGasto(g);
                retorno.Add(dto);
            }

            return retorno;
        }
    }
}

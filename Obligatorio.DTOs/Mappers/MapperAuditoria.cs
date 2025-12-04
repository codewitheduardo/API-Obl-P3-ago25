using Obligatorio.DTOs.DTOs.DTOsAuditoria;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperAuditoria
    {
        public static DTOAuditoria FromAuditoriaToDTOAuditoria(Auditoria a)
        {
            DTOAuditoria dto = new DTOAuditoria();
            dto.Accion = a.Accion;
            dto.Autor = a.Autor;
            dto.Fecha = a.Fecha;
            return dto;
        }

        public static List<DTOAuditoria> FromListAuditoriaToListDTOAuditoria(List<Auditoria> listaDeAuditorias)
        {
            List<DTOAuditoria> retorno = new List<DTOAuditoria>();

            foreach (Auditoria a in listaDeAuditorias)
            {
                DTOAuditoria dto = MapperAuditoria.FromAuditoriaToDTOAuditoria(a);
                retorno.Add(dto);
            }
            return retorno;
        }
    }
}

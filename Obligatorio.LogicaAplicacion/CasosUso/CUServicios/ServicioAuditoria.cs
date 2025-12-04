using Obligatorio.LogicaAplicacion.ICasosUso.ICUServicios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUServicios
{
    public class ServicioAuditoria : IServicioAuditoria
    {
        private IRepositorioAuditoria _repositorioAuditoria;

        public ServicioAuditoria(IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioAuditoria = repositorioAuditoria;
        }

        public void Auditar(string accion, string entidad, string? identificadorEntidad, string autor, string observaciones)
        {
            Auditoria aud = new Auditoria();
            aud.Accion = accion;
            aud.Entidad = entidad;
            aud.IdentificadorEntidad = identificadorEntidad;
            aud.Autor = autor;
            aud.Observaciones = observaciones;

            _repositorioAuditoria.Add(aud);
        }
    }
}

using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoria : IRepositorioAuditoria
    {
        private ApplicationDbContext _context;

        public RepositorioAuditoria(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Auditoria a)
        {
            _context.Auditorias.Add(a);
            _context.SaveChanges();
        }

        public List<Auditoria> FindByGastoId(int gastoId)
        {
            return _context.Auditorias
        // filtro primero por entidad e identificador
        .Where(a => a.Entidad == "Gasto" &&
                    a.IdentificadorEntidad == gastoId.ToString())
        // orden por fecha
        .OrderByDescending(a => a.Fecha)
        // join con usuarios por UsuarioId
        .Join(
            _context.Usuarios,
            aud => aud.Autor,   // clave en Auditoria
            usr => usr.Id.ToString(),         // clave en Usuario
            (aud, usr) => new Auditoria
            {
                Accion = aud.Accion,
                Fecha = aud.Fecha,
                Autor = usr.Nombre + " " + usr.Apellido
            }
        )
        .ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private ApplicationDbContext _context;

        public RepositorioEquipo(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Equipo e)
        {
            _context.Equipos.Add(e);
            _context.SaveChanges();
            return e.Id;
        }

        public List<Equipo> FindAll()
        {
            return _context.Equipos.ToList();
        }

        public Equipo? FindById(int id)
        {
            return _context.Equipos.Where(e => e.Id == id).SingleOrDefault();
        }

        public List<Equipo> FindByMonto(decimal monto)
        {
            return _context.Equipos
                .Include(e => e.Usuarios)
                .ThenInclude(u => u.Pagos)
                .Where(e => e.Usuarios.Any(u => u.Pagos.OfType<PagoUnico>().Any(p => p.MontoFinal > monto)) )
                .OrderByDescending(e => e.Nombre)
                .ToList();  
        }

        public void Remove(int id)
        {
            Equipo aBorrar = FindById(id);
            _context.Remove(aBorrar);
            _context.SaveChanges();
        }

        public void Update(Equipo e)
        {
            _context.Equipos.Update(e);
            _context.SaveChanges();
        }
    }
}

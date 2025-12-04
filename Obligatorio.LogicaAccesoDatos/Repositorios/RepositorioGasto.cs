using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioGasto : IRepositorioGasto
    {
        private ApplicationDbContext _context;

        public RepositorioGasto(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Gasto nuevo)
        {
            _context.Gastos.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Gasto> FindAll()
        {
            return _context.Gastos.ToList();
        }

        public Gasto? FindById(int id)
        {
            return _context.Gastos.Where(g => g.Id == id).SingleOrDefault();
        }

        public void Remove(int id)
        {
            Gasto aEliminar = FindById(id);
            _context.Gastos.Remove(aEliminar);
            _context.SaveChanges();
        }

        public void Update(Gasto g)
        {
            _context.Gastos.Update(g);
            _context.SaveChanges();
        }

        public Gasto FindByNombre(string nombre)
        {
            return _context.Gastos.Where(g => g.Nombre.Equals(nombre)).SingleOrDefault();
        }

        public List<Gasto> FindAllActivos()
        {
            return _context.Gastos.Where(g => g.Activo == true).ToList();
        }
    }
}

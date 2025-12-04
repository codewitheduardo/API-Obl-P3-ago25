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
    public class RepositorioUsuario : IRepositorioUsuario
    {
        ApplicationDbContext _context;

        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Usuario nuevo)
        {
            _context.Usuarios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public Usuario? FindById(int id)
        {
            return _context.Usuarios
                .Include(u => u.Equipo)
                .Where(u => u.Id == id)
                .SingleOrDefault();
        }

        public List<Usuario> FindAll()
        {
            return _context.Usuarios
                .Include(u => u.Equipo)
                .ToList();
        }

        public void Remove(int id)
        {
            Usuario aEliminar = FindById(id);
            _context.Usuarios.Remove(aEliminar);
            _context.SaveChanges();
        }

        public void Update(Usuario u)
        {
            _context.Usuarios.Update(u);
            _context.SaveChanges();
        }

        public Usuario? FindByEmail(string email)
        {
            return _context.Usuarios
                .Include(u => u.Equipo)
                .Where(u => u.Email.Direccion + u.Email.Dominio == email)
                .SingleOrDefault();
        }

        public List<Usuario> FindUsersByMontoPago(decimal monto)
        {
            return _context.Usuarios
                .Include(u => u.Pagos)
                .Include(u => u.Equipo)
                .Where(u => u.Pagos.Any(p => p.MontoFinal > monto))
                .ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioPago : IRepositorioPago
    {
        private ApplicationDbContext _context;

        public RepositorioPago(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Pago p)
        {
            p.Usuario.AgregarPago(p);
            _context.Pagos.Add(p);
            _context.SaveChanges();
            return p.Id;
        }

        public List<Pago> FindAll()
        {
            return _context.Pagos.ToList();
        }

        public Pago? FindById(int id)
        {
            return _context.Pagos
                .Include(p => p.Usuario)
                .Include(p => p.TipoGasto)
                .Where(p => p.Id == id)
                .SingleOrDefault();
        }

        public void Update(Pago p)
        {
            _context.Pagos.Update(p);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var aEliminar = FindById(id);

            aEliminar.Usuario?.Pagos?.Remove(aEliminar);
            _context.Pagos.Remove(aEliminar);
            _context.SaveChanges();
        }

        public List<Pago> FindByMesAnio(int mes, int anio)
        {
            var desde = new DateTime(anio, mes, 1);
            var hasta = desde.AddMonths(1);

            var recurrentes = _context.Pagos
                .OfType<PagoRecurrente>()
                .Where(pr => pr.Periodo.Desde >= desde && pr.Periodo.Desde < hasta)
                .Include(pr => pr.TipoGasto)
                .Include(pr => pr.Usuario)
                .ToList();

            var unicos = _context.Pagos
                .OfType<PagoUnico>()
                .Where(pu => pu.Fecha >= desde && pu.Fecha < hasta)
                .Include(pu => pu.TipoGasto)
                .Include(pu => pu.Usuario)
                .ToList();

            return recurrentes.Cast<Pago>().Concat(unicos.Cast<Pago>()).ToList();
        }

        public List<Pago> FindByUsuario(string email)
        {
            return _context.Pagos
                .Include(p => p.Usuario)
                .Include(p => p.TipoGasto)
                .Where(p => p.Usuario.Email.Direccion + p.Usuario.Email.Dominio == email)
                .ToList();
        }
    }
}

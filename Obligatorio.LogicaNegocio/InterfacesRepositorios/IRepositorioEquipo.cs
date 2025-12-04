using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEquipo : IRepositorio<Equipo>
    {
        int Add(Equipo e);
        Equipo FindById(int id);
        List<Equipo> FindAll();
        void Update(Equipo e);
        void Remove(int id);
        List<Equipo> FindByMonto(decimal monto);
    }
}

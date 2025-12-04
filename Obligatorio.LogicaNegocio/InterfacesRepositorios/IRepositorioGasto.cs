using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioGasto : IRepositorio<Gasto>
    {
        int Add(Gasto nuevo);
        Gasto FindById(int id);
        List<Gasto> FindAll();
        void Remove(int id);
        void Update(Gasto g);
        Gasto FindByNombre(string nombre);
        List<Gasto> FindAllActivos();
    }
}

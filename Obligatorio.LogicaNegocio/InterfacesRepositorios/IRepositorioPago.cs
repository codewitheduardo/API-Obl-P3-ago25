using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPago : IRepositorio<Pago>
    {
        int Add(Pago p);
        Pago FindById(int id);
        List<Pago> FindAll();
        void Update(Pago p);
        void Remove(int id);
        List<Pago> FindByMesAnio(int mes, int anio);
        List<Pago> FindByUsuario(string email);
    }


}

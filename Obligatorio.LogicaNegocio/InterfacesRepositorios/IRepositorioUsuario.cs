using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        int Add(Usuario nuevo);
        Usuario FindById(int id);
        List<Usuario> FindAll();
        void Update(Usuario u);
        void Remove(int id);
        Usuario FindByEmail(string email);
        List<Usuario> FindUsersByMontoPago(decimal monto);
    }
}

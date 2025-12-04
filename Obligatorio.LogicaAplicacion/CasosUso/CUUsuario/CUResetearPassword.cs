using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUResetearPassword : ICUResetearPassword
    {
        private IRepositorioUsuario _repositorioUsuario;

        public CUResetearPassword(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public string ResetearPassword(string email)
        {
            Usuario u = _repositorioUsuario.FindByEmail(email);

            if (u is null)
            {
                throw new UsuarioNoEncontradoException($"No se encontró un usuario con el email {email}");
            }

            string nueva = Utilidades.PasswordService.GenerateSecurePassword();
            string password = Utilidades.Crypto.HashConBcrypt(nueva, 10);

            u.Password = password;
            _repositorioUsuario.Update(u);

            return nueva;
        }
    }
}

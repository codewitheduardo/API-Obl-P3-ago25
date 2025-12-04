using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEUsuario;
using Obligatorio.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public EmailVO Email { get; set; }
        public Rol Rol { get; set; }
        public Equipo Equipo { get; set; }
        public List<Pago> Pagos { get; set; }

        public Usuario() { }

        public Usuario(string nombre, string apellido, string password, EmailVO email, Rol rol, Equipo equipo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Password = password;
            Email = email;
            Rol = rol;
            Equipo = equipo;
        }

        public bool esAdministrador()
        {
            return Rol == Rol.ADMINISTRADOR;
        }

        public bool esGerente()
        {
            return Rol == Rol.GERENTE;
        }

        public bool esEmpleado()
        {
            return Rol == Rol.EMPLEADO;
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarApellido();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new NombreInvalidoException("El nombre no puede estar vacio");
            }
        }

        private void ValidarApellido()
        {
            if (string.IsNullOrWhiteSpace(Apellido))
            {
                throw new ApellidoInvalidoException("El apellido no puede estar vacio");
            }
        }

        public void AgregarPago(Pago pago)
        {
            if (Pagos == null)
            {
                Pagos = new List<Pago>();
            }

            pago.Usuario = this;
            Pagos.Add(pago);
        }
    }
}
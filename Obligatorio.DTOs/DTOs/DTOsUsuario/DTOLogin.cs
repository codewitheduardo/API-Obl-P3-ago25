using System.ComponentModel.DataAnnotations;

namespace Obligatorio.DTOs.DTOs.DTOsUsuario
{
    public class DTOLogin
    {
        [Required(ErrorMessage = "Ingrese su correo")]

        public string Correo { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña")]

        public string Password { get; set; }
    }
}

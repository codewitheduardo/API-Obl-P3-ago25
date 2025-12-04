using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio.LogicaNegocio.ValueObjects
{
    [ComplexType]
    public record EmailVO
    {
        public string Direccion { get; init; }
        public string Dominio { get; init; }
        public string EmailCompleto => Direccion + Dominio;

        public EmailVO(string direccion, string dominio)
        {
            Direccion = direccion;
            Dominio = dominio;
        }

        public static string GenerarDireccion(string nombre, string apellido)
        {
            string nombreNorm = Normalizar(nombre);
            string apellidoNorm = Normalizar(apellido);

            string nombreParte;

            if (nombreNorm.Length >= 3)
            {
                nombreParte = nombreNorm.Substring(0, 3);
            }
            else
            {
                nombreParte = nombreNorm;
            }

            string apellidoParte;

            if (apellidoNorm.Length >= 3)
            {
                apellidoParte = apellidoNorm.Substring(0, 3);
            }
            else
            {
                apellidoParte = apellidoNorm;
            }

            return nombreParte + apellidoParte;
        }

        public static string GenerarDominio(string dominioEquipo)
        {
            dominioEquipo = dominioEquipo.Replace("@", "").Replace(".com", "");
            dominioEquipo = char.ToLower(dominioEquipo[0]) + dominioEquipo.Substring(1);

            return "@" + dominioEquipo + ".com";
        }

        private static string Normalizar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "";

            texto = texto.ToLower();
            texto = texto.Replace("á", "a").Replace("é", "e").Replace("í", "i")
                         .Replace("ó", "o").Replace("ú", "u")
                         .Replace("ñ", "n");

            string resultado = "";
            foreach (char c in texto)
            {
                if (char.IsLetter(c))
                    resultado += c;
            }

            return resultado;
        }
    }
}

using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEGasto;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Gasto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Pago>? Pagos { get; set; }
        public bool Activo { get; set; }

        public Gasto(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Pagos = new List<Pago>();
            Activo = true;
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new NombreInvalidoException("El nombre no puede estar vacio");
            }
        }

        private void ValidarDescripcion()
        {
            if (string.IsNullOrWhiteSpace(Descripcion))
            {
                throw new DescripcionInvalidaException("La descripción no puede estar vacia");
            }
            else if (Descripcion.Length < 5)
            {
                throw new DescripcionInvalidaException("La descripción debe tener al menos 5 caracteres");
            }
        }
    }
}

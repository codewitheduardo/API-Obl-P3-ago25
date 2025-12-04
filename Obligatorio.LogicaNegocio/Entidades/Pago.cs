using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEGasto;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public abstract class Pago
    {
        public int Id { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public Gasto TipoGasto { get; set; }
        public Usuario Usuario { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoFinal { get; set; }
        public abstract void CalcularMontoTotal();
        public abstract decimal CalcularSaldoPendiente();
        public abstract DateTime GetFechaDesde();

        public void Validar()
        {
            ValidarDescripcion();
            ValidarMonto();
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

        private void ValidarMonto()
        {
            if (Monto < 0)
            {
                throw new MontoNoValidoException("El monto debe ser un número positivo");
            }
        }
    }
}

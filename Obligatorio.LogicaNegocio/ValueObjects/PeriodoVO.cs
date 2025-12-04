using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPeriodoVO;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio.LogicaNegocio.ValueObjects
{
    [ComplexType]
    public record PeriodoVO
    {
        public DateTime Desde { get; init; }
        public DateTime Hasta { get; init; }

        public void Validar()
        {
            ValidarFechas();
        }

        private void ValidarFechas()
        {
            if (Desde >= Hasta)
            {
                throw new PeriodoNoValidoException("La fecha 'Desde' debe ser anterior a la fecha 'Hasta'");
            }
            if (Desde.Day != Hasta.Day)
            {
                throw new DiaNoCoincidenteException($"La fecha final debe tener el mismo día que la fecha inicial ({Desde.Day})");
            }
        }

        public int ObtenerCantidadMeses()
        {
            return ((Hasta.Year - Desde.Year) * 12) + Hasta.Month - Desde.Month + 1;
        }

        public int ObtenerMesesRestantes()
        {
            DateTime hoy = DateTime.Now;

            if (hoy > Hasta)
            {
                return 0;
            }

            int mesesRestantes = ((Hasta.Year - hoy.Year) * 12) + Hasta.Month - hoy.Month + 1;

            return mesesRestantes;
        }
    }
}

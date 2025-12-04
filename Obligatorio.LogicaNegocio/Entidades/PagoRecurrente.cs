using Obligatorio.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class PagoRecurrente : Pago
    {
        public PeriodoVO Periodo { get; set; }

        public override void CalcularMontoTotal()
        {
            MontoFinal = Monto * Periodo.ObtenerCantidadMeses();
        }
        
        public override decimal CalcularSaldoPendiente()
        {
            return Monto * Periodo.ObtenerMesesRestantes();
        }

        public override DateTime GetFechaDesde()
        {
            return Periodo.Desde;
        }
    }
}

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class PagoUnico : Pago
    {
        public DateTime Fecha { get; set; }
        public string NroRecibo { get; set; }

        public override void CalcularMontoTotal()
        {
            MontoFinal = Monto;
        }

        public override decimal CalcularSaldoPendiente()
        {
            return 0;
        }

        public override DateTime GetFechaDesde()
        {
            return Fecha;
        }
    }
}

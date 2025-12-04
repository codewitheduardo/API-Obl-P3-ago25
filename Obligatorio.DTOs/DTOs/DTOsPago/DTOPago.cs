using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Obligatorio.DTOs.DTOs.DTOsPago
{
    public class DTOPago
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string MetodoPago { get; set; }
        public string Gasto { get; set; }
        [JsonIgnore]
        public string UsuarioNombre { get; set; }
        [JsonIgnore]
        public string UsuarioEmail { get; set; }
        public decimal MontoFinal { get; set; }
        public string TipoPago { get; set; }
        public decimal SaldoPendiente { get; set; }

        // Propiedad compartida
        public string FechaInicio { get; set; }

        // Propiedades específicas para PagoRecurrente
        public string FechaFin { get; set; }

    }
}

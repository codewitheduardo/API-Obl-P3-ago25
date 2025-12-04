using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOsPago
{
    public class DTOAltaPago
    {
        public string TipoPago { get; set; }
        public string MetodoPago { get; set; }
        public int IdGasto { get; set; }
        [JsonIgnore]     // No aparece en el JSON
        [BindNever]      // El cliente no puede enviarlo
        [ValidateNever]  // No se valida automáticamente
        public string Email { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

        // Propiedades específicas para PagoUnico
        public DateTime? FechaInicio { get; set; }

        // Propiedades específicas para PagoRecurrente
        public DateTime? FechaFin { get; set; }
    }
}

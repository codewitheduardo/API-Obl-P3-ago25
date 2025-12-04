using Obligatorio.DTOs.DTOs.DTOsGasto;
using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.DTOs.DTOs.DTOsServicio;

namespace Obligatorio.WebApp.Models
{
    public class AltaPagoVM
    {
        public DTOAltaPago Dto { get; set; } = new DTOAltaPago();
        public List<DTOGasto> TodosLosGastos { get; set; } = new List<DTOGasto>();
        public List<DTOMetodoPago> TodosLosMetodosDePago { get; set; } = new List<DTOMetodoPago>();
    }
}

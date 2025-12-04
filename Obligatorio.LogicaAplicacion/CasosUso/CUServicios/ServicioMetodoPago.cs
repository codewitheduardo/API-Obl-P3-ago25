using Obligatorio.DTOs.DTOs.DTOsServicio;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUServicios;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUServicios
{
    public class ServicioMetodoPago : IServicioMetodoPago
    {
        public List<DTOMetodoPago> ObtenerMetodos()
        {
            return Enum.GetValues(typeof(MetodoPago))
                       .Cast<MetodoPago>()
                       .Select(e => new DTOMetodoPago
                       {
                           Nombre = e.ToString(),
                           Valor = (int)e
                       })
                       .ToList();
        }
    }
}

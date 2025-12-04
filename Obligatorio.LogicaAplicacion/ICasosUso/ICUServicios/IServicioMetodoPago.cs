using Obligatorio.DTOs.DTOs.DTOsServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUServicios
{
    public interface IServicioMetodoPago
    {
        List<DTOMetodoPago> ObtenerMetodos();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.ObtenerMateriasEstudiantes;
using MediatR;

namespace Application.UseCases.ObtenerMateriasByEstudiante
{
    public class SPMateriasEstudianteRequest : IRequest<List<SPMateriasEstudianteResponse>>
    {

        public int IdUsuario { get; set; }
    }
}

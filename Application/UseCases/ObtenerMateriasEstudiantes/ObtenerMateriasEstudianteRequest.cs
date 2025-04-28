using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.ObtenerEstudianteProfesorMateria;
using MediatR;

namespace Application.UseCases.ObtenerMateriasEstudiantes
{
    public class ObtenerMateriasEstudianteRequest : IRequest<List<ObtenerMateriasEstudianteResponse>>
    {
          
        public int IdMateria { get; set; }

    }
}

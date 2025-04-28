using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Materias;
using MediatR;

namespace Application.UseCases.ObtenerEstudianteProfesorMateria
{
    public class ObtenerEstudianteProfesorMateriaRequest : IRequest<List<ObtenerEstudianteProfesorMateriaResponse>>
    {
        public int IdProfesor { get; set; }
        public int IdMateria { get; set; }
    }
}

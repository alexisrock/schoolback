using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.ObtenerMateriasByEstudiante;
using MediatR;

namespace Application.UseCases.ObtenerMateriasByProfesor
{
    public class ObtenerMateriasByProfesorRequest : IRequest<List<ObtenerMateriasByProfesorResponse>>
    {
        public int IdUsuario { get; set; }
    }
}

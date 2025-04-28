using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.ObtenerCursos;
using MediatR;

namespace Application.UseCases.Materias
{
    public class MateriaProfesorRequest : IRequest<List<SPMateriasProfesorResponse>>
    {
    }

    public class MateriaRequest : IRequest<List<MateriaResponse>>
    {
    }
}

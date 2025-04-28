using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.RegistrarUsuarioEstudiante;
using MediatR;

namespace Application.UseCases.ObtenerCursos
{
    public class CursoRequest : IRequest<List<CursoResponse>>
    {
    }
}

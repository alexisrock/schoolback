using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mapper;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.ObtenerCursos
{
    public class CursoHandler : IRequestHandler<CursoRequest, List<CursoResponse>>
    {

        private readonly ICursoRepository _cursoRepository;

        public CursoHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<List<CursoResponse>> Handle(CursoRequest request, CancellationToken cancellationToken)
        {
            var listResponse = new List<CursoResponse>();
			try
			{
                var listCursos = await _cursoRepository.GetAll();
                listResponse.MapperListCursoResponse(listCursos);
                return listResponse;

            }
            catch (Exception)
            {

                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}

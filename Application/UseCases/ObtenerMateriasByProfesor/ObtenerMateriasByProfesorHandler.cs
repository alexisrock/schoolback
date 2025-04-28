using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mapper;
using Application.UseCases.ObtenerMateriasByEstudiante;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.ObtenerMateriasByProfesor
{
    public class ObtenerMateriasByProfesorHandler : IRequestHandler<ObtenerMateriasByProfesorRequest, List<ObtenerMateriasByProfesorResponse>>
    {

        private readonly IProfesorRepository _profesorRepository;

        public ObtenerMateriasByProfesorHandler(IProfesorRepository profesorRepository)
        {
            _profesorRepository = profesorRepository;
        }

        public async Task<List<ObtenerMateriasByProfesorResponse>> Handle(ObtenerMateriasByProfesorRequest request, CancellationToken cancellationToken)
        {
            var listResponse = new List<ObtenerMateriasByProfesorResponse>();
            try
            {

                var list = await _profesorRepository.GetMateriasByIdprofesor(request.IdUsuario);
                listResponse.MapperObtenerMateriasByIProfesorResponse(list);
                return listResponse;
            }
            catch (Exception)
            {
                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}

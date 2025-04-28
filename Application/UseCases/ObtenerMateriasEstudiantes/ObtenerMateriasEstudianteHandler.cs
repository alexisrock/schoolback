using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mapper;
using Application.UseCases.ObtenerEstudianteProfesorMateria;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.ObtenerMateriasEstudiantes
{
    public class ObtenerMateriasEstudianteHandler : IRequestHandler<ObtenerMateriasEstudianteRequest, List<ObtenerMateriasEstudianteResponse>>
    {

        private readonly IEstudianteRepository estudianteRepository;

        public ObtenerMateriasEstudianteHandler(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }

        public async Task<List<ObtenerMateriasEstudianteResponse>> Handle(ObtenerMateriasEstudianteRequest request, CancellationToken cancellationToken)
        {
            List<ObtenerMateriasEstudianteResponse> listResponse = new List<ObtenerMateriasEstudianteResponse> ();
            try
            {

                var list = await estudianteRepository.GetMateriasEstudiante(request.IdMateria);
                listResponse.MapperObtenerEstudianteMateriaResponse(list);
                return listResponse;
            }
            catch (Exception)
            {

                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}

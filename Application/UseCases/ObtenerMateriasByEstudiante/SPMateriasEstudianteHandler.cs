using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mapper;
using Application.UseCases.ObtenerMateriasEstudiantes;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.ObtenerMateriasByEstudiante
{
    public class SPMateriasEstudianteHandler : IRequestHandler<SPMateriasEstudianteRequest, List<SPMateriasEstudianteResponse>>
    {

        private readonly IEstudianteRepository estudianteRepository;

        public SPMateriasEstudianteHandler(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }

        public async Task<List<SPMateriasEstudianteResponse>> Handle(SPMateriasEstudianteRequest request, CancellationToken cancellationToken)
        {
            var listResponse = new List<SPMateriasEstudianteResponse>();

            try
            {

                var list = await estudianteRepository.GetMateriasByIdEstudiante(request.IdUsuario);
                listResponse.MapperObtenerMateriasByIdEstudianteResponse(list);
                return listResponse;
            }
            catch (Exception)
            {
                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}

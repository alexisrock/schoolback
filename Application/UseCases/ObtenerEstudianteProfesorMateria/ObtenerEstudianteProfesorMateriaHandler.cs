using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mapper;
using Application.UseCases.Materias;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.ObtenerEstudianteProfesorMateria
{
    public class ObtenerEstudianteProfesorMateriaHandler : IRequestHandler<ObtenerEstudianteProfesorMateriaRequest, List<ObtenerEstudianteProfesorMateriaResponse>>
    {
        private readonly IProfesorRepository profesorRepository;

        public ObtenerEstudianteProfesorMateriaHandler(IProfesorRepository profesorRepository)
        {
            this.profesorRepository = profesorRepository;
        }

        public async Task<List<ObtenerEstudianteProfesorMateriaResponse>> Handle(ObtenerEstudianteProfesorMateriaRequest request, CancellationToken cancellationToken)
        {
            List <ObtenerEstudianteProfesorMateriaResponse> listResponse = new List<ObtenerEstudianteProfesorMateriaResponse> ();
            try
            {

                var listSp = await profesorRepository.GetMateriasprofesor(request.IdProfesor, request.IdMateria);
                listResponse.MapperObtenerEstudianteProfesorMateriaResponse(listSp);
                return listResponse;
            }
            catch (Exception)
            {

                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}

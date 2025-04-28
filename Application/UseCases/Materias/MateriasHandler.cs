using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mapper;
using Application.UseCases.ObtenerCursos;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Materias
{
    public class MateriasHandler : IRequestHandler<MateriaProfesorRequest, List<SPMateriasProfesorResponse>>,
        IRequestHandler<MateriaRequest, List<MateriaResponse>>
    {
        private readonly IMateriaProfesorRepository _repository;
        private readonly IMateriaRepository _materiaRepository;

        public MateriasHandler(IMateriaProfesorRepository repository, IMateriaRepository materiaRepository)
        {
            _repository = repository;
            _materiaRepository = materiaRepository;
        }

        public async Task<List<SPMateriasProfesorResponse>> Handle(MateriaProfesorRequest request, CancellationToken cancellationToken)
        {

            var listResponse = new List<SPMateriasProfesorResponse>();
			try
			{
                var listMaterias = await _repository.GetMateriasprofesor();
                listResponse.MapperListMateriaResponse(listMaterias);
                return listResponse;
            }
            catch (Exception)
            {

                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public async Task<List<MateriaResponse>> Handle(MateriaRequest request, CancellationToken cancellationToken)
        {
            var listResponse = new List<MateriaResponse>();

            try
            {
                var list = await _materiaRepository.GetAll();
                listResponse.MapperListMateriaResponse(list);
                return listResponse;
            }
            catch (Exception)
            {

                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}

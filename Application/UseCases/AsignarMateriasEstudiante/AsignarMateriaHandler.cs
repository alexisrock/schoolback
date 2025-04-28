using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Application.Mapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.AsignarMateriasEstudiante
{
    public class AsignarMateriaHandler : IRequestHandler<AsignarMateriaRequest, BaseResponse>
    {

        private readonly IInscripcionMateriaRepository _inscripcionMateriaRepository;

        public AsignarMateriaHandler(IInscripcionMateriaRepository inscripcionMateriaRepository)
        {
            _inscripcionMateriaRepository = inscripcionMateriaRepository;
        }

        public async Task<BaseResponse> Handle(AsignarMateriaRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                if (await ValidarMateriasEstudiante(request.IdEstudiante))
                {
                    throw new ApiException("Ya tiene materias registradas", (int)System.Net.HttpStatusCode.BadRequest);
                }

                if (!request.Materias.Any())
                {
                    throw new ApiException("Debe registrar al menos una materia", (int)System.Net.HttpStatusCode.BadRequest);
                }

                if (ValidarIdProfeinMaterias(request.Materias))
                {
                    throw new ApiException("No puede registrar dos materias con el mismo profesor", (int)System.Net.HttpStatusCode.BadRequest);
                }


                await Insert(request);

                response.SetDataResponse(HttpStatusCode.OK, $"Materias registradas con exito");
                return response;
            }
            catch (Exception ex) when (ex is ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }


        private async  Task<bool> ValidarMateriasEstudiante(int idEstudiante)
        {
            var materias = await _inscripcionMateriaRepository.GetListByParam( x => x.IdEstudiante== idEstudiante);
            return materias.Any();
        }

        private bool ValidarIdProfeinMaterias(List<AsignarMateriaProfesorRequest> materia)
        {
            var list = materia.GroupBy(x => x.IdProfesor).ToList();
            return list.Count != materia.Count;
        }

        private async Task Insert(AsignarMateriaRequest request)
        {
            List<InscripcionMateria> listAsignarMateria = new List<InscripcionMateria>();
            request.Materias.ForEach(materia => {
                var inscripcionMateria = new InscripcionMateria(materia.IdMateriaProfesor, request.IdEstudiante);
                listAsignarMateria.Add(inscripcionMateria);
            });

            await _inscripcionMateriaRepository.Create(listAsignarMateria.ToArray());
        }

    }
}

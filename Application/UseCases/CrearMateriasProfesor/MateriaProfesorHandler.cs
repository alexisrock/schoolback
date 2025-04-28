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
using FluentValidation;
using MediatR;

namespace Application.UseCases.CrearMateriasProfesor
{
    public class MateriaProfesorHandler : IRequestHandler<MateriaProfesorRequest, BaseResponse>
    {
         
        private readonly IMateriaProfesorRepository repository;

        public MateriaProfesorHandler(IMateriaProfesorRepository repository)
        {
            
            this.repository = repository;
        }

        public async Task<BaseResponse> Handle(MateriaProfesorRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                if (!request.Materias.Any()  ||  request.Materias.Count >= 3) {

                    string mensaje = request.Materias.Any() ? "La cantidad de materias por profesor es mayor a 3" : "Debe agregar al menos una materia";
                    throw new ApiException(mensaje, (int)System.Net.HttpStatusCode.BadRequest);
                }
                if(await ValidateMateriasProfesor(request.IdProfesor))
                {
                    throw new ApiException("Ya tiene materias registradas", (int)System.Net.HttpStatusCode.BadRequest);
                }

                await InsertMateriasProfesor(request);
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


        private  async Task InsertMateriasProfesor(MateriaProfesorRequest request)
        {
            List<MateriaProfesor> materiaProfesors = new List<MateriaProfesor>();

            request.Materias.ForEach(materia => {
                var materiasProfesor = new MateriaProfesor(materia.IdMateria, request.IdProfesor);
                materiaProfesors.Add(materiasProfesor);
            });

            await repository.CreateRange(materiaProfesors.ToArray());
        }


        private async Task<bool> ValidateMateriasProfesor(int idProfesor)
        {
            var listMateras = await repository.GetAllById(idProfesor);
            return listMateras.Any();
        }
    }
}

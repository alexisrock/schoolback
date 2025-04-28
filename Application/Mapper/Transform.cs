using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Application.UseCases.Materias;
using Application.UseCases.ObtenerCursos;
using Application.UseCases.ObtenerEstudianteProfesorMateria;
using Application.UseCases.ObtenerMateriasByEstudiante;
using Application.UseCases.ObtenerMateriasByProfesor;
using Application.UseCases.ObtenerMateriasEstudiantes;
using Application.UseCases.ObtenerRoles;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Mapper
{
    [ExcludeFromCodeCoverage]
    internal static class Transform
    {

        internal static BaseResponse SetDataResponse(this BaseResponse objeto, HttpStatusCode StatusCode, string? Message)
        {
            objeto.message = Message;
            return objeto;
        }

        internal static List<RolResponse> MapperListRolResponse(this List<RolResponse> listResponse, List<Rol> list)
        {
            if (list.Any())
            {

                list.ForEach(rol => {
                    var response = new RolResponse();
                    response.Id = rol.Id;
                    response.Description = rol.Description;
                    listResponse.Add(response);
                });

            }

            return listResponse;           
        }

        internal static List<CursoResponse> MapperListCursoResponse(this List<CursoResponse> cursoResponses, List<Curso> cursos)
        {

            if (cursos.Any())
            {
                cursos.ForEach(curso => {
                    var response = new CursoResponse();
                    response.Id = curso.Id;
                    response.Descripcion = curso.Descripcion;
                    cursoResponses.Add(response);
                });
            }
            return cursoResponses;
        }

        internal static List<SPMateriasProfesorResponse> MapperListMateriaResponse(this List<SPMateriasProfesorResponse> materiaResponses, List<SPMateriasProfesor> materias)
        {
            if (materias.Any())
            {
                materias.ForEach(materia => {
                    var response = new SPMateriasProfesorResponse();
                    response.Id = materia.Id;
                    response.IdMateria = materia.IdMateria; 
                    response.Descripcion = materia.Descripcion;
                    response.IdProfesor = materia.IdProfesor;
                    response.NameUsuario = materia.NameUsuario;



                    materiaResponses.Add(response);
                });
            }

            return materiaResponses;
        }

        internal static List<MateriaResponse> MapperListMateriaResponse(this List<MateriaResponse> materiaResponses, List<Materia> materias)
        {
            if (materias.Any())
            {
                materias.ForEach(materia => {
                    var response = new MateriaResponse();
                    response.Id = materia.Id;               
                    response.Descripcion = materia.Descripcion;
                    



                    materiaResponses.Add(response);
                });
            }

            return materiaResponses;
        }

        internal static List<ObtenerEstudianteProfesorMateriaResponse> MapperObtenerEstudianteProfesorMateriaResponse(this List<ObtenerEstudianteProfesorMateriaResponse> listResponse, List<SPEstudiantesByProfesor> list)
        {
            if (list.Any())
            {

                list.ForEach(list => {
                    var response = new ObtenerEstudianteProfesorMateriaResponse();
                    response.Estudiante = list.Estudiante;
                    response.Email = list.Email;
                    listResponse.Add(response);
                });
            }

            return listResponse;
        }

        internal static List<ObtenerMateriasEstudianteResponse> MapperObtenerEstudianteMateriaResponse(this List<ObtenerMateriasEstudianteResponse> listResponse, List<SPEstudiantesMaterias> list)
        {
            if (list.Any())
            {

                list.ForEach(list => {
                    var response = new ObtenerMateriasEstudianteResponse();
                    response.Estudiante = list.Estudiante;
                    response.Email = list.Email;
                    response.Profesor = list.Profesor;
                    listResponse.Add(response);
                });
            }

            return listResponse;
        }


        internal static List<SPMateriasEstudianteResponse> MapperObtenerMateriasByIdEstudianteResponse(this List<SPMateriasEstudianteResponse> listResponse, List<SPMateriasEstudiante> list)
        {
            if (list.Any())
            {

                list.ForEach(list => {
                    var response = new SPMateriasEstudianteResponse();
                    response.Materia = list.Materia;
                    response.MateriaId = list.MateriaId;
                    response.Profesor = list.Profesor;
                    listResponse.Add(response);
                });
            }

            return listResponse;
        }

        internal static List<ObtenerMateriasByProfesorResponse> MapperObtenerMateriasByIProfesorResponse(this List<ObtenerMateriasByProfesorResponse> listResponse, List<SPMateriasByIdProfesor> list)
        {
            if (list.Any())
            {

                list.ForEach(list => {
                    var response = new ObtenerMateriasByProfesorResponse();
                    response.Materia = list.Materia;
                    response.MateriaId = list.MateriaId;                   
                    listResponse.Add(response);
                });
            }

            return listResponse;
        }
    }
}

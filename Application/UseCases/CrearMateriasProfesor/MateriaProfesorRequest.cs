using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Application.UseCases.RegistrarUsuarioEstudiante;
using MediatR;

namespace Application.UseCases.CrearMateriasProfesor
{
    public class MateriaProfesorRequest : IRequest<BaseResponse>    {    
        public int IdProfesor { get; set; }
        public List<MateriaIdProfesorRequest> Materias { get; set; }
       
    }

    public class MateriaIdProfesorRequest
    {
        public int IdMateria { get; set; }
    }
}

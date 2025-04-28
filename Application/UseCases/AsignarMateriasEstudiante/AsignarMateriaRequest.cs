using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Application.UseCases.CrearMateriasProfesor;
using MediatR;

namespace Application.UseCases.AsignarMateriasEstudiante
{
    public class AsignarMateriaRequest : IRequest<BaseResponse>
    {

        public int IdEstudiante { get; set; }
        public List<AsignarMateriaProfesorRequest> Materias { get; set; }
    }


    public class AsignarMateriaProfesorRequest
    {
        public int IdMateriaProfesor { get; set; }
        public int IdProfesor { get; set; }

    }
}

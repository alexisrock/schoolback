using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ObtenerMateriasEstudiantes
{
    public class ObtenerMateriasEstudianteResponse
    {
        public string Estudiante { get; set; }
        public string Email { get; set; }
        public string Profesor { get; set; }
    }
}

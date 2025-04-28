using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ObtenerMateriasByEstudiante
{
    public class SPMateriasEstudianteResponse
    {
        public int MateriaId { get; set; }
        public string Materia { get; set; }
        public string Profesor { get; set; }

    }
}

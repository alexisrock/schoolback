using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InscripcionMateria
    {

        public int Id { get; set; }
        public int IdMateriaProfesor { get; set; }
        public MateriaProfesor MateriaProfesor { get; set; }
        public int IdEstudiante { get; set; }        
        public Estudiante Estudiante { get; set; }

        public InscripcionMateria(int idMateria, int idEstudiante)
        {
            IdMateriaProfesor = idMateria;
            IdEstudiante = idEstudiante;
        }

        public InscripcionMateria()
        {
        }
    }
}

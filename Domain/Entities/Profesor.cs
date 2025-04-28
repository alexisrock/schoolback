using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Profesor
    {
        public Profesor()
        {
        }

        public Profesor(int idUsuario, string profesion)
        {
            IdUsuario = idUsuario;
            Profesion = profesion;         
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Profesion { get; set; }
        public Users Usuario { get; set; }
    }

    public class SPEstudiantesByProfesor
    {
        public string Estudiante { get; set; }
        public string Email { get; set; }
    }

    public class SPMateriasByIdProfesor
    {
        public int MateriaId { get;  set; }
        public string Materia { get; set; }

    }


}

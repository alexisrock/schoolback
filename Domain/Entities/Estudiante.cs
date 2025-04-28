using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public Users Usuario { get; set; }
        public int IdCurso { get; set; }       
        public Curso Curso { get; set; }
   

        public Estudiante(int idUsuario, int idCurso)
        {
            IdUsuario = idUsuario;
            IdCurso = idCurso;
        }

        public Estudiante()
        {
        }
    }

    public class SPEstudiantesMaterias
    {
        public string Estudiante { get; set; }
        public string Email { get; set; }
        public string Profesor { get; set; }
    }


    public class SPMateriasEstudiante
    {
        public int MateriaId { get; set; }
        public string Materia { get; set; }
        public string Profesor { get; set; }
    }
}

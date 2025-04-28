using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Materias
{
    public class SPMateriasProfesorResponse
    {
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public string Descripcion { get; set; }
        public int IdProfesor { get; set; }
        public string NameUsuario { get; set; }
    }


    public class MateriaResponse
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}

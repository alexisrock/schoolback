namespace Domain.Entities
{
    public class MateriaProfesor
    {
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public int IdProfesor { get; set; }

        public Materia Materia  { get; set; }
        public Profesor Profesor { get; set; }

        public MateriaProfesor(int idMateria, int idProfesor)
        {
            IdMateria = idMateria;
            IdProfesor = idProfesor;
        }

        public MateriaProfesor()
        {
        }
    }



    public class SPMateriasProfesor
    {
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public string Descripcion { get; set; }
        public int IdProfesor { get; set; }
        public string NameUsuario { get; set; }


    }
}

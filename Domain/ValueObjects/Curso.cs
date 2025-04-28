using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.ValueObjects
{
    public class Curso
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
     


        public Curso() { }
    }
}

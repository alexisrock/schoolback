using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Users
    {
        
        public int Id { get; set; }
        public string NameUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public Rol Rol { get; set; }  

        public Users(string nombre, string email, string password, int idRol)
        {
            NameUsuario = nombre;
            Email = email;
            Password = password;
            IdRol = idRol;
        }

        public Users()
        {
        }
    }
}

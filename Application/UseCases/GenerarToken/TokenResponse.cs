using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.GenerarToken
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public int IdRol { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipo { get; set; }

    }
}

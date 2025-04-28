using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.UseCases.ValidarToken
{
    public class TokenRequest : IRequest<bool>
    {
        public string? Token { get; set; }
    }
}

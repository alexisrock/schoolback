using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using MediatR;

namespace Application.UseCases.ObtenerRoles
{
    public class RolRequest : IRequest<List<RolResponse>>
    {
    }
}

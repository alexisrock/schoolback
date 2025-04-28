using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;
using Application.Mapper;

namespace Application.UseCases.ObtenerRoles
{
    public class RolesHandler : IRequestHandler<RolRequest, List<RolResponse>>
    {

        private readonly IRolRepository _repository;

        public RolesHandler(IRolRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RolResponse>> Handle(RolRequest request, CancellationToken cancellationToken)
        {
            var listResponse = new List<RolResponse>();
            try
            {

                var listRol = await _repository.GetAll();
                listResponse.MapperListRolResponse(listRol);
                return listResponse;
            }
            catch (Exception)
            {

                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}

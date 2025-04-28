using ApiManejoRRHH.Helpers;
using Application.Common;
using Application.UseCases.AsignarMateriasEstudiante;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Controlador de materia profesor
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InscripcionMateriaController : ControllerBase
    {

        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        public InscripcionMateriaController(ISender _sender)
        {
            this._sender = _sender;
        }





        /// <summary>
        /// Metodo para la creacion de materias de un estudiante      
        /// </summary>
        [HttpPost, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] AsignarMateriaRequest request)
        {
            var user = await _sender.Send(request);
            return Ok(user);
        }

    }
}

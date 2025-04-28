using ApiManejoRRHH.Helpers;
using Application.Common;
using Application.UseCases.CrearMateriasProfesor;
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
    public class MateriaProfesorController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        public MateriaProfesorController(ISender _sender)
        {
            this._sender = _sender;
        }


        /// <summary>
        /// Metodo para la creacion materias de un profesor      
        /// </summary>
        [HttpPost, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] MateriaProfesorRequest request)
        { 
            var user = await _sender.Send(request);
            return Ok(user);
        }



    }
}

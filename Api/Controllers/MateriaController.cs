using ApiManejoRRHH.Helpers;
using Application.UseCases.Materias;
using Application.UseCases.ObtenerRoles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Controller of rol
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MateriaController : ControllerBase
    {


        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        public MateriaController(ISender sender)
        {
            this._sender = sender;
        }


        /// <summary>
        /// Metodo para obtener todas las materias      
        /// </summary>
        ///  

        [HttpGet, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var listproducto = await _sender.Send(new MateriaRequest() { });
            return Ok(listproducto);
        }




        /// <summary>
        /// Metodo para obtener  las materias  que el estudiante puede registrar    
        /// </summary>
        ///  

        [HttpGet, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllMaterias()
        {
            var listproducto = await _sender.Send(new MateriaProfesorRequest() { });
            return Ok(listproducto);
        }
    }
}

using ApiManejoRRHH.Helpers;
using Application.UseCases.Materias;
using Application.UseCases.ObtenerEstudianteProfesorMateria;
using Application.UseCases.ObtenerMateriasByProfesor;
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
    public class ProfesorController : ControllerBase
    {




        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProfesorController(ISender sender)
        {
            this._sender = sender;
        }


        /// <summary>
        /// Metodo para obtener las los nombres de los estudiantes por materia y profesor
        /// </summary>
        ///  


        [HttpGet, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllEstudiantesMateria([FromQuery] int idProfesor, [FromQuery] int idMateria)
        {
            var listproducto = await _sender.Send(new ObtenerEstudianteProfesorMateriaRequest() { IdProfesor= idProfesor, IdMateria = idMateria });
            return Ok(listproducto);
        }



        /// <summary>
        /// Metodo para obtener las los nombres de los estudiantes por materia y profesor
        /// </summary>
        ///  


        [HttpGet, Route("[action]/{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllMaterias( int idUsuario)
        {
            var listproducto = await _sender.Send(new ObtenerMateriasByProfesorRequest() { IdUsuario = idUsuario   });
            return Ok(listproducto);
        }


    }
}

using ApiManejoRRHH.Helpers;
using Application.UseCases.ObtenerEstudianteProfesorMateria;
using Application.UseCases.ObtenerMateriasByEstudiante;
using Application.UseCases.ObtenerMateriasEstudiantes;
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
    public class EstudianteController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        public EstudianteController(ISender sender)
        {
            this._sender = sender;
        }

        /// <summary>
        /// Metodo para obtener todas las materias por IdUsuario
        /// </summary>

        [HttpGet, Route("[action]/{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllByIdEstudiante (int idUsuario)
        {
            var listproducto = await _sender.Send(new SPMateriasEstudianteRequest() {   IdUsuario = idUsuario });
            return Ok(listproducto);
        }




        /// <summary>
        /// Metodo para obtener por materia todos estudiantes   
        /// </summary>

        [HttpGet, Route("[action]/{idMateria}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllMateriasEstudiantes( int idMateria)
        {
            var listproducto = await _sender.Send(new ObtenerMateriasEstudianteRequest() { IdMateria = idMateria });
            return Ok(listproducto);
        }
    }
}

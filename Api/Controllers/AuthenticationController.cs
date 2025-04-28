﻿
using System.Net;
using Microsoft.AspNetCore.Mvc; 
using MediatR;
using Application.Common;
using Application.UseCases.GenerarToken;
using Application.UseCases.RegistrarUsuarioEstudiante;
using Application.UseCases.RegistrarUsuarioProfesor;

namespace Api.Controllers
{
    /// <summary>
    /// Controller of Authentication
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _sender;

        

        /// <summary>
        /// Constructor
        /// </summary>
        public AuthenticationController(ISender sender)
        {
            this._sender = sender;
        }



        /// <summary>
        /// Metodo de autenticacion      
        /// </summary>
        ///  
        /// <returns></returns>
        /// /// <remarks>
        /// Request example:
        ///  
        ///     {
        ///        "Email": "prueba@correo.com",
        ///        "Password": "cHJ1RUJB"
        /// 
        ///     }
        ///
        /// </remarks>

        [HttpPost, Route("[action]")]
        [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Authentication([FromBody] TokenCreateRequest userTokenRequest)
        {
            var user = await _sender.Send(userTokenRequest);
            return Ok(user);
        }






        /// <summary>
        /// Metodo para la creacion del usuario estudiante estudiante sin token      
        /// </summary>
        ///
        /// <returns></returns>
     


        [HttpPost, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEstudiante([FromBody] UsuarioEstudianteRequest request)
        {
            var user = await _sender.Send(request);
            return Ok(user);
        }



        /// <summary>
        /// Metodo para la creacion del usuario profesor estudiante sin token      
        /// </summary>
        ///
        /// <returns></returns>



        [HttpPost, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProfesor([FromBody] UsuarioProfesorRequest request)
        {
            var user = await _sender.Send(request);
            return Ok(user);
        }


    }
}

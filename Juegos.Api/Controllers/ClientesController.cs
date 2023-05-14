using Juegos.Api.DataTransferObjects;
using Juegos.Core;
using Juegos.Core.Entities;
using Juegos.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Juegos.Api.Controllers
{
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientesController(IClientService clientService) {
            this.clientService = clientService;
        }

        /// <summary>
        /// Crea un cliente
        /// </summary>
        /// <param name="juegoId">Id del juego</param>
        /// <param name="client">Id del cliente</param>
        /// <returns></returns>
        [HttpPost("videojuegos/{juegoId}/clientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ClienteDetailDto> CreateClient([FromRoute]int juegoId, Cliente client)
        {
            var result = this.clientService.Create(client);
            if (result.Succeeded)
            {
                return new CreatedAtActionResult(nameof(GetClienteById), "Clientes", new { juegoId = juegoId, clientId = client.Id }, client);
            }
            return GetErrorResult<Cliente>(result);


        }
        /// <summary>
        /// Lista los clientes que crentaron un juego
        /// </summary>
        /// <param name="juegoId">Id del juego rentado</param>
        /// <param name="clienteId">Id del cliente</param>
        /// <returns></returns>
        [HttpGet("videojuegos/{juegoId}/[controller]/{clienteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClienteDetailDto> GetClienteById([FromRoute]int juegoId, int clienteId)
        {

            var result = this.clientService.GetById(clienteId, juegoId);
            if (result.Succeeded)
            {
                return Ok(result.Result);
            }
            return GetErrorResult<Cliente>(result);
        }

        private ActionResult GetErrorResult<TResult>(OperationResult<TResult> result)
        {
            switch (result.Error.Code)
            {
                case Core.ErrorCode.NotFound:
                    return NotFound(result.Error.Message);
                case Core.ErrorCode.Unauthorized:
                    return Unauthorized(result.Error.Message);
                default:
                    return BadRequest(result.Error.Message);
            }
        }
    }
}

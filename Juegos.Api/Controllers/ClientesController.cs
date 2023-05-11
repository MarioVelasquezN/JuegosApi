using Juegos.Api.Models;
using Juegos.Api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Juegos.Api.Controllers
{
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IRepository<Cliente> clienteRepository;
        private readonly IRepository<Videojuego> videojuegoRepository;

        public ClientesController(IRepository<Cliente> clienteRepository, IRepository<Videojuego> videojuegoRepository) {
            this.clienteRepository = clienteRepository;
            this.videojuegoRepository = videojuegoRepository;
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
        public ActionResult CreateClient([FromRoute]int juegoId, Cliente client)
        {
           
            var juego = this.videojuegoRepository.GetById(juegoId);
            if (juego is null)
            {
                return BadRequest($"No se encontro un juego con id {juegoId} para rentar");
            }
            
            this.clienteRepository.Add(client);
            return new CreatedAtActionResult(nameof(GetClientesById), "Clientes", new { juegoId = juegoId, clienteId = client.Id }, client);

        }
        /// <summary>
        /// Lista los clientes que crentaron un juego
        /// </summary>
        /// <param name="juegoId">Id del juego rentado</param>
        /// <param name="clienteId">Id del cliente</param>
        /// <returns></returns>
        [HttpGet("videojuegos/{juegoId}/[controller]/{cleinteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetClientesById([FromRoute] int juegoId, int clienteId)
        {

            var juego = videojuegoRepository.GetById(juegoId);
            if (juego is null)
            {
                return BadRequest($"No se encontro un juego con el id {juegoId}");
            }
            var cliente = videojuegoRepository.GetById(clienteId);
            if (cliente == null)
            {
                return BadRequest($"No se encontro cliente con Id {clienteId}");
            }
            return Ok(cliente);
        }
    }

    
}

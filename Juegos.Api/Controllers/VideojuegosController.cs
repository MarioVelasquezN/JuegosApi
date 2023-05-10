using Juegos.Api;
using Juegos.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Juegos.Api.Controllers
{
    [ApiController]
    public class VideojuegosController : ControllerBase
    {
        private readonly JuegosContext context;

        public VideojuegosController(JuegosContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Agrega un Juego a la Categtoria
        /// </summary>
        /// <param name="categId">El id de Categoria que agregara al juego</param>
        /// <param name="juego">El Juego que se agregara a la categoria</param>
        /// <returns>El juego agregado</returns>
        [HttpPost("categorias/{categId}/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public IActionResult AddJuego([FromRoute]int categId,[FromBody]Videojuego juego)
        {
            var categ = context.Categorias.FirstOrDefault(x => x.Id == categId);
            if (categ == null)
            {
                return BadRequest($"No se encontro categoria con Id {categId} para crear el Juego");
            }


            context.VideoJuegos.Add(juego);
            context.SaveChanges();
            return new CreatedAtActionResult("GetJuegosById", "Videojuegos", new { categId = categId, juegoId = juego.Id }, juego);
            
          
        }

        /// <summary>
        /// Muestra los Juegos por  Id de Categoria
        /// </summary>
        /// <param name="categId">El Id de la Categoria</param>
        /// <returns>Los Juegos en la categoria</returns>
        [HttpGet("categorias/{categId}/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetJuegosByCategoria([FromRoute]int categId)
        {
            var categ = context.Categorias.FirstOrDefault(x => x.Id == categId);
            if (categ == null)
            {
                return BadRequest($"No se encontro categoria con Id {categId}");
            }
            return Ok(context.VideoJuegos.Where(x => x.CategoriaId == categId));
            
            
        }

        /// <summary>
        /// Muestra los Juegos por Id dentro de una Categoria especifica
        /// </summary>
        /// <param name="categId">Id de la Categoria</param>
        /// <param name="juegoId">Id del Juego</param>
        /// <returns>El juego en la categoria</returns>
        [HttpGet("categorias/{categId}/[controller]/{juegoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetJuegosById([FromRoute] int categId,int juegoId)
        {
            var categ = context.Categorias.FirstOrDefault(x => x.Id == categId);
            if (categ == null)
            {
                return BadRequest($"No se encontro categoria con Id {categId}");
            }
            var juego = context.VideoJuegos.FirstOrDefault(x => x.CategoriaId == categId && x.Id == juegoId);
            if (juego is null)
            {
                return NotFound($"No se encontro un juego con el id {juegoId}");
            }
            return Ok(juego);
        }
        
    }
}


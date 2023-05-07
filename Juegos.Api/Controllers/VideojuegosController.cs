using Juegos.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Juegos.Api.Controllers
{
    [ApiController]
    public class VideojuegosController : ControllerBase
    {
        /// <summary>
        /// Agrega un Juego a la Categtoria
        /// </summary>
        /// <param name="categId">El id de Categoria que agregara al juego</param>
        /// <param name="juego">El Juego que se agregara a la categoria</param>
        /// <returns>El juego agregado</returns>
        [HttpPost("categorias/{categId}/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddJuego(Guid categId,[FromBody]Videojuego juego)
        {
            var categ = Database.Categorias.FirstOrDefault(x => x.Id == categId);
            if (categ == null)
            {
                return BadRequest($"No se encontro categoria con Id {categId} para crear el Juego");
            }
            juego.Id=Guid.NewGuid();
            Database.Videojuegos.Add(juego);
            return Ok(juego);

        }

        /// <summary>
        /// Muestra los Juegos por  Id de Categoria
        /// </summary>
        /// <param name="categId">El Id de la Categoria</param>
        /// <returns>Los Juegos en la categoria</returns>
        [HttpGet("categorias/{categId}/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetJuegosByCategoria([FromRoute]Guid categId)
        {
            var categ = Database.Categorias.FirstOrDefault(x => x.Id == categId);
            if (categ == null)
            {
                return BadRequest($"No se encontro categoria con Id {categId}");
            }
            return Ok(Database.Videojuegos.Where(x=>x.CategoriaId==categId));
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
        public ActionResult GetJuegosById([FromRoute] Guid categId,Guid juegoId)
        {
            var categ = Database.Categorias.FirstOrDefault(x => x.Id == categId);
            if (categ == null)
            {
                return BadRequest($"No se encontro categoria con Id {categId}");
            }
            return Ok(Database.Videojuegos.FirstOrDefault(x => x.CategoriaId == categId && x.Id==juegoId));
        }
        //[HttpGet(Name ="GetVideo-juegos")]
        //public IEnumerable<Videojuego> get()
        //{
        //    return Database.Categorias;
        //}

        //[HttpGet("{id}")]
        //public Videojuego getById(Guid id)
        //{
        //    return Videojuegos.FirstOrDefault(x=>x.Id==id);
        //}
    }
}

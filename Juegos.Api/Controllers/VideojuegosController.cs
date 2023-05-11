using Juegos.Api;
using Juegos.Api.DataTransferObjects;
using Juegos.Api.Models;
using Juegos.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Juegos.Api.Controllers
{
    [ApiController]
    public class VideojuegosController : ControllerBase
    {
        private readonly IRepository<Videojuego> videojuegoRepository;
        private readonly IRepository<Categoria> categoriaRepository;

        public VideojuegosController(IRepository<Videojuego> videojuegoRepository, IRepository<Categoria> categoriaRepository)
        {
            this.videojuegoRepository = videojuegoRepository;
            this.categoriaRepository = categoriaRepository;
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
        public ActionResult<VideoJuegoDetailDto> AddJuego([FromRoute]int categId,[FromBody]VideojuegoCreateDto juego)
        {
            var categ = this.categoriaRepository.GetById(categId);
            if (categ == null)
            {
                return BadRequest($"No se encontro categoria con Id {categId} para crear el Juego");
            }
            var createdVideojuego=videojuegoRepository.Add(new Videojuego
            {
                Nombrejuego=juego.Nombrejuego,
                FechaPublicacion=juego.FechaPublicacion,
                Autor=juego.Autor,
                ModoJuego=juego.ModoJuego,
                CopiasDisponibles=juego.CopiasDisponibles,
            });
            return new CreatedAtActionResult("GetJuegosById", "Videojuegos", new {categId=categId,juego= createdVideojuego.Id },new VideoJuegoDetailDto
            {
                Id=createdVideojuego.Id,
                Nombrejuego=createdVideojuego.Nombrejuego,
                FechaPublicacion=createdVideojuego.FechaPublicacion,
                Autor=createdVideojuego.Autor,
                ModoJuego=createdVideojuego.ModoJuego,
                CopiasDisponibles=createdVideojuego.CopiasDisponibles
            });
            
          
        }

        /// <summary>
        /// Muestra los Juegos por  Id de Categoria
        /// </summary>
        /// <param name="categId">El Id de la Categoria</param>
        /// <returns>Los Juegos en la categoria</returns>
        [HttpGet("categorias/{categId}/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<VideojuegoCreateDto>> GetJuegosByCategoria([FromRoute]int categId)
        {
            var categ = this.categoriaRepository.GetById(categId);
            if (categ == null)
            {
                return BadRequest($"No se encontro categoria con Id {categId}");
            }
            return Ok(videojuegoRepository.Filter(x => x.CategoriaId == categId)
                .Select(x=>new VideoJuegoDetailDto
                {
                    Id = x.Id,
                    Nombrejuego=x.Nombrejuego,
                    FechaPublicacion=x.FechaPublicacion,
                    Autor=x.Autor,
                    ModoJuego=x.ModoJuego,
                    CopiasDisponibles=x.CopiasDisponibles,
                    CategoriaId=x.CategoriaId
                }));
       
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
        public ActionResult<VideoJuegoDetailDto> GetJuegosById([FromRoute] int categId,int juegoId)
        {
            var categ = this.categoriaRepository.GetById(categId);
            if (categ == null)
            {
                return BadRequest($"No se encontro categoria con Id {categId}");
            }
            var juego = videojuegoRepository.GetById(juegoId);
            if (juego is null)
            {
                return NotFound($"No se encontro un juego con el id {juegoId}");
            }
            return Ok(new VideoJuegoDetailDto
            {
                Id = juego.Id,
                Nombrejuego = juego.Nombrejuego,
                FechaPublicacion = juego.FechaPublicacion,
                Autor = juego.Autor,
                ModoJuego = juego.ModoJuego,
                CopiasDisponibles = juego.CopiasDisponibles,
                CategoriaId = juego.CategoriaId,
            });
        }
        
    }
}


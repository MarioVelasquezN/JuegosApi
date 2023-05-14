using Juegos.Api.DataTransferObjects;
using Juegos.Core.Entities;
using Juegos.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Juegos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly IRepository<Categoria> categoriaRepository;

        public CategoriasController(IRepository<Categoria> categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        /// <summary>
        /// Muestra una lista de categorias
        /// </summary>
        /// <param name="nombre">Nombre de la categoria</param>
        /// <returns>Las Categorias Creadas</returns>
        [HttpGet(Name = "GetCategorias")]
        public ActionResult<IEnumerable<CategoriaListDto>> GetCategorias([FromQuery] string? nombre)
        {

            if (string.IsNullOrEmpty(nombre))
            {
                return Ok(categoriaRepository.Get().Select(x => new CategoriaListDto
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Nombrecategoria = x.Nombrecategoria
                }));
            }
            var categorias=categoriaRepository.Filter(x => x.Nombrecategoria.StartsWith(nombre));
            return Ok(categorias.Select(x => new CategoriaListDto
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nombrecategoria = x.Nombrecategoria
            }));
            //var categoriasList = new List<CategoriaListDto>();
            //foreach(var categoria in categorias)
            //{
            //    categoriasList.Add(new CategoriaListDto
            //    {
            //        Id = categoria.Id,
            //        Codigo=categoria.Codigo,
            //        Nombrecategoria=categoria.Nombrecategoria
            //    });
            //}
            
            
        }
        /// <summary>
        /// Muestra las categorias por id
        /// </summary>
        /// <param name="id">El id de las categorias</param>
        /// <returns>Los Id de las categorias creadas</returns>
        [HttpGet("{id}")]
        public ActionResult<CategoriaDetailDto> GetUserById(int id)
        {
            var categ=categoriaRepository.GetById(id);
            if (categ is null)
            {
                return BadRequest("No existe la categoria");
            }
            return Ok(new CategoriaDetailDto
            {
                Id=categ.Id,
                Nombrecategoria=categ.Nombrecategoria,
                Juegos=categ.Juegos.Select(x=> new VideoJuegoDetailDto
                {
                    Id = x.Id,
                    Nombrejuego = x.Nombrejuego,
                    FechaPublicacion=x.FechaPublicacion,
                    Autor=x.Autor,
                    ModoJuego=x.ModoJuego,
                    CopiasDisponibles=x.CopiasDisponibles,
                    CategoriaId=x.Id

                }).ToList()
            });
        }

        /// <summary>
        /// Crea una categoria
        /// </summary>
        /// <param name="categoria">Nombre de la categoria creada</param>
        /// <returns>Las Categorias creadas</returns>
        [HttpPost]
        public ActionResult<CategoriaDetailDto> CreateCategoria([FromBody]CategoriaCreateDto categoriaDto)
        {
            var categoria = new Categoria
            {
                Codigo = categoriaDto.Codigo,
                Nombrecategoria = categoriaDto.Nombrecategoria
            };
            var newCategoria=categoriaRepository.Add(categoria);
            return Ok(new CategoriaDetailDto
            {
                Id = newCategoria.Id,
                Nombrecategoria = newCategoria.Nombrecategoria,
                //Juegos=newCategoria.Juegos.Select(x=> new VideoJuegoDetailDto
                //{
                //    Id = x.Id,
                //    Nombrejuego = x.Nombrejuego,
                //    FechaPublicacion = x.FechaPublicacion,
                //    Autor = x.Autor,
                //    ModoJuego = x.ModoJuego,
                //    CopiasDisponibles = x.CopiasDisponibles,
                //    CategoriaId = x.Id
                //}).ToList()
            });
        }
        /// <summary>
        /// Actualiza las categorias segun su Id
        /// </summary>
        /// <param name="id">El id de las Categorias</param>
        /// <param name="categoria">Nombre de las categorias</param>
        /// <returns>Las categorias Editadas</returns>
        [HttpPut("{id}")]
        public ActionResult<CategoriaDetailDto> UpdateCategoria(int id, [FromBody]CategoriaCreateDto categoria)
        {

            var updatetedCategory=categoriaRepository.Update(new Categoria
            {
                Id=id,
                Nombrecategoria=categoria.Nombrecategoria
            });

            return Ok(new CategoriaDetailDto
            {
                Id = updatetedCategory.Id,
                Nombrecategoria = updatetedCategory.Nombrecategoria,
                //Juegos = updatetedCategory.Juegos.Select(x => new VideoJuegoDetailDto
                //{
                //    Id = x.Id,
                //    Nombrejuego = x.Nombrejuego,
                //    FechaPublicacion = x.FechaPublicacion,
                //    Autor = x.Autor,
                //    ModoJuego = x.ModoJuego,
                //    CopiasDisponibles = x.CopiasDisponibles,
                //    CategoriaId = x.Id
                //}).ToList()
            });
        }

    }
}
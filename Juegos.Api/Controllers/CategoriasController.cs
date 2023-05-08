using Juegos.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Juegos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly JuegosContext context;

        public CategoriasController(JuegosContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Muestra una lista de categorias
        /// </summary>
        /// <param name="nombre">Nombre de la categoria</param>
        /// <returns>Las Categorias Creadas</returns>
        [HttpGet(Name = "GetCategorias")]
        public IEnumerable<Categoria> GetCategorias([FromQuery] string? nombre)
        {

            if (string.IsNullOrEmpty(nombre))
            {
                return context.Categorias;
            }
            return context.Categorias.Where(x => x.Nombrecategoria.StartsWith(nombre));
            
            
        }
        /// <summary>
        /// Muestra las categorias por id
        /// </summary>
        /// <param name="id">El id de las categorias</param>
        /// <returns>Los Id de las categorias creadas</returns>
        [HttpGet("{id}")]
        public Categoria GetUserById(int id)
        {

            return context.Categorias.FirstOrDefault(x=>x.Id == id);
            
        }

        /// <summary>
        /// Crea una categoria
        /// </summary>
        /// <param name="categoria">Nombre de la categoria creada</param>
        /// <returns>Las Categorias creadas</returns>
        [HttpPost]
        public Categoria CreateCategoria([FromBody]Categoria categoria)
        {

            context.Categorias.Add(categoria);
            Console.WriteLine(context.Categorias);
            return categoria;
        }
        /// <summary>
        /// Actualiza las categorias segun su Id
        /// </summary>
        /// <param name="id"El id de las Categorias></param>
        /// <param name="categoria">Nombre de las categorias</param>
        /// <returns>Las categorias Editadas</returns>
        [HttpPut("{id}")]
        public Categoria UpdateCategoria(int id, [FromBody]Categoria categoria)
        {

            var categoriaRemove=context.Categorias.FirstOrDefault(x=>x.Id == id);
            context.Categorias.Remove(categoriaRemove);
            context.Categorias.Add(categoria);
            return categoria;
        }

    }
}
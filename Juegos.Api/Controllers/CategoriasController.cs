using Juegos.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Juegos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        


        [HttpGet(Name = "GetCategorias")]
        public IEnumerable<Categoria> GetCategorias([FromQuery] string? nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return Database.Categorias;
            }
            return Database.Categorias.Where(x=>x.Nombrecategoria.StartsWith(nombre));
        }

        [HttpGet("{id}")]
        public Categoria GetUserById(Guid id)
        {
            return Database.Categorias.FirstOrDefault(x=>x.Id == id);
        }

        [HttpPost]
        public Categoria CreateCategoria([FromBody]Categoria categoria)
        {
            categoria.Id = Guid.NewGuid();
            Database.Categorias.Add(categoria);
            Console.WriteLine(Database.Categorias);
            return categoria;
        }

        [HttpPut("{id}")]
        public Categoria UpdateCategoria(Guid id, [FromBody]Categoria categoria)
        {
            var categoriaRemove=Database.Categorias.FirstOrDefault(x=>x.Id == id);
            Database.Categorias.Remove(categoriaRemove);
            Database.Categorias.Add(categoria);
            return categoria;

        }

    }
}
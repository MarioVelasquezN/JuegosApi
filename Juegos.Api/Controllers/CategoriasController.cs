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
        


        [HttpGet(Name = "GetCategorias")]
        public IEnumerable<Categoria> GetCategorias([FromQuery] string? nombre)
        {
            var builder = new DbContextOptionsBuilder<JuegosContext>().UseSqlite("DataSource=Juegos.db").EnableSensitiveDataLogging().LogTo(message=> Debug.Write(message));
            var context = new JuegosContext(builder.Options);
            context.Database.EnsureCreated();

            if (string.IsNullOrEmpty(nombre))
            {
                return context.Categorias;
            }
            return context.Categorias.Where(x => x.Nombrecategoria.StartsWith(nombre));
            
            
        }

        [HttpGet("{id}")]
        public Categoria GetUserById(int id)
        {
            var builder = new DbContextOptionsBuilder<JuegosContext>().UseSqlite("DataSource=Juegos.db");
            var context = new JuegosContext(builder.Options);
            context.Database.EnsureCreated();
            return context.Categorias.FirstOrDefault(x=>x.Id == id);
            
        }

        [HttpPost]
        public Categoria CreateCategoria([FromBody]Categoria categoria)
        {
            var builder = new DbContextOptionsBuilder<JuegosContext>().UseSqlite("DataSource=Juegos.db");
            var context = new JuegosContext(builder.Options);
            context.Database.EnsureCreated();
            context.Categorias.Add(categoria);
            Console.WriteLine(context.Categorias);
            return categoria;
        }

        [HttpPut("{id}")]
        public Categoria UpdateCategoria(int id, [FromBody]Categoria categoria)
        {
            var builder = new DbContextOptionsBuilder<JuegosContext>().UseSqlite("DataSource=Juegos.db");
            var context = new JuegosContext(builder.Options);
            context.Database.EnsureCreated();
            var categoriaRemove=context.Categorias.FirstOrDefault(x=>x.Id == id);
            context.Categorias.Remove(categoriaRemove);
            context.Categorias.Add(categoria);
            return categoria;
        }

    }
}
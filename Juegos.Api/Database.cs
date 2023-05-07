using Juegos.Api.Models;

namespace Juegos.Api
{
    public static class Database
    {
            public readonly static IList<Categoria> Categorias = new List<Categoria>
            {
                    new()
                    {
                        Id=Guid.NewGuid(),
                        Codigo=1,
                        Nombrecategoria="Aventura",
                        //videojuegos = new List<Videojuego> {
                        //    new Videojuego {
                        //        Id=Guid.NewGuid(),
                        //        Nombrejuego = "The Legend of Zelda: Breath of the Wild",
                        //        FechaPublicacion = new DateTime(2017, 3, 3),
                        //        Autor = "Nintendo",
                        //        ModoJuego = "single player",
                        //        CopiasDisponibles = 50
                        //    }
                        //}

                        },
                    new()
                    {
                        Id=Guid.NewGuid(),
                        Codigo=2,
                        Nombrecategoria="Terror",
                        //videojuegos = new List<Videojuego> {
                        //    new Videojuego {
                        //        Id=Guid.NewGuid(),
                        //        Nombrejuego = "The Legend of Zelda: Breath of the Wild",
                        //        FechaPublicacion = new DateTime(2017, 3, 3),
                        //        Autor = "Nintendo",
                        //        ModoJuego = "single player",
                        //        CopiasDisponibles = 50
                        //    }
                        //}


                    },
                    new()
                    {
                        Id=Guid.NewGuid(),
                        Codigo=3,
                        Nombrecategoria="MMORPG",
                        //videojuegos = new List<Videojuego> {
                        //    new Videojuego {
                        //        Id=Guid.NewGuid(),
                        //        Nombrejuego = "The Legend of Zelda: Breath of the Wild",
                        //        FechaPublicacion = new DateTime(2017, 3, 3),
                        //        Autor = "Nintendo",
                        //        ModoJuego = "single player",
                        //        CopiasDisponibles = 50
                        //    }


                        //}
                    }
            };

        public static IList<Videojuego> Videojuegos = new List<Videojuego>();
    }
}

namespace Juegos.Api.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombrecategoria { get; set; }
        public ICollection<Videojuego> Juegos { get; set; } = new HashSet<Videojuego>();
   
    }
}

namespace Juegos.Core.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombrecategoria { get; set; }
        public ICollection<Videojuego>? Juegos { get; set; } = new HashSet<Videojuego>();
   
    }
}

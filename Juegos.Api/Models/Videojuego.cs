namespace Juegos.Api.Models
{
    public class Videojuego
    {
        public Guid Id { get; set; }
        public string Nombrejuego { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Autor { get; set; }
        public string ModoJuego { get;
        set; }
        public int CopiasDisponibles { get; set; }
        public Guid CategoriaId { get; set; }
    }
}

using Juegos.Api.Models;

namespace Juegos.Api.DataTransferObjects
{
    public class VideoJuegoDetailDto
    {
        public int Id { get; set; }
        public string Nombrejuego { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Autor { get; set; }
        public string ModoJuego { get; set; }
        public int CopiasDisponibles { get; set; }
        public int CategoriaId { get; set; }
    }
}

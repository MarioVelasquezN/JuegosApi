using Juegos.Api.Models;

namespace Juegos.Api.DataTransferObjects
{
    public class VideojuegoCreateDto
    {
        public string Nombrejuego { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Autor { get; set; }
        public string ModoJuego { get; set; }
        public int CopiasDisponibles { get; set; }
    }
}

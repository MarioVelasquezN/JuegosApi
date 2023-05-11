using Juegos.Api.Models;

namespace Juegos.Api.DataTransferObjects
{
    public class ClienteDetailDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Renta { get; set; }
        public ICollection<VideojuegoCreateDto> videojuegos { get; set; }
    }
}

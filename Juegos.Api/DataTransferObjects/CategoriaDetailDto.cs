

namespace Juegos.Api.DataTransferObjects
{
    public class CategoriaDetailDto
    {
        public int Id { get; set; }
        public string Nombrecategoria { get; set; }
        public ICollection<VideoJuegoDetailDto> Juegos { get; set; }
    }
}



namespace Juegos.Api.DataTransferObjects
{
    public class ClienteCreateDto
    {
        public string Nombre { get; set; }
        public DateTime Renta { get; set; }
        //public int CategoId { get; set; }
        //public Categoria Categoria { get; set; }
        //public ICollection<Videojuego> videojuegos { get; set; } = new HashSet<Videojuego>();
    }
}

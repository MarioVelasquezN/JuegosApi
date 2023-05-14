namespace Juegos.Core.Entities
{
    public class Videojuego
    {
        public int Id { get; set; }
        public string Nombrejuego { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Autor { get; set; }
        public string ModoJuego { get;set; }
        public int CopiasDisponibles { get; set; }
        public int CategoriaId { get; set; }
        //public Videojuego VideoJuego { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<Cliente> Clientes { get; set; }=new HashSet<Cliente>();
    }
}

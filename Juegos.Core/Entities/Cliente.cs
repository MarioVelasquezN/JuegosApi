namespace Juegos.Core.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Renta { get; set; }
        //public int CategoId { get; set; }
        //public Categoria Categoria { get; set; }
        public ICollection<Videojuego> videojuegos { get; set; } = new HashSet<Videojuego>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace MoviesWebApi.Entities
{
    public class Genres
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Movies> Movies { get; set; }
    }
}

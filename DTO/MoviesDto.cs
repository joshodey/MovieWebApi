using MoviesWebApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApi.DTO
{
    public record MoviesDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RealeaseDate { get; set; }
        public ICollection<Ratings> Ratings { get; set; }
        public double TicketPrice { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
        public int GenresId { get; set; }
        public List<Genres> Genre { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApi.Entities
{
    public class Ratings
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }
        public string comment { get; set; }
        public string email { get; set; }

        [ForeignKey(nameof(Movies))]
        public string MovieId { get; set; }
        public Movies Movies { get; set;}
    }
}

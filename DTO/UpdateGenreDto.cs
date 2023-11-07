namespace MoviesWebApi.DTO
{
    public record UpdateGenreDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

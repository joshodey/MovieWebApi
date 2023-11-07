namespace MoviesWebApi.DTO
{
    public record UpdateRatingsDto
    {
        public int Value { get; set; }
        public string comment { get; set; }
    }
}

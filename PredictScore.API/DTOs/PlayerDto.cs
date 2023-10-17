namespace PredictScore.API.DTOs
{
    public class CreatePlayerDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Alias { get; set; }
        public string? Email { get; set; }

        public IEnumerable<int>? PredictionSeasonIds { get; set; }
    }
}

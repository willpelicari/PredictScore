namespace PredictScore.Core.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string? FirstName { get; set;}
        public string? LastName { get; set; }
        public string? Alias { get; set; }
        public string? Email { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastModificationDateTime { get; set; } = DateTime.Now;

        public IEnumerable<PredictionSeason>? PredictionSeasons { get; set; }
        public IEnumerable<Group>? Groups { get; set; }
    }
}

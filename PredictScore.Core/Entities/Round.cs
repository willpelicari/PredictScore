namespace PredictScore.Core.Entities
{
    public class Round
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public required Season Season { get; set; }
        public int SeasonId { get; set; }

        public IEnumerable<Match>? Matches { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastModificationDateTime { get; set; } = DateTime.Now;
    }
}

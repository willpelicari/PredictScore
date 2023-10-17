namespace PredictScore.Core.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public required Competition Competition { get; set; }
        public int CompetitionId { get; set; }

        public IEnumerable<Round>? Rounds { get; set; }
        public IEnumerable<Team>? Teams { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastModificationDateTime { get; set; } = DateTime.Now;
    }
}

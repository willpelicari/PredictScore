namespace PredictScore.Core.Entities
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public required Sport Sport { get; set; }
        public int SportId { get; set; }

        public IEnumerable<Season>? Seasons { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastModificationDateTime { get; set; } = DateTime.Now;
    }
}

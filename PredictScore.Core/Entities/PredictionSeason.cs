namespace PredictScore.Core.Entities
{
    public class PredictionSeason
    {
        public int Id { get; set; }

        public required Season Season { get; set; }
        public int SeasonId { get; set; }

        public required PredictionSeasonRules PredictionSeasonRules { get; set; }
        public int PredictionSeasonRulesId { get; set; }

        public required Group Group { get; set; }
        public int GroupId { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastModificationDateTime { get; set; } = DateTime.Now;
    }
}

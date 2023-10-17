using System.ComponentModel.DataAnnotations.Schema;

namespace PredictScore.Core.Entities
{
    public class PredictionSeasonRules
    {
        public int Id { get; set; }
        public int WinnerScorePoints { get; set; }
        public int FullScorePoints { get; set; }
        public int HalfScorePoints { get; set; }
        public int ScoreDifferencePoint { get; set; }

        public required PredictionSeason PredictionSeason { get; set; }
        [ForeignKey(nameof(PredictionSeason))]
        public int PredictionSeasonId { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastModificationDateTime { get; set; } = DateTime.Now;
    }
}

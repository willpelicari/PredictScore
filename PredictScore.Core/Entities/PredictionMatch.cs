using System.ComponentModel.DataAnnotations.Schema;
using PredictScore.Core.Entities.Enums;
using PredictScore.Core.Entities.Interfaces;

namespace PredictScore.Core.Entities
{
    public class PredictionMatch : IMatch
    {
        public int Id { get; set; }
        public PredictionState State { get; set; }

        public Team HomeTeam => Match.HomeTeam;
        public int HomeScore { get; set; }

        public Team AwayTeam => Match.AwayTeam;
        public int AwayScore { get; set; }

        public required Match Match { get; set; }
        public int MatchId { get; set; }

        public required Player Player { get; set; }
        public int PlayerId { get; set; }

        public int TotalPoints { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastModificationDateTime { get; set; } = DateTime.Now;
    }
}

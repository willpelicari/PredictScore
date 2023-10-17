using PredictScore.Core.Entities.Interfaces;

namespace PredictScore.Core.Entities
{
    public class Match : IMatch
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public required Team HomeTeam { get; set; }
        public int HomeTeamId { get; set; }
        public int HomeScore { get; set; }

        public required Team AwayTeam { get; set; }
        public int AwayTeamId { get; set; }
        public int AwayScore { get; set; }

        public required Round Round { get; set; }
        public int RoundId { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastModificationDateTime { get; set; } = DateTime.Now;
    }
}

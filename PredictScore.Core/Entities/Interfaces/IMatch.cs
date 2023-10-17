namespace PredictScore.Core.Entities.Interfaces
{
    public interface IMatch
    {
        public Team? HomeTeam { get; }
        public int HomeScore { get; set; }
        public Team? AwayTeam { get; }
        public int AwayScore { get; set; }
    }
}

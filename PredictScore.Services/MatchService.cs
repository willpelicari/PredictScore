using PredictScore.Core.Entities;
using PredictScore.Core.Entities.Interfaces;
using PredictScore.Services.Interfaces;

namespace PredictScore.Services
{
    internal class MatchService : IMatchService
    {
        public Team? GetWinner(IMatch match)
        {
            if (match.HomeScore == match.AwayScore)
            {
                return null;
            }

            return match.HomeScore > match.AwayScore ? match.HomeTeam : match.AwayTeam;
        }
    }
}

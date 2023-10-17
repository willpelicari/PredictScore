using PredictScore.Core.Entities;
using PredictScore.Core.Entities.Interfaces;

namespace PredictScore.Services.Interfaces
{
    public interface IMatchService
    {
        public Team? GetWinner(IMatch match);
    }
}

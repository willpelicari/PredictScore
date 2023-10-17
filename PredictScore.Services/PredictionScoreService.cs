using PredictScore.Core.Entities;
using PredictScore.Services.Interfaces;

namespace PredictScore.Services
{
    internal class PredictionScoreService : IPredictionScoreService
    {
        public Task<PredictionMatch> SaveAsync(PredictionMatch? predictionMatch)
        {
            throw new NotImplementedException();
        }
    }
}

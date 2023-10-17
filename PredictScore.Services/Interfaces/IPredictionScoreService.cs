using PredictScore.Core.Entities;

namespace PredictScore.Services.Interfaces
{
    public interface IPredictionScoreService
    {
        public Task<PredictionMatch> SaveAsync(PredictionMatch? predictionScore);
    }
}

using PredictScore.Core.Entities;

namespace PredictScore.Services.Interfaces
{
    public interface IPredictionEvaluatorService
    {
        public Task<PredictionMatch> EvaluatePredictedScoreAsync(int predictionSeasonId, PredictionMatch predictionScore);
    }
}

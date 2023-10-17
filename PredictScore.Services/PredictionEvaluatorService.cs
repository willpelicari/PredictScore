using PredictScore.Core.Entities;
using PredictScore.Core.Entities.Enums;
using PredictScore.Services.Interfaces;

namespace PredictScore.Services
{
    internal class PredictionEvaluatorService : IPredictionEvaluatorService
    {
        private readonly IGroupRulesService _groupRuleService;
        private readonly IMatchService _matchService;
        private readonly IPredictionScoreService _predictionScoreService;

        public PredictionEvaluatorService(
            IGroupRulesService groupRuleService,
            IMatchService matchService,
            IPredictionScoreService predictionScoreService)
        {
            _groupRuleService = groupRuleService;
            _matchService = matchService;
            _predictionScoreService = predictionScoreService;
        }

        public async Task<PredictionMatch> EvaluatePredictedScoreAsync(int predictionSeasonId, PredictionMatch predictionMatch)
        {
            if (predictionMatch is not { State: PredictionState.ToBeEvaluated })
            {
                throw new ArgumentException("Prediction cannot be evaluated.");
            }

            var seasonRules = await _groupRuleService.GetSeasonRulesAsync(predictionSeasonId) ?? throw new Exception("Season not found");

            var finalScore = 0;
            finalScore += EvaluateWinnerRule(seasonRules, predictionMatch);
            finalScore += EvaluateFullAndHalfScoreRule(seasonRules, predictionMatch);
            finalScore += EvaluateScoreDifferenceRule(seasonRules, predictionMatch);
            predictionMatch.TotalPoints = finalScore;

            return await _predictionScoreService.SaveAsync(predictionMatch);
        }

        private int EvaluateWinnerRule(PredictionSeasonRules seasonRules, PredictionMatch predictionMatch)
        {
            if (seasonRules.WinnerScorePoints <= 0)
            {
                return 0;
            }

            var predictedWinner = _matchService.GetWinner(predictionMatch);
            var realWinner = _matchService.GetWinner(predictionMatch.Match);

            return predictedWinner?.Id == realWinner?.Id ? seasonRules.WinnerScorePoints : 0;
        }

        private static int EvaluateFullAndHalfScoreRule(PredictionSeasonRules seasonRules, PredictionMatch predicted)
        {
            var finalScore = 0;
            var real = predicted.Match;

            if (seasonRules.FullScorePoints > 0)
            {
                if (predicted.HomeScore == real.HomeScore &&
                    predicted.AwayScore == real.AwayScore)
                {
                    finalScore += seasonRules.FullScorePoints;
                }
            }
            else if (seasonRules.HalfScorePoints > 0)
            {
                if (predicted.HomeScore == real.HomeScore)
                {
                    finalScore += seasonRules.HalfScorePoints;
                }

                if (predicted.AwayScore == real.AwayScore)
                {
                    finalScore += seasonRules.HalfScorePoints;
                }
            }

            return finalScore;
        }

        private static int EvaluateScoreDifferenceRule(PredictionSeasonRules seasonRules, PredictionMatch predicted)
        {
            if (seasonRules.ScoreDifferencePoint <= 0)
            {
                return 0;
            }

            var real = predicted.Match;
            var predictedDifference = Math.Abs(predicted.HomeScore - predicted.AwayScore);
            var realDifference = Math.Abs(real.HomeScore - real.AwayScore);

            return predictedDifference == realDifference ? seasonRules.ScoreDifferencePoint : 0;
        }
    }
}

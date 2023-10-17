using PredictScore.Core.Entities;

namespace PredictScore.Services.Interfaces
{
    public interface IGroupRulesService
    {
        public Task<PredictionSeasonRules> GetSeasonRulesAsync(int seasonRulesId);
    }
}

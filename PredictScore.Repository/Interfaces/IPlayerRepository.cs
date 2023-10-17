using PredictScore.Core.Entities;

namespace PredictScore.Repository.Interfaces
{
    public interface IPlayerRepository
    {
        public Task<Player?> GetPlayerAsync(int playerId);
        public Task<Player> CreateNewPlayerAsync(Player player);
        public Task<Player?> UpdatePlayerAsync(Player player);
        public Task<Player?> DeletePlayerAsync(int playerId);
    }
}

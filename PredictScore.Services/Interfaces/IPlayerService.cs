using PredictScore.Core.Entities;

namespace PredictScore.Services.Interfaces
{
    public interface IPlayerService
    {
        public Task<Player> CreatePlayerAsync(Player player);
        public Task<Player?> RetrievePlayerAsync(int id);
        public Task<Player> UpdatePlayerAsync(Player player);
        public Task<IEnumerable<Player>> ListPlayersAsync();
        public Task<Player> DeletePlayerAsync(int id);
    }
}

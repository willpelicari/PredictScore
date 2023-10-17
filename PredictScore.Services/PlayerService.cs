using PredictScore.Core.Entities;
using PredictScore.Repository.Interfaces;
using PredictScore.Services.Interfaces;

namespace PredictScore.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Player> CreatePlayerAsync(Player player)
        {
            if (player.FirstName == null || player.LastName == null || player.Email == null)
            {
                throw new ArgumentException("Missing required parameters");
            }

            return await _playerRepository.CreateNewPlayerAsync(player);
        }

        public async Task<Player?> RetrievePlayerAsync(int playerId)
        {
            if (playerId <= 0)
            {
                throw new ArgumentException("Id must be greater than 0", nameof(playerId));
            }

            return await _playerRepository.GetPlayerAsync(playerId);
        }

        public async Task<Player> UpdatePlayerAsync(Player player)
        {
            if (player.Id == 0)
            {
                throw new ArgumentException("Cannot create a new player by this method");
            }

            return await _playerRepository.UpdatePlayerAsync(player) ?? throw new InvalidOperationException("Player not found");
        }

        public Task<IEnumerable<Player>> ListPlayersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Player> DeletePlayerAsync(int id)
        {
            var player = await _playerRepository.DeletePlayerAsync(id) ?? throw new InvalidOperationException("Player not found");
            return player;
        }
    }
}

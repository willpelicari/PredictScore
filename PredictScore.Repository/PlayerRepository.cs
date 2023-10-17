using PredictScore.Core.Entities;
using PredictScore.Repository.Interfaces;

namespace PredictScore.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        public async Task<Player?> GetPlayerAsync(int playerId)
        {
            await using var db = new PredictScoreDbContext();
            var player = db.Players.FirstOrDefault(player => player.Id == playerId);
            return player;
        }

        public async Task<Player> CreateNewPlayerAsync(Player player)
        {
            await using var db = new PredictScoreDbContext();
            var registeredPlayer = db.Players.Add(player);
            await db.SaveChangesAsync();
            return registeredPlayer.Entity;
        }

        public async Task<Player?> UpdatePlayerAsync(Player player)
        {
            await using var db = new PredictScoreDbContext();
            var updatedPlayer = db.Players.FirstOrDefault(x => x.Id == player.Id);

            if (updatedPlayer == null)
            {
                return null;
            }

            updatedPlayer.FirstName = player.FirstName;
            updatedPlayer.LastName = player.LastName;
            updatedPlayer.Alias = player.Alias;
            updatedPlayer.Email = player.Email;
            updatedPlayer.LastModificationDateTime = DateTime.Now;

            await db.SaveChangesAsync();

            return updatedPlayer;
        }

        public async Task<Player?> DeletePlayerAsync(int id)
        {
            await using var db = new PredictScoreDbContext();
            var deletedPlayer = db.Players.FirstOrDefault(x => x.Id == id);

            if (deletedPlayer == null)
            {
                return null;
            }

            db.Players.Remove(deletedPlayer);
            await db.SaveChangesAsync();
            return deletedPlayer;
        }
    }
}

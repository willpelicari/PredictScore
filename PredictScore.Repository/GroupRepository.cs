using PredictScore.Core.Entities;
using PredictScore.Repository.Interfaces;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace PredictScore.Repository
{
    public class GroupRepository : IGroupRepository
    {
        public async Task<Group?> GetGroupAsync(int groupId)
        {
            await using var db = new PredictScoreDbContext();
            var group = db.Groups.Include(x => x.Players).FirstOrDefault(group => group.Id == groupId);
            return group;
        }

        public async Task<Group> CreateNewGroupAsync(Group group, IEnumerable<Player> players)
        {
            await using var db = new PredictScoreDbContext();
            var registeredGroup = await db.Groups.AddAsync(group);
            await db.SaveChangesAsync();

            registeredGroup.Entity.Players ??= new List<Player>();
            foreach (var player in players)
            {
                registeredGroup.Entity.Players.Add(player);
            }

            await db.SaveChangesAsync();
            return registeredGroup.Entity;
        }

        public async Task<Group?> UpdateGroupAsync(Group group)
        {
            await using var db = new PredictScoreDbContext();
            db.Groups.Attach(group);

            group.LastModificationDateTime = DateTime.Now;

            db.Entry(group).State = EntityState.Modified;

            await db.SaveChangesAsync();

            return group;
        }

        public async Task<Group?> AddPlayerToGroupAsync(Group group, Player player)
        {
            await using var db = new PredictScoreDbContext();
            db.Groups.Attach(group);

            group.LastModificationDateTime = DateTime.Now;
            group.Players?.Add(player);

            db.Entry(group).State = EntityState.Modified;

            await db.SaveChangesAsync();

            return group;
        }

        public async Task<Group?> DeleteGroupAsync(int groupId)
        {
            throw new NotImplementedException();
        }
    }
}

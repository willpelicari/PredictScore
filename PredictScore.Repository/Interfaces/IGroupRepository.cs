using PredictScore.Core.Entities;

namespace PredictScore.Repository.Interfaces
{
    public interface IGroupRepository
    {
        public Task<Group?> GetGroupAsync(int groupId);
        public Task<Group> CreateNewGroupAsync(Group group, IEnumerable<Player> players);
        public Task<Group?> UpdateGroupAsync(Group group);
        public Task<Group?> AddPlayerToGroupAsync(Group group, Player player);
        public Task<Group?> DeleteGroupAsync(int groupId);
    }
}

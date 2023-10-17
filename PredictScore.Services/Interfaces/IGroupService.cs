using PredictScore.Core.Entities;

namespace PredictScore.Services.Interfaces
{
    public interface IGroupService
    {
        Task<Group?> RetrieveGroupAsync(int groupId);
        Task CreateGroupAsync(Group group);
        Task UpdateGroupAsync(Group group);
        Task<Group> DeleteGroupAsync(int groupId);
        Task<Group?> AddPlayerToGroupAsync(int groupId, int playerId);
    }
}

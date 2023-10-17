using PredictScore.Core.Entities;
using PredictScore.Repository.Interfaces;
using PredictScore.Services.Interfaces;

namespace PredictScore.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IPlayerService _playerService;

        public GroupService(IGroupRepository groupRepository, IPlayerService playerService)
        {
            _groupRepository = groupRepository;
            _playerService = playerService;
        }

        public async Task<Group?> RetrieveGroupAsync(int groupId)
        {
            return await _groupRepository.GetGroupAsync(groupId);
        }

        public async Task CreateGroupAsync(Group group)
        {
            var players = new List<Player>();

            if (group.Players != null)
            {
                foreach (var groupPlayer in group.Players)
                {
                    var player = await _playerService.RetrievePlayerAsync(groupPlayer.Id) ??
                             throw new ArgumentException("Player not found");
                    players.Add(player);
                }
            }

            await _groupRepository.CreateNewGroupAsync(group, players);
        }

        public async Task UpdateGroupAsync(Group group)
        {
            await _groupRepository.UpdateGroupAsync(group);
        }

        public async Task<Group> DeleteGroupAsync(int groupId)
        {
            return await _groupRepository.DeleteGroupAsync(groupId) ?? throw new InvalidOperationException("Group not found"); ;
        }

        public async Task<Group?> AddPlayerToGroupAsync(int groupId, int playerId)
        {
            var group = RetrieveGroupAsync(groupId);
            var player = _playerService.RetrievePlayerAsync(playerId);

            await Task.WhenAll(group, player);

            if (group.Result is null)
            {
                throw new ArgumentException("Group not found");
            }

            if (player.Result is null)
            {
                throw new ArgumentException("Player not found");
            }

            return await _groupRepository.AddPlayerToGroupAsync(group.Result, player.Result);
        }
    }
}

using AutoMapper;
using PredictScore.API.DTOs;
using PredictScore.Core.Entities;

namespace PredictScore.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            PlayerMappings();
            GroupMappings();
        }

        private void PlayerMappings()
        {
            CreateMap<CreatePlayerDto, Player>();
            CreateMap<PlayerDto, Player>();
            CreateMap<Player, PlayerDto>();
        }

        private void GroupMappings()
        {
            CreateMap<CreateGroupDto, Group>()
                .ForMember(group => group.Players, o => o.MapFrom(dto => dto.MemberIds.Select(x => new Player { Id = x })));
            CreateMap<GroupDto, Group>()
                .ForMember(group => group.Players, o => o.MapFrom(dto => dto.Members.Select(x => new Player { Id = x.Id })));
            CreateMap<Group, GroupDto>()
                .ForMember(dto => dto.Members, o => o.MapFrom(group => group.Players.Select(x => new SimplePlayerDto
                {
                    Id = x.Id,
                    FullName = $"{x.FirstName} {x.LastName}"
                })));
        }
    }
}

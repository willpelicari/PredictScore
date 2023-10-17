using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PredictScore.API.DTOs;
using PredictScore.Core.Entities;
using PredictScore.Services.Interfaces;

namespace PredictScore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupController(
            IGroupService groupService,
            ILogger<GroupController> logger,
            IMapper mapper
        )
        {
            _groupService = groupService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{groupId}")]
        public async Task<IActionResult> GetGroupAsync(int groupId)
        {
            try
            {
                var group = await _groupService.RetrieveGroupAsync(groupId);

                if (group == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GroupDto>(group));
            }
            catch (ArgumentException argException)
            {
                return BadRequest(argException.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SetGroupAsync(CreateGroupDto createGroupDto)
        {
            try
            {
                var group = _mapper.Map<Group>(createGroupDto);
                await _groupService.CreateGroupAsync(group);

                return Ok(_mapper.Map<GroupDto>(group));
            }
            catch (ArgumentException argException)
            {
                return BadRequest(argException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroupAsync(GroupDto groupDto)
        {
            try
            {
                var group = _mapper.Map<Group>(groupDto);
                await _groupService.UpdateGroupAsync(group);

                return Ok(_mapper.Map<GroupDto>(group));
            }
            catch (ArgumentException argException)
            {
                return BadRequest(argException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        [HttpDelete("{groupId}")]
        public async Task<IActionResult> DeleteGroupAsync(int groupId)
        {
            try
            {
                var group = await _groupService.DeleteGroupAsync(groupId);
                return Ok(_mapper.Map<Group>(group));
            }
            catch (ArgumentException argException)
            {
                return BadRequest(argException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        [HttpPost("{groupId}/players/{playerId}")]
        public async Task<IActionResult> AddPlayerToGroupAsync(int groupId, int playerId)
        {
            try
            {
                var group = await _groupService.AddPlayerToGroupAsync(groupId, playerId);

                return Ok(_mapper.Map<GroupDto>(group));
            }
            catch (ArgumentException argException)
            {
                return BadRequest(argException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
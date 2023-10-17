using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PredictScore.API.DTOs;
using PredictScore.Core.Entities;
using PredictScore.Services.Interfaces;

namespace PredictScore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayerController(
            IPlayerService playerService,
            ILogger<PlayerController> logger,
            IMapper mapper
        )
        {
            _playerService = playerService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{playerId}")]
        public async Task<IActionResult> GetPlayerAsync(int playerId)
        {
            try
            {
                var player = await _playerService.RetrievePlayerAsync(playerId);

                if (player == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<PlayerDto>(player));
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

        [HttpPost]
        public async Task<IActionResult> SetPlayerAsync(CreatePlayerDto createPlayerDto)
        {
            try
            {
                var player = _mapper.Map<Player>(createPlayerDto);
                await _playerService.CreatePlayerAsync(player);

                return Ok(_mapper.Map<PlayerDto>(player));
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
        public async Task<IActionResult> UpdatePlayerAsync(PlayerDto playerDto)
        {
            try
            {
                var player = _mapper.Map<Player>(playerDto);
                await _playerService.UpdatePlayerAsync(player);

                return Ok(_mapper.Map<PlayerDto>(player));
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

        [HttpDelete("{playerId}")]
        public async Task<IActionResult> DeletePlayerAsync(int playerId)
        {
            try
            {
                var player = await _playerService.DeletePlayerAsync(playerId);
                return Ok(_mapper.Map<PlayerDto>(player));
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
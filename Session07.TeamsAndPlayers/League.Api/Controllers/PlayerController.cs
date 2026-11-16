using League.Api.Requests;
using League.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace League.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;

        public PlayerController(IPlayerService playerService, ITeamService teamService)
        {
            _playerService = playerService;
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _playerService.GetAllPlayersAsync();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpGet("team/{teamId}")]
        public async Task<IActionResult> GetPlayersByTeamId(int teamId)
        {
            var players = await _playerService.GetPlayersByTeamIdAsync(teamId);
            if (players == null || !players.Any())
            {
                return NotFound();
            }
            return Ok(players);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerRequest createPlayerRequest)
        {
            var player = await _playerService.CreatePlayerAsync(createPlayerRequest);
            if (player == null)
            {
                return BadRequest("Failed to create player.");
            }
            return CreatedAtAction(nameof(GetPlayerById), new { teamId = player.TeamId }, player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, [FromBody] UpdatePlayerRequest updatePlayerRequest)
        {
            var player = await _playerService.UpdatePlayerAsync(id, updatePlayerRequest);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var result = await _playerService.DeletePlayerAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}

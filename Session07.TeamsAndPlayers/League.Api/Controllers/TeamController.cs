using League.Api.Requests;
using League.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace League.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;

        public TeamController(ITeamService teamService, IPlayerService playerService)
        {
            _teamService = teamService;
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamRequest createTeamRequest)
        {
            var createdTeam = await _teamService.CreateTeamAsync(createTeamRequest);
            if (createdTeam == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetTeamById), new { id = createdTeam.Id }, createdTeam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] UpdateTeamRequest updateTeamRequest)
        {
            var updatedTeam = await _teamService.UpdateTeamAsync(id, updateTeamRequest);
            if (updatedTeam == null)
            {
                return NotFound();
            }
            return Ok(updatedTeam);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var deleted = await _teamService.DeleteTeamAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}

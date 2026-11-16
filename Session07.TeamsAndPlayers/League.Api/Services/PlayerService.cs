using League.Api.Data;
using League.Api.Responses;
using Microsoft.EntityFrameworkCore;
using League.Api.Requests;
using League.Api.Models;

namespace League.Api.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly AppDbContext _dbContext;
        private readonly TeamService _teamService;

        public PlayerService(AppDbContext dbContext, TeamService teamService)
        {
            _dbContext = dbContext;
            _teamService = teamService;
        }

        public async Task<IEnumerable<PlayerResponse>> GetAllPlayersAsync() =>
            await _dbContext.Players.
            Select(p => new PlayerResponse
            {
                Id = p.Id,
                Name = p.Name,
                ShirtNumber = p.ShirtNumber,
                Position = p.Position,
                TeamId = p.TeamId
            })
            .ToListAsync();

        public async Task<PlayerResponse?> GetPlayerByIdAsync(int id)
        {
            return await _dbContext.Players
                .Where(p => p.Id == id)
                .Select(p => new PlayerResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    ShirtNumber = p.ShirtNumber,
                    Position = p.Position,
                    TeamId = p.TeamId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PlayerResponse>?> GetPlayersByTeamIdAsync(int teamId)
        {
            if (!await _teamService.TeamExistsAsync(teamId))
            {
                return null;
            }

            return await _dbContext.Players
                .Where(p => p.TeamId == teamId)
                .Select(p => new PlayerResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    ShirtNumber = p.ShirtNumber,
                    Position = p.Position,
                    TeamId = p.TeamId
                })
                .ToListAsync();
        }

        public async Task<PlayerResponse?> CreatePlayerAsync(CreatePlayerRequest createPlayerRequest)
        {
            var player = new Player
            {
                Name = createPlayerRequest.Name,
                ShirtNumber = createPlayerRequest.ShirtNumber,
                Position = createPlayerRequest.Position,
                TeamId = createPlayerRequest.TeamId,
            };
            _dbContext.Players.Add(player);
            await _dbContext.SaveChangesAsync();
            return await GetPlayerByIdAsync(player.Id);
        }
           
        public async Task<PlayerResponse?> UpdatePlayerAsync(int id, UpdatePlayerRequest updatePlayerRequest)
        {
            var player = await _dbContext.Players.FindAsync(id);
            if (player == null)
            {
                return null;
            }

            player.Name = updatePlayerRequest.Name;
            player.ShirtNumber = updatePlayerRequest.ShirtNumber;
            player.Position = updatePlayerRequest.Position;
            player.TeamId = updatePlayerRequest.TeamId;

            await _dbContext.SaveChangesAsync();
            return await GetPlayerByIdAsync(player.Id);
        }

        public async Task<bool> DeletePlayerAsync(int id)
        {
            var player = await _dbContext.Players.FindAsync(id);
            if (player == null)
            {
                return false;
            }
            _dbContext.Players.Remove(player);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}

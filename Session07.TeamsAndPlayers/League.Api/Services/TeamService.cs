using League.Api.Responses;
using Microsoft.EntityFrameworkCore;
using League.Api.Data;
using League.Api.Models;
using League.Api.Requests;

namespace League.Api.Services
{
    public class TeamService : ITeamService
    {   
        private readonly AppDbContext _dbContext;

        public TeamService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TeamResponse>> GetAllTeamsAsync() =>
            await _dbContext.Teams
                .Select(t => new TeamResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                    City = t.City
                })
                .ToListAsync();

        public async Task<TeamResponse?> GetTeamByIdAsync(int id) =>
            await _dbContext.Teams
                .Where(t => t.Id == id)
                .Select(t => new TeamResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                    City = t.City
                })
                .FirstOrDefaultAsync();

        public async Task<TeamResponse?> CreateTeamAsync(CreateTeamRequest createTeamRequest)
        {
            var team = new Team
            {
                Name = createTeamRequest.Name,
                City = createTeamRequest.City
            };

            _dbContext.Teams.Add(team);
            await _dbContext.SaveChangesAsync();
            return new TeamResponse
            {
                Id = team.Id,
                Name = team.Name,
                City = team.City
            };
        }

        public async Task<TeamResponse?> UpdateTeamAsync(int id, UpdateTeamRequest updateTeamRequest)
        {
            var team = await _dbContext.Teams.FirstOrDefaultAsync(t => t.Id == id);
            if (team == null)
            {
                return null;
            }
            team.Name = updateTeamRequest.Name;
            team.City = updateTeamRequest.City;

            await _dbContext.SaveChangesAsync();
            return (await GetTeamByIdAsync(team.Id))!;
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            var team = await _dbContext.Teams.FirstOrDefaultAsync(t => t.Id == id);
            if (team == null)
            {
                return false;
            }

            _dbContext.Teams.Remove(team);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TeamExistsAsync(int id) =>
            await _dbContext.Teams.AnyAsync(t => t.Id == id);
    }
}

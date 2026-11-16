using League.Api.Requests;
using League.Api.Responses;

namespace League.Api.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamResponse>> GetAllTeamsAsync();
        Task<TeamResponse?> GetTeamByIdAsync(int id);
        Task<TeamResponse?> CreateTeamAsync(CreateTeamRequest createTeamRequest);
        Task<TeamResponse?> UpdateTeamAsync(int id, UpdateTeamRequest updateTeamRequest);
        Task<bool> DeleteTeamAsync(int id);
        Task<bool> TeamExistsAsync(int id);
    }
}

using League.Api.Requests;
using League.Api.Responses;

namespace League.Api.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerResponse>> GetAllPlayersAsync();
        Task<PlayerResponse?> GetPlayerByIdAsync(int id);
        Task<IEnumerable<PlayerResponse>?> GetPlayersByTeamIdAsync(int teamId);
        Task<PlayerResponse?> CreatePlayerAsync(CreatePlayerRequest createPlayerRequest);
        Task<PlayerResponse?> UpdatePlayerAsync(int id, UpdatePlayerRequest updatePlayerRequest);
        Task<bool> DeletePlayerAsync(int id);
    }
}

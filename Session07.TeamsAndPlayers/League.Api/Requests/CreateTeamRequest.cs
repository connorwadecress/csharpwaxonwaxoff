namespace League.Api.Requests
{
    public class CreateTeamRequest
    {
        public required string Name { get; set; }
        public required string City { get; set; }
        public required List<CreatePlayerRequest> Players { get; set; }
    }
}

namespace League.Api.Requests
{
    public class UpdateTeamRequest
    {
        public required string Name { get; set; }
        public required string City { get; set; }
        public required List<UpdatePlayerRequest> Players { get; set; }
    }
}

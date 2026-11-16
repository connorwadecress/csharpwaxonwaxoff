namespace League.Api.Requests
{
    public class UpdatePlayerRequest
    {
        public required string Name { get; set; }
        public required int ShirtNumber { get; set; }
        public required string Position { get; set; }
        public required int TeamId { get; set; }    
    }
}

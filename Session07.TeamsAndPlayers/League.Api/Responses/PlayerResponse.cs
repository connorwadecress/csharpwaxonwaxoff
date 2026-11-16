namespace League.Api.Responses
{
    public class PlayerResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int ShirtNumber { get; set; }
        public required string Position { get; set; }
        public required int TeamId { get; set; }
    }
}

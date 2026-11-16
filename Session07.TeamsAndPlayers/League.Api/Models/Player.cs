namespace League.Api.Models
{
    public class Player
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int ShirtNumber { get; set; }
        public required string Position { get; set; }
        public required int TeamId { get; set; }
        public Team Team { get; set; } = null!;
    } 
}

namespace League.Api.Models
{
    public class Team
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}

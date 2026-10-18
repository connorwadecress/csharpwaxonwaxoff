namespace QuoteOfTheDay.Api.Models
{
    public record Quote
    {
        public required int Id { get; init; }
        public required string Text { get; init; }
        public required string Author { get; init; }
    }
}

namespace QuoteOfTheDay.Api.Models
{
    public record CreateQuoteRequest
    {
        public required string Text { get; init; }
        public required string Author { get; init; }
    }
}

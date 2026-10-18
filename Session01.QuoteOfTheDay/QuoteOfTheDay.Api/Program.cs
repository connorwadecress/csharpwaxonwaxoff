using QuoteOfTheDay.Api.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Quote> quotes = new List<Quote>
{
    new Quote { Id = 1, Text = "The only way to do great work is to love what you do.", Author = "Steve Jobs" },
    new Quote { Id = 2, Text = "Success is not the key to happiness. Happiness is the key to success.", Author = "Albert Schweitzer" },
    new Quote { Id = 3, Text = "The best way to predict the future is to invent it.", Author = "Alan Kay" },
    new Quote { Id = 4, Text = "Don't watch the clock; do what it does. Keep going.", Author = "Sam Levenson" },
    new Quote { Id = 5, Text = "The only limit to our realization of tomorrow will be our doubts of today.", Author = "Franklin D. Roosevelt" }
};

app.MapGet("/quotes", () => Results.Ok(quotes));
app.MapGet("/quotes/random", () =>
{
    var index = Random.Shared.Next(quotes.Count);
    var randomQuote = quotes[index];
    return Results.Ok(randomQuote);
});
app.MapPost("/quotes", (CreateQuoteRequest request) =>
{
    var newQuote = new Quote
    {
        Id = quotes.Max(q => q.Id) + 1,
        Text = request.Text,
        Author = request.Author
    };
    quotes.Add(newQuote);
    return Results.Created($"/quotes/{newQuote.Id}", newQuote);
});

app.Run();

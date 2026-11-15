using System.ComponentModel.DataAnnotations;

namespace Library.Api.Models
{
    public class UpdateBookRequest
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
        [Range(1450, 2100)]
        public required int PublishedYear { get; set; }
    }
}

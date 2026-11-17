namespace Enrolments.Application.Responses
{
    public class CourseResponse
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Title { get; set; }
        public required int Credits { get; set; }
    }
}

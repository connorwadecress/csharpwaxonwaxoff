namespace Enrolments.Application.Requests
{
    public class CreateCourseRequest
    {
        public required string Code { get; set; }
        public required string Title { get; set; }
        public required int Credits { get; set; }
    }
}

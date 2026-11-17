namespace Enrolments.Application.Requests
{
    public class UpdateCourseRequest
    {
        public required string Code { get; set; }
        public required string Title { get; set; }
        public required int Credits { get; set; }
    }
}

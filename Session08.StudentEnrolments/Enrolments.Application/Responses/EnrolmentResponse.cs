namespace Enrolments.Application.Responses
{
    public class EnrolmentResponse
    {
        public int StudentId { get; set; }
        public required string StudentName { get; set; }
        public int CourseId { get; set; }
        public required string CourseCode { get; set; }
        public required string CourseTitle { get; set; }
        public DateTime EnrolledOn { get; set; }
    }
}

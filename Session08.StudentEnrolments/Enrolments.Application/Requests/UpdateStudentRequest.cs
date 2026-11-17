namespace Enrolments.Application.Requests
{
    public class UpdateStudentRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
}

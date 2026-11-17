namespace Enrolments.Domain.Entities
{
    // no Id, key is StudentId + CourseId (see AppDbContext)
    public class Enrolment
    {
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public DateTime EnrolledOn { get; set; }
    }
}

namespace Enrolments.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Title { get; set; }
        public required int Credits { get; set; }

        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
    }
}

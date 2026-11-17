using Enrolments.Domain.Entities;

namespace Enrolments.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> CodeExistsAsync(string code);
        void Add(Course course);
        void Remove(Course course);
        Task SaveChangesAsync();
    }
}

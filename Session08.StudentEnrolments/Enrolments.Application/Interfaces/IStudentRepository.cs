using Enrolments.Domain.Entities;

namespace Enrolments.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
        void Add(Student student);
        void Remove(Student student);
        Task SaveChangesAsync();
    }
}

using Enrolments.Application.Interfaces;
using Enrolments.Domain.Entities;
using Enrolments.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Enrolments.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Student>> GetAllAsync() =>
            await _dbContext.Students.ToListAsync();

        public async Task<Student?> GetByIdAsync(int id) =>
            await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);

        public async Task<bool> ExistsAsync(int id) =>
            await _dbContext.Students.AnyAsync(s => s.Id == id);

        public void Add(Student student) =>
            _dbContext.Students.Add(student);

        public void Remove(Student student) =>
            _dbContext.Students.Remove(student);

        public async Task SaveChangesAsync() =>
            await _dbContext.SaveChangesAsync();
    }
}

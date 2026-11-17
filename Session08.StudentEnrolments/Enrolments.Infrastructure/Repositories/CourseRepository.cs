using Enrolments.Application.Interfaces;
using Enrolments.Domain.Entities;
using Enrolments.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Enrolments.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _dbContext;

        public CourseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Course>> GetAllAsync() =>
            await _dbContext.Courses.ToListAsync();

        public async Task<Course?> GetByIdAsync(int id) =>
            await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<bool> ExistsAsync(int id) =>
            await _dbContext.Courses.AnyAsync(c => c.Id == id);

        // for the 409 on a duplicate code, so we dont wait for sql to blow up on the unique index
        public async Task<bool> CodeExistsAsync(string code) =>
            await _dbContext.Courses.AnyAsync(c => c.Code == code);

        public void Add(Course course) =>
            _dbContext.Courses.Add(course);

        public void Remove(Course course) =>
            _dbContext.Courses.Remove(course);

        public async Task SaveChangesAsync() =>
            await _dbContext.SaveChangesAsync();
    }
}

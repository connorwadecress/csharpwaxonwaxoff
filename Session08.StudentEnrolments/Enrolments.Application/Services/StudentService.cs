using Enrolments.Application.Interfaces;
using Enrolments.Application.Requests;
using Enrolments.Application.Responses;
using Enrolments.Domain.Entities;

namespace Enrolments.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentResponse>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Select(ToResponse);
        }

        public async Task<StudentResponse?> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return null;
            }
            return ToResponse(student);
        }

        public async Task<StudentResponse> CreateStudentAsync(CreateStudentRequest createStudentRequest)
        {
            var student = new Student
            {
                FirstName = createStudentRequest.FirstName,
                LastName = createStudentRequest.LastName,
                Email = createStudentRequest.Email
            };

            _studentRepository.Add(student);
            await _studentRepository.SaveChangesAsync();
            return ToResponse(student);
        }

        public async Task<StudentResponse?> UpdateStudentAsync(int id, UpdateStudentRequest updateStudentRequest)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return null;
            }

            student.FirstName = updateStudentRequest.FirstName;
            student.LastName = updateStudentRequest.LastName;
            student.Email = updateStudentRequest.Email;

            await _studentRepository.SaveChangesAsync();
            return ToResponse(student);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return false;
            }

            _studentRepository.Remove(student);
            await _studentRepository.SaveChangesAsync();
            return true;
        }

        // map so its not repeted
        private static StudentResponse ToResponse(Student student) =>
            new StudentResponse
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email
            };
    }
}

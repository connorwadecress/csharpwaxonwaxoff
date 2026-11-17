using Enrolments.Application.Requests;
using Enrolments.Application.Responses;

namespace Enrolments.Application.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponse>> GetAllStudentsAsync();
        Task<StudentResponse?> GetStudentByIdAsync(int id);
        Task<StudentResponse> CreateStudentAsync(CreateStudentRequest createStudentRequest);
        Task<StudentResponse?> UpdateStudentAsync(int id, UpdateStudentRequest updateStudentRequest);
        Task<bool> DeleteStudentAsync(int id);
    }
}

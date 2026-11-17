using Enrolments.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Enrolments.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            //services.AddScoped<ICourseService, CourseService>();
            //services.AddScoped<IEnrolmentService, EnrolmentService>();

            return services;
        }
    }
}

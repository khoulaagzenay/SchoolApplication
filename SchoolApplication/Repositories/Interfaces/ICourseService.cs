using SchoolApplication.Models;

namespace SchoolApplication.Repositories.Interfaces
{
    public interface ICourseService
    {
        Task<Course?> GetCourseByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<int> AddCourseAsync(Course course);
        Task<int> UpdateCourseAsync(Course course);
        Task<int> DeleteCourseAsync(int id);
    }
}

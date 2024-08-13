using SchoolApplication.Models;

namespace SchoolApplication.Repositories.Interfaces
{
    public interface IStudentService
    {
        Task<Student> GetStudentByIdAsync(int id);

        Task<IEnumerable<Student>> GetAllStudentsAsync();

        Task<int> AddStudentAsync(Student student);
        Task<int> UpdateStudentAsync(Student student);
        Task<int> DeleteStudentAsync(int id);

    }
}

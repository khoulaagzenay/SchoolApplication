using SchoolApplication.Models;
using SchoolApplication.Repositories.Interfaces;

namespace SchoolApplication.Repositories.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;

        public StudentService(IGenericRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }


        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<int> AddStudentAsync(Student student)
        {
            return await _studentRepository.AddAsync(student);
        }
        public async Task<int> UpdateStudentAsync(Student student)
        {
            return await _studentRepository.UpdateAsync(student);
        }
        public async Task<int> DeleteStudentAsync(int id)
        {
            return await _studentRepository.DeleteAsync(id);
        }

    }
}

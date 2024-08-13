using Microsoft.EntityFrameworkCore;
using SchoolApplication.Data;
using SchoolApplication.Models;
using SchoolApplication.Repositories.Interfaces;

namespace SchoolApplication.Repositories.DbRepositories
{
    public class StudentDbRepository : IGenericRepository<Student>
    {
        private readonly SchoolContext _context;

        public StudentDbRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<Student> GetByIdAsync(int id, bool hasAllInfo = false) => await _context.Students.FindAsync(id);

        public async Task<IEnumerable<Student>> GetAllAsync(bool hasAllInfo = false) => await _context.Students.ToListAsync();
        public async Task<int> AddAsync(Student entity)
        {
            await _context.Students.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(Student entity)
        {
            _context.Students.Update(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                return await _context.SaveChangesAsync();
            }

            return -1;
        }
    }
       
    
    



}

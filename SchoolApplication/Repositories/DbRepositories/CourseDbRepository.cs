using Microsoft.EntityFrameworkCore;
using SchoolApplication.Data;
using SchoolApplication.Models;
using SchoolApplication.Repositories.Interfaces;

namespace SchoolApplication.Repositories.DbRepositories
{
    public class CourseDbRepository : IGenericRepository<Course>
    {
        private readonly SchoolContext _context;

        public CourseDbRepository(SchoolContext context)
        {
            _context = context;
        }


        public async Task<Course?> GetByIdAsync(int id, bool hasAllInfo = false) => await _context.Courses.FindAsync(id);

        public async Task<IEnumerable<Course>> GetAllAsync(bool hasAllInfo = false) => await _context.Courses.ToListAsync();

        public async Task<int> AddAsync(Course entity)
        {
            await _context.Courses.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Course entity)
        {
            _context.Courses.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var Course = await _context.Courses.FindAsync(id);
            if (Course != null)
            {
                _context.Courses.Remove(Course);
                return await _context.SaveChangesAsync();
            }

            return -1;
        }
    }
}

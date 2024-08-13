using Microsoft.EntityFrameworkCore;
using SchoolApplication.Data;
using SchoolApplication.Models;
using SchoolApplication.Repositories.Interfaces;

namespace SchoolApplication.Repositories.DbRepositories
{
    public class GradeDbRepository : IGenericRepository<Grade>
    {
        private readonly SchoolContext _context;

        public GradeDbRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<Grade?> GetByIdAsync(int id)
        {
            return await GetByIdAsync(id, false);
        }
        public async Task<Grade?> GetByIdAsync(int id, bool hasAllInfos)
        {
            if (!hasAllInfos)
            {
                return await _context.Grades.FindAsync(id);
            }

            return await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .SingleOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Grade>> GetAllAsync() => await GetAllAsync(false);
        public async Task<IEnumerable<Grade>> GetAllAsync(bool hasAllInfos)
        {
            if (!hasAllInfos) return await _context.Grades.ToListAsync();

            return await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
            .ToListAsync();
        }

        public async Task<int> AddAsync(Grade entity)
        {
            await _context.Grades.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Grade entity)
        {
            _context.Grades.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade != null)
            {
                _context.Grades.Remove(grade);
                return await _context.SaveChangesAsync();
            }

            return -1;
        }
    }
}

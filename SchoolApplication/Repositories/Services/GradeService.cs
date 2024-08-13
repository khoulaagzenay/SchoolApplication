using SchoolApplication.Models;
using SchoolApplication.Repositories.Interfaces;

namespace SchoolApplication.Repositories.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGenericRepository<Grade> _gradeRepository;

        public GradeService(IGenericRepository<Grade> gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<Grade?> GetGradeByIdAsync(int id, bool hasAllInfos = false)
        {
            return await _gradeRepository.GetByIdAsync(id, hasAllInfos);
        }

        public async Task<IEnumerable<Grade>> GetAllGradesAsync(bool hasAllInfos = false)
        {
            return await _gradeRepository.GetAllAsync(hasAllInfos);
        }

        public async Task<int> AddGradeAsync(Grade grade)
        {
            return await _gradeRepository.AddAsync(grade);
        }

        public async Task<int> UpdateGradeAsync(Grade grade)
        {
            return await _gradeRepository.UpdateAsync(grade);
        }

        public async Task<int> DeleteGradeAsync(int id)
        {
            return await _gradeRepository.DeleteAsync(id);
        }
    }
}

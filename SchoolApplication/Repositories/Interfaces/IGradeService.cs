using SchoolApplication.Models;

namespace SchoolApplication.Repositories.Interfaces
{
    public interface IGradeService
    {
        Task<Grade?> GetGradeByIdAsync(int id, bool hasAllInfos = false);
        Task<IEnumerable<Grade>> GetAllGradesAsync(bool hasAllInfos = false);
        Task<int> AddGradeAsync(Grade grade);
        Task<int> UpdateGradeAsync(Grade grade);
        Task<int> DeleteGradeAsync(int id);
    }
}

namespace SchoolApplication.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id, bool hasAllInfo = false);
        Task<IEnumerable<TEntity>> GetAllAsync(bool hasAllInfo = false);
        Task<int> AddAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(int id);
    }
}

using ABPTestApp.Domain;

namespace ABPTestApp.Application.Interfaces
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(int id) where T: BaseEntity;

        Task<List<Experiment>> GetExperimentsByNameAsync(string experimentName);

        Task<List<T>> GetAllAsync<T>() where T : BaseEntity;

        Task AddAsync<T>(T entity) where T : BaseEntity;

        Task DeleteAsync<T>(int id) where T : BaseEntity;

        Task SaveChangesAsync();
    }
}

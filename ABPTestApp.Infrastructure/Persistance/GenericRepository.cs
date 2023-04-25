using ABPTestApp.Application.Interfaces;
using ABPTestApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace ABPTestApp.Infrastructure.Persistance
{
    public class GenericRepository : IRepository
    {
        private readonly ExperimentDbContext _experimentDbContext;

        public GenericRepository(ExperimentDbContext experimentDbContext)
        {
            _experimentDbContext = experimentDbContext;
        }

        public async Task AddAsync<T>(T entity) where T : BaseEntity
        {
            await _experimentDbContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync<T>(int id) where T : BaseEntity
        {
            var entity = await _experimentDbContext.Set<T>().FindAsync(id);

            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            _experimentDbContext.Set<T>().Remove(entity);
        }

        public Task<List<T>> GetAllAsync<T>() where T : BaseEntity
        {
            return _experimentDbContext.Set<T>().ToListAsync();
        }

        public Task<List<Device>> GetAllDevicesAsync()
        {
            return _experimentDbContext.Set<Device>().Include(d => d.Experiment).ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            var entity = await _experimentDbContext.Set<T>().FindAsync(id);

            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            return entity;
        }

        public async Task<List<Experiment>> GetExperimentsByNameAsync(string experimentName)
        {
            var experiments = await _experimentDbContext.Experiments.Where(x => x.Name == experimentName)
                .ToListAsync();

            return experiments;
        }

        public async Task SaveChangesAsync()
        {
            await _experimentDbContext.SaveChangesAsync();
        }
    }
}

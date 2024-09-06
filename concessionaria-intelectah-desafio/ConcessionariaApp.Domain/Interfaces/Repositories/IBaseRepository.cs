using ConcessionariaApp.Domain.Common;

namespace ConcessionariaApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Add(T value);
        void Delete(T value);
        void Update(T value);
        Task<T> GetAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}

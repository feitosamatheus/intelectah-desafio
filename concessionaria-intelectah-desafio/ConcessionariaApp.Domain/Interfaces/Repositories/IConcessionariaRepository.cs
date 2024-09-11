using ConcessionariaApp.Domain.Entities;

namespace ConcessionariaApp.Domain.Interfaces.Repositories
{
    public interface IConcessionariaRepository : IBaseRepository<Concessionaria>
    {
        Task<Concessionaria> BuscarConcessionariaPorNome(string nome);
    }
}

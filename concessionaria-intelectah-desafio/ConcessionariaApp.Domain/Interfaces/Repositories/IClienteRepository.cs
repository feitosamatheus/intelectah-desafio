using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.ValueObjects;

namespace ConcessionariaApp.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente> BuscarClientePorCpf(string CPF);
    }
}

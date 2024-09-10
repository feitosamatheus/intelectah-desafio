using ConcessionariaApp.Domain.Entities;

namespace ConcessionariaApp.Domain.Interfaces.Repositories
{
    public interface IFabricanteRepository : IBaseRepository<Fabricante>
    {
        Task<Fabricante> BuscarFabricantePorNomeAsync(string nome, CancellationToken cancellationToken);
    }
}

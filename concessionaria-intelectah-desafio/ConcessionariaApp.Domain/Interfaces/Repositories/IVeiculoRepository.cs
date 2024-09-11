using ConcessionariaApp.Domain.Entities;

namespace ConcessionariaApp.Domain.Interfaces.Repositories
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        Task<IEnumerable<Veiculo>> BucarVeiculoPorProdutoModelo(string modelo, int fabricanteId);
    }
}

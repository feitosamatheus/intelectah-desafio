using ConcessionariaApp.Domain.Entities;

namespace ConcessionariaApp.Domain.Interfaces.Repositories
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        Task<IEnumerable<Veiculo>> BucarVeiculoPorFabricanteModelo(string modelo, int fabricanteId);
        Task<IEnumerable<Veiculo>> BucarVeiculoPorFabricante(int fabricanteId);
        Task<IEnumerable<Veiculo>> BucarVeiculoPorModelo(string modelo);
    }
}

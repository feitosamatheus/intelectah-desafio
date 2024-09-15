using ConcessionariaApp.Domain.Entities;

namespace ConcessionariaApp.Domain.Interfaces.Repositories
{
    public interface IVendaRepository : IBaseRepository<Venda>
    {
        Task<int> BuscarQuantidadeVendaPorConcessionaria(int concessionariaId);
        Task<IEnumerable<Venda>> BucarRelatorioVendaPorAnoMes(int mes, int ano);
    }
}

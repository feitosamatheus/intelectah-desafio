namespace ConcessionariaApp.Application.Dtos.Relatorios
{
    public class RelatorioConcessionariaVendaDTO
    {
        public string Nome { get; set; }
        public int QtdVendas { get; set; }
        public RelatorioVeiculosVendaDTO VeiculoMaisVendido { get; set;}
        public decimal TotalVenda { get; set; }
    }
}
using ConcessionariaApp.Domain.Enums;

namespace ConcessionariaApp.Domain.Entities
{
    public class Veiculo
    {
        public int VeiculoId { get; private set; }
        public string Modelo { get; private set; }
        public string AnoFabricacao { get; private set; }
        public decimal Preco { get; private set; }
        public int FabricanteId { get; private set; }
        public ETipoVeiculo TipoVeiculo { get; private set; }
        public string Descricao { get; set; }

        public Fabricante Fabricante { get; private set; }

        public Veiculo(string modelo, string anoFabricacao, decimal preco, int fabricanteId, ETipoVeiculo tipoVeiculo, string descricao = "")
        {
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            Preco = preco;
            FabricanteId = fabricanteId;
            TipoVeiculo = tipoVeiculo;
            Descricao = descricao;
        }
    }
}

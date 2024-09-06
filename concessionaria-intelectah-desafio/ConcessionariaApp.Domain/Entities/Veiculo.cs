using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Enums;

namespace ConcessionariaApp.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public string Modelo { get; private set; }
        public int AnoFabricacao { get; private set; }
        public decimal Preco { get; private set; }
        public int FabricanteId { get; private set; }
        public ETipoVeiculo TipoVeiculo { get; private set; }
        public string Descricao { get; set; }

        public Fabricante Fabricante { get; private set; }
        public ICollection<Venda> Vendas { get; private set; }

        public Veiculo(){ }
        public Veiculo(string modelo, int anoFabricacao, decimal preco, int fabricanteId, ETipoVeiculo tipoVeiculo, string descricao = "")
        {
            if(preco < 0)
                throw new ArgumentOutOfRangeException(nameof(Preco), "O preço não pode ser negativo.");

            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            Preco = preco;
            FabricanteId = fabricanteId;
            TipoVeiculo = tipoVeiculo;
            Descricao = descricao;
        }
    }
}

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
        private Veiculo(string modelo, int anoFabricacao, decimal preco, int fabricanteId, ETipoVeiculo tipoVeiculo, string descricao = "")
        {
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            Preco = preco;
            FabricanteId = fabricanteId;
            TipoVeiculo = tipoVeiculo;
            Descricao = descricao;
        }

        public static Veiculo Criar(string modelo, int anoFabricacao, decimal preco, int fabricanteId, ETipoVeiculo tipoVeiculo, string descricao = "")
        {
            if (preco <= 0)
                throw new ArgumentOutOfRangeException(nameof(Preco), "O preço não pode ser negativo.");
            if (anoFabricacao > DateTime.Now.Year)
                throw new ArgumentOutOfRangeException(nameof(Preco), "Ano de fabricação não pode ser no futuro.");
            if (anoFabricacao < 1920)
                throw new ArgumentOutOfRangeException(nameof(Preco), "Ano inválido.");
            if (preco <= 0)
                throw new ArgumentOutOfRangeException(nameof(Preco), "Preço inválido.");
            if (fabricanteId <= 0)
                throw new ArgumentOutOfRangeException(nameof(Preco), "Fabricante inválido.");
            if (!Enum.IsDefined(typeof(ETipoVeiculo), tipoVeiculo))
                throw new ArgumentException("Tipo de veículo inválido.", nameof(tipoVeiculo));

            return new Veiculo(modelo, anoFabricacao, preco, fabricanteId, tipoVeiculo, descricao);
        }

    }
}

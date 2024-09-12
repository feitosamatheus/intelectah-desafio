using ConcessionariaApp.Domain.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConcessionariaApp.Domain.Entities
{
    public class Venda : BaseEntity
    {    
        public int VeiculoId { get; private set; }
        public int ConcessionariaId { get; private set; }
        public int ClienteId { get; private set; }
        public DateTime DataVenda { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public string ProtocoloVenda { get; private set; }

        public Veiculo Veiculo { get; private set; }
        public Concessionaria Concessionaria { get; private set; }
        public Cliente Cliente { get; private set; }

        public Venda(){}
        private Venda(Veiculo veiculo, Concessionaria concessionaria, int clienteId, DateTime dataVenda, decimal precoVenda, string protocolo)
        {
            if(dataVenda > DateTime.Now)
                throw new ArgumentOutOfRangeException(nameof(DataVenda), "A data da venda não pode ser no futuro.");
            if(PrecoVenda < 0 )
                throw new ArgumentOutOfRangeException(nameof(PrecoVenda), "O preço não pode ser negativo.");
            if (PrecoVenda > veiculo.Preco)
                throw new ArgumentOutOfRangeException(nameof(PrecoVenda), "O preço da venda não pode ser maior que do veículo.");

            VeiculoId = veiculo.Id;
            ConcessionariaId = concessionaria.Id;
            ClienteId = clienteId;
            DataVenda = dataVenda;
            PrecoVenda = precoVenda;
            ProtocoloVenda = protocolo;
        }
        
        public static Venda Criar(Veiculo veiculo, Concessionaria concessionaria, int clienteId, DateTime dataVenda, decimal precoVenda)
        {


            return new Venda(veiculo, concessionaria, clienteId, dataVenda, precoVenda, "Em construção");
        }

        public void GerarProtocolo()
        {
            var anoAtual = DateTime.Now.Year;
            var padraoNumero = "VE"+ anoAtual+ "00000000000000";
            var idLength = Id.ToString().Length;

            ProtocoloVenda = padraoNumero.Substring(0, padraoNumero.Length - idLength) + Id;
        }

    }
}

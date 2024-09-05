namespace ConcessionariaApp.Domain.Entities
{
    public class Venda
    {    
        public int VendaId { get; private set; }
        public int VeiculoId { get; private set; }
        public int ConcessionariaId { get; private set; }
        public int ClienteId { get; private set; }
        public DateTime DataVenda { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public string ProtocoloVenda { get; private set; }

        public Veiculo Veiculo { get; private set; }
        public Concessionaria Concessionaria { get; private set; }
        public Cliente Cliente { get; private set; }

        public Venda(int veiculoId, int concessionariaId, int clienteId, DateTime dataVenda, decimal precoVenda, string protocoloVenda)
        {
            VeiculoId = veiculoId;
            ConcessionariaId = concessionariaId;
            ClienteId = clienteId;
            DataVenda = dataVenda;
            PrecoVenda = precoVenda;
            ProtocoloVenda = protocoloVenda;
        }
    }
}

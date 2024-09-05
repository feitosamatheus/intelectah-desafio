
namespace ConcessionariaApp.Domain.Entities
{
    public class Fabricante
    {
        public int FabricanteId { get; private set;}
        public string Nome { get; private set; } // deve ser único
        public string PaisOrigem { get; private set; }
        public int AnoFundacao { get; private  set; }
        public string WebSite { get; private set; }
        
        public ICollection<Veiculo> Veiculos { get; private set; }

        public Fabricante(string nome, int anoFundacao, string webSite, string paisOrigem)
        {
            Nome = nome;
            AnoFundacao = anoFundacao;
            WebSite = webSite;
            PaisOrigem = paisOrigem;
        }
    }
}

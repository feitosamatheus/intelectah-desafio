
using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Enums;
using ConcessionariaApp.Domain.ValueObjects;

namespace ConcessionariaApp.Domain.Entities
{
    public class Fabricante : BaseEntity
    {
        public string Nome { get; private set; }
        public string PaisOrigem { get; private set; }
        public int AnoFundacao { get; private  set; }
        public string WebSite { get; private set; }
        
        public ICollection<Veiculo> Veiculos { get; private set; }

        public Fabricante() { }
        private Fabricante(string nome, int anoFundacao, string webSite, string paisOrigem)
        {
            Nome = nome;
            AnoFundacao = anoFundacao;
            WebSite = webSite;
            PaisOrigem = paisOrigem;
        }

        public static Fabricante Criar(string nome, int anoFundacao, string paisOrigem,  string webSite)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(paisOrigem))
                throw new ArgumentException("Pais de origem não pode ser vazia.");
            if (anoFundacao > DateTime.Now.Year || anoFundacao < 1856)
                throw new ArgumentException("O endereço de email não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(paisOrigem))
                throw new ArgumentException("Website não pode ser vazia.");

            return new Fabricante(nome, anoFundacao, paisOrigem, webSite);
        }

    }
}

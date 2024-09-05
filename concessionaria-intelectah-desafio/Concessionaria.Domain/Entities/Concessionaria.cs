using ConcessionariaApp.Domain.ValueObjects;

namespace ConcessionariaApp.Domain.Entities
{
    public class Concessionaria
    {
        public int ConcessionariaId { get; private set; }
        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }  
        public Telefone Telefone { get; private set; }
        public Email Email { get; private set; }
        public int CapacidadeMaximaVeiculos { get; private set; }

        public ICollection<Venda> Vendas { get; private set; }

        public Concessionaria(string nome, Endereco endereco, Telefone telefone, Email email, int capacidadeMaximaVeiculos)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            CapacidadeMaximaVeiculos = capacidadeMaximaVeiculos;
        }
    }
}

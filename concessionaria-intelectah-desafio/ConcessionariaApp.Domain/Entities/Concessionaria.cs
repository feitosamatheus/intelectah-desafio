using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.ValueObjects;
using System.Runtime.Serialization;

namespace ConcessionariaApp.Domain.Entities
{
    public class Concessionaria : BaseEntity
    {
        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }  
        public Telefone Telefone { get; private set; }
        public Email Email { get; private set; }
        public int CapacidadeMaximaVeiculos { get; private set; }

        public ICollection<Venda> Vendas { get; private set; }

        public Concessionaria(){ }
        private Concessionaria(string nome, Endereco endereco, Telefone telefone, Email email, int capacidadeMaximaVeiculos)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            CapacidadeMaximaVeiculos = capacidadeMaximaVeiculos;
        }

        public static Concessionaria Criar(string nome, string rua, string cidade, string estado, string cep, string telefoneRepassado, string enderecoEmail, int capacidadeMaximaVeiculos)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(rua) || string.IsNullOrWhiteSpace(cidade) || string.IsNullOrWhiteSpace(estado) || string.IsNullOrWhiteSpace(cep))
                throw new ArgumentException("Informe o endereço completo.");
            if (string.IsNullOrWhiteSpace(enderecoEmail))
                throw new ArgumentException("O endereço de email não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(telefoneRepassado))
                throw new ArgumentException("O telefone não pode ser vazio.");
            if (capacidadeMaximaVeiculos <= 0)
                throw new ArgumentException("A capacidade de veiculos tem que ser um valor positivo.");

            var endereco = Endereco.Criar(rua, cidade, estado, cep);
            var email = Email.Criar(enderecoEmail);
            var telefone = Telefone.Criar(telefoneRepassado);

            return new Concessionaria(nome, endereco, telefone, email, capacidadeMaximaVeiculos);
        }
    }
}

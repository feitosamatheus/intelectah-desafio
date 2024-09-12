using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.ValueObjects;

namespace ConcessionariaApp.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; private set; }
        public CPF Cpf { get; private set; }
        public Telefone Telefone { get; private set; }

        public ICollection<Venda> Vendas { get; private set; }

        public Cliente(){ }
        private Cliente(string nome, CPF cpf, Telefone telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
        }
        public static Cliente Criar(string nome, string cpf, string telefone)
        {
            var telefoneObj = Telefone.Criar(telefone);
            var CpfObj = CPF.Criar(cpf);
            return new Cliente(nome, CpfObj, telefoneObj);
        }
    }
}

using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.ValueObjects;

namespace ConcessionariaApp.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public int Nome { get; private set; }
        public CPF Cpf { get; private set; }
        public Telefone Telefone { get; private set; }

        public ICollection<Venda> Vendas { get; private set; }

        public Cliente(){ }
        public Cliente(int nome, CPF cpf, Telefone telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
        }
    }
}

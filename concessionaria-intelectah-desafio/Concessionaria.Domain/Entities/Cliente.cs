using Concessionaria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; private set; }
        public int Nome { get; private set; }
        public CPF Cpf { get; private set; }
        public Telefone Telefone { get; private set; }
        
        public Cliente(int nome, CPF cpf, Telefone telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
        }
    }
}

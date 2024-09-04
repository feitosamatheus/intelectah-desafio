using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Domain.ValueObjects
{
    public class CPF
    {
        public string Numero { get; set; }

        public CPF(string numero)
        {
            Numero = numero;
        }

        public override bool Equals(object obj)
        {
            if (obj is not CPF cpf)
                return false;

            return Numero == cpf.Numero;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numero);

        }

    }
}

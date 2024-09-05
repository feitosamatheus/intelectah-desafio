using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Domain.Exceptions
{
    public class CpfInvalidoException : DomainException
    {
        public CpfInvalidoException() : base("CPF inválido.") { }

        public CpfInvalidoException(string menssagem) : base(menssagem) { }
        public CpfInvalidoException(string menssagem, Exception exception) : base(menssagem, exception) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Domain.Exceptions
{
    public class EmailInvalidoException : DomainException
    {
        public EmailInvalidoException() : base("Endereço de Email inválido.") { }

        public EmailInvalidoException(string menssagem) : base(menssagem) { }
        public EmailInvalidoException(string menssagem, Exception exception) : base(menssagem, exception) { }
    }
}

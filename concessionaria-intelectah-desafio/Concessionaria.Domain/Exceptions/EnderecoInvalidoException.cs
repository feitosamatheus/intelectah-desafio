using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Domain.Exceptions
{
    public class EnderecoInvalidoException : DomainException
    {
        public EnderecoInvalidoException() : base("Endereço inválido.") { }

        public EnderecoInvalidoException(string menssagem) : base(menssagem) { }
        public EnderecoInvalidoException(string menssagem, Exception exception) : base(menssagem, exception) { }
    }
}

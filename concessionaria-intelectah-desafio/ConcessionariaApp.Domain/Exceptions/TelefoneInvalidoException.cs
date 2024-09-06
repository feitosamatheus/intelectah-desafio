using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Domain.Exceptions
{
    public class TelefoneInvalidoException : DomainException
    {
        public TelefoneInvalidoException() : base("Telefone inválido.") { }

        public TelefoneInvalidoException(string menssagem) : base(menssagem) { }
        public TelefoneInvalidoException(string menssagem, Exception exception) : base(menssagem, exception) { }
    }
}

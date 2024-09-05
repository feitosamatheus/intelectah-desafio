using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException() : base(){ }

        public DomainException(string menssagem) : base(menssagem){ }
        public DomainException(string menssagem, Exception exception) : base(menssagem, exception) { }
    }
}

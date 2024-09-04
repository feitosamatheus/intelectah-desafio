using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Domain.Entities
{
    public class Fabricante
    {
        public int FabricanteId { get; private set;}
        public string Nome { get; private  set; } // deve ser único
        public DateTime AnoFundacao { get; private  set; }
        public string WebSite { get; private set; }
    }
}

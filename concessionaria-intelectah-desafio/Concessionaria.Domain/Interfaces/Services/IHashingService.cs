using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Domain.Interfaces.Services
{
    public interface IHashingService
    {
        string GerarHash(string valor);
        bool ValidarHash(string valorRepassado, string HashAtual);
    }
}

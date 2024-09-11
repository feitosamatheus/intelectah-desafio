using ConcessionariaApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Interfaces
{
    public interface ICepService
    {
        Task<Endereco> BuscarEnderecoPorCep(string cep);
        Task<bool> ValidarCep(string cep);

    }
}

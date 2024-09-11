using ConcessionariaApp.Application.Dtos.Concessionarias;
using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Interfaces
{
    public interface IConcessionariaService
    {
        Task<ResultadoOperacao> CadastrarConcessionaria(CadastrarConcessionariaDTO dto);
        Task<Endereco> BuscarEnderecoPorCep(string cep);
    }
}

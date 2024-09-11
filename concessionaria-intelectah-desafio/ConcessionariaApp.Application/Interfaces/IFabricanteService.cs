using ConcessionariaApp.Application.Dtos.Fabricantes;
using ConcessionariaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Interfaces
{
    public interface IFabricanteService
    {
        Task<ResultadoOperacao> CriarFabricante(CriarFabricanteDTO dto);
        Task<IEnumerable<FabricanteDTO>> ObterTodosParticipantes();
    }
}

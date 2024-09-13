using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaApp.Application.Dtos.Common;

namespace ConcessionariaApp.Application.Interfaces
{
    public interface ICommonService
    {
        Task<IEnumerable<AnoDTO>> ObterIntervaloAno(int anoInicial, int anoFinal);
        Task<IEnumerable<MesDTO>> ObterMeses();
    }
}

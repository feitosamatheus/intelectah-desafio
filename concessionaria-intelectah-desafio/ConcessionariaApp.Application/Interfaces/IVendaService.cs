using ConcessionariaApp.Application.Dtos.Vendas;
using ConcessionariaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Interfaces
{
    public interface IVendaService
    {
        Task<ResultadoOperacao> RegistrarVenda(RegistrarVendaDTO dto);
    }
}

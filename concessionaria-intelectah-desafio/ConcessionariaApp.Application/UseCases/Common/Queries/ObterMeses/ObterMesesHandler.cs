using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaApp.Application.Dtos.Common;
using MediatR;

namespace ConcessionariaApp.Application.UseCases.Common.Queries.ObterMeses
{
    public sealed class ObterMesesHandler : IRequestHandler<ObterMesesQuery, IEnumerable<MesDTO>>
    {
        public Task<IEnumerable<MesDTO>> Handle(ObterMesesQuery request, CancellationToken cancellationToken)
        {
            var mesesArray = Meses();
            var mesesLista = mesesArray.Select(m => new MesDTO { Nome = m[0], Valor = int.Parse(m[1])});
            return Task.FromResult(mesesLista);
        }

        public string[][] Meses()
        {
            return [["Janeiro", "1"],
                    ["Fevereiro", "2"],
                    ["Março", "3"],
                    ["Abril", "4"],
                    ["Maio", "5"],
                    ["Junho", "6"],
                    ["Julho", "7"],
                    ["Agosto", "8"],
                    ["Setembro", "9"],
                    ["Outubro", "10"],
                    ["Novembro", "11"],
                    ["Dezembro", "12"]];
        }
    }
}

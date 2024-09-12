using ConcessionariaApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Concessionarias.Queries.BuscarConcessionariaPorLocalizacao
{
    public sealed record BuscarConcessionariaPorLocalizacaoQuery( string Localizacao) : IRequest<IEnumerable<Concessionaria>>;
}

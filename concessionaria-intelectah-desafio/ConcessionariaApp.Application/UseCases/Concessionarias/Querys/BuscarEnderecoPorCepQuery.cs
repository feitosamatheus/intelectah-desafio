using ConcessionariaApp.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Concessionarias.Querys
{
    public sealed record BuscarEnderecoPorCepQuery(string cep) : IRequest<Endereco>;
}

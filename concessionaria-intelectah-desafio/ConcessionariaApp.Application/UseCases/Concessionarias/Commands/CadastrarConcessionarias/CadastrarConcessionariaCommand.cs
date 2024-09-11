using ConcessionariaApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Concessionarias.Commands.CadastrarConcessionarias
{
    public sealed record CadastrarConcessionariaCommand(
                                                        string Nome,
                                                        string EnderecoCompleto,
                                                        string Cidade,
                                                        string Estado,
                                                        string Cep,
                                                        string Email,
                                                        string Telefone,
                                                        int CapacidadeMaxima) : IRequest<ResultadoOperacao>;
}

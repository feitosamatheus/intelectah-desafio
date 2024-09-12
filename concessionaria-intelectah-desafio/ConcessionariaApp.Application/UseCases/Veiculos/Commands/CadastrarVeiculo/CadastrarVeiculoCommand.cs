using ConcessionariaApp.Application.Attributes;
using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Veiculos.Commands.CadastrarVeiculo
{
    public sealed record CadastrarVeiculoCommand(string Modelo,
                                                    int AnoFabricacao,
                                                    string Preco,
                                                    int FabricanteId,
                                                    string TipoVeiculo,
                                                    string Descricao) : IRequest<ResultadoOperacao>;
}

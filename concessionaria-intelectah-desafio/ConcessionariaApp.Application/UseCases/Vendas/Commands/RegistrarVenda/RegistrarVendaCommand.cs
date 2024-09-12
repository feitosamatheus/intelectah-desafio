using ConcessionariaApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Vendas.Commands.RegistrarVenda
{
    public sealed record RegistrarVendaCommand( int VeiculoId ,
                                                int ConcessionariaId ,
                                                string NomeCliente ,
                                                string CPF ,
                                                string TelefoneCliente,
                                                DateTime DataVenda,
                                                string ValorVenda) : IRequest<ResultadoOperacao>;
}

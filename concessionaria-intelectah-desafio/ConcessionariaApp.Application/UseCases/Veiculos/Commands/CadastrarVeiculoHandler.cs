using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Enums;
using ConcessionariaApp.Domain.Interfaces;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Veiculos.Commands
{
    public class CadastrarVeiculoHandler : IRequestHandler<CadastrarVeiculoCommand, ResultadoOperacao>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CadastrarVeiculoHandler(IVeiculoRepository veiculoRepository, IUnitOfWork unitOfWork)
        {
            _veiculoRepository = veiculoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultadoOperacao> Handle(CadastrarVeiculoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tipoVeiculoEnum = (ETipoVeiculo)Enum.Parse(typeof(ETipoVeiculo), request.TipoVeiculo);
                var veiculoCriado = Veiculo.Criar(request.Modelo, request.AnoFabricacao, decimal.Parse(request.Preco), request.FabricanteId, tipoVeiculoEnum, request.Descricao);
                _veiculoRepository.Add(veiculoCriado);
                await _unitOfWork.CommitAsync(cancellationToken);
                return ResultadoOperacao.OK("Veículo cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return ResultadoOperacao.Falha(ex.Message);
            }
        }
    }
}

using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Vendas.Commands.RegistrarVenda
{
    public sealed class RegistrarVendaHandler : IRequestHandler<RegistrarVendaCommand, ResultadoOperacao>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IConcessionariaRepository _concessionariaRepository;
        private readonly ICashingService _cashingService;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarVendaHandler(IVendaRepository vendaRepository, IClienteRepository clienteRepository, ICashingService cashingService, IUnitOfWork unitOfWork, IConcessionariaRepository concessionariaRepository, IVeiculoRepository veiculoRepository)
        {
            _vendaRepository = vendaRepository;
            _clienteRepository = clienteRepository;
            _cashingService = cashingService;
            _unitOfWork = unitOfWork;
            _concessionariaRepository = concessionariaRepository;
            _veiculoRepository = veiculoRepository;
        }

        public async Task<ResultadoOperacao> Handle(RegistrarVendaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var concessionaria = await _concessionariaRepository.GetAsync(request.ConcessionariaId, cancellationToken);
                var qtdVendaPorConcessionaria = await _vendaRepository.BuscarQuantidadeVendaPorConcessionaria(concessionaria.Id);
                if (qtdVendaPorConcessionaria >= concessionaria.CapacidadeMaximaVeiculos)
                    return ResultadoOperacao.Falha("A concessionária atingiu a capacidade maxíma.");

                var veiculo = await _veiculoRepository.GetAsync(request.VeiculoId, cancellationToken);
                if (veiculo.Preco < decimal.Parse(request.ValorVenda))
                    return ResultadoOperacao.Falha("O valor da venda não pode ser maior que o valor do veículo.");

                var clienteExistente = await _clienteRepository.BuscarClientePorCpf(request.CPF);
                Cliente clienteVenda;
                if(clienteExistente is not null)
                {
                    clienteVenda = clienteExistente;
                }
                else
                {
                    clienteVenda = Cliente.Criar(request.NomeCliente, request.CPF, request.TelefoneCliente);
                    _clienteRepository.Add(clienteVenda);
                    await _unitOfWork.CommitAsync(cancellationToken);
                }

                Venda novaVenda = Venda.Criar(veiculo, concessionaria, clienteVenda.Id, request.DataVenda, decimal.Parse(request.ValorVenda));
                _vendaRepository.Add(novaVenda);
                await _unitOfWork.CommitAsync(cancellationToken);

                novaVenda.GerarProtocolo();
                _vendaRepository.Update(novaVenda);

                await _unitOfWork.CommitAsync(cancellationToken);

                return ResultadoOperacao.OK(novaVenda.ProtocoloVenda);
            }
            catch(Exception ex)
            {
                return ResultadoOperacao.Falha(ex.Message);
            }
        }
    }
}

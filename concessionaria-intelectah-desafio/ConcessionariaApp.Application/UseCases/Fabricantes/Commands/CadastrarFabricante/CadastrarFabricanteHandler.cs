using ConcessionariaApp.Domain.Common;
using ConcessionariaApp.Domain.Entities;
using ConcessionariaApp.Domain.Interfaces;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Fabricantes.Commands.CadastrarFabricante
{
    public sealed class CadastrarFabricanteHandler : IRequestHandler<CadastrarFabricanteCommand, ResultadoOperacao>
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CadastrarFabricanteHandler(IFabricanteRepository fabricanteRepository, IUnitOfWork unitOfWork)
        {
            _fabricanteRepository = fabricanteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultadoOperacao> Handle(CadastrarFabricanteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fabricante = await _fabricanteRepository.BuscarFabricantePorNomeAsync(request.Nome, cancellationToken);
                if (fabricante is not null)
                    return ResultadoOperacao.Falha("Fabricante já cadastrado no sistema.");

                var novoFabricante = Fabricante.Criar(request.Nome, request.AnoFundacao, request.PaisOrigem, request.WebSite);
                _fabricanteRepository.Add(novoFabricante);

                await _unitOfWork.CommitAsync(cancellationToken);

                return ResultadoOperacao.OK("Fabricante cadastrado com sucesso.");
            }
            catch(Exception ex)
            {
                return ResultadoOperacao.Falha(ex.Message);
            }
        }
    }
}

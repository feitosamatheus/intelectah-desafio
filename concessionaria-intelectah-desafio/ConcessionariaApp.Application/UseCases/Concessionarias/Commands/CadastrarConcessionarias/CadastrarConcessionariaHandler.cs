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

namespace ConcessionariaApp.Application.UseCases.Concessionarias.Commands.CadastrarConcessionarias
{
    public class CadastrarConcessionariaHandler : IRequestHandler<CadastrarConcessionariaCommand, ResultadoOperacao>
    {
        private readonly IConcessionariaRepository _concessionariaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CadastrarConcessionariaHandler(IConcessionariaRepository concessionariaRepository, IUnitOfWork unitOfWork)
        {
            _concessionariaRepository = concessionariaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultadoOperacao> Handle(CadastrarConcessionariaCommand request, CancellationToken cancellationToken)
        {
            try 
            { 
                var concessionaria = await _concessionariaRepository.BuscarConcessionariaPorNome(request.Nome);
                if(concessionaria is not null)
                    return ResultadoOperacao.Falha("Nome já sendo utilizado, por favor informe outro.");

                var novaConcessionaria = Concessionaria.Criar(request.Nome, 
                                                              request.EnderecoCompleto,
                                                              request.Cidade, 
                                                              request.Estado, 
                                                              request.Cep, 
                                                              request.Telefone, 
                                                              request.Email,
                                                              request.CapacidadeMaxima);
            
                _concessionariaRepository.Add(novaConcessionaria);
                await _unitOfWork.CommitAsync(cancellationToken);
                return ResultadoOperacao.OK("Concessionária cadastrada com sucesso.");
            }
            catch(Exception ex)
            {
                return ResultadoOperacao.Falha(ex.Message);
            }
        }
    }
}

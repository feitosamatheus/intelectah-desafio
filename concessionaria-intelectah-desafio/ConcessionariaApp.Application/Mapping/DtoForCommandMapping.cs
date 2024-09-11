using AutoMapper;
using ConcessionariaApp.Application.Dtos.Autenticacao;
using ConcessionariaApp.Application.Dtos.Concessionarias;
using ConcessionariaApp.Application.Dtos.Fabricantes;
using ConcessionariaApp.Application.Dtos.Veiculos;
using ConcessionariaApp.Application.Dtos.Vendas;
using ConcessionariaApp.Application.UseCases.Concessionarias.Commands.CadastrarConcessionarias;
using ConcessionariaApp.Application.UseCases.Fabricantes.Commands.CadastrarFabricante;
using ConcessionariaApp.Application.UseCases.Login.Command.AutenticarUsuario;
using ConcessionariaApp.Application.UseCases.Login.Command.RegistrarUsuario;
using ConcessionariaApp.Application.UseCases.Veiculos.Commands;
using ConcessionariaApp.Application.UseCases.Vendas.Commands.RegistrarVenda;
using ConcessionariaApp.Application.UseCases.Vendas.Queries.BuscarVeiculoPorFiltroVenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Mapping
{
    public class DtoForCommandMapping : Profile
    {
        public DtoForCommandMapping()
        {
            CreateMap<AutenticarUsuarioDTO, AutenticarUsuarioCommand>();
            CreateMap<RegistrarUsuarioDTO, RegistrarUsuarioCommand>()
                .ForCtorParam("Nome", opt => opt.MapFrom(src => src.Nome))
            .ForCtorParam("Sobrenome", opt => opt.MapFrom(src => src.Sobrenome))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("Senha", opt => opt.MapFrom(src => src.Senha));

            CreateMap<CadastrarFabricanteDTO, CadastrarFabricanteCommand>();
            CreateMap<CadastrarVeiculoDTO, CadastrarVeiculoCommand>();
            CreateMap<CadastrarConcessionariaDTO, CadastrarConcessionariaCommand>();
            CreateMap<RegistrarVendaDTO, RegistrarVendaCommand>();
            CreateMap<FiltroVendaDTO, BuscarVeiculoPorFiltroVendaQuery>();

        }
    }
}

using AutoMapper;
using ConcessionariaApp.Application.Dtos.Autenticacao;
using ConcessionariaApp.Application.UseCases.Login.Command.AutenticarUsuario;
using ConcessionariaApp.Application.UseCases.Login.Command.RegistrarUsuario;
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
            .ForCtorParam("Senha", opt => opt.MapFrom(src => src.Senha)); ;

        }
    }
}

using AutoMapper;
using ConcessionariaApp.Application.Dtos.Autenticacao;
using ConcessionariaApp.Application.Dtos.Fabricantes;
using ConcessionariaApp.Application.Dtos.Vendas;
using ConcessionariaApp.Application.UseCases.Login.Command.AutenticarUsuario;
using ConcessionariaApp.Application.UseCases.Login.Command.RegistrarUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Mapping
{
    public class CommandForDtoMapping : Profile
    {
        public CommandForDtoMapping()
        {
            CreateMap<AutenticarUsuarioCommand, AutenticarUsuarioDTO>();
            CreateMap<RegistrarUsuarioCommand, RegistrarUsuarioDTO>();
        }
    }
}

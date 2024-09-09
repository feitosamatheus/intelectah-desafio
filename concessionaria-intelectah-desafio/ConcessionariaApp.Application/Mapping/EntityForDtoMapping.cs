using AutoMapper;
using ConcessionariaApp.Application.Dtos.Login;
using ConcessionariaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Mapping
{
    public class EntityForDtoMapping : Profile
    {
        public EntityForDtoMapping()
        {
            CreateMap<Usuario, AutenticacaoUsuarioResultadoDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.EnderecoEmail));
        }
    }
}

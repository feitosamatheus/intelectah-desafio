using AutoMapper;
using ConcessionariaApp.Application.Dtos.Autenticacao;
using ConcessionariaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Mapping
{
    public class DtoForEntityMapping : Profile
    {
        public DtoForEntityMapping() 
        {
            //CreateMap<ResgistrarUsuarioDTO, Usuario>();
        }
    }
}

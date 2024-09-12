using AutoMapper;
using ConcessionariaApp.Application.Dtos.Concessionarias;
using ConcessionariaApp.Application.Dtos.Fabricantes;
using ConcessionariaApp.Application.Dtos.Login;
using ConcessionariaApp.Application.Dtos.Veiculos;
using ConcessionariaApp.Application.Dtos.Vendas;
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
            CreateMap<Fabricante, FabricanteDTO>();
            CreateMap<Concessionaria, ConcessionariaFiltroDTO>();
            CreateMap<Veiculo, VeiculoVendaDTO>().ForMember(dest => dest.FabricanteNome, opt => opt.MapFrom(src => src.Fabricante.Nome));
            CreateMap<Veiculo, VeiculoFiltroDTO>().ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Modelo)); 
        }
    }
}

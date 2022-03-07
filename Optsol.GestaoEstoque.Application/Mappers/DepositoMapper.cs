using AutoMapper;
using Optsol.GestaoEstoque.Application.ViewModels;
using Optsol.GestaoEstoque.Dominio.Entidades;

namespace Optsol.GestaoEstoque.Application.Mappers
{
    public class DepositoMapper : Profile
    {
        public DepositoMapper()
        {
            CreateMap<Deposito, DepositoViewModel>()
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.Nome))
                .ForMember(dst => dst.Localizacao, src => src.MapFrom(x => x.Localizacao));
        }
    }
}
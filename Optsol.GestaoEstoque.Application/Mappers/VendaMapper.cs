using AutoMapper;
using Optsol.GestaoEstoque.Application.ViewModels;
using Optsol.GestaoEstoque.Dominio.Entidades;

namespace Optsol.GestaoEstoque.Application.Mappers
{
    public class VendaProdutoMapper : Profile
    {
        public VendaProdutoMapper()
        {
            CreateMap<Venda, VendasViewModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Comprador, src => src.MapFrom(x => x.Comprador));
        }
    }
}
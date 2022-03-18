using AutoMapper;
using Optsol.GestaoEstoque.Application.ViewModels;
using Optsol.GestaoEstoque.Dominio.Entidades;

namespace Optsol.GestaoEstoque.Application.Mappers
{
    public class VendaProdutoMapper : Profile
    {
        public VendaProdutoMapper()
        {
            CreateMap<VendaProduto, VendaProdutoViewModel>()
                .ForMember(dst => dst.VendaId, src => src.MapFrom(x => x.VendaId))
                .ForMember(dst => dst.ProdutoId, src => src.MapFrom(x => x.ProdutoId))
                .ForMember(dst => dst.QuantidadeVendida, src => src.MapFrom(x => x.QuantidadeVendida));
        }
    }
}
using AutoMapper;
using Optsol.GestaoEstoque.Application.ViewModels;
using Optsol.GestaoEstoque.Dominio.Entidades;

namespace Optsol.GestaoEstoque.Application.Mappers
{
    public class ProdutoMapper : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.Nome))
                .ForMember(dst => dst.Preco, src => src.MapFrom(x => x.Preco));
            //.ForMember(dst => dst.Comprador, src => src.MapFrom(x => x.Comprador))
            //.ForMember(dst => dst.CodigoVenda, src => src.MapFrom(x => x.CodigoVenda));
        }
    }
}
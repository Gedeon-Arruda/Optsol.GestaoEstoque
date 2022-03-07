using AutoMapper;
using Optsol.GestaoEstoque.Application.ViewModels;
using Optsol.GestaoEstoque.Dominio.Entidades;

namespace Optsol.GestaoEstoque.Application.Mappers
{
    public class VendaMapper : Profile
    {
        public VendaMapper()
        {
            CreateMap<Venda, VendaViewModel>()
                .ForMember(dst => dst.Data, src => src.MapFrom(x => x.Data))
                .ForMember(dst => dst.Comprador, src => src.MapFrom(x => x.Comprador));
        }
    }
}
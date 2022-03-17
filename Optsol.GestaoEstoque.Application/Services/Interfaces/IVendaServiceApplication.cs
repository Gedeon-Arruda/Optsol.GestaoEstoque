using Optsol.GestaoEstoque.Application.ViewModels;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Application.Services.Interfaces
{
    public interface IVendaServiceApplication
    {
        VendasViewModel RealizarVenda(VendasViewModel vendasVw);

        ICollection<VendasViewModel> GetVendaList();
    }
}
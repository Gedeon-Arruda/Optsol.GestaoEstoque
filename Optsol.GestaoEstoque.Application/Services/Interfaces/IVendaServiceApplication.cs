using Optsol.GestaoEstoque.Application.ViewModels;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Application.Services.Interfaces
{
    public interface IVendaServiceApplication
    {
        VendaProdutoViewModel RealizarVenda(VendaProdutoViewModel vendasVw);

        ICollection<VendaProdutoViewModel> GetVendaList();
    }
}
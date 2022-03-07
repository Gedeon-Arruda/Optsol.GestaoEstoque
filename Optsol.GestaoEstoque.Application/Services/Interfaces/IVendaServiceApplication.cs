using Optsol.GestaoEstoque.Application.ViewModels;
using Optsol.GestaoEstoque.Dominio.Entidades;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Application.Services.Interfaces
{
    public interface IVendaServiceApplication
    {
        int RealizarVenda(VendaViewModel venda);

        ICollection<VendaViewModel> GetVendaList();
    }
}
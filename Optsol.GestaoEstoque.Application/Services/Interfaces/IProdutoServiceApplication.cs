using Optsol.GestaoEstoque.Application.ViewModels;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Application.Services.Interfaces
{
    public interface IProdutoServiceApplication
    {
        int CriarProduto(ProdutoViewModel produto);

        ICollection<ProdutoViewModel> ObterProdutos();

        ProdutoViewModel ObterProdutoId(int id);

        ProdutoViewModel DeletarProdutoId(int id);

        ICollection<ProdutoViewModel> OrdenarProduto();

        ProdutoViewModel EditarProduto(int id, ProdutoViewModel produto);

        DepositoViewModel RemoverProdutoDeposito(int depositoId, int produtoId);
        ProdutoViewModel TransferirProdutoDeposito(int depositoId, int produtoId);
    }
}
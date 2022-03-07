using Optsol.GestaoEstoque.Application.ViewModels;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Application.Services.Interfaces
{
    public interface IDepositoServiceApplication
    {
        int CriarDeposito(DepositoViewModel deposito);

        ICollection<DepositoViewModel> ObterDeposito();

        void DeletarDepositoId(int id);

        DepositoViewModel EditarDeposito(int id, DepositoViewModel deposito);

        void ExcluirProduto(int id, ProdutoViewModel produto);

        ICollection<ProdutoViewModel> ObterProdutosDeposito(int id);

        ProdutoViewModel ObterProduto(int id);
    }
}
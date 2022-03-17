using Optsol.GestaoEstoque.Dominio.Entidades;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Dominio.Repositorios
{
    public interface IProdutoRepository
    {
        void Inserir(Produto produtoDominio);

        //Produto ObterProdutoPorCodigoVenda(string codigoVenda);

        Produto ObterPorId(int id);

        Produto RemoveProdutoId(int id);

        ICollection<Produto> ObterListaProduto();

        ICollection<Produto> OrdenarProdutoId();

        void EditarProdutoId(Produto produto);

        void RemoverProdutoDeposito(Deposito deposito);

        Produto TransferirProduto(int depositoId, int produtoId);
    }
}
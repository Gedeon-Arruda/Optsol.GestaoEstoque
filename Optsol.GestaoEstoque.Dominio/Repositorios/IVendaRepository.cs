using Optsol.GestaoEstoque.Dominio.Entidades;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Dominio.Repositorios
{
    public interface IVendaRepository
    {
        VendaProduto Inserir(VendaProduto venda);

        ICollection<VendaProduto> ObterTodos();
    }
}
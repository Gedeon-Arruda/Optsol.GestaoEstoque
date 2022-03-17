using Optsol.GestaoEstoque.Dominio.Entidades;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Dominio.Repositorios
{
    public interface IVendaRepository
    {
        Venda Inserir(Venda venda);

        ICollection<Venda> ObterTodos();
    }
}
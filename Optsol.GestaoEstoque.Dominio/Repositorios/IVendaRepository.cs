using Optsol.GestaoEstoque.Dominio.Entidades;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Dominio.Repositorios
{
    public interface IVendaRepository
    {
        void Inserir(Venda  venda);

        ICollection<Venda> ObterTodos();
    }
}
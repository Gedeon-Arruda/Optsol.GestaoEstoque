using Optsol.GestaoEstoque.Dominio.Entidades;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Dominio.Repositorios
{
    public interface IDepositoRepository
    {
        void Inserir(Deposito deposito);

        ICollection<Deposito> ObterTodos();

        void Remover(Deposito deposito);

        void Editar(Deposito deposito);

        Deposito ObterDepositoPorNome(string nome);

        ICollection<Deposito> OrdenarDepositoPorNome(string nome);

        Deposito ObterPorId(int id);

        Deposito RemoverProdutoNoDeposito(Deposito produtoDeposito);
        void SaveChanges();
    }
}
using Microsoft.EntityFrameworkCore;
using Optsol.GestaoEstoque.Dominio.Entidades;
using Optsol.GestaoEstoque.Dominio.Repositorios;
using Optsol.GestaoEstoque.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Optsol.GestaoEstoque.Infra.Repositorios
{
    public class DepositoRepository : IDepositoRepository
    {
        private readonly GestaoEstoqueContext context;

        public DepositoRepository(GestaoEstoqueContext context)
        {
            this.context = context;
        }

        void IDepositoRepository.Inserir(Deposito deposito)
        {
            context.Set<Deposito>().Add(deposito);
            context.SaveChanges();
        }

        public ICollection<Deposito> ObterTodos()
        {
            return context.Set<Deposito>().ToList();
        }

        public void Remover(Deposito deposito)
        {
            context.Set<Deposito>().Remove(deposito);
            context.SaveChanges();
        }

        public void Editar(Deposito deposito)
        {
            context.Set<Deposito>().Update(deposito);
            context.SaveChanges();
        }

        public Deposito ObterDepositoPorNome(string nome)
        {
            var deposito = context.Set<Deposito>().FirstOrDefault(x => x.Nome == nome);
            return deposito;
        }

        public ICollection<Deposito> OrdenarDepositoPorNome(string nome)
        {
            var depositoOrdenado = context.Set<Deposito>().OrderBy(x => x.Nome).ToList();
            return depositoOrdenado;
        }

        public Deposito ObterPorId(int id)
        {
            var obterDepositoId = context.Set<Deposito>()
                .Include(x => x.Produtos)
                .SingleOrDefault(x => x.Id == id);
            return obterDepositoId;
        }

        public Deposito RemoverProdutoNoDeposito(Deposito produtoDeposito)
        {
            var obterDeposito = context.Set<Deposito>()
                .Include(x => x.Produtos)
                .SingleOrDefault(x => x.Id == produtoDeposito.Id);
                
            return obterDeposito;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
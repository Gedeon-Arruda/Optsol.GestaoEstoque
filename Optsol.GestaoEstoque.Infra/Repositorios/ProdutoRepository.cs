using Microsoft.EntityFrameworkCore;
using Optsol.GestaoEstoque.Dominio.Entidades;
using Optsol.GestaoEstoque.Dominio.Repositorios;
using Optsol.GestaoEstoque.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Optsol.GestaoEstoque.Infra.Repositorios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly GestaoEstoqueContext context;

        public ProdutoRepository(GestaoEstoqueContext context)
        {
            this.context = context;
        }

        public void Inserir(Produto produto)
        {
            context.Set<Produto>().Add(produto);
            context.SaveChanges();
        }

        public ICollection<Produto> ObterListaProduto()
        {
            return context.Set<Produto>().Include(s => s.Deposito).ToList();
        }

        public Produto ObterPorId(int id)
        {
            var produto = context.Set<Produto>().FirstOrDefault(x => x.Id == id);
            return produto;
        }

        public Produto ObterProdutoPorCodigoVenda(string codigoVenda)
        {
            var produto = context.Set<Produto>().FirstOrDefault(x => x.CodigoVenda == codigoVenda);
            return produto;
        }

        public ICollection<Produto> OrdenarProdutoId()
        {
            var protudoOrdenado = context.Set<Produto>().OrderBy(x => x.Id).ThenBy(x => x.Nome).ToList();
            return protudoOrdenado;
        }

        public Produto RemoveProdutoId(int id)
        {
            var produto = context.Set<Produto>().FirstOrDefault(x => x.Id == id);
            context.Remove(produto);
            context.SaveChanges();

            return produto;
        }

        public void EditarProdutoId(Produto produto)
        {
            context.Set<Produto>().Update(produto);
            context.SaveChanges();
        }

        public void RemoverProdutoDeposito(Deposito deposito)
        {
            var produtoDeposito = context.Set<Produto>().FirstOrDefault(x => x.Id == deposito.Id);
            produtoDeposito.Deposito = null;
            context.SaveChanges();
        }
    }
}
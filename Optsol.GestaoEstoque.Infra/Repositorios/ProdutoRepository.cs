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
        private readonly GestaoEstoqueContext _context;

        public ProdutoRepository(GestaoEstoqueContext context)
        {
            _context = context;
        }

        public void Inserir(Produto produto)
        {
            _context.Set<Produto>().Add(produto);
            _context.SaveChanges();
        }

        public ICollection<Produto> ObterListaProduto()
        {
            return _context.Set<Produto>().Include(s => s.Deposito).ToList();
        }

        public Produto ObterPorId(int id)
        {
            var produto = _context.Set<Produto>().FirstOrDefault(x => x.Id == id);
            return produto;
        }

        public Produto ObterProdutoPorCodigoVenda(string codigoVenda)
        {
            var produto = _context.Set<Produto>().FirstOrDefault(x => x.CodigoVenda == codigoVenda);
            return produto;
        }

        public ICollection<Produto> OrdenarProdutoId()
        {
            var protudoOrdenado = _context.Set<Produto>().OrderBy(x => x.Id).ThenBy(x => x.Nome).ToList();
            return protudoOrdenado;
        }

        public Produto RemoveProdutoId(int id)
        {
            var produto = _context.Set<Produto>().Include(d => d.Deposito).FirstOrDefault(x => x.Id == id);
            _context.Remove(produto);
            _context.SaveChanges();

            return produto;
        }

        public void EditarProdutoId(Produto produto)
        {
            _context.Set<Produto>().Update(produto);
            _context.SaveChanges();
        }

        public void RemoverProdutoDeposito(Deposito deposito)
        {
            var produtoDeposito = _context.Set<Produto>().FirstOrDefault(x => x.Id == deposito.Id);
            produtoDeposito.Deposito = null;
            _context.SaveChanges();
        }
        public Produto TransferirProduto(int depositoId, int produtoId)
        {
            var transferirProduto = _context.Set<Produto>().Include(_ => _.Deposito).FirstOrDefault(x => x.Id == produtoId);
            var deposito = _context.Set<Deposito>().FirstOrDefault(x => x.Id == depositoId);
            transferirProduto.Deposito = deposito;
            _context.SaveChanges();

            return transferirProduto;
        }
    }
}
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
        private readonly GestaoEstoqueContext _context;

        public DepositoRepository(GestaoEstoqueContext context)
        {
            _context = context;
        }

        void IDepositoRepository.Inserir(Deposito deposito)
        {
            _context.Set<Deposito>().Add(deposito);
            _context.SaveChanges();
        }

        public ICollection<Deposito> ObterTodos()
        {
            return _context.Set<Deposito>().ToList();
        }

        public void Remover(Deposito deposito)
        {
            _context.Set<Deposito>().Remove(deposito);
            _context.SaveChanges();
        }

        public void Editar(Deposito deposito)
        {
            _context.Set<Deposito>().Update(deposito);
            _context.SaveChanges();
        }

        public Deposito ObterDepositoPorNome(string nome)
        {
            var deposito = _context.Set<Deposito>().FirstOrDefault(x => x.Nome == nome);
            return deposito;
        }

        public ICollection<Deposito> OrdenarDepositoPorNome(string nome)
        {
            var depositoOrdenado = _context.Set<Deposito>().OrderBy(x => x.Nome).ToList();
            return depositoOrdenado;
        }

        public Deposito ObterPorId(int id)
        {
            var obterDepositoId = _context.Set<Deposito>()
                .Include(x => x.Produtos)
                .SingleOrDefault(x => x.Id == id);
            return obterDepositoId;
        }

        public Deposito RemoverProdutoNoDeposito(Produto produtoDeposito)
        {
            var obterDeposito = _context.Set<Deposito>()
                .Include(x => x.Produtos)
                .SingleOrDefault(x => x.Id == produtoDeposito.Id);

            return obterDeposito;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
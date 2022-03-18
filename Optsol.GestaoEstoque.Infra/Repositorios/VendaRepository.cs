using Microsoft.EntityFrameworkCore;
using Optsol.GestaoEstoque.Dominio.Entidades;
using Optsol.GestaoEstoque.Dominio.Repositorios;
using Optsol.GestaoEstoque.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Optsol.GestaoEstoque.Infra.Repositorios
{
    public class VendaRepository : IVendaRepository
    {
        private readonly GestaoEstoqueContext _context;

        public VendaRepository(GestaoEstoqueContext context)
        {
            _context = context;
        }

        public VendaProduto Inserir(VendaProduto venda)
        {
            _context.Set<VendaProduto>().Add(venda);
            _context.SaveChanges();

            return venda;
        }

        public ICollection<VendaProduto> ObterTodos()
        {
            return _context.Set<VendaProduto>().Include(s => s.Produto).Include(v => v.Venda).ToList();
        }
    }
}
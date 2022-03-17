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

        public Venda Inserir(Venda venda)
        {
            _context.Set<Venda>().Add(venda);
            _context.SaveChanges();

            return venda;
        }

        public ICollection<Venda> ObterTodos()
        {
            return _context.Set<Venda>().Include(s => s.Produtos).ToList();
        }
    }
}
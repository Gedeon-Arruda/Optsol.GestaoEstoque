using Optsol.GestaoEstoque.Dominio.Entidades;
using Optsol.GestaoEstoque.Dominio.Repositorios;
using Optsol.GestaoEstoque.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Optsol.GestaoEstoque.Infra.Repositorios
{
    public class VendaRepository : IVendaRepository
    {
        private readonly GestaoEstoqueContext context;

        public VendaRepository(GestaoEstoqueContext context)
        {
            this.context = context;
        }

        public void Inserir(Venda venda)
        {
            context.Set<Venda>().Add(venda);
            context.SaveChanges();
        }

        public ICollection<Venda> ObterTodos()
        {
            return context.Set<Venda>().ToList();
        }
    }
}
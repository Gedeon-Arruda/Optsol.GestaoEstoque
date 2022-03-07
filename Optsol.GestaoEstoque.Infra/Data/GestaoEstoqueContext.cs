using Microsoft.EntityFrameworkCore;
using Optsol.GestaoEstoque.Infra.Configuracoes;

namespace Optsol.GestaoEstoque.Infra.Data
{
    public class GestaoEstoqueContext : DbContext
    {
        public GestaoEstoqueContext(DbContextOptions<GestaoEstoqueContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GestaoEstoqueContext).Assembly);

            //modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            //modelBuilder.ApplyConfiguration(new DepositoConfiguration());
            //modelBuilder.ApplyConfiguration(new VendaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
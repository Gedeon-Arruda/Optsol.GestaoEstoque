using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
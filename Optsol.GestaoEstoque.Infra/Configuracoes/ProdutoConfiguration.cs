using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optsol.GestaoEstoque.Dominio.Entidades;

namespace Optsol.GestaoEstoque.Infra.Configuracoes
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(X => X.Preco).HasColumnName("PRECO");
            builder.Property(x => x.DepositoId).HasColumnName("DEPOSITOID");
        }
    }
}
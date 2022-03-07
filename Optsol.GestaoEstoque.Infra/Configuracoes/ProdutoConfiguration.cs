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

            builder.HasKey(t => t.Id).HasName("PK_PRODUTO_ID");
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(X => X.Preco).HasColumnName("PRECO");
            builder.Property(x => x.Comprador).HasColumnName("COMPRADOR");
            builder.Property(x => x.CodigoVenda).HasColumnName("CODIGOVENDA").HasMaxLength(10).HasDefaultValue("11111");
            builder.Property(x => x.DepositoId).HasColumnName("DEPOSITOID");
            builder.Property(x => x.VendaId).HasColumnName("VENDAID");
        }
    }
}
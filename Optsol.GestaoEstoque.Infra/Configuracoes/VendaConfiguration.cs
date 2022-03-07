using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optsol.GestaoEstoque.Dominio.Entidades;

namespace Optsol.GestaoEstoque.Infra.Configuracoes
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("VENDA");

            builder.HasKey(t => t.Id).HasName("PK_VENDA_ID");
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(x => x.Data).HasColumnName("DataVenda").HasMaxLength(100).IsRequired();
            builder.Property(X => X.Comprador).HasColumnName("Comprador").HasMaxLength(500).IsRequired();
            builder.HasMany(x => x.Produtos).WithOne(x => x.Venda).HasForeignKey(x => x.VendaId);
        }
    }
}
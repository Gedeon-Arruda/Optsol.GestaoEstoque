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

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(X => X.Comprador).HasColumnName("COMPRADOR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Data).HasColumnName("DATA").IsRequired();
        }
    }
}
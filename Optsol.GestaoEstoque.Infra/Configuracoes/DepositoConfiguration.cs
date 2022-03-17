using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optsol.GestaoEstoque.Dominio.Entidades;

namespace Optsol.GestaoEstoque.Infra.Configuracoes
{
    public class DepositoConfiguration : IEntityTypeConfiguration<Deposito>
    {
        public void Configure(EntityTypeBuilder<Deposito> builder)
        {
            builder.ToTable("DEPOSITO");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(X => X.Localizacao).HasColumnName("LOCALIZACAO").HasMaxLength(500).IsRequired();
            builder.HasMany(x => x.Produtos).WithOne(x => x.Deposito).HasForeignKey(x => x.DepositoId);
        }
    }
}
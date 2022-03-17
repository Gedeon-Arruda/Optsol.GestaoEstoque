using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optsol.GestaoEstoque.Dominio.Entidades;

namespace Optsol.GestaoEstoque.Infra.Configuracoes
{
    public class VendaProdutoConfiguration : IEntityTypeConfiguration<VendaProduto>
    {
        public void Configure(EntityTypeBuilder<VendaProduto> builder)
        {
            builder.ToTable("VENDAPRODUTO");

            builder.HasKey(vp => vp.Id);
            builder.Property(vp => vp.Id).HasColumnName("ID");
            builder.Property(vp => vp.ProdutoId).HasColumnName("PRODUTOID").IsRequired();
            builder.Property(vp => vp.VendaId).HasColumnName("VENDAID").IsRequired();
            builder.Property(vp => vp.QuantidadeVendida).HasColumnName("QUANTIDADEVENDIDA").IsRequired();
            builder.HasOne(vp => vp.Venda).WithMany(v => v.Produtos).HasForeignKey(vp => vp.VendaId);
            builder.HasOne(vp => vp.Produto).WithMany(p => p.Vendas).HasForeignKey(vp => vp.ProdutoId);
        }
    }
}
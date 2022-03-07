﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Optsol.GestaoEstoque.Infra.Data;

namespace Optsol.GestaoEstoque.Infra.Migrations
{
    [DbContext(typeof(GestaoEstoqueContext))]
    [Migration("20220303195857_ImplementacaoEntidadeVenda")]
    partial class ImplementacaoEntidadeVenda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Optsol.GestaoEstoque.Dominio.Entidades.Deposito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Localizacao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.HasKey("Id")
                        .HasName("PK_DEPOSITO_ID");

                    b.ToTable("DEPOSITO");
                });

            modelBuilder.Entity("Optsol.GestaoEstoque.Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoVenda")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasDefaultValue("11111")
                        .HasColumnName("CODIGOVENDA");

                    b.Property<string>("Comprador")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("COMPRADOR");

                    b.Property<int>("DepositoId")
                        .HasColumnType("int")
                        .HasColumnName("DEPOSITOID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.Property<int>("Preco")
                        .HasColumnType("int")
                        .HasColumnName("PRECO");

                    b.HasKey("Id")
                        .HasName("PK_PRODUTO_ID");

                    b.HasIndex("DepositoId");

                    b.ToTable("PRODUTO");
                });

            modelBuilder.Entity("Optsol.GestaoEstoque.Dominio.Entidades.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comprador")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Comprador");

                    b.Property<DateTime>("Data")
                        .HasMaxLength(100)
                        .HasColumnType("datetime2")
                        .HasColumnName("DataVenda");

                    b.HasKey("Id")
                        .HasName("PK_VENDA_ID");

                    b.ToTable("VENDA");
                });

            modelBuilder.Entity("Optsol.GestaoEstoque.Dominio.Entidades.Produto", b =>
                {
                    b.HasOne("Optsol.GestaoEstoque.Dominio.Entidades.Deposito", "Deposito")
                        .WithMany("Produtos")
                        .HasForeignKey("DepositoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deposito");
                });

            modelBuilder.Entity("Optsol.GestaoEstoque.Dominio.Entidades.Deposito", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
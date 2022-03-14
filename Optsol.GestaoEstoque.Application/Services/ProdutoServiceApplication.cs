using AutoMapper;
using Optsol.GestaoEstoque.Application.Services.Interfaces;
using Optsol.GestaoEstoque.Application.ViewModels;
using Optsol.GestaoEstoque.Dominio.Entidades;
using Optsol.GestaoEstoque.Dominio.Repositorios;
using System;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Application.Services
{
    public class ProdutoServiceApplication : IProdutoServiceApplication
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IDepositoRepository depositoRepository;
        private readonly IMapper mapper;

        public ProdutoServiceApplication(IProdutoRepository produtoRepository, IMapper mapper, IDepositoRepository depositoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.mapper = mapper;
            this.depositoRepository = depositoRepository;
        }

        public int CriarProduto(ProdutoViewModel produtoVm)
        {
            // transformar produtoviewmodel em produto
            var produtoExistente = produtoRepository.ObterProdutoPorCodigoVenda(produtoVm.CodigoVenda);

            if (produtoExistente != null)
            {
                throw new Exception("Codigo de venda do produto existente");
            }

            if (produtoVm.Deposito == null)
            {
                var produtoSemDeposito = new Produto(produtoVm.Nome, produtoVm.Preco, produtoVm.Comprador, produtoVm.CodigoVenda);
                produtoRepository.Inserir(produtoSemDeposito);
                return produtoSemDeposito.Id;
            }

            var deposito = depositoRepository.ObterPorId(produtoVm.Deposito.Id);

            var produtoComDeposito = new Produto(produtoVm.Nome, produtoVm.Preco, produtoVm.Comprador, produtoVm.CodigoVenda, deposito);
            produtoRepository.Inserir(produtoComDeposito);

            var produtoVw = mapper.Map<ProdutoViewModel>(produtoComDeposito);

            return produtoVw.Id;
        }

        public ProdutoViewModel ObterProdutoId(int id)
        {
            var produto = produtoRepository.ObterPorId(id);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            var produtoVm = mapper.Map<ProdutoViewModel>(produto);
            return produtoVm;
        }

        public ProdutoViewModel DeletarProdutoId(int id)
        {
            var DeletarProduto = produtoRepository.RemoveProdutoId(id);

            if (DeletarProduto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            var produtoVm = mapper.Map<ProdutoViewModel>(DeletarProduto);

            return produtoVm;
        }

        public ICollection<ProdutoViewModel> ObterProdutos()
        {
            var obterProdutos = produtoRepository.ObterListaProduto();

            if (obterProdutos == null)
            {
                throw new Exception("Não existem produtos cadastrados");
            }

            var produtos = mapper.Map<ICollection<ProdutoViewModel>>(obterProdutos);

            return produtos;
        }

        public ICollection<ProdutoViewModel> OrdenarProduto()
        {
            var ordenarProduto = produtoRepository.OrdenarProdutoId();

            if (ordenarProduto == null)
            {
                throw new Exception("Não existem produtos cadastrados");
            }

            var produtos = mapper.Map<ICollection<ProdutoViewModel>>(ordenarProduto);

            return produtos;
        }

        public ProdutoViewModel EditarProduto(int id, ProdutoViewModel produtoEditado)
        {
            var produto = produtoRepository.ObterPorId(id);

            if (produto == null)
            {
                throw new Exception("Não foi possível localizar seu produto");
            }

            produto.Nome = produtoEditado.Nome;
            produto.Preco = produtoEditado.Preco;
            produto.Comprador = produtoEditado.Comprador;

            produtoRepository.EditarProdutoId(produto);

            var produtos = mapper.Map<ProdutoViewModel>(produto);

            return produtos;
        }

        public DepositoViewModel RemoverProdutoDeposito(int depositoId, int produtoId)
        {
            var deposito = depositoRepository.ObterPorId(depositoId);

            var excluirProduto = produtoRepository.RemoveProdutoId(deposito.Id);

            depositoRepository.SaveChanges();

            var depositoVm = mapper.Map<DepositoViewModel>(excluirProduto);

            return depositoVm;
        }

        public ProdutoViewModel TransferirProdutoDeposito(int depositoId, int produtoId)
        {
            var produto = produtoRepository.ObterPorId(produtoId);

            var deposito = depositoRepository.ObterPorId(depositoId);

            produto.AlterarDeposito(deposito);

            depositoRepository.SaveChanges();

            var produtoVw = mapper.Map<ProdutoViewModel>(produto);

            return produtoVw;
        }
    }
}
using AutoMapper;
using Optsol.GestaoEstoque.Application.Services.Interfaces;
using Optsol.GestaoEstoque.Application.ViewModels;
using Optsol.GestaoEstoque.Dominio.Entidades;
using Optsol.GestaoEstoque.Dominio.Repositorios;
using System;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Application.Services
{
    public class DepositoServiceApplication : IDepositoServiceApplication
    {
        private readonly IDepositoRepository depositoRepository;
        private readonly IMapper mapper;

        public DepositoServiceApplication(IDepositoRepository depositoRepository, IMapper mapper)
        {
            this.depositoRepository = depositoRepository;
            this.mapper = mapper;
        }

        public int CriarDeposito(DepositoViewModel depositoVm)
        {
            // transformar DepositoViewModel em deposito
            var depositoExistente = depositoRepository.ObterDepositoPorNome(depositoVm.Nome);

            if (depositoExistente != null)
            {
                throw new Exception("Já existe um deposito com esse nome!");
            }

            var deposito = new Deposito(depositoVm.Nome, depositoVm.Localizacao);

            depositoRepository.Inserir(deposito);

            var depositoVw = mapper.Map<DepositoViewModel>(deposito);

            return depositoVw.Id;
        }

        public void DeletarDepositoId(int id)
        {
            var deposito = depositoRepository.ObterPorId(id);

            if (deposito == null)
            {
                throw new Exception("Deposito não encontrado");
            }

            depositoRepository.Remover(deposito);
        }

        public ICollection<ProdutoViewModel> ObterProdutosDeposito(int id)
        {
            var deposito = depositoRepository.ObterPorId(id);

            if (deposito == null)
            {
                throw new Exception("Produtos não encontrado");
            }

            var produtos = mapper.Map<ICollection<ProdutoViewModel>>(deposito.Produtos);

            return produtos;
        }

        public ICollection<DepositoViewModel> ObterDeposito()
        {
            var obterDepositos = depositoRepository.ObterTodos();

            if (obterDepositos == null)
            {
                throw new Exception("Não existem depositos cadastrados");
            }

            var depositos = mapper.Map<ICollection<DepositoViewModel>>(obterDepositos);

            return depositos;
        }

        public ICollection<DepositoViewModel> OrdenarDeposito(Deposito deposito)
        {
            var ordenarDepositos = depositoRepository.OrdenarDepositoPorNome(deposito.Nome);

            if (ordenarDepositos == null)
            {
                throw new Exception("Não existem depositos cadastrados");
            }

            var depositos = mapper.Map<ICollection<DepositoViewModel>>(ordenarDepositos);

            return depositos;
        }

        public DepositoViewModel EditarDeposito(int id, DepositoViewModel depositoEditado)
        {
            var deposito = depositoRepository.ObterPorId(id);

            if (deposito == null)
            {
                throw new Exception("Não foi possível localizar seu deposito");
            }

            deposito.Nome = depositoEditado.Nome;
            deposito.Localizacao = depositoEditado.Localizacao;

            depositoRepository.Editar(deposito);

            var depositos = mapper.Map<DepositoViewModel>(deposito);

            return depositos;
        }

        public void ExcluirProduto(int id, ProdutoViewModel produtoVw)
        {
            var produto = depositoRepository.ObterPorId(produtoVw.Id);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            depositoRepository.Remover(produto);
        }

        public ProdutoViewModel ObterProduto(int id)
        {
            var produto = depositoRepository.ObterPorId(id);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            var produtoNoDeposito = mapper.Map<ProdutoViewModel>(produto);

            return produtoNoDeposito;
        }
    }
}
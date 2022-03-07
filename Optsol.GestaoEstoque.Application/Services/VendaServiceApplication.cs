using AutoMapper;
using Optsol.GestaoEstoque.Application.Services.Interfaces;
using Optsol.GestaoEstoque.Application.ViewModels;
using Optsol.GestaoEstoque.Dominio.Entidades;
using Optsol.GestaoEstoque.Dominio.Repositorios;
using System;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Application.Services
{
    public class VendaServiceApplication : IVendaServiceApplication
    {
        private readonly IVendaRepository vendaRepository;
        private readonly IMapper mapper;

        public VendaServiceApplication(IVendaRepository vendaRepository, IMapper mapper)
        {
            this.vendaRepository = vendaRepository;
            this.mapper = mapper;
        }

        public ICollection<VendaViewModel> GetVendaList()
        {
            var obterVendas = vendaRepository.ObterTodos();

            if (obterVendas == null)
            {
                throw new Exception("Não existem vendas cadastrados");
            }

            var vendas = mapper.Map<ICollection<VendaViewModel>>(obterVendas);

            return vendas;
        }

        public int RealizarVenda(VendaViewModel vendaVw)
        {
            var venda = new Venda(vendaVw.Data, vendaVw.Comprador);

            vendaRepository.Inserir(venda);

            return venda.Id;
        }
    }
}
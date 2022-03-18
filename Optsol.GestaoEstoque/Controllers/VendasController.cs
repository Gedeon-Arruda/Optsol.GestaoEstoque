using Microsoft.AspNetCore.Mvc;
using Optsol.GestaoEstoque.Application.Services.Interfaces;
using Optsol.GestaoEstoque.Application.ViewModels;
using System;

namespace Optsol.GestaoEstoque.Controllers
{
    [ApiController]
    [Route("api/vendas-produtos")]
    public class VendasController : ControllerBase
    {
        public IVendaServiceApplication aplicacao;

        public VendasController(IVendaServiceApplication aplicacaoParametro)
        {
            aplicacao = aplicacaoParametro;
        }

        [HttpGet]
        public IActionResult ObterVendas()
        {
            var vendas = aplicacao.GetVendaList();

            return Ok(vendas);
        }

        [HttpPost]
        public IActionResult CriarVenda(VendaProdutoViewModel vendaVw)
        {
            try
            {
                var venda = aplicacao.RealizarVenda(vendaVw);

                return Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
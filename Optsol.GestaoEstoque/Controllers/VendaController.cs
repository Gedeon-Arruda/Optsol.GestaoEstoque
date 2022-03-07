using Microsoft.AspNetCore.Mvc;
using Optsol.GestaoEstoque.Application.Services.Interfaces;
using Optsol.GestaoEstoque.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        public IVendaServiceApplication aplicacao;

        public VendaController(IVendaServiceApplication aplicacaoParametro)
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
        public IActionResult SalvaVenda(VendaViewModel vendaVw)
        {
            try
            {
                var id = aplicacao.RealizarVenda(vendaVw);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
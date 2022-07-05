using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Optsol.GestaoEstoque.Application.Services.Interfaces;
using Optsol.GestaoEstoque.Application.ViewModels;
using System;

namespace Optsol.GestaoEstoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositoController : ControllerBase
    {
        private readonly IDepositoServiceApplication _depositoServiceApplication;

        public DepositoController(IDepositoServiceApplication depositoServiceApplication, IMapper mapper)
        {
            _depositoServiceApplication = depositoServiceApplication;
        }

        [HttpGet]
        public IActionResult Obter()
        {
            var depositos = _depositoServiceApplication.ObterDeposito();
            return Ok(depositos);
        }

        [HttpPost]
        public IActionResult SalvaDeposito(DepositoViewModel deposito)
        {
            try
            {
                var id = _depositoServiceApplication.CriarDeposito(deposito);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarDeposito(int id)
        {
            try
            {
                _depositoServiceApplication.DeletarDepositoId(id);

                return Ok(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditarDepositoID(int id, DepositoViewModel deposito)
        {
            try
            {
                var listaProduto = _depositoServiceApplication.EditarDeposito(id, deposito);
                return Ok(listaProduto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/produtos")]
        public IActionResult ObterProdutosDeposito(int id)
        {
            try
            {
                var produto = _depositoServiceApplication.ObterProdutosDeposito(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
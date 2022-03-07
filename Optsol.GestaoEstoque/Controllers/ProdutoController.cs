using Microsoft.AspNetCore.Mvc;
using Optsol.GestaoEstoque.Application.Services.Interfaces;
using Optsol.GestaoEstoque.Application.ViewModels;
using System;

namespace Optsol.GestaoEstoque.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        public IProdutoServiceApplication aplicacao;

        public ProdutoController(IProdutoServiceApplication aplicacaoParametro)
        {
            aplicacao = aplicacaoParametro;
        }

        [HttpGet]
        public IActionResult ObterProdutos()
        {
            var produtos = aplicacao.ObterProdutos();
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult SalvaProduto(ProdutoViewModel produto)
        {
            try
            {
                var id = aplicacao.CriarProduto(produto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterProdutoID(int id)
        {
            try
            {
                var obterID = aplicacao.ObterProdutoId(id);
                return Ok(obterID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(int id)
        {
            try
            {
                var deletarProduto = aplicacao.DeletarProdutoId(id);

                return Ok(deletarProduto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("ProdutosOrdenadosId")]
        public IActionResult OrdenarProdutoId()
        {
            var ordenarProduto = aplicacao.OrdenarProduto();

            return Ok(ordenarProduto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarProdutoID(int id, ProdutoViewModel produto)
        {
            try
            {
                var listaProduto = aplicacao.EditarProduto(id, produto);
                return Ok(listaProduto);
            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }

        [HttpDelete("{depositoId}/Produto/{produtoId}")]
        public IActionResult ExcluirProdutoDeposito(int depositoId, int produtoId)
        {
            try
            {
                var deletarProduto = aplicacao.RemoverProdutoDeposito(depositoId, produtoId);

                return Ok(deletarProduto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
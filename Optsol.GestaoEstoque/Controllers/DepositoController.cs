using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Optsol.GestaoEstoque.Application.Services.Interfaces;
using Optsol.GestaoEstoque.Application.ViewModels;
using System;

namespace Optsol.GestaoEstoque.Controllers
{
    [ApiController]
    [Route("api/depositos")]
    public class DepositoController : ControllerBase
    {
        private readonly IDepositoServiceApplication _depositoServiceApplication;

        public DepositoController(IDepositoServiceApplication depositoServiceApplication, IMapper mapper)
        {
            _depositoServiceApplication = depositoServiceApplication;
        }

        #region DocumentacaoAPI

        /// <summary> Buscar lista de depositos.</summary>

        #endregion DocumentacaoAPI

        [HttpGet]
        public IActionResult Obter()
        {
            var depositos = _depositoServiceApplication.ObterDeposito();
            return Ok(depositos);
        }

        #region DocumentacaoAPI

        /// <summary>
        /// Cadastrar um deposito.
        /// </summary>
        /// <remarks>
        ///
        /// {
        ///"nome": "Laticínios",
        ///"localizacao": "Doca 01"
        ///}
        ///</remarks>
        ///
        ///
        /// <param name="deposito">Dados do deposito: </param>
        /// <returns>Retorna o Id do Deposito Criado.</returns>
        /// <response code="200"> Sucesso </response>
        /// <response code="400"> Não foi possivel criar seu deposito </response>
        ///

        #endregion DocumentacaoAPI

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

        #region DocumentacaoAPI

        /// <summary> Deletar um deposito por id.</summary>

        #endregion DocumentacaoAPI

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

        #region DocumentacaoAPI

        /// <summary>Alterar um deposito por id.</summary>

        #endregion DocumentacaoAPI

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

        #region DocumentacaoAPI

        /// <summary>Busca um deposito por ID e lista os produtos nele.</summary>

        #endregion DocumentacaoAPI

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
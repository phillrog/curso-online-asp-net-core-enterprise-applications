using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSE.Carrinho.API.Models;
using NSE.WebAPI.Core.Controllers;
using NSE.WebAPI.Core.Usuario;
using System;
using System.Threading.Tasks;

namespace NSE.Carrinho.API.Controllers
{

	[Route("api/carrinho")]
	[Authorize]
	public class CarrinhoController : MainController
	{
		private readonly IAspNetUser _user;

		public CarrinhoController(IAspNetUser user)
		{
			_user = user;
		}

		[HttpGet("healthcheck")]
		public IActionResult Get()
		{
			return Ok(new { status = "Estou vivo" });
		}

		[HttpGet()]
		public async Task<CarrinhoCliente> ObterCarrinho()
		{
			_user.ObterUserId();
			return null;
		}

		[HttpPost]
		public async Task<IActionResult> AdicionarItemCarrinho(CarrinhoItem item)
		{
			return CustomResponse();
		}

		[HttpPut("{produtoId}")]
		public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, CarrinhoItem item)
		{
			return CustomResponse();
		}

		[HttpDelete("{produtoId}")]
		public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
		{
			{
				return CustomResponse();
			}
		}
	}
}

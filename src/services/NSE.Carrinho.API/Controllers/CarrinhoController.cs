﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSE.Carrinho.API.Data;
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
		private readonly CarrinhoContext _context;

		public CarrinhoController(IAspNetUser user,
			CarrinhoContext carrinhoContext)
		{
			_user = user;
			_context = carrinhoContext;
		}

		[HttpGet("healthcheck")]
		public IActionResult Get()
		{
			return Ok(new { status = "Estou vivo" });
		}

		[HttpGet()]
		public async Task<CarrinhoCliente> ObterCarrinho()
		{
			return await ObterCarrinhoCliente() ?? new CarrinhoCliente();
		}

		[HttpPost]
		public async Task<IActionResult> AdicionarItemCarrinho(CarrinhoItem item)
		{
			var carrinho = await ObterCarrinhoCliente();
			if (carrinho == null)
				ManipularNovoCarrinho(item);
			else
				ManipularCarrinhoExistente(carrinho, item);

			if (!OperacaoValida()) return CustomResponse();

			var result = await _context.SaveChangesAsync();

			if (result <= 0) AdicionarErroProcessamento("Não foi possível persistir os dados no banco");

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

		private async Task<CarrinhoCliente> ObterCarrinhoCliente()
		{
			return await _context.CarrinhoClientes
				.Include(c => c.Itens)
				.FirstOrDefaultAsync(c => c.ClienteId == _user.ObterUserId());
		}		

		private void ManipularNovoCarrinho(CarrinhoItem item)
		{
			var carrinho = new CarrinhoCliente(_user.ObterUserId());

			carrinho.AdicionarItem(item);

			_context.CarrinhoClientes.Add(carrinho);
		}

		private void ManipularCarrinhoExistente(CarrinhoCliente carrinho, CarrinhoItem item)
		{
			var produtoItemExistente = carrinho.CarrinhoItemExistente(item);

			carrinho.AdicionarItem(item);

			if (produtoItemExistente)
			{
				_context.CarrinhoItens.Update(carrinho.ObterPorProdutoId(item.ProdutoId));
			}
			else {
				_context.CarrinhoItens.Add(item);
			}

			_context.CarrinhoClientes.Update(carrinho);
		}
	}
}

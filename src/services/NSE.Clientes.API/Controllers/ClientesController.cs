using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSE.Clientes.API.Application.Commands;
using NSE.Clientes.API.Models;
using NSE.Core.Mediator;
using NSE.WebAPI.Core.Controllers;
using NSE.WebAPI.Core.Usuario;

namespace NSE.Clientes.API.Controllers
{
	[Route("api/[controller]")]
	public class ClientesController : MainController
	{
		private readonly IClienteRepository _clienteRepository;
		private readonly IMediatorHandler _mediator;
		private readonly IAspNetUser _user;

		public ClientesController(IClienteRepository clienteRepository, IMediatorHandler mediator, IAspNetUser user)
		{
			_clienteRepository = clienteRepository;
			_mediator = mediator;
			_user = user;
		}


		[HttpGet("clientes")]
		public async Task<IActionResult> Index()
		{
			var resultado = await _mediator.EnviarComando(new RegistrarClienteCommand ( 
				Guid.NewGuid(),
				"Guilherme Noah Peixoto",
				"tesate@teste.com",
				"082.573.287-58"
				
			));

			return CustomResponse(resultado);
		}

		[HttpGet("endereco")]
		public async Task<IActionResult> ObterEndereco()
		{
			var endereco = await _clienteRepository.ObterEnderecoPorId(_user.ObterUserId());

			return endereco == null ? NotFound() : CustomResponse(endereco);
		}

		[HttpPost("endereco")]
		public async Task<IActionResult> AdicionarEndereco(AdicionarEnderecoCommand endereco)
		{
			endereco.ClienteId = _user.ObterUserId();
			return CustomResponse(await _mediator.EnviarComando(endereco));
		}
	}
}

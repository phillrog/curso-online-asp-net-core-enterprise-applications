using Microsoft.AspNetCore.Mvc;
using NSE.Clientes.API.Application.Commands;
using NSE.Core.Mediator;
using NSE.WebAPI.Core.Controllers;
using System;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Controllers
{
	[Route("api/[controller]")]
	public class ClientesController : MainController
	{
		private readonly IMediatorHandler _mediatorHandler;

		public ClientesController(IMediatorHandler mediatorHandler)
		{
			_mediatorHandler = mediatorHandler;
		}

		[HttpGet("clientes")]
		public async Task<IActionResult> Index()
		{
			var resultado = await _mediatorHandler.EnviarComando(new RegistrarClienteCommand ( 
				Guid.NewGuid(),
				"Guilherme Noah Peixoto",
				"tesate@teste.com",
				"082.573.287-58"
				
			));

			return CustomResponse(resultado);
		}
	}
}

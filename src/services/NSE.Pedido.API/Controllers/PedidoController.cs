using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Core.Mediator;
using NSE.Pedidos.API.Application.Commands;
using NSE.Pedidos.API.Application.Queries;
using NSE.WebAPI.Core.Controllers;
using NSE.WebAPI.Core.Usuario;


namespace NSE.Pedido.API.Controllers
{
	[Route("api/pedido")]
	[Authorize]
	public class PedidoController : MainController
	{
		private readonly IMediatorHandler _mediator;
		private readonly IAspNetUser _user;
		private readonly IPedidoQueries _pedidoQueries;

		[HttpGet("healthcheck")]
		[AllowAnonymous]
		public IActionResult Get()
		{
			return Ok(new { status = "Estou vivo" });
		}

		public PedidoController(IMediatorHandler mediator,
			IAspNetUser user,
			IPedidoQueries pedidoQueries)
		{
			_mediator = mediator;
			_user = user;
			_pedidoQueries = pedidoQueries;
		}

		[HttpPost]
		public async Task<IActionResult> AdicionarPedido(AdicionarPedidoCommand pedido)
		{
			pedido.ClienteId = _user.ObterUserId();
			return CustomResponse(await _mediator.EnviarComando(pedido));
		}

		[HttpGet("ultimo")]
		public async Task<IActionResult> UltimoPedido()
		{
			var pedido = await _pedidoQueries.ObterUltimoPedido(_user.ObterUserId());

			return pedido == null ? NotFound() : CustomResponse(pedido);
		}

		[HttpGet("lista-cliente")]
		public async Task<IActionResult> ListaPorCliente()
		{
			var pedidos = await _pedidoQueries.ObterListaPorClienteId(_user.ObterUserId());

			return pedidos == null ? NotFound() : CustomResponse(pedidos);
		}
	}
}
}

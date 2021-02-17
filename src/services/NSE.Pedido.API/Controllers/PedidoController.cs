using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.WebAPI.Core.Controllers;

namespace NSE.Pedido.API.Controllers
{
	[Route("api/pedido")]
	[Authorize]
	public class PedidoController : MainController
	{
		[HttpGet("healthcheck")]
		[AllowAnonymous]
		public IActionResult Get()
		{
			return Ok(new { status = "Estou vivo" });
		}
	}
}

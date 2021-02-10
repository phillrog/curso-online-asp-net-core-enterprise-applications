using Microsoft.AspNetCore.Mvc;
using NSE.WebAPI.Core.Controllers;

namespace NSE.Carrinho.API.Controllers
{

	[Route("api/carrinho")]
	public class CarrinhoController : MainController
	{	
		[HttpGet("healthcheck")]
		public IActionResult Get()
		{
			return Ok(new { status = "Estou vivo" }) ;
		}
	}
}

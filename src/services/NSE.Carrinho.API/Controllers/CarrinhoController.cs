using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSE.WebAPI.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Carrinho.API.Controllers
{

	[Route("api/[controller]")]
	public class CarrinhoController : MainController
	{	
		private readonly ILogger<CarrinhoController> _logger;

		public CarrinhoController(ILogger<CarrinhoController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		[Route("healthcheck")]
		public IActionResult Get()
		{
			return Ok(new { Status = "Estou vivo" });
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Identidade.API.Controllers
{
	public abstract class MainController : ControllerBase
	{
		protected ICollection<string> Erros = new List<string>();

		protected ActionResult CustomResponse(object result = null)
		{
			if (OperacaoValida())
			{
				return Ok();
			}

			return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]> {
				{ "Mensagens"  , Erros.ToArray() }
			}));
		}

		private bool OperacaoValida()
		{
			return !Erros.Any();
		}
	}
}

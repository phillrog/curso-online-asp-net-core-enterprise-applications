using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using System.Linq;

namespace NSE.WebApp.MVC.Controllers
{
	public class MainController : Controller
	{
		protected bool ResponsePossuiErros(ResponseResult resposta)
		{
			if (resposta != null && resposta.Errors.Mensagens.Any())
			{
				return true;
			}
			return false;
		}
	}
}

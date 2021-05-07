using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
	public class CatalogoController : MainController
	{
		private readonly ICatalogoService _catalogoService;

		public CatalogoController(ICatalogoService catalogoService)
		{
            _catalogoService = catalogoService;
        }

        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task<IActionResult> Index([FromQuery(Name ="pageSize")] int pageSize = 8, [FromQuery(Name ="pageIndex")] int pageIndex = 1, [FromQuery(Name ="query")] string query = null)
        {
            var produtos = await _catalogoService.ObterTodos(pageSize, pageIndex, query);
            
            ViewBag.Pesquisa = query;

            return View(produtos);
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            var produto = await _catalogoService.ObterPorId(id);
            return View(produto);
        }
    }
}

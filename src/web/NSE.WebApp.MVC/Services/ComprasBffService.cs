using Microsoft.Extensions.Options;
using NSE.Core.Communication;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
	public interface IComprasBffService
	{
		Task<CarrinhoViewModel> ObterCarrinho();
		Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoViewModel produto);
		Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel produto);
		Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
	}
	public class ComprasBffService : Service, IComprasBffService
	{
		private readonly HttpClient _httpClient;

		public ComprasBffService(HttpClient httpClient, IOptions<AppSettings> settings)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri(settings.Value.ComprasBffUrl);
		}

		public async Task<CarrinhoViewModel> ObterCarrinho()
		{
			var response = await _httpClient.GetAsync("carrinho/");

			TratarErrosResponse(response);

			return await DeserializarObjetoResponse<CarrinhoViewModel>(response);
		}

		public async Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoViewModel produto)
		{
			var itemContent = ObterConteudo(produto);

			var response = await _httpClient.PostAsync("carrinho/", itemContent);

			if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

			return RetornoOk();
		}

		public async Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel produto)
		{
			var itemContent = ObterConteudo(produto);

			var response = await _httpClient.PutAsync($"carrinho/{produto.ProdutoId}", itemContent);

			if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

			return RetornoOk();
		}

		public async Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
		{
			var response = await _httpClient.DeleteAsync($"carrinho/{produtoId}");

			if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

			return RetornoOk();
		}
	}
}

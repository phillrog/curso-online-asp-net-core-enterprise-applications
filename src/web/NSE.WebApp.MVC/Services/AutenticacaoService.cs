using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
	public class AutenticacaoService : Service, IAutenticacaoService
	{
		private readonly HttpClient _httpClient;

		public AutenticacaoService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
		{
			var loginContent = ObterConteudo(usuarioLogin);
			var response = await _httpClient.PostAsync("http://nse.identidade.api/api/identidade/autenticar", loginContent);

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			if (!TratarErrosResponse(response))
			{
				return new UsuarioRespostaLogin
				{
					ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
				};
			}
			return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
		}

		public async Task<UsuarioRespostaLogin> Resgitro(UsuarioRegistro usuarioRegistro)
		{
			var registroContent = ObterConteudo(usuarioRegistro);
			var response = await _httpClient.PostAsync("http://nse.identidade.api/api/identidade/nova-conta", registroContent);

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			if (!TratarErrosResponse(response))
			{
				return new UsuarioRespostaLogin
				{
					ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
				};
			}
			return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
		}
	}
}
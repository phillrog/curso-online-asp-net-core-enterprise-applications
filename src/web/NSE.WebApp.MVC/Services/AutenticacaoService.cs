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
	public class AutenticacaoService : IAutenticacaoService
	{
		private readonly HttpClient _httpClient;

		public AutenticacaoService(HttpClient httpClient )
		{
			_httpClient = httpClient;
		}
		public async Task<string> Login(UsuarioLogin usuarioLogin)
		{
			var loginContent = new StringContent(JsonSerializer.Serialize(usuarioLogin), Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync("http://nse.identidade.api/api/identidade/autenticar", loginContent);

			return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
		}

		public async Task<string> Resgitro(UsuarioRegistro usuarioRegistro)
		{
			var registroContent = new StringContent(JsonSerializer.Serialize(usuarioRegistro), Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync("http://nse.identidade.api/api/identidade/nova-conta", registroContent);

			return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
		}
	}
}

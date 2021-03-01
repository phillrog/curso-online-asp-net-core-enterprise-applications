using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Carrinho.API.Services
{
	public class CarrinhoIntegrationHandler : BackgroundService
	{
		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			throw new System.NotImplementedException();
		}
	}
}
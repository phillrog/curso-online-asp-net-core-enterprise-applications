using EasyNetQ;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Clientes.API.Application.Commands;
using NSE.Core.Mediator;
using NSE.Core.Messages.Integration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Services
{
	public class RegistroClienteIntegrationHandler : BackgroundService
	{
		private IBus _bus;
		private readonly IServiceProvider _serviceProvider;

		public RegistroClienteIntegrationHandler()
		{
			
		}

		public RegistroClienteIntegrationHandler(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			_bus = RabbitHutch.CreateBus("host=rabbit-nerdstore:5672");

			await _bus.Rpc.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
				new ResponseMessage(await RegistrarCliente(request)));
		}

		public async Task<ValidationResult> RegistrarCliente(UsuarioRegistradoIntegrationEvent message)
		{
			var clienteCommand = new RegistrarClienteCommand(message.Id, message.Nome, message.Email, message.Cpf);
			ValidationResult sucesso;

			using (var scope = _serviceProvider.CreateScope())
			{
				var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
				sucesso = await mediator.EnviarComando(clienteCommand);			
			}

			return sucesso;
		}
	}
}

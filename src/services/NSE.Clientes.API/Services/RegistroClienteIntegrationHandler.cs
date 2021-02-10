using EasyNetQ;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Clientes.API.Application.Commands;
using NSE.Core.Mediator;
using NSE.Core.Messages.Integration;
using NSE.MessageBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Services
{
	public class RegistroClienteIntegrationHandler : BackgroundService
	{
		private readonly IMessageBus _bus;
		private readonly IServiceProvider _serviceProvider;

		public RegistroClienteIntegrationHandler()
		{
			
		}

		public RegistroClienteIntegrationHandler(IServiceProvider serviceProvider,
			IMessageBus messageBus	)
		{
			_serviceProvider = serviceProvider;
			_bus = messageBus;
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			SetResponder();

			return Task.CompletedTask;
		}

		private void SetResponder()
		{
			 _bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
				await RegistrarCliente(request));

			_bus.AdvancedBus.Connected += OnConnect;
		}

		private void OnConnect(object sender, ConnectedEventArgs e)
		{
			SetResponder();
		}

		public async Task<ResponseMessage> RegistrarCliente(UsuarioRegistradoIntegrationEvent message)
		{
			var clienteCommand = new RegistrarClienteCommand(message.Id, message.Nome, message.Email, message.Cpf);
			ValidationResult sucesso;

			using (var scope = _serviceProvider.CreateScope())
			{
				var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
				sucesso = await mediator.EnviarComando(clienteCommand);			
			}

			return new ResponseMessage(sucesso);
		}
	}
}

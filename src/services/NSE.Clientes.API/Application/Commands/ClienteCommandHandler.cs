using FluentValidation.Results;
using MediatR;
using NSE.Clientes.API.Models;
using NSE.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Application.Commands
{
	public class ClienteCommandHandler : CommandHandler,  IRequestHandler<RegistrarClienteCommand, ValidationResult>
	{
		public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
		{
			if (!message.EhValido()) return message.ValidationResult;

			var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);

			return message.ValidationResult;
		}
	}
}

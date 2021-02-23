using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Pedidos.API.Application.Commands
{
	public class PedidoCommandHandler : CommandHandler,
		IRequestHandler<AdicionarPedidoCommand, ValidationResult>
	{
		public Task<ValidationResult> Handle(AdicionarPedidoCommand message, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}
	}
}